using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursachProject_Kinoteatr
{
    public partial class Form_OrdersList : Form
    {
        public Form_OrdersList()
        {
            InitializeComponent();
        }

        private void Form_OrdersList_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Form form_service = new Form_ServiceMeny();
            //form_service.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form_orderscr = new Form_CreateOrder();
            form_orderscr.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form_service = new Form_ServiceMeny();
            form_service.Show();

            this.Close();
        }
    }
}
