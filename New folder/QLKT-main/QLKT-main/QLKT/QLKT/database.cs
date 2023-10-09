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


        string stringconnect = @"Data Source=LAPTOP-Q300FTPF\SQLEXPRESS;Initial Catalog=QLKT3;Integrated Security=True";
        public SqlConnection connector;
        public SqlCommand commander;
        public SqlDataAdapter adapter;
        public DataTable table;
        public SqlDataReader reader;


        public bool CheckDataExists(string procname, SqlParameter[] parameters)
        {
            bool dataExists = false;
            connector = new SqlConnection(stringconnect);
            connector.Open();
            commander = new SqlCommand(procname, connector);           
            commander.CommandType = CommandType.StoredProcedure;

            // Thêm OUTPUT parameter
            SqlParameter existsParameter = new SqlParameter("@exists", SqlDbType.Bit);
            existsParameter.Direction = ParameterDirection.Output;
            commander.Parameters.Add(existsParameter);
            if (parameters != null)
            {
                commander.Parameters.AddRange(parameters);
            }
            try
            {
                commander.ExecuteNonQuery();
                dataExists = (bool)existsParameter.Value;
            }
       
            catch (SqlException ex)
            {
               
            }

            return dataExists;
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
            connector.Close();
            commander.Dispose();
            adapter.Dispose();
            return table;
        }



    }


 
}
