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
    public partial class Form_ServiceMeny : Form
    {
        public Form_ServiceMeny()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form reg = Application.OpenForms[0];
            reg.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form_orders = new Form_OrdersList();
            form_orders.Show();

            this.Close();
        }
    }
}
