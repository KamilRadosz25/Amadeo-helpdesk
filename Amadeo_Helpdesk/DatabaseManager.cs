using Npgsql;
using System;

namespace Amadeo_Helpdesk
{
    internal class DatabaseManager
    {
        private NpgsqlConnection _connection;

        public DatabaseManager(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }

        public int Update(string query)
        {
            var command = new NpgsqlCommand(query, _connection);
            return command.ExecuteNonQuery();
        }

        public void SelectForChangeInvoiceCost(string query, int rownumbers)
        {
            var command = new NpgsqlCommand(query, _connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} {1} {2} {3}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
            }
        }
        
 
    }
}