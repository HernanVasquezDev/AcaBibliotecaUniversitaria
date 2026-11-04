using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Biblioteca.Data.Database
{
    public class SqlConnectionFactory(string connectionstring)
    {
        private readonly string _connectionString = connectionstring;

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
