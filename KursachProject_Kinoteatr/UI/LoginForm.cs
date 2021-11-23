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

namespace KursachProject_Kinoteatr
{
    public partial class Form1 : Form
    {
        public Simulation s;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s = new Simulation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form_service = new Form_ServiceMeny();
            form_service.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s.Start();
            this.label3.Text = "Testing = on";
            this.label3.Visible = true;
            this.label3.ForeColor = Color.FromArgb(99, 196, 39);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s.Stop();
            this.label3.Text = "Testing = off";
            this.label3.Visible = true;
            this.label3.ForeColor = Color.FromArgb(196, 0, 0);
        }
    }
}
