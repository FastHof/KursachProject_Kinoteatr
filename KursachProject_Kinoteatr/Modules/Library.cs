using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KursachProject_Kinoteatr
{
    class Library
    {
        public string SQLconnectstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C: \\Users\\Nikita Egorov\\source\\repos\\KursachProject_Kinoteatr\\KursachProject_Kinoteatr\\Database1.mdf\";Integrated Security=True";
        SqlConnection SQLconnection;

        public void LoadSQL()
        {
            SQLconnection = new SqlConnection(SQLconnectstr);
            //SQLconnection.Open();
        }

        public void ComandSQL(string SQLcomandstr)
        {
            SqlCommand command = new SqlCommand(SQLcomandstr, SQLconnection);
            //command.CommandText = SQLcomandstr;
        }
    }
}
