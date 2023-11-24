using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common.Cache;
using System.Data;

namespace DataAccess
{
    public class CitasDao:ConnectionToSql
    {


        //Metodo para consulta transat sql sin parametros -- todos los clas sedes
        public DataTable ListarSede()
        {
            var Connection = GetConnection();
            Connection.Open();
            var Command = new SqlCommand();

            Command.Connection = Connection;
            Command.CommandText = "select sede.id, sede.nombre from SEDE sede order by sede.id ASC";
            Command.CommandType = CommandType.Text;
            SqlDataReader reader = Command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            Connection.Close();
            
            //Prueba
            DataRow fila = dt.NewRow();
            fila["nombre"] = "Todas las sedes";
            dt.Rows.InsertAt(fila, 0);
            //Prueba

            return dt;
        }


        //Metodo para consulta transat sql sin parametros -- todos los contratos activos
        public DataTable ListarCONT()
        {
            var Connection = GetConnection();
                Connection.Open();
                var Command = new SqlCommand();
                
            Command.Connection = Connection;
            Command.CommandText = "SELECT DISTINCT " +
                       "CASE " +
                       "WHEN CONT.contrato = 'MUT P INTEG (SUB 21062) 2' or CONT.contrato = 'MUT P INTEG (CONT 21062) 2' or CONT.contrato = 'ZZ_MUT P INTEG (CONT 20500) 2' or CONT.contrato = 'ZZ_MUT P INTEG (SUB 20500) 2' THEN 'SERVIHDA' " +
                       "WHEN CONT.contrato = 'MUT P INTEG (SUB 21062) SR' or CONT.contrato = 'MUT P INTEG (CONT 21062) SR' THEN 'SER RESILIENTE' " +
                       "WHEN CONT.contrato = 'MUT A MUTUAL AR (CONT 20155) 2' or CONT.contrato = 'MUT A MUTUAL AR (SUB 20155) 2' THEN 'AMARTE' " +
                       "WHEN CONT.contrato = 'MUTUAL EPOC (20158) 2' THEN 'RESPIRA' " +
                       "WHEN CONT.contrato = 'MUTUAL EVEN (CONT) 2' or CONT.contrato = 'MUTUAL EVEN (SUB) 2' THEN 'EVENTO' " +
                       "WHEN CONT.contrato = 'CAPITA RUTA DE PYM  (SUB 20970)' or CONT.contrato = 'CAPITA RUTA DE PYM (CONT 20970)' THEN 'CAPITA RUTA DE PYM' " +
                       "WHEN CONT.contrato = 'RECUPERACION DE LA SALUD (SUB 20972)' or CONT.contrato = 'RECUPERACION DE LA SALUD (CONT 20972)' THEN 'RECUPERACION DE LA SALUD' " +
                       "ELSE cont.contrato " +
                       "END AS contrato " +
                       "FROM FC_CONTRATO CONT " +
                       "WHERE CONT.idestado = 'A'";
            Command.CommandType = CommandType.Text;
            SqlDataReader reader = Command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            Connection.Close();

            //Prueba
            DataRow fila2 = dt.NewRow();
            fila2["contrato"] = "Todos los contratos";
            dt.Rows.InsertAt(fila2, 0);
            //Prueba

            return dt;      
        }


        //Metodo para consulta transat sql con 5 parametros -- reporte de citas
        public bool LlenarT(string sede, String MEDT, String programa, DateTime Fechaini, DateTime Fechafin)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select "+
                        "MED.nombrecompleto as MEDICO, "+
	                    "COUNT(Case cita.estado When 'RS' Then cita.estado End) as RESERVADAS, "+
	                    "COUNT(Case cita.estado When 'CO' Then cita.estado End) as CONFIRMADAS, "+
	                    "COUNT(Case cita.estado When 'AT' Then cita.estado End) as ATENDIDOS, "+
	                    "COUNT(Case cita.estado When 'EA' Then cita.estado End) as EN_ATENCION, "+
                        "COUNT(Case cita.estado When 'RS' Then cita.estado End) " +
                        "+ COUNT(Case cita.estado When 'CO' Then cita.estado End) "+
                        "+ COUNT(Case cita.estado When 'AT' Then cita.estado End) " +
                        "+ COUNT(Case cita.estado When 'EA' Then cita.estado End) as TOTAL " +
                        "from MEDICO MED " +
                        "INNER JOIN HC_CITA cita ON MED.id = cita.idmedico "+
                        "INNER JOIN OBJETOPERFIL per ON MED.tipousuario = per.perfil "+
                        "INNER JOIN PACIENTEASEGURADO PAS ON cita.idpacienteasegurado = PAS.id "+
                        "INNER JOIN PACIENTE PA ON PAS.idpaciente = PA.id "+
                        "INNER JOIN FC_CONTRATO CON ON PAS.idcontrato = CON.id "+
                        "INNER JOIN SEDE sede ON cita.idsede = sede.id " +
                        "WHERE sede.nombre like('%' + @sede + '%') and " +
                        "MED.nombrecompleto like(@MEDT + '%') and " +
                        "CON.contrato like('%' + @programa + '%') and " +
                        "CONVERT(DATE, cita.fechainicio) >= CONVERT(DATE, @Fechaini) and " +
                        "CONVERT(DATE, cita.fechainicio) <= CONVERT(DATE, @Fechafin) " +
                        "GROUP BY MED.nombrecompleto";
                    Command.Parameters.AddWithValue("@sede", sede);
                    Command.Parameters.AddWithValue("@MEDT", MEDT);
                    Command.Parameters.AddWithValue("@programa", programa);
                    Command.Parameters.AddWithValue("@Fechaini", Fechaini);
                    Command.Parameters.AddWithValue("@Fechafin", Fechafin);
                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        
                        CitasCache.Tabla = dt;
                        return true;   
                    }
                    else
                        return false;

                }
            }

        }


    }
}
