using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyon.Helpers
{
    public class DatabaseHelper
    {
        public static OleDbConnection Connect()
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=OtelRezervasyon.mdb");
            connection.Open();
            return connection;

        }


        public static DataTable LoadDataTable(OleDbCommand command)
        {
            DataTable dt = new DataTable();
            var result = command.ExecuteScalar();
            OleDbDataReader dataReader = command.ExecuteReader();
           
            dt.Load(dataReader);

            if (dt.Rows.Count > 0)
            {
                return dt;

            }

            return dt;

        }


        public static int ExecuteSql(OleDbCommand command)
        {
            int affectedRow = 0;
            if (command.Connection.State == ConnectionState.Open)
            {
                try
                {
                    affectedRow = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return affectedRow;
        }

        public static int rowCount(string sql)
        {
            OleDbConnection connection = Connect();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = cmd;
            adp.Fill(dt);


            cmd.Connection.Close();
            connection.Close();
            adp.Dispose();
            cmd.Dispose();


            return dt.Rows.Count;

        }

    }
}
