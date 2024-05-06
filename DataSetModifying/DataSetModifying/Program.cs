using Microsoft.Data.SqlClient;
using System.Data;

namespace DataSetModifying
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Creating dataset
            DataSet dataSet = new DataSet();
            //Creating dataTable 
            DataTable dataTable = new DataTable("Persons");
            //Defining the columns of dataTable
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Age",typeof(int));
            //Adding values to the datatable
            dataTable.Rows.Add(1, "Vinayak", 26);
            dataTable.Rows.Add(2, "hakim", 32);
            //Add the datatable to the dataset
            dataSet.Tables.Add(dataTable);
            //Inserting new Records
            DataRow newrow = dataSet.Tables["Persons"].NewRow();
            newrow["Id"] = 3;
            newrow["Name"] = "Manu";
            newrow["Age"] = 23;
            dataSet.Tables["Persons"].Rows.Add(newrow);
            //Updating new records
            DataRow updaterow = dataSet.Tables["Persons"].Rows[2];
            updaterow["Name"] = "Manu Krishna";
            updaterow["Age"] = 22;
            //Deleting record from tabledata
            dataSet.Tables["Persons"].Rows[1].Delete();
            Program program = new Program();
            program.Display(dataSet);
        }
        private void Display(DataSet dataset)
        {
            foreach (DataRow row in dataset.Tables["Persons"].Rows)
            {
                Console.WriteLine(row[0] + "    " + row[1]);
            }
        }
    }
}
