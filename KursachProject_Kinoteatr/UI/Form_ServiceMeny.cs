using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KursachProject_Kinoteatr.Modules;
using System.Data.SqlClient;

namespace KursachProject_Kinoteatr
{
    public partial class Form_ServiceMeny : Form
    {
        public Form_ServiceMeny()
        {
            InitializeComponent();
        }

        private void Form_ServiceMeny_Load(object sender, EventArgs e)
        {
            Library lib = new Library();

            lib.LoadSQL(lib.SQLconnectstr);
            lib.ComandSQL("INSERT INTO dbo.CUsers VALUES (\"test_name\", \"Dima\", \"+7 800 703 35 50\", 272737, \"no\");");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form login = new Form1();
            login.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form_orders = new Form_OrdersList();
            form_orders.Show();

            this.Hide();
        }
    }
}
