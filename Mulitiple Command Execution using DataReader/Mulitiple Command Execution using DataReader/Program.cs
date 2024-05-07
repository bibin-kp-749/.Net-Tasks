using Microsoft.Data.SqlClient;
using System.Data;

namespace Multiple_commmand_execution_using_DataReader
{
 class Program
    {
        public static void Main(string[] args)
        {
            //Define connection string
            string Connection_string = "data source = DESKTOP-QJT086F ; database = Bibin ; integrated security = SSPI ; TrustServerCertificate = true";
            try
            {
                //create an connection object using the connection string
                using (SqlConnection _con = new SqlConnection(Connection_string))
                {
                    //Check the connction object opened or not
                    if (_con.State == ConnectionState.Closed)
                        _con.Open();
                    //create an sql command by using the connnection object
                    using (SqlCommand cmd = new SqlCommand("select * from student ; select * from BOOKS", _con))
                    {
                        //execute the created command 
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            //print the values in First statement
                            while (dr.Read())
                            {
                                Console.WriteLine(dr[0] + "   " + dr[1]);
                            }
                            //NextResult method return true if the exexuted command return multiple result set
                            while (dr.NextResult())
                            {
                                //print the values in Second statement
                                while (dr.Read())
                                {
                                    Console.WriteLine(dr[0] + "  " + dr[1]);
                                }
                            }
                        }
                    }
                    
                }
            } catch (SqlException ex) //Catching the sql exception
            {
                Console.WriteLine("Sql exception is occured",ex.Message);
            }
            catch (Exception ex) //Catching the exception
            {
                Console.WriteLine("Exception is occured", ex.Message);
            }
        }
    }
}