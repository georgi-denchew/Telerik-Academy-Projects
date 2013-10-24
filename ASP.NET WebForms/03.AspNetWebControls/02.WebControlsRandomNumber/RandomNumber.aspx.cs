using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.WebControlsRandomNumber
{
    public partial class RandomNumber : System.Web.UI.Page
    {
        Random rand;

        protected void ButtonNumberGenerator_Click(object sender, EventArgs e)
        {
            try
            {
                int minimalNumber = int.Parse(this.TextBoxFirstNumber.Text);
                int maximalNumber = int.Parse(this.TextBoxSecondNumber.Text);

                rand = new Random();

                int resultNumber = rand.Next(minimalNumber, maximalNumber);

                this.TextBoxResultNumber.Text = resultNumber.ToString();
            }
            catch (Exception ex)
            {
                this.TextBoxResultNumber.Text = ex.Message;
            }
        }
    }
}