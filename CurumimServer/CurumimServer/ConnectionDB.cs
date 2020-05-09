using System.Data;
using System.Data.SqlClient;

namespace CurumimServer
{
    public class ConnectionDB
    {
        private SqlConnection conection = new SqlConnection("Data Source=localHost;Initial Catalog=curumimGame;Integrated Security=True");

        public SqlConnection OpenConnection()
        {
            if (conection.State == ConnectionState.Closed)
                conection.Open();
            return conection;
        }
        public SqlConnection ClouseConnection()
        {
            if (conection.State == ConnectionState.Open)
                conection.Close();
            return conection;
        }

    }
}
