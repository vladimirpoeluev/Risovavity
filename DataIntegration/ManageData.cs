using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace DataIntegration
{
    public class ManageData
    {
        SqlConnection connection;

        public ManageData()
        {
            try
            {
                IConfiguration _configuration = new ConfigurationBuilder()
                    .AddJsonFile("appConfig.json", optional: false, reloadOnChange: true)
                    .Build();
                connection = new SqlConnection(_configuration.GetSection("SqlServer").GetConnectionString("dataBase"));
                connection.Open();
            }
            catch(Exception ex)
            {
                throw new Exception("Не удалось подключиться к базе данных: " + ex.Message);
            }

        }

        public void SqlRequest(string sqlR)
        {
            SqlCommand cmd = new SqlCommand(sqlR, connection);
            cmd.ExecuteNonQuery();
        }

        public void SqlRequest(string sqlR, Dictionary<string, object> options)
        {
            SqlCommand cmd = new SqlCommand(sqlR, connection);
            foreach (var item in options)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            cmd.ExecuteNonQuery();
        }


        public SqlDataReader SqlRequestReader(string sqlR)
        {
            SqlCommand cmd = new SqlCommand(sqlR, connection);

            return cmd.ExecuteReader();
        }

        public SqlDataReader SqlRequestReader(string sqlR, Dictionary<string, object> options)
        {
            SqlCommand cmd = new SqlCommand(sqlR, connection);
            foreach(var item in options)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            return cmd.ExecuteReader();
        }


        public void Update()
        {
            try
            {
                IConfiguration _configuration = new ConfigurationBuilder()
                    .AddJsonFile("appConfig.json", optional: false, reloadOnChange: true)
                    .Build();
                connection = new SqlConnection(_configuration.GetSection("SqlServer").GetConnectionString("dataBase"));
                connection.Open();
            }
            catch
            {
                throw new Exception("Не удалось подключиться к базе данных");
            }

        }


        ~ManageData()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
            
        }

    }
}
