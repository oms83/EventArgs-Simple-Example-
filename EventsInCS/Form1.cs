using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsInCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void userControl11_OnCalculationComplate(int obj)
        {
            MessageBox.Show("Result: " +  obj);
        }

        private void userControl12_OnCalculationComplate(int obj)
        {

        }
    }
}
