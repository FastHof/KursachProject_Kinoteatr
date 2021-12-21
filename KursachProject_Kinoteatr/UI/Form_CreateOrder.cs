using KursachProject_Kinoteatr.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KursachProject_Kinoteatr
{
    public partial class Form_CreateOrder : Form
    {
        public Form_CreateOrder()
        {
            InitializeComponent();
        }

        Library lib;
        List<Ticket> TicketList;

        private void Form_CreateOrder_Load(object sender, EventArgs e)
        {
            lib = new Library();
            lib.LoadSQL(lib.SQLconnection_str);

            TicketList = new List<Ticket>();

            MovesListFill();
            ShowLineListFill();
        }

        private void Form_CreateOrder_FormClosed(object sender, FormClosedEventArgs e)
        {

        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TicketList.Add(new Ticket(lib.SelectToDataView("SELECT * FROM Moves;").Rows[listBox_Moves.SelectedIndex], lib.SelectToDataView("SELECT * FROM ShowLine").Rows[listBox_Moves.SelectedIndex], (int)numericUpDown1.Value, (int)numericUpDown2.Value));
            OrdersListFill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form_orders = new Form_OrdersList();
            form_orders.Show();

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form hall = new Form_HallPlan();
            hall.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TicketList.RemoveAt(listBox_Orderlist.SelectedIndex);
            OrdersListFill();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void listBox_Moves_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowLineListFill();
        }



        void MovesListFill()
        {
            listBox_Moves.DataSource = lib.GetTableToDataView("Moves");           
        }

        void ShowLineListFill()
        {
            listBox_Show.DataSource = lib.SelectToDataView("SELECT * FROM ShowLine WHERE move = " + listBox_Moves.SelectedIndex + ";");
        }

        void OrdersListFill()
        {
            listBox_Orderlist.DataSource = TicketList.ToArray();
        }

        public void SetPlaceNum(int row, int place)
        {
            numericUpDown1.Value = row;
            numericUpDown2.Value = place;
        }




        class Ticket
        {
            DataRow move, showline;
            int hallrow, hallplace;

            public Ticket(DataRow m, DataRow sl, int hr, int hp)
            {
                move = m;
                showline = sl;
                hallrow = hr;
                hallplace = hp;
            }
        }
    }
}
