using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.WebFormsIntro
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.TextBoxName.Text;

                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Name cannot be null");
                }

                this.PanelHello.GroupingText = string.Format("Hello, {0}!", name);

            }
            catch (ArgumentException ex)
            {
                this.PanelHello.GroupingText = ex.Message;
            }
        }
    }
}