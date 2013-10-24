using _06.WebCalculator.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.WebCalculator
{
    public partial class _Default : Page
    {
        //private long firstVariable;
        //private long secondVariable;
        private string operation;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "1";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "2";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "3";
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.LabelFirstNumber.Text) && !string.IsNullOrWhiteSpace(this.LabelFirstNumber.Text))
            {
                CalculateResult();
            }
            else
            {
                this.LabelFirstNumber.Text = this.TextBoxScreen.Text;
                this.LabelOperation.Text = "add";
                this.TextBoxScreen.Text = "";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "4";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "5";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "6";
        }

        protected void ButtonSubstract_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.LabelFirstNumber.Text) && !string.IsNullOrWhiteSpace(this.LabelFirstNumber.Text))
            {
                CalculateResult();
            }
            else
            {
                this.LabelFirstNumber.Text = this.TextBoxScreen.Text;
                this.LabelOperation.Text = "substract";
                this.TextBoxScreen.Text = "";
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "7";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "8";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text += "9";
        }

        protected void ButtonMultiply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.LabelFirstNumber.Text) && !string.IsNullOrWhiteSpace(this.LabelFirstNumber.Text))
            {
                CalculateResult();
            }
            else
            {
                this.LabelFirstNumber.Text = this.TextBoxScreen.Text;
                this.LabelOperation.Text = "multiply";
                this.TextBoxScreen.Text = "";
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text = string.Empty;
            this.LabelFirstNumber.Text = string.Empty;
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TextBoxScreen.Text) && !string.IsNullOrWhiteSpace(this.TextBoxScreen.Text))
            {
                this.TextBoxScreen.Text += "0";
            }
        }

        protected void ButtonDivide_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.LabelFirstNumber.Text) && !string.IsNullOrWhiteSpace(this.LabelFirstNumber.Text))
            {
                CalculateResult();
            }
            else
            {
                this.LabelFirstNumber.Text = this.TextBoxScreen.Text;
                this.LabelOperation.Text = "divide";
                this.TextBoxScreen.Text = "";
            }
        }

        protected void ButtonSquareRoot_Click(object sender, EventArgs e)
        {
            double number = double.Parse(this.TextBoxScreen.Text);
            var sqrt = Math.Sqrt(number);
            this.TextBoxScreen.Text = sqrt.ToString();
        }

        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            CalculateResult();
        }

        private void CalculateResult()
        {
            long firstVariable = long.Parse(this.LabelFirstNumber.Text);
            long secondVariable = long.Parse(this.TextBoxScreen.Text);
            decimal result = 0;

            switch (this.LabelOperation.Text)
            {
                case "add":
                    result = firstVariable + secondVariable;
                    this.TextBoxScreen.Text = result.ToString();
                    break;
                case "substract":
                    result = firstVariable - secondVariable;
                    this.TextBoxScreen.Text = result.ToString();
                    break;
                case "multiply":
                    result = firstVariable * secondVariable;
                    this.TextBoxScreen.Text = result.ToString();
                    break;
                case "divide":
                    result = firstVariable / secondVariable;
                    this.TextBoxScreen.Text = result.ToString();
                    break;
                default:
                    break;
            }

            this.LabelFirstNumber.Text = string.Empty;
        }
    }
}