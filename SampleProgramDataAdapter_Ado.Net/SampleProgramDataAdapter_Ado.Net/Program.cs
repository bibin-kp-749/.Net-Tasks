using Microsoft.Data.SqlClient;
using System.Data;

namespace SamplePraogram
{
    class Solution
    {
        public static void Main(string[] args)
        {
            //Variable hold the data for connection
            string connectionstr = "data source = DESKTOP-QJT086F ; database = Bibin ; integrated security = SSPI ; TrustServerCertificate = true";
            try
            {
                //Implementing the connection to the database
                using (SqlConnection _con = new SqlConnection(connectionstr))
                {
                    //preparing an Sql command
                    SqlDataAdapter da =new SqlDataAdapter("select * from BOOKS",_con);

                    //Using Data Table
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //The following things are done by the Fill method
                    //1. Open the connection
                    //2. Execute Command
                    //3. Retrieve the Result
                    //4. Fill/Store the Retrieve Result in the Data table
                    //5. Close the connection
                    Console.WriteLine("Using Data Table");
                    //Active and Open connection is not required
                    //dt.Rows: Gets the collection of rows that belong to this table
                    //DataRow: Represents a row of data in a DataTable.
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["BOOK_NAME"]);
                        //Instead  mention the attribute -row["BOOK_NAME"]- we can also use the indeger index position like this -row[1]-
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    Console.WriteLine("-----------------------------");

                    //Using DataSet
                    DataSet ds = new DataSet();
                    da.Fill(ds,"Books");
                    //Here, the datatable student will be stored in Index position 0
                    Console.WriteLine("Using Data set");
                    //Tables: Gets the collection of tables contained in the System.Data.DataSet.
                    //Accessing the datatable from the dataset using the datatable name
                    //We can also the datatable from the data using the index as '0' -->'DataRow row in ds.Tables[0].Rows'
     //like this -> foreach (DataRow row in ds.Tables[0].Rows)
                    foreach (DataRow row in ds.Tables["Books"].Rows)
                    {
                        //Accessing the data using string Key Name
                        Console.WriteLine(row["BOOK_NAME"]);
                        //Accessing the data using integer index position
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                }
            }catch (SqlException ex) //Handling the sql exceptions
            {
                Console.WriteLine("Sql Exception Occured :",ex.Message);
            }
            catch (Exception ex) //Handling the exception
            {
                Console.WriteLine("Exception Occured :", ex.Message);
            }
            Console.ReadKey();
        }

    }
}
