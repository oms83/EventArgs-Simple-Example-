namespace EventsInCS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userControl11 = new User_Controls.Control.UserControl1();
            this.userControl12 = new User_Controls.Control.UserControl1();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(412, 209);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(216, 183);
            this.userControl11.TabIndex = 0;

            // Subscribe to the event 
            this.userControl11.OnCalculationComplate += new System.Action<int>(this.userControl11_OnCalculationComplate);
            
            // 
            // userControl12
            // 
            this.userControl12.Location = new System.Drawing.Point(106, 82);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(216, 183);
            this.userControl12.TabIndex = 1;
            this.userControl12.OnCalculationComplate += new System.Action<int>(this.userControl12_OnCalculationComplate);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 477);
            this.Controls.Add(this.userControl12);
            this.Controls.Add(this.userControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.Control.UserControl1 userControl11;
        private User_Controls.Control.UserControl1 userControl12;
    }
}

