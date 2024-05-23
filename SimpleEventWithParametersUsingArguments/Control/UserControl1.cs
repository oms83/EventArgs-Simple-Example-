using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEventWithParametersUsingArguments.Control
{

    public class CalculationComplateEventArgs
    {
        public int Val1 { get; }
        public int Val2 { get; }
        public int Result { get; }

        public CalculationComplateEventArgs(int Val1, int Val2, int Result)
        {
            this.Val1 = Val1;
            this.Val2 = Val2;
            this.Result = Result;
        }
    }

    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }


        public event EventHandler<CalculationComplateEventArgs> OnCalculationComplate;

        public void RaiseOnCalculationComplate(int Val1, int Val2, int Result)
        {
            RaiseOnCalculationComplate(new CalculationComplateEventArgs(Val1, Val2, Result));
        }

        protected virtual void RaiseOnCalculationComplate(CalculationComplateEventArgs e)
        {
            OnCalculationComplate?.Invoke(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Val1 = int.Parse(textBox1.Text);
            int Val2 = int.Parse(textBox2.Text);
            int Result = (Val1 + Val2);
            label1.Text = Result.ToString();
            RaiseOnCalculationComplate(Val1, Val2, Result);
        }
    }
}
