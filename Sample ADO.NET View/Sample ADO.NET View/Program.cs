using Microsoft.Data.SqlClient;
using System.Data;

namespace Sample_ADO_NET_View
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Defined connection string 
            string Connection_str = "data source = DESKTOP-QJT086F ; database = Bibin ; integrated security = SSPI ; TrustServerCertificate = true";
            try
            {
                //Created connection object using connection string
                using (SqlConnection _con = new SqlConnection(Connection_str))
                {
                    //Created adapter by using the connection object
                    using (SqlDataAdapter ad = new SqlDataAdapter("select * from student", _con))
                    {
                        //Created an datatable for hold the data from database
                        DataTable dt = new DataTable();
                        //Filled the datatable with datas from the database
                        ad.Fill(dt);
                        //Created a data view by using constructor
                        using (DataView dataView1 = new DataView(dt))
                        {
                            dataView1.Sort = "name DESC"; //Sorting the data in dataview
                            dataView1.RowFilter = "department='chemistry'"; //Filtering the data in dataview
                            Console.WriteLine("---Using dtatview constructor\n");
                            //Printing the data in the dataview
                            foreach (DataRowView row in dataView1)
                            {
                                Console.WriteLine(row[0] + "  " + row[1] + "   " + row[2]);
                            }
                            Console.WriteLine("\n");
                        }
                        //Created dataview by using default View
                        using (DataView dataView2 = dt.DefaultView)
                        {
                            Console.WriteLine("---Using Defultview Property\n");
                            dataView2.Sort = "name"; //Sorting the data in dataview
                            dataView2.RowFilter = "department='cs'"; //Filtering the data in dataview
                            //Printing the data in the dataview
                            foreach (DataRowView row in dataView2)
                            {
                                Console.WriteLine(row[0] + "  " + row[1] + " " + row[2]);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex) //Catching the sql exception 
            {
                Console.WriteLine("Sql exception is Occured ", ex.Message);
            }catch (Exception ex) //Catching the exception
            {
                Console.WriteLine("Exception is Occured",ex.Message);
            }
        }
    }
}
