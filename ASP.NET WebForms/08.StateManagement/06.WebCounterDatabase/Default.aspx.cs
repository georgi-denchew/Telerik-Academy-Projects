using _06.WebCounterDatabase.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.WebCounterDatabase
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var counter = context.Visitors.FirstOrDefault();

            if (counter == null)
            {
                counter = new Visitor();
                counter.Count = 1;
                context.Visitors.Add(counter);
            }

            else
            {
                counter.Count++;
            }

            context.SaveChanges();

            var image = ImageCreator.DrawText(
                counter.Count.ToString(),
                new Font("Arial", 15, FontStyle.Italic),
                Color.Black, Color.White);


            this.image.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(image);
        }
    }
}