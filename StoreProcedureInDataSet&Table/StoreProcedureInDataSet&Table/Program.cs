using Microsoft.Data.SqlClient;
using System.Data;

namespace StoreProcedureInDataSetandTable
{
    class Program
    {
        // Connection string to connect to the database
        private readonly string connection_str = "data source = DESKTOP-QJT086F ; database = Bibin ; integrated security = SSPI ; TrustServerCertificate = true";
        public static void Main(string[] args)
        {
            //created instance of Program Class 
            Program program = new Program();
            program.Store_ProcedureGetAllBooks();
            program.Store_ProcedureGetGetBookBy_Id(104);
        }
        //Method for Getting all Books
        private void Store_ProcedureGetAllBooks()
        {
            try
            {
                Console.WriteLine("Getting All Student Details in Data Set");
                // Creating a SqlConnection object and initializing it with the connection string
                using (SqlConnection _con = new SqlConnection(connection_str))
                {
                    // Creating a SqlDataAdapter object with the stored procedure name and connection object
                    SqlDataAdapter _adapter = new SqlDataAdapter("Get_Books", _con);
                    // Specifying that the command type is a stored procedure
                    _adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    // Creating a DataSet object to hold the result set
                    DataSet dt = new DataSet();
                    // Creating a DataTable object to hold the result set
                    //DataTable dt =new DataTable();
                    // Filling the DataSet with data from the stored procedure
                    _adapter.Fill(dt, "Books");
                    //Fillinng the datatable with data from store procedure
                    //_adapter.Fill(dt);
                    // Iterating through each row in the DataTable and printing values
                    foreach (DataRow row in dt.Tables["Books"].Rows)
                    {
                        Console.WriteLine(row[0] + " " + row[1]);
                    }
                    //for data datatable
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    Console.WriteLine(row[0] + " " + row[1]);
                    //}
                }
            }
            catch (SqlException ex) //Catching the Sql exception
            {
                Console.WriteLine("Sql exception occured :",ex.Message);
            }
            catch(Exception ex) //Catching the exception
            {
                Console.WriteLine("Exception occured :",ex.Message);
            }
        }
        //Method for getting Books by Id 
        private void Store_ProcedureGetGetBookBy_Id(int id)
        {
            try
            {
                //Creating an sqlconnection object and intializing it with connection string
                using(SqlConnection _con = new SqlConnection(connection_str))
                {
                    //Creating an saladapter object with the storeprocedure name and connection object
                    SqlDataAdapter adapter = new SqlDataAdapter("Get_Book_By_Id", _con);
                    //Specify the Command type is StoredProcedure
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    // Add parameters to the SqlCommand
                    adapter.SelectCommand.Parameters.AddWithValue("@id",id);
                    //Creating dataset object to hold the result set
                    DataSet dt = new DataSet();
                    //Creating datatable objet to hold the result set
                    //DataTable dt=new DataTable();
                    //Filling the dataset with data from the storeprocedure
                    adapter.Fill(dt, "Books");
                    //Filling the datatable with data from the storeprocedure
                    //adapter.Fill(dt);
                    //printing the values of dataset
                    foreach (DataRow row in dt.Tables[0].Rows)
                    {
                        Console.WriteLine(row[0] + " " + row[1]);
                    }
                    //printing the values of datatble
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    Console.WriteLine(row[0] + " " + row[1]);
                    //}
                }
            }catch (SqlException ex) //Catching the Sql exception
            {
                Console.WriteLine("Sql exception Occured"+ex.Message);//Loging the Sql Exception
            }catch(Exception ex) //Catching the exception
            {
                Console.WriteLine("Exception Occured", ex.Message);//Login the exception
            }
        }
    }
}
