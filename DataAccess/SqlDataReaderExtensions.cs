using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
	public static class SqlDataReaderExtensions
    {
		//metodo para ceptar valores nulos de sql
		public static T Get<T>(this SqlDataReader reader, int columnName)
		{
			if (reader.IsDBNull(columnName))
				return default;
			return reader.GetFieldValue<T>(columnName);
		}
	}
}
