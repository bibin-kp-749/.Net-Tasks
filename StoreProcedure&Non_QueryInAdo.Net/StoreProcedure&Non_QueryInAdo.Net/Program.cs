using Microsoft.Data.SqlClient;
using System.Data;
namespace StoreProcedureAndNonQuery
{
    class Solution
    {
        //created a varible to store the connection details
        private readonly string _strConnection ="data source = DESKTOP-QJT086F ; database = practical_section ; integrated security = SSPI ; TrustServerCertificate = true";
        public static void Main(string[] args)
        {
            //created an instance of solution
            Solution solution = new Solution();
            solution.AddStudent("uwaise", 34, 100);
            solution.ViewStudents();
            solution.UpdateData(109,"Navin", 78, 101);
            solution.DeleteStudentById(102);
        }
        //function for add students
        private void AddStudent(string StudentName,int mark,int teacher_id)
        {
            //connected to the dataabase
            using(SqlConnection _con= new SqlConnection(_strConnection))
            {
                try
                {
                  //prepared an sql command for inserting data into table  
                  SqlCommand cmd = new SqlCommand("insert into Students values(@StudentName,@mark,@teacher_id)",_con);
                  cmd.Parameters.AddWithValue("@StudentName", StudentName);
                  cmd.Parameters.AddWithValue("@mark", mark);
                  cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                    //cheking the connection opened or not
                    if (_con.State == ConnectionState.Closed)
                        _con.Open();
                    //executed the command
                    cmd.ExecuteReader();
                    Console.WriteLine("Successfully submitted");
                }
                catch (SqlException ex)//hanled the sql Exception
                {
                    Console.WriteLine(ex.ToString());
                }catch (Exception ex)//handled the common exception
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        //method for view all the students present in the table
        private void ViewStudents()
        {
            //connect to database
            using(SqlConnection _con = new SqlConnection(_strConnection))
            {
                //creating an sql command
                SqlCommand cmd = new SqlCommand("GetStudents", _con)
                {
                    CommandType = CommandType.StoredProcedure //specifying the type is storeprocedure 
                };
                try
                {
                    if (_con.State == ConnectionState.Closed) //checking the connection is open or not
                        _con.Open();
                    SqlDataReader rd = cmd.ExecuteReader(); //executing the command
                    while (rd.Read())
                    {
                        Console.WriteLine(rd["student_name"] + " -->  " + rd["marks"]); //loged out the out put
                    }
                }catch(SqlException ex) //handled the sql exception
                {
                    Console.WriteLine(ex.ToString());
                }catch (Exception ex) //handled the sql common exception that occurs run time
                {
                    Console.WriteLine(ex.ToString()); 
                }
            }
        }
        //Method for update Students 
        private void UpdateData(int id,string StudentName, int mark, int teacher_id)
        {
            using(SqlConnection _con=new SqlConnection(_strConnection)) //connected to database 
            {
                try
                {
                    if (_con.State == ConnectionState.Closed) //checking the connection is open or not
                        _con.Open();
                    SqlCommand _cmd = new SqlCommand("update Students set student_name=@student_name,marks=@marks,teacher_id=@teacher_id where student_id=@student_id", _con);
                    _cmd.Parameters.AddWithValue("@student_id",id);
                    _cmd.Parameters.AddWithValue("@student_name",StudentName);
                    _cmd.Parameters.AddWithValue("@marks",mark);
                    _cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                    _cmd.ExecuteNonQuery(); //executing the command
                    Console.WriteLine("Updated Successfully");
                }
                catch(SqlException ex) //handling the Sql Exception
                {
                    Console.WriteLine(ex.ToString());
                }catch (Exception ex) //handlig the other errors
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        //method for deleting student record
        private void DeleteStudentById(int id)
        {
            using(SqlConnection _con=new SqlConnection(_strConnection)) //connected to database
            {
                try
                {
                    if (_con.State == ConnectionState.Closed) //checking the connection is open or not
                        _con.Open();
                    SqlCommand _cmd = new SqlCommand("delete from Students where student_id=@id", _con);//create an sql command
                    _cmd.Parameters.AddWithValue("@id", id);
                    _cmd.ExecuteNonQuery(); //executed the command
                    Console.WriteLine("Deleted the Student");
                }catch(SqlException ex) //handling the Sql Exception
                {
                    Console.WriteLine(ex.ToString());
                }catch(Exception ex) //handlig the other errors
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}