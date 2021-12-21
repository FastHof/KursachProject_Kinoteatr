using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace KursachProject_Kinoteatr.Modules
{
    class SQLiteLib
    {
        public string connection_str = "Data Source = C:\\moveslist.db ;Version=3; FailIfMissing=False";

        SqliteConnection scon;
        SqliteCommand scomm;

        public void LoadSQLiteDB(string constr)
        {
            try
            {
                scon = new SqliteConnection(constr);
                scon.Open();

                Console.WriteLine("Подключение открыто!");
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        void ComandSQLite(string comm)
        {
            scomm = new SqliteCommand();
            scomm.CommandText = comm;
            scomm.ExecuteNonQuery();
        }
        
    }
}
