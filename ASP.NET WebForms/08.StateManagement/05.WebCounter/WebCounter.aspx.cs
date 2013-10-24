using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.WebCounter
{
    public partial class WebCounter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["visitorsCount"] == null)
            {
                Application["visitorsCount"] = 1;
            }
            Application["visitorsCount"] = (int)Application["visitorsCount"] + 1;

            var image = ImageCreator.DrawText(
                Application["visitorsCount"].ToString(), 
                new Font("Arial", 15, FontStyle.Italic), 
                Color.Black, Color.White);


            this.ImageContainer.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(image);
        }
    }
}