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
    public class CitasMedicos : ConnectionToSql
    {

        //Metodo con parametros para consultar 
        public bool ListarCitasGeneral(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE " +
                    "WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'MEDICINA GENERAL (CONTROL) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'MEDICINA GENERAL (P. VEZ) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'MEDICINA GENERAL (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'MEDICINA GENERAL (P. VEZ) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%CONTROL%' THEN 'MEDICINA GENERAL (CONTROL) (PRESENCIAL)'" +
                    "WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%PRIMERA%' THEN 'MEDICINA GENERAL (P. VEZ) (PRESENCIAL)' " +
                    "ELSE SER.nombre " +
                    "END as 'M. GENERAL', " +
                                        "CASE " +
                    "WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
                    "END as 'Última', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Proxima', " +
                    /*"CASE " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +*/
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) > GETDATE() THEN 'OK' " +
                    "END as Estado " +
                    "from dbo.PACIENTE PAC " +
                    "INNER JOIN dbo.PACIENTEASEGURADO CONT on PAC.id = CONT.idpaciente " +
                    "INNER JOIN dbo.FC_CONTRATO FCCONT on CONT.idcontrato = FCCONT.id " +
                    "INNER JOIN dbo.HC_CITA Cita on CONT.id = Cita.idpacienteasegurado " +
                    "RIGHT JOIN dbo.FC_SERVICIO SER on Cita.idservicio = SER.id " +
                    //"LEFT JOIN FC_TOPESERVICIO tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato) " +
                    "LEFT JOIN vitalapps.dbo.FC_VTOPES tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato)" +
                    "INNER JOIN FC_CLASESERVICIO CLA ON SER.idclaseservicio = CLA.id " +
                    "INNER JOIN FC_ESPECIALIDAD ES ON SER.idespecialidad = ES.id " +
                    "WHERE(pac.tipoidentificacion + pac.identificacion) = @identy " +
                    "AND ES.id in (250) " +
                    "AND CLA.id in (1) " +
                    "AND cita.estado in ('AT', 'RS') " +
                    "AND SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by 'Última' DESC";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.Parameters.AddWithValue("@fechaini", Fechaini);
                    Command.Parameters.AddWithValue("@fechafin", Fechafin);
                    Command.Parameters.AddWithValue("@service", Service);
                    Command.Parameters.AddWithValue("@programa", Programa);

                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtMG = new DataTable();
                    adapter.Fill(dtMG);

                    if (dtMG.Rows.Count > 0)
                    {
                        CitasCache.TablaCMgeneral = dtMG;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar 
        public bool ListarCitasInterna(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE " +
                    "WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'MEDICINA INTERNA (CONTROL) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'MEDICINA INTERNA (P. VEZ) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESENCIAL%' THEN 'MEDICINA INTERNA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESENCIAL%' THEN 'MEDICINA INTERNA (P. VEZ) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%CONTROL%' THEN 'MEDICINA INTERNA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%PRIMERA%' THEN 'MEDICINA INTERNA (P. VEZ) (PRESENCIAL)' " +
                    "ELSE SER.nombre " +
                    "END as 'M. INTERNA', " +
                                        "CASE " +
                    "WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
                    "END as 'Última', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Proxima', " +
                    /*"CASE " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +*/
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) > GETDATE() THEN 'OK' " +
                    "END as Estado " +
                    "from dbo.PACIENTE PAC " +
                    "INNER JOIN dbo.PACIENTEASEGURADO CONT on PAC.id = CONT.idpaciente " +
                    "INNER JOIN dbo.FC_CONTRATO FCCONT on CONT.idcontrato = FCCONT.id " +
                    "INNER JOIN dbo.HC_CITA Cita on CONT.id = Cita.idpacienteasegurado " +
                    "RIGHT JOIN dbo.FC_SERVICIO SER on Cita.idservicio = SER.id " +
                    //"LEFT JOIN FC_TOPESERVICIO tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato) " +
                    "LEFT JOIN vitalapps.dbo.FC_VTOPES tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato)" +
                    "INNER JOIN FC_CLASESERVICIO CLA ON SER.idclaseservicio = CLA.id " +
                    "INNER JOIN FC_ESPECIALIDAD ES ON SER.idespecialidad = ES.id " +
                    "WHERE(pac.tipoidentificacion + pac.identificacion) = @identy " +
                    "AND ES.id in (251) " +
                    "AND CLA.id in(1) " +
                    "AND cita.estado in ('AT', 'RS') " +
                    "AND SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by 'Última' DESC";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.Parameters.AddWithValue("@fechaini", Fechaini);
                    Command.Parameters.AddWithValue("@fechafin", Fechafin);
                    Command.Parameters.AddWithValue("@service", Service);
                    Command.Parameters.AddWithValue("@programa", Programa);

                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtMI = new DataTable();
                    adapter.Fill(dtMI);

                    if (dtMI.Rows.Count > 0)
                    {
                        CitasCache.TablaCMinterna = dtMI;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar 
        public bool ListarCitasInfecto(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE " +
                    "WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'INFECTOLOGÍA (CONTROL) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'INFECTOLOGÍA (P. VEZ) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESENCIAL%' THEN 'INFECTOLOGÍA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESENCIAL%' THEN 'INFECTOLOGÍA (P. VEZ) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%CONTROL%' THEN 'INFECTOLOGÍA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%PRIMERA%' THEN 'INFECTOLOGÍA (P. VEZ) (PRESENCIAL)' " +
                    "ELSE SER.nombre " +
                    "END as 'INFECTOLOGIA', " +
                                        "CASE " +
                    "WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
                    "END as 'Última', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Proxima', " +
                    /*"CASE " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +*/
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) > GETDATE() THEN 'OK' " +
                    "END as Estado " +
                    "from dbo.PACIENTE PAC " +
                    "INNER JOIN dbo.PACIENTEASEGURADO CONT on PAC.id = CONT.idpaciente " +
                    "INNER JOIN dbo.FC_CONTRATO FCCONT on CONT.idcontrato = FCCONT.id " +
                    "INNER JOIN dbo.HC_CITA Cita on CONT.id = Cita.idpacienteasegurado " +
                    "RIGHT JOIN dbo.FC_SERVICIO SER on Cita.idservicio = SER.id " +
                    //"LEFT JOIN FC_TOPESERVICIO tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato) " +
                    "LEFT JOIN vitalapps.dbo.FC_VTOPES tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato)" +
                    "INNER JOIN FC_CLASESERVICIO CLA ON SER.idclaseservicio = CLA.id " +
                    "INNER JOIN FC_ESPECIALIDAD ES ON SER.idespecialidad = ES.id " +
                    "WHERE(pac.tipoidentificacion + pac.identificacion) = @identy " +
                    "AND ES.id in (524) " +
                    "AND CLA.id in(1) " +
                    "AND cita.estado in ('AT', 'RS') " +
                    "AND SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by 'Última' DESC";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.Parameters.AddWithValue("@fechaini", Fechaini);
                    Command.Parameters.AddWithValue("@fechafin", Fechafin);
                    Command.Parameters.AddWithValue("@service", Service);
                    Command.Parameters.AddWithValue("@programa", Programa);

                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtI = new DataTable();
                    adapter.Fill(dtI);

                    if (dtI.Rows.Count > 0)
                    {
                        CitasCache.TablaCinfecto = dtI;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

    }
}
