using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Controls.Control
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        // Define a custom event handler delegate with parameter
        public event Action<int> OnCalculationComplate;
        // Create a protected method to raise th event with a parameter
        protected virtual void CalculationComplate(int Value)
        {
            Action<int> handler = OnCalculationComplate;

            if (handler != null )
            {
                handler( Value ); // Raise the event with the parameter
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtResult.Text = (Convert.ToInt32(txtOne.Text) + Convert.ToInt32(txtTwo.Text)).ToString();

            //if (OnCalculationComplate != null )
            //{
            //    CalculationComplate(int.Parse(txtResult.Text)); // Raise the event with the parameter
            //}

            // Raise the event with parameter
            OnCalculationComplate?.Invoke(int.Parse(txtResult.Text));
        }
    }
}
