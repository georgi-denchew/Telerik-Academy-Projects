using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Sumator
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void ButtonSumator_Click(object ender, EventArgs e)
        {
            try
            {
                decimal firstNumber = decimal.Parse(this.TextBoxFirstNumber.Text);
                decimal secondNumber = decimal.Parse(this.TextBoxSecondNumber.Text);
                decimal sum = firstNumber + secondNumber;
                this.TextBoxSum.Text = sum.ToString();
            }
            catch (Exception)
            {
                this.TextBoxSum.Text = "Invalid input.";
            }
        }
    }
}