using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace KursachProject_Kinoteatr.Modules
{
    public class Simulation
    {
        private bool isActive = false;
        public Label label;

        public void Start()
        {
            isActive = true;
            Task.Run(() => Generate());
        }
        public void Stop()
        {
            isActive = false;
        }

        private void Generate()
        {
            while(isActive)
            {
                Debug.WriteLine("1");
                //label.Text = "1";
                Thread.Sleep(2000);
            }
        }
    }
}
