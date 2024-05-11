using Microsoft.Data.SqlClient;
using System.Data;

namespace ADOTransactionDemo
{
    class Program
    {
        private readonly string connectionstr = "data source = DESKTOP-QJT086F ; database = master ; integrated security = SSPI ; TrustServerCertificate = true";
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.MoneyTransfer("Account1","Account2",500);
            program.GetAccountsData();
        }
        private  void MoneyTransfer(string accountnumber1,string accountnumber2, int price)
        {
            using(SqlConnection _con = new SqlConnection(connectionstr))
            {
                if(_con.State==ConnectionState.Closed)
                    _con.Open();
                SqlTransaction transaction=_con.BeginTransaction();
                try
                {
                    SqlCommand _cmd = new SqlCommand("update Accounts set Balance=Balance-@balance where AccountNumber=@accountnumber1",_con,transaction);
                    _cmd.Parameters.AddWithValue("@balance", price);
                    _cmd.Parameters.AddWithValue("@accountnumber1", accountnumber1);
                    _cmd.ExecuteNonQuery();
                    _cmd = new SqlCommand("update Accounts set Balance=Balance+@balance where AccountNumber=@accountnumber2", _con, transaction);
                    _cmd.Parameters.AddWithValue("@balance", price);
                    _cmd.Parameters.AddWithValue("@accountnumber2", accountnumber2);
                    _cmd.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Transaction Successfully Completed");
                }catch(SqlException ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Transction Failed");
                }catch (Exception ex)
                {
                    Console.WriteLine("Exception occured ", ex.Message);
                }

            }
        }
        private void GetAccountsData()
        {
            using(SqlConnection _con=new SqlConnection(connectionstr))
            {
                using(SqlDataAdapter _ad= new SqlDataAdapter("select * from Accounts", _con))
                {
                    DataTable dt = new DataTable("Accounts");
                    _ad.Fill(dt);
                    foreach(DataRow row in dt.Rows)
                        Console.WriteLine($"{row[0]}   {row[1]}   {row[2]}");
                }
            }
        }
    }
}
