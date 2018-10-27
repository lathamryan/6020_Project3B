using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Latham_Project3A
{
    public partial class frmCalorie : Form
    {
        public frmCalorie()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string tempage = Convert.ToString(txtAge.Text);

                //Using RexEx to clean string because it grabs all punctuation 
                string pattern = @"[\p{P}]";
                string cleanage = Regex.Replace(tempage, pattern, "");
                //send clean string back to text box
                txtAge.Text = cleanage.ToString();
                //send clean string to integer age variable
                int age = Convert.ToInt32(cleanage);

                string tempweight = Convert.ToString(txtWeight.Text);

                //Using RexEx to clean string because it grabs all punctuation 
                string cleanweight = Regex.Replace(tempweight, pattern, "");
                //send clean string back to text box
                txtWeight.Text = cleanweight.ToString();
                //send clean string to integer weight variable
                int weight = Convert.ToInt32(cleanweight);


                if (weight >= 500 | weight <= 90)
                    MessageBox.Show("We recommend you see a physician for calorie intake.");
                const decimal convertkg = 2.2m;
                decimal weightkg = weight / convertkg;
                decimal totalCalories = 0;
                const decimal multF18to30 = 14.7m;
                const decimal multF31to60 = 8.7m;
                const decimal multF61older = 10.5m;
                const decimal multM18to30 = 15.3m;
                const decimal multM31to60 = 11.6m;
                const decimal multM61older = 13.5m;

                //source for all calculations https://www.dummies.com/health/nutrition/how-to-determine-your-calorie-needs/ 

                if (rdbFemale.Checked)
                {
                    if (age < 18)
                        MessageBox.Show("You must be 18 years or older to use this app!");
                    else if (age > 125)
                        MessageBox.Show("Oldest verified human was Jeanne Calment at 122 years, 164 days. Please enter a valid age.");
                    else if (age >= 18 && age <= 30)
                        totalCalories = (multF18to30 * weightkg) + 496;
                    else if (age > 30 && age <= 60)
                        totalCalories = (multF31to60 * weightkg) + 829;
                    else if (age > 60 && age <= 125)
                        totalCalories = (multF61older * weightkg) + 596;
                }
                else if (rdbMale.Checked)
                {
                    if (age < 18)
                        MessageBox.Show("You must be 18 years or older to use this app!");
                    else if (age > 125)
                        MessageBox.Show("Oldest verified human was Jeanne Calment at 122 years, 164 days. Please enter a valid age.");
                    else if (age >= 18 && age <= 30)
                        totalCalories = (multM18to30 * weightkg) + 679;
                    else if (age > 30 && age <= 60)
                        totalCalories = (multM31to60 * weightkg) + 879;
                    else if (age > 60 && age <= 125)
                        totalCalories = (multM61older * weightkg) + 487;
                }
                txtCalOutput.Text = totalCalories.ToString("n0");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format. Please enter numeric value for Age or Weight.");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte random = Convert.ToByte(txtRandomIn.Text);
                const decimal numerator = 1m;
                decimal randomconversion = numerator / random;

                txtRandomOut.Text = randomconversion.ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("DivideByZero error. Please do not enter zero in the random input box.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Overflow error. Please enter a value smaller than 256.");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
