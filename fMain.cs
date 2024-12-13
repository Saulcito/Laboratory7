using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory7
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbX1.Text) || (String.IsNullOrEmpty(tbX2.Text))) 
            {
                tbY.Text = "No data entered!";
                return;
            }
            try
            {
                double x1 = double.Parse(tbX1.Text);
                double x2 = double.Parse(tbX2.Text);
                double tolerance = 1e-6;
                if (Math.Abs(Math.Cos(x2)) < tolerance)
                {
                    MessageBox.Show("The value of x2 must not lead to division by zero (abs(cos(x2)) < tolerance)", "Calculation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                double avg = (x1 + x2) / 2;
                double numerator = Math.Sqrt(Math.Pow(x1, 3) + Math.Pow(x2, 5));
                double denominator = 1000 * Math.Sqrt(x1 + Math.Pow(x2, 5));
                double y = (numerator / denominator) + 65;
                tbY.Text = y.ToString("F4");


                MessageBox.Show($"Arithmetic mean: {avg.ToString("F4")}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter correct numeral values!", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"An error occurred: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbX1.Text = String.Empty;
            tbX2.Text = String.Empty;
            tbY.Text = String.Empty;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
