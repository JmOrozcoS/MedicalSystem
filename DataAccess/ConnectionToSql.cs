using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnectionToSql
    {

        private readonly string ConnectionString;
        public ConnectionToSql()
        {

            ConnectionString = "Server=98.99.1.110\\MSSQLEMEDICO,1435;Initial Catalog=emedico; Persist Security Info=False; User ID = usuariovitalsalud; Password = VitalSalud2021*";

        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
