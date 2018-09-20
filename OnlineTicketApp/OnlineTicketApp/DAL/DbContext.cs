using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketApp.DAL
{
    public abstract class DbContext : IDisposable
    {
        protected SqlConnection _Connection { get; set; }

        public DbContext(string connectionStringName)
        {
            Open(connectionStringName);
        }

        protected void Open(string connectionStringName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

            _Connection = new SqlConnection(connectionString);

            _Connection.Open();
        }

      
        public void Dispose()
        {
            _Connection.Close();
        }
    }
}
