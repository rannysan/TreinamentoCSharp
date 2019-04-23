using System;
using System.Data.SqlClient;


namespace TrainingProject.Controllers
{
    public class DbProvider : IDisposable
    {
        public SqlConnection Connection { get; private set; }
        public static string ConnectionString { get; private set; }


        public DbProvider()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new Exception("ConnectionString cannot be empty or contains only white spaces.");
            this.Connection = new SqlConnection(ConnectionString);
        }
        public DbProvider(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Parameter 'connectionString' cannot be null, empty or contains only white spaces.", "connectionString");
            this.Connection = new SqlConnection(connectionString);
        }

        public static void SetConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Parameter 'connectionString' cannot be null, empty or contains only white spaces.", "connectionString");
           
            ConnectionString = connectionString;
        }

        public void Dispose()
        {
            Connection = null;
        }
    }
}
