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
    public partial class Form_DataBaseEditor : Form
    {
        public Form_DataBaseEditor()
        {
            InitializeComponent();
        }

        Form mainf = Application.OpenForms[0];
        Library lib;

        string curenttable, curenttable_localize;

        private void Form_DataBaseEditor_Load(object sender, EventArgs e)
        {
            lib = new Library();
            lib.LoadSQL(lib.SQLconnection_str);

            

            DataGridViewDataSet("CUsers", "Пользователи");
        }

        private void Form_DataBaseEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainf.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewDataSet("CUsers", "Пользователи");
            //this.dataGridView1.DataSource = lib.SelectToDataView("SELECT name, phone FROM CUsers;");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewDataSet("Moves", "Фильмы");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewDataSet("Halls", "Залы");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //DataGridViewDataSet("ShowLine", "Показы");
            DataGridViewDataSelect("SELECT m.name, sl.hallnum, sl.date, sl.time_start, sl.time_end FROM ShowLine AS sl LEFT JOIN Moves AS m ON sl.move = m.id ORDER BY sl.date, sl.time_start, sl.time_end;", "Показы");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewDataSet("Orders", "Заказы");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            DataGridViewDataSet("Tickets", "Билеты");
        }


        private void DataGridViewDataSet(string table, string localization)
        {
            try
            {
                this.dataGridView1.DataSource = lib.GetTableToDataView(table);

                label1.Text = localization;
                curenttable = table;
                curenttable_localize = localization;
            }
            catch
            {
                label1.Text = "Таблица не найдена!";
            }
            
        }

        private void DataGridViewDataSelect(string select, string localization)
        {
            try
            {
                this.dataGridView1.DataSource = lib.SelectToDataView(select);

                label1.Text = localization;
                curenttable = select;
                curenttable_localize = localization;
            }
            catch
            {
                label1.Text = "Запрос не выполнен!";
            }

        }




        private void button9_Click(object sender, EventArgs e)
        {
            if (curenttable != null)
            {
                lib.AddRowToDataView(curenttable);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (curenttable != null)
            {
                try
                {
                    lib.UpdateTableToDataView(curenttable);
                    DataGridViewDataSet(curenttable, curenttable_localize);
                }
                catch
                {
                    label1.Text = "Что то пошло не так. \nДанные не синхронизированы!";
                }
            }
            else
            {
                label1.Text = "Таблица не выбрана!";
            }
        }
    }
}
