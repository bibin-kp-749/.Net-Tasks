using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DatasetModifyingAdo_Net
{
    class Program
    { 
        public static void Main(string[] args)
        {  
            string _connectionString = "data source = DESKTOP-QJT086F ; database = Bibin ; integrated security = SSPI ; TrustServerCertificate = true";
            using(SqlConnection _con=new SqlConnection(_connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Books", _con);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(row[0]);
                }
            }
        }
        //Method to Insert data
        private void InsertRecord(string bookname,int Auther_id)
        {
            
        }
    }
}
