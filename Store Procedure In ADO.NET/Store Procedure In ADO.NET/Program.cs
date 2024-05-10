using Microsoft.Data.SqlClient;
using System.Data;

namespace StoreProcedureInADO_NET
{
    class Program
    {
        //Defined connetionString
        private readonly string connectionstr = "data source = DESKTOP-QJT086F ; database = master ; integrated security = SSPI ; TrustServerCertificate = true";
        static void Main(string[] args)
        {
            //Create an instance of Program
            Program program = new Program();
            program.SP_WithoutInput_and_Output();
            program.SP_WithInput_and_Without_Output(103);
            program.SP_WithInput_and_Output(103);
        }
        //Method for Calling StoreProcedure WithoutInput&output
        private void SP_WithoutInput_and_Output()
        {
            try
            {
                //Creating Sql connection object using ConnectionString
                using (SqlConnection _con = new SqlConnection(connectionstr))
                {
                    //Checikng the connection is opened or not
                    if (_con.State == ConnectionState.Closed)
                        _con.Open();
                    //Implementing Storeprocedure using connection object
                    using (SqlCommand _cmd = new SqlCommand("GetAllData",_con))
                    {
                        //Specify the storeProcedure
                        _cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader rd = _cmd.ExecuteReader();
                        while (rd.Read())
                            Console.WriteLine($"{rd[0]}    {rd[1]}    {rd[2]}");
                    }
                }
            } catch (SqlException ex) //Catching sql exception
            {
                Console.WriteLine("Sql exception occured",ex.Message);
            }catch (Exception ex) //Catching exception
            {
                Console.WriteLine("Exception occured", ex.StackTrace);
            }
        }
        //Method for Calling StoreProcedure With Input& Without output
        private void SP_WithInput_and_Without_Output(int Id)
        {
            try
            {
                //Creating Sql connection object using ConnectionString
                using(SqlConnection _con = new SqlConnection(connectionstr))
                {
                    //Checikng the connection is opened or not
                    if (_con.State == ConnectionState.Closed)
                        _con.Open();
                    //Implementing Storeprocedure using connection object
                    using(SqlCommand _cmd = new SqlCommand("View_databy_id", _con))
                    {
                        //Specify the storeProcedure
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Parameters.AddWithValue("@id", Id);
                        SqlDataReader dr=_cmd.ExecuteReader();
                        while(dr.Read())
                            Console.WriteLine($"{dr[0]}    {dr[1]}    {dr[2]}");

                    }
                }
            }catch(SqlException ex) //Catching sql exception
            {
                Console.WriteLine("Sql exception occure ",ex.Message);
            }catch(Exception ex) //Catching exception
            {
                Console.WriteLine("Exception occure ", ex.Message);
            }
        }
        //Method for Calling StoreProcedure With Input&output
        private void SP_WithInput_and_Output(int Id)
        {
            try
            {
                //Creating Sql connection object using ConnectionString
                using (SqlConnection _con = new SqlConnection(connectionstr))
                {
                    //Checikng the connection is opened or not
                    if (_con.State == ConnectionState.Closed)
                        _con.Open();
                    //Implementing Storeprocedure using connection object
                    using (SqlCommand _cmd = new SqlCommand("Return_databyId", _con))
                    {
                        //Specify the storeProcedure
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Parameters.AddWithValue("@id", Id);
                        SqlParameter output = new SqlParameter("@kk", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        _cmd.Parameters.Add(output);
                        _cmd.ExecuteNonQuery();
                        Console.WriteLine((int)_cmd.Parameters["@kk"].Value);
                    }
                }
            } catch(SqlException ex) //Catching sql exception
            {
                Console.WriteLine("Sql exception occure ", ex.Message);
            }catch (Exception ex) //Catching exception
            {
                Console.WriteLine("Exception occure ", ex.Message);
            }
        }
    }
}
