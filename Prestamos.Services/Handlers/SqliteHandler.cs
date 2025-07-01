using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stock.Services.Handlers
{
    public class SqliteHandler
    {
        public static string ConnectionString = string.Empty;

        public static string GetJson(string request)
        {
            return JsonConvert.SerializeObject(GetDt(request), Newtonsoft.Json.Formatting.Indented);
        }

        public static string GetScalar(string request)
        {
            string scalarResult = string.Empty;
            SqliteConnection cnn = new SqliteConnection(ConnectionString);
            cnn.Open();
            SqliteCommand mycommand = new SqliteCommand(request, cnn);
            mycommand.CommandText = request;
            object result = mycommand.ExecuteScalar();
            if (result != null)
            {
                scalarResult = result.ToString();
            }
            cnn.Close();
            return scalarResult;
        }
        public static DataTable GetDt(string query)
        {
            string response = string.Empty;
            DataTable dt = new DataTable();
            SqliteConnection cnn = new SqliteConnection(ConnectionString);
            cnn.Open();
            SqliteCommand mycommand = new SqliteCommand(query, cnn);
            mycommand.CommandText = query;
            SqliteDataReader reader = mycommand.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
            return dt;
        }

        public static bool Exec(string query)
        {
            bool response = false;
            SqliteConnection Conn = new SqliteConnection(ConnectionString);
            SqliteCommand Command = new SqliteCommand(query, Conn);
            Conn.Open();

            try
            {
                Command.ExecuteNonQuery();
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }

            Conn.Close();

            return response;
        }
    }
}
