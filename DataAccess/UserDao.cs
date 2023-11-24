using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace DataAccess
{
    public class UserDao : ConnectionToSql
    {


        public void EditProfile(int id, String user, String pname, String sname, String papellido, String sapellido, String email, String pass)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText =
                        "update vitalapps.dbo.USUARIOS set usuario=@user, primernombre=@pname, " +
                        "segundonombre=@sname, primerapellido=@papellido, segundoapellido=@sapellido, " +
                        "email=@email, clave=@pass where id=@id";
                    Command.Parameters.AddWithValue("@id", id);
                    Command.Parameters.AddWithValue("@user", user);
                    Command.Parameters.AddWithValue("@pname", pname);
                    Command.Parameters.AddWithValue("@sname", sname);
                    Command.Parameters.AddWithValue("@papellido", papellido);
                    Command.Parameters.AddWithValue("@sapellido", sapellido);
                    Command.Parameters.AddWithValue("@email", email);
                    Command.Parameters.AddWithValue("@pass", pass);
                    //Command.Parameters.AddWithValue("@posicion", posicion);
                    Command.CommandType = CommandType.Text;
                    Command.ExecuteNonQuery();
                }
            }
        }

            public bool Login(String user, String pass)
            {
                using (var Connection = GetConnection())
                {
                    Connection.Open();
                    using (var Command = new SqlCommand())
                    {
                        Command.Connection = Connection;
                        Command.CommandText = 
                            "select med.id, med.usuario, med.primernombre, med.segundonombre, med.primerapellido, med.segundoapellido, " +
                            "med.email, ob.descripcion,med.estado, med.clave from vitalapps.dbo.USUARIOS med INNER JOIN vitalapps.dbo.USUARIOPERFIL OB ON med.tipousuario = OB.perfil" +
                            " where med.usuario = @user and med.clave = @pass";
                        Command.Parameters.AddWithValue("@user", user);
                        Command.Parameters.AddWithValue("@pass", pass);
                        Command.CommandType = CommandType.Text;
                        SqlDataReader reader = Command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read()) {
                                UserLoginCache.IdUser = reader.GetInt32(0);
                                UserLoginCache.User = reader.GetString(1);
                                UserLoginCache.FirstName = reader.GetString(2);
                                UserLoginCache.Sname = reader.GetString(3);
                                UserLoginCache.LastName = reader.GetString(4);
                                UserLoginCache.Ssurname = reader.GetString(5);
                                UserLoginCache.Email = reader.GetString(6);
                                UserLoginCache.Position = reader.GetString(7);
                                UserLoginCache.Estado = reader.GetString(8);
                                UserLoginCache.Pass = reader.GetString(9);
                        }
                            return true;
                        }
                        else
                            return false;
                    }
                }

            }

    }
}
