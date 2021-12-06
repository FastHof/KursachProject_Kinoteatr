using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KursachProject_Kinoteatr
{
    class Library
    {
        public string SQLconnectstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nikita Egorov\\source\\repos\\KursachProject_Kinoteatr\\KursachProject_Kinoteatr\\UC_Database.mdf\";Integrated Security=True";
        SqlConnection SQLconnection = null;

        public void LoadSQL(string conect)
        {
            SQLconnection = new SqlConnection(conect); 

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

        public void ComandSQL(string SQLcomandstr)
        {
            try 
            {
                using (SqlCommand command = new SqlCommand(SQLcomandstr, SQLconnection)) 
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Запись добавлена");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
