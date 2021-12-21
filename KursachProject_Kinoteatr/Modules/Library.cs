using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KursachProject_Kinoteatr
{
    class Library
    {
        public string SQLconnection_str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nikita Egorov\\source\\repos\\KursachProject_Kinoteatr\\KursachProject_Kinoteatr\\UC_Database.mdf\";Integrated Security=True";
        SqlConnection SQLconnection = null;
        SqlCommand SQLComm = null;
        public UC_DatabaseDataSet UC_DB_DataSet = null;
        public SqlDataAdapter UC_DB_Adapter = null;
        SqlCommandBuilder UC_DB_CommandBuilder = null;

        public void LoadSQL(string conectstring)
        {
            SQLconnection = new SqlConnection(conectstring);
            UC_DB_DataSet = new UC_DatabaseDataSet();

            try
            {
                SQLconnection.Open();
                Console.WriteLine("SQL - Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ComandSQL(string SQLcommand_str)
        {
            try 
            {
                SQLComm = new SqlCommand();
                SQLComm.CommandText = SQLcommand_str;
                SQLComm.Connection = SQLconnection;

                SQLComm.ExecuteNonQueryAsync();

                Console.WriteLine("Запись добавлена");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable GetTableToDataView(string table)
        {
            DataTable dt = new DataTable();
            UC_DB_Adapter = new SqlDataAdapter("SELECT * FROM " + table, SQLconnection);
            UC_DB_Adapter.Fill(dt);

            return dt;
        }

        public DataTable SelectToDataView(string select)
        {
            DataTable dt = new DataTable();
            UC_DB_Adapter = new SqlDataAdapter(select, SQLconnection);
            UC_DB_Adapter.Fill(dt);

            return dt;
        }

        public void UpdateTableToDataView(string table)
        {
            UC_DB_CommandBuilder = new SqlCommandBuilder(UC_DB_Adapter);
            UC_DB_Adapter.Update(UC_DB_DataSet, table);
            UC_DB_DataSet.AcceptChanges();
        }

        public void AddRowToDataView (string table)
        {
            UC_DB_DataSet.Tables[table].Rows.Add(UC_DB_DataSet.Tables[table].NewRow());
        }

        public void InsertDataToDB(string command)
        {

        }
    }
}
