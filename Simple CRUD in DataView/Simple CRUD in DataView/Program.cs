using Microsoft.Data.SqlClient;
using System.Data;

namespace Simple_CRUD_in_DataView
{
    class Program
    {
        //defined connection string
        private readonly string ConnectionStr = "data source = DESKTOP-QJT086F ; database = Bibin ; integrated security = SSPI ; TrustServerCertificate = true";
        public static void Main(string[] args)
        {
            //creating an instance of Program Class
            Program program = new Program();
            program.CreateView("nnn", "kkkk", 21);
            program.UpdateView(101, "sreena", "cs", 21);
            program.DeleteView(102);
        }
        //Method for Creating newrow in dataview
        private void CreateView(string name, string department, int Age)
        {
            try
            {
                //Created connectio object using connection string 
                using (SqlConnection _con = new SqlConnection(ConnectionStr))
                {
                    //Created adapter using connection object
                    using (SqlDataAdapter dt = new SqlDataAdapter("select * from student", _con))
                    {
                        //created datatable
                        DataTable dataTable = new DataTable();
                        dt.Fill(dataTable); //Filled the data from database
                        DataView dataView = new DataView(dataTable); //Created a dataview using dataTable
                        dataView.AllowNew = true; //allow to create new record
                        DataRowView newrow = dataView.AddNew(); //Creating new row for View
                        newrow[1] = name;
                        newrow[2] = department;
                        newrow[3] = Age;
                        //Printed the data of dataView
                        foreach (DataRowView row in dataView)
                        {
                            Console.WriteLine(row[1] + "  " + row[2]);
                        }
                    }
                }
            }
            catch (SqlException ex) //Catching sql exception
            {
                Console.WriteLine("Sql Exception Occured ",ex.Message);
            }catch (Exception ex) //Catching exception
            {
                Console.WriteLine("Exception Occured ",ex.Message);
            }
        }
        //Method for Updating dataview
        private void UpdateView(int id, string name, string department, int Age)
        {
            try
            {
                //Created connectio object using connection string 
                using (SqlConnection _con = new SqlConnection(ConnectionStr))
                {
                    //Created adapter using connection object
                    using (SqlDataAdapter dt = new SqlDataAdapter("select * from student", _con))
                    {
                        //created datatable
                        DataTable dataTable = new DataTable();
                        dt.Fill(dataTable); //Filled the data from database
                        DataView dataView = new DataView(dataTable); //Created a dataview using dataTable
                        foreach (DataRowView row in dataView)
                        {
                            if (Convert.ToInt32(row[0]) == id)
                            {
                                row[1] = name;
                                row[2] = department;
                                row[3] = Age;
                            }
                        }
                        //Printed the data of dataView
                        foreach (DataRowView row in dataView)
                        {
                            Console.WriteLine(row[0] + "  " + row[1]);
                        }
                    }
                }
            }
            catch (SqlException ex) //Catching sql exception
            {
                Console.WriteLine("Sql Exception occured",ex.Message);
            }catch(Exception ex) //Catching exception
            {
                Console.WriteLine("Exception occured ", ex.Message);
            }
        }
        //Method for deleting dataview row
        private void DeleteView(int id)
        {
            try
            {
                //Created connectio object using connection string 
                using (SqlConnection _con = new SqlConnection(ConnectionStr))
                {
                    //Created adapter using connection object
                    using (SqlDataAdapter dt = new SqlDataAdapter("select * from student", _con))
                    {
                        //created datatable
                        DataTable dataTable = new DataTable();
                        dt.Fill(dataTable); //Filled the data from database
                        DataView dataView = new DataView(dataTable); //Created a dataview using dataTable
                        foreach (DataRowView row in dataView)
                        {
                            if (Convert.ToInt32(row[0]) == id)
                            {
                                row.Delete(); //deleting the row from dataview by using id
                            }
                        }
                        //Printed the data of dataView
                        foreach (DataRowView row in dataView)
                        {
                            Console.WriteLine(row[0]+"  " + row[1]+"  " + row[2]);
                        }
                    }
                }
            }
            catch (SqlException ex) //Catching sql exception
            {
                Console.WriteLine("Sql exception occured ",ex.Message);
            }catch (Exception ex) //Catching exception
            {
                Console.WriteLine("Exception occured ",ex.Message);
            }
        }
    }
}
