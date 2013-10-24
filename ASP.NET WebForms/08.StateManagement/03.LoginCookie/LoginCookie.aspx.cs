using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.LoginCookie
{
    public partial class LoginCookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserName", "pesho");
            cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Add(cookie);

            Response.Redirect("LoggedIn.aspx");
        }
    }
}