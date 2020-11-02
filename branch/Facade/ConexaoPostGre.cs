using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Npgsql;

namespace Facade
{
    public class ConexaoPostGre
    {
        private NpgsqlConnection connect = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IntegraSoftConnectionString"].ConnectionString);        
        private NpgsqlCommand command;
        private NpgsqlDataReader reader;

        public NpgsqlDataReader Reader
        {
            get { return reader; }
        }

        public void Open()
        {
            connect.Open();
            command = connect.CreateCommand();
        }

        public void Close()
        {
            connect.Close();
        }

        public void ExecuteNonQuery(String sql)
        {
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public void ExecuteNonQuery(String sql, Object[] param)
        {
            command.CommandText = Construct(sql, param);
            command.ExecuteNonQuery();
        }

        public void ExecuteReader(String sql)
        {
            command.CommandText = sql;
            reader = command.ExecuteReader();
        }

        public void ExecuteReader(String sql, Object[] param)
        {
            command.CommandText = Construct(sql, param);
            reader = command.ExecuteReader();
        }

        private String Construct(String sql, Object[] param)
        {
            sql = String.Format(sql, param);
            sql = sql.Replace("True", "1");
            sql = sql.Replace("False", "0");
            command.CommandText = sql;
            return sql;
        }
    }
}

