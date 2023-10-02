using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Mainproject
{

  
    internal class cosodulieu
    {

        string chuoiketnoi = @"Data Source=SIILO;Initial Catalog=quanlykhutro;Integrated Security=True";
        SqlConnection ketnoi = null;
        SqlCommand lenhsql = null;
        SqlDataAdapter laydulieu = null;
        DataTable bangdulieu = null;





        // hàm gọi tới Pro 
        public DataTable proc(string tenproc, SqlParameter[] parameters)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            lenhsql = new SqlCommand(tenproc, ketnoi);
            lenhsql.CommandType = CommandType.StoredProcedure;
            laydulieu = new SqlDataAdapter(lenhsql);
            bangdulieu = new DataTable();
            try
            {
                if (parameters != null)
                {
                    lenhsql.Parameters.AddRange(parameters);
                    laydulieu.Fill(bangdulieu);
                    lenhsql.Dispose();
                    laydulieu.Dispose();
                    ketnoi.Close();
                }
                else
                {
                    lenhsql.ExecuteNonQuery();
                    laydulieu.Fill(bangdulieu);
                    lenhsql.Dispose();
                    laydulieu.Dispose();
                    ketnoi.Close();
                }
            }
            catch
            {
                
            }
            

            return bangdulieu;
        }
    }
}
