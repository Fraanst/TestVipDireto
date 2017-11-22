using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FluxosTestes_Vip.Controller
{
    public class ConnectionFactory
    {
        #region Propriedades
        SqlConnection connection { get; set; }
        SqlCommand command { get; set; }
        public string ConnectionString { get; set; }
        #endregion

        #region Construtores
        private ConnectionFactory() { }

        public ConnectionFactory(string connString)
        {
            ConnectionString = connString;
        }
        #endregion

        #region Métodos
        public IDataReader ExecuteQuery(string query)
        {
            SqlDataReader dataReader;
            connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                    return dataReader;
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.Write("Não foi possível executar a query. " + e.Message);
                return null;
            }
        }

        public bool ExecuteNonQuery(string query)
        {
            connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Não foi possível executar a query. " + e.Message);
                if (connection.State == ConnectionState.Open) CloseConnection();
                return false;
            }
        }

        public void CloseConnection()
        {
            connection.Dispose();
            connection.Close();
        }
        #endregion
    }
}
