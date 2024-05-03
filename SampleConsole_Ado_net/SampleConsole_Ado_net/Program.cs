using Microsoft.Data.SqlClient;
using System.Data;
namespace ConsoleSampleado_net
{
    class Program
    {
    public static void Main(string[] args)
    {
            //created an innstance of Program class
            Program pg = new Program();
            pg.GetResult();
    }
        private void GetResult()
        {
            //estabished Connection to the sql server
            SqlConnection _Con = new SqlConnection("data source = DESKTOP-QJT086F ; database = practical_section ; integrated security = SSPI ; TrustServerCertificate = true");
            //Defined the command for performing
            SqlCommand _Command = new SqlCommand("select * from Students", _Con);
            try
            {
                //checking the Connection is closed or not 
                if (_Con.State == ConnectionState.Closed)
                    _Con.Open(); //If it is true open the connection
                SqlDataReader rd = _Command.ExecuteReader();//executed the command
                while (rd.Read()) //consoled the result by using loop
                {
                    Console.WriteLine(rd["student_name"]+" -->  "+ rd["marks"]);
                }
            }catch (Exception ex) //handled the exception
            {
                Console.WriteLine(ex.Message);
            }
            finally //closed the connection  
            {
                if (_Con.State == ConnectionState.Open)
                    _Con.Close(); 
            }
        }

    }
}