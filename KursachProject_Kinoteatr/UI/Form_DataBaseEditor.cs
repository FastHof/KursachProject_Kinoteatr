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
    public partial class Form_DataBaseEditor : Form
    {
        public Form_DataBaseEditor()
        {
            InitializeComponent();
        }

        private void Form_DataBaseEditor_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "uC_DatabaseDataSet.CUsers". При необходимости она может быть перемещена или удалена.
            this.cUsersTableAdapter.Fill(this.uC_DatabaseDataSet.CUsers);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form mainf = Application.OpenForms[0];
            mainf.Show();

            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //label1.Text = dataGridView1.DataSource.ToString();
            //this.cUsersTableAdapter.Fill(this.uC_DatabaseDataSet.CUsers);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = MovesBindingSource;
            //this.cUsersTableAdapter.Fill(this.uC_DatabaseDataSet.);
        }
    }
}
