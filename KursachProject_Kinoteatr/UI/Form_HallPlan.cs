using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursachProject_Kinoteatr.UI
{
    public partial class Form_HallPlan : Form
    {
        public Form_HallPlan()
        {
            InitializeComponent();
        }

        public int RowsNum = 7;
        public int PlacesNum = 5;

        public int SelectedRow = 0;
        public int SelectedPlace = 0;

        float ImageDiferenceProcent;

        float LeftOffcet = 30;
        float UpOffcet = 50;

        float PlaceImageSize = 137;
        float NewPlaceImageSize;

        float PlacesDistanceX;
        float PlacesDistanceY;

        List<Place> PlaceList;
        int PlaceListNum = 0;

        private void Form_HallPlan_Load(object sender, EventArgs e)
        {
            PlaceList = new List<Place>();

            ImageDiferenceProcent = 0.5f;

            NewPlaceImageSize = PlaceImageSize * ImageDiferenceProcent;

            CreatePlaces();
        }

        private void Form_HallPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form_CreateOrder orderform = (Form_CreateOrder)Application.OpenForms["Form_CreateOrder"];

            orderform.SetPlaceNum(SelectedRow, SelectedPlace);
        }



        private void CreatePlaces()
        {
            PlacesDistanceX = ((this.Width - LeftOffcet - (NewPlaceImageSize * PlacesNum)) / PlacesNum);
            PlacesDistanceY = ((this.Height - UpOffcet - (NewPlaceImageSize * RowsNum)) / RowsNum);

            Point bp;
            Size sz;

            for (int i = 0; i < RowsNum; i++)
            {
                for (int j = 0; j < PlacesNum; j++)
                {
                    bp = new Point((int)LeftOffcet + ((int)NewPlaceImageSize * j) + ((int)PlacesDistanceX * j), (int)UpOffcet + ((int)NewPlaceImageSize * i) + ((int)PlacesDistanceY * i));

                    sz = new Size((int)NewPlaceImageSize, (int)NewPlaceImageSize);

                    PlaceList.Add(new Place(i, j, bp, sz));
                    PlaceList[PlaceListNum].butt.Tag = PlaceListNum;
                    this.Controls.Add(PlaceList[PlaceListNum].butt);
                    PlaceList[PlaceListNum].butt.Click += new EventHandler(SelectPlace_Click);

                    PlaceListNum++;
                }
            }
        }

        private void SelectPlace_Click(object sender, EventArgs e)
        {
            Button tmpbutt = sender as Button;
            SelectedPlace = (PlaceList[(int)tmpbutt.Tag].PlaceID) + 1;
            SelectedRow = (PlaceList[(int)tmpbutt.Tag].RowID) + 1;

            label1.Text = SelectedRow.ToString() + " | " + SelectedPlace.ToString();

            this.Close();
        }

        void ChangeSelectedID(int newid)
        {

        }

        class Place
        {
            public int RowID = 0;
            public int PlaceID = 0;
            public Button butt;

            bool Busy = false;

            public Place(int row, int place, Point loc, Size bsize)
            {
                butt = new Button();

                RowID = row;
                PlaceID = place;

                butt.Location = loc;
                butt.Size = bsize;
                butt.Visible = true;
                butt.Text = RowID.ToString() + " || " + PlaceID.ToString() + "\n" + loc.ToString();

                //butt.Click += new EventHandler(SelectPlace_Click);
            }
        }
    }
}
