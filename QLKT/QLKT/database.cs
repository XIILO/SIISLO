using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKT
{


    internal class database
    {


        string stringconnect = @"Data Source=SIILO;Initial Catalog=QLKT;Integrated Security=True";
        public SqlConnection connector;
        public SqlCommand commander;
        public SqlDataAdapter adapter;
        public DataTable table;
        public SqlDataReader reader;

        public bool checker(string procname, SqlParameter[] parameter) 
        {
            
            connector = new SqlConnection(stringconnect);
            commander = new SqlCommand(procname, connector);
            commander.CommandType = CommandType.StoredProcedure;
            connector.Open();
            commander.Parameters.AddRange(parameter);
            bool result = (bool)commander.ExecuteScalar();
            if(result)
            {
               
                commander.Dispose();
                connector.Close();
                return true;
            }
            else
            {
                
                commander.Dispose();
                connector.Close();
                return false;
            }   
        }

        public DataTable Proc(string procname, SqlParameter[] parameters)
        {
            connector = new SqlConnection(stringconnect);
            commander = new SqlCommand(procname, connector);
            commander.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(commander);
            table = new DataTable();
            connector.Open();
            if(parameters != null)
            {
                commander.Parameters.AddRange(parameters);
                adapter.Fill(table);
            }
            else
            {
                commander.ExecuteNonQuery();
                adapter.Fill(table);
            }
            commander.Dispose();
            adapter.Dispose();
            connector.Close();

            return table;
        }


    }


 
}
