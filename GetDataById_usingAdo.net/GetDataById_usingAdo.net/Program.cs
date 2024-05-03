using Microsoft.Data.SqlClient;
using System.Data;
namespace GetDataById
{
    class Solution
    {
        public static void Main(string[] args)
        {
            //created an instance of Solution
            Solution soltion = new Solution();
            soltion.GetDataById(100);
        }
        private void GetDataById(int id)
        {  
                //Established connnection to the database
                SqlConnection _Con = new SqlConnection("data source = DESKTOP-QJT086F ; database = practical_section ; integrated security = SSPI ; TrustServerCertificate = true");
                //created commands for performing
                SqlCommand _cmd = new SqlCommand("select * from Students where student_id=@Id",_Con);
                 //parameter for query
                _cmd.Parameters.AddWithValue("@id", id);
            try
            {
                if (_Con.State == ConnectionState.Closed)
                    _Con.Open();
                SqlDataReader rd = _cmd.ExecuteReader();
                while (rd.Read()) //consoled out the record
                {
                    Console.WriteLine(rd["student_name"] + " -->  " + rd["marks"]);
                }
            }catch(SqlException ex) //Handled the sql exceptions
            {
                Console.WriteLine("something went wrong with your query!"+ex);
            }
            catch(Exception ex) //Handling the common exceptions that occur
            {
                Console.WriteLine("Somethig went wrong !"+ex);
            }
            finally //closed the connection
            {
                if(_Con.State==ConnectionState.Open)
                _Con.Close();
            }
        }
    }
}