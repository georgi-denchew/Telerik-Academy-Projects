using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.HelloAspNet
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            this.PanelHello.GroupingText = string.Format(
                "Hello, Asp.Net! Current assembly Location: {0}", assembly.Location);
        }
    }
}