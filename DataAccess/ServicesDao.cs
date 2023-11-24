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
    public class ServicesDao : ConnectionToSql
    {

        //Insertar Topes
        public void InsertTope(int idServicio, int idContrato, String cantidadI)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "use [vitalapps] insert into vitalapps.dbo.FC_VTOPES(idservicio,idcontrato,cantidad) Values(@idServicio, @idContrato, @cantidadI)";
                    Command.Parameters.AddWithValue("@idServicio", idServicio);
                    Command.Parameters.AddWithValue("@idContrato", idContrato);
                    Command.Parameters.AddWithValue("@cantidadI", cantidadI);
                    Command.CommandType = CommandType.Text;
                    Command.ExecuteNonQuery();
                }
            }
        }

        //Actualizar Topes
        public void EditTope(int id, String cantidad)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "update vitalapps.dbo.FC_VTOPES set cantidad=@cantidad where id=@id";
                    Command.Parameters.AddWithValue("@id", id);
                    Command.Parameters.AddWithValue("@cantidad", cantidad);
                    Command.CommandType = CommandType.Text;
                    Command.ExecuteNonQuery();
                }
            }
        }


        //Metodo con parametros para consultar topes
        public bool ListTopes(String t)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "SELECT VT.id, VT.cantidad as 'Tope (Dias)', S.nombre as 'Servicio' from vitalapps.dbo.FC_VTOPES VT " +
                    "INNER JOIN emedico.dbo.FC_SERVICIO S ON VT.idservicio = S.id " +
                    "INNER JOIN emedico.dbo.FC_CONTRATO C ON VT.idcontrato = C.id " +
                    "WHERE C.id like ('%' + @contrato + '%') ";
                    Command.Parameters.AddWithValue("@contrato", t);
                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dttopes = new DataTable();
                    adapter.Fill(dttopes);

                    if (dttopes.Rows.Count > 0)
                    {
                        ServicesCache.TablaTopes = dttopes;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }


        //Metodo con parametros para consultar procedures
        public bool ListServices(String t)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "SELECT SER.id, SER.nombre FROM FC_SERVICIO SER "+
                    "INNER JOIN FC_TARIFADETALLE TAR ON SER.ID = TAR.idservicio " +
                    "INNER JOIN FC_TARIFA T ON TAR.idtarifa = T.id " +
                    "INNER join FC_CONTRATOTARIFA CT ON T.id = CT.idtarifa " +
                    "INNER JOIN FC_CONTRATO C ON CT.idcontrato = C.id " +
                    "WHERE C.id like('%' + @tarifa + '%') " +
                    //"WHERE T.id like('%' + @tarifa + '%') " +
                    "ORDER BY SER.nombre";
                    Command.Parameters.AddWithValue("@tarifa", t);
                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtServices = new DataTable();
                    adapter.Fill(dtServices);

                    if (dtServices.Rows.Count > 0)
                    {
                        ServicesCache.TablaServices = dtServices;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

    }

}
