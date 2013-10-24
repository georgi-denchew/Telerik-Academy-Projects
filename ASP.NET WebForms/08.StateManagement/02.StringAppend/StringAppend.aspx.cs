using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.StringAppend
{
    public partial class StringAppend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAppend_Click(object sender, EventArgs e)
        {
            this.LabelOutput.Text += this.TextBoxStringAppend.Text;

            if (Session["stringList"] == null)
            {
                Session["stringList"] = new List<string>();
            }

            (Session["stringList"] as List<string>).Add(this.TextBoxStringAppend.Text);


        }
    }
}