﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEventWithParametersUsingArguments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void userControl11_OnCalculationComplate(object sender, 
            Control.CalculationComplateEventArgs e)
        {
            MessageBox.Show($"{e.Val1} + {e.Val2} = {e.Result}");
        }

    }
}
