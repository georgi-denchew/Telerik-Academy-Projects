using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.HtmlControlsRandomNumbers
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        private Random rand;

        protected void ButtonNumberGenerator_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int minimalNumber = int.Parse(this.TextFirstNumber.Value);
                int maximalNumber = int.Parse(this.TextSecondNumber.Value);
                
                rand = new Random();

                int result = rand.Next(minimalNumber, maximalNumber);

                this.ResultContainer.InnerText = string.Format("Random number: {0}", result);
            }
            catch (Exception ex)
            {
                this.ResultContainer.InnerText = ex.Message;
            }
        }
    }
}