using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.CarsForm
{
    public partial class CarsForm : System.Web.UI.Page
    {
        public Producer[] Producers
        {
            get
            {
                return new Producer[] 
                {
                    new Producer{Name = "BMW",Models = new string[] { "321", "518", "721" } },
                    new Producer { Name = "Audi", Models = new string[] { "A3", "A6", "A8" } },
                    new Producer { Name = "Mercedes", Models = new string[] { "C220", "E320", "S500" } }
                };
            }
        }

        public Extra[] Extras
        {
            get
            {
                return new Extra[]
                {
                    new Extra{Name="Air Conditioner"}, new Extra{Name="ABS"}, new Extra{Name="Automatic Transmission"},
                };
            }
        }

        public string[] Engines
        {
            get
            {
                return new string[] {"1600cc", "1800cc", "2200cc", "3200cc", "5000cc", };
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DropDownListProducers.DataSource = this.Producers;
                this.DropDownListModels.DataSource = this.Producers.First().Models;
                this.CheckBoxListExtras.DataSource = this.Extras;


                this.DataBind();
            }
        }

        protected void DropDownListProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producerName = this.DropDownListProducers.SelectedItem.Text;

            this.DropDownListModels.DataSource = this.Producers.First(x => x.Name == producerName).Models;

            this.DropDownListModels.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string result = string.Format("Producer: {0}; ", this.DropDownListProducers.SelectedItem.Text);
            result += string.Format("Model: {0}; ", this.DropDownListModels.SelectedItem.Text);

            result += "Extras: ";

            for (int i = 0; i < this.CheckBoxListExtras.Items.Count; i++)
            {
                if (this.CheckBoxListExtras.Items[i].Selected)
                {
                    result += this.CheckBoxListExtras.Items[i].Text + ", ";
                }
            }

            if (result.EndsWith(", "))
            {
                result.Remove(result.Length - 2, 2);
                result += "; ";
            }

            result += string.Format("Engine: {0};", this.RadioButtonListEngine.SelectedItem.Text);

            this.LiteralInformation.Text = result;
        }
    }
}