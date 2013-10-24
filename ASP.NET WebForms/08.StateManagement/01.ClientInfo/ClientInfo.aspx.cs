using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.ClientInfo
{
    public partial class ClientInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralInfo.Text += "Browser: " + Request.Browser.Type + "<br/>";
            string ip = null;
            var ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string singleIp = Request.ServerVariables["REMOTE_ADDR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                ip = ipList.Split(',')[0];
            }
            else if (!string.IsNullOrEmpty(singleIp) && !singleIp.StartsWith("::"))
            {
                ip = singleIp;
            }
            else
            {
                ip = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())[2].ToString();
            }

            this.LiteralInfo.Text += "Client IP Address: " + ip;

        }
    }
}