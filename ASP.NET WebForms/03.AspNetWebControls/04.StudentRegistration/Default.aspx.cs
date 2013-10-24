using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _04.StudentRegistration
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            HtmlGenericControl firstNameDiv = new HtmlGenericControl("div");
            HtmlGenericControl firstNameContainer = new HtmlGenericControl("span");
            firstNameContainer.InnerText = this.TextBoxFirstName.Text;
            firstNameContainer.ID = "firstNameContainer";
            HtmlGenericControl firstNameLabel = new HtmlGenericControl("span");
            firstNameLabel.InnerText = "First name: ";
            firstNameDiv.Controls.Add(firstNameLabel);
            firstNameDiv.Controls.Add(firstNameContainer);
            this.PanelInfoContainer.Controls.Add(firstNameDiv);

            HtmlGenericControl lastNameDiv = new HtmlGenericControl("div");
            HtmlGenericControl lastNameContainer = new HtmlGenericControl("span");
            lastNameContainer.InnerText = this.TextBoxLastName.Text;
            lastNameContainer.ID = "lastNameContainer";
            HtmlGenericControl lastNameLabel = new HtmlGenericControl("span");
            lastNameLabel.InnerText = "Last name: ";
            lastNameDiv.Controls.Add(lastNameLabel);
            lastNameDiv.Controls.Add(lastNameContainer);
            this.PanelInfoContainer.Controls.Add(lastNameDiv);

            HtmlGenericControl facultyNumberDiv = new HtmlGenericControl("div");
            HtmlGenericControl facultyNumberContainer = new HtmlGenericControl("span");
            facultyNumberContainer.InnerText = this.TextBoxFacultyNumber.Text;
            facultyNumberContainer.ID = "facultyNumberContainer";
            HtmlGenericControl facultyNumberLabel = new HtmlGenericControl("span");
            lastNameLabel.InnerText = "Faculty Number: ";
            facultyNumberDiv.Controls.Add(facultyNumberLabel);
            facultyNumberDiv.Controls.Add(facultyNumberContainer);
            this.PanelInfoContainer.Controls.Add(facultyNumberDiv);

            HtmlGenericControl universityDiv = new HtmlGenericControl("div");
            HtmlGenericControl universityContainer = new HtmlGenericControl("span");
            int universityNumber = int.Parse(this.DropDownListUniversity.Text);
            universityContainer.InnerText = this.DropDownListUniversity.Items[universityNumber - 1].Text;
            universityContainer.ID = "universityContainer";
            HtmlGenericControl universityLabel = new HtmlGenericControl("span");
            universityLabel.InnerText = "University: ";
            universityDiv.Controls.Add(universityLabel);
            universityDiv.Controls.Add(universityContainer);
            this.PanelInfoContainer.Controls.Add(universityDiv);

            HtmlGenericControl specialtyDiv = new HtmlGenericControl("div");
            HtmlGenericControl specialtyContainer = new HtmlGenericControl("span");
            int specialtyNumber = int.Parse(this.DropDownListSpecialty.Text);
            specialtyContainer.InnerText = this.DropDownListSpecialty.Items[specialtyNumber - 1].Text;
            specialtyContainer.ID = "specialtyContainer";
            HtmlGenericControl specialtyLabel = new HtmlGenericControl("span");
            specialtyLabel.InnerText = "Specialty: ";
            specialtyDiv.Controls.Add(specialtyLabel);
            specialtyDiv.Controls.Add(specialtyContainer);
            this.PanelInfoContainer.Controls.Add(specialtyDiv);

            HtmlGenericControl coursesDiv = new HtmlGenericControl("div");
            HtmlGenericControl coursesContainer = new HtmlGenericControl("span");
            var selectedIndices = this.ListBoxCourses.GetSelectedIndices();

            for (int i = 0; i < selectedIndices.Length; i++)
            {
                coursesContainer.InnerText += string.Format("{0}, ", this.ListBoxCourses.Items[selectedIndices[i]].Text);
            }

            coursesContainer.InnerText = coursesContainer.InnerText.Remove(coursesContainer.InnerText.Length - 2, 2);
            coursesContainer.ID = "coursesContainer";
            HtmlGenericControl coursesLabel = new HtmlGenericControl("span");
            coursesLabel.InnerText = "Courses: ";
            coursesDiv.Controls.Add(coursesLabel);
            coursesDiv.Controls.Add(coursesContainer);
            this.PanelInfoContainer.Controls.Add(coursesDiv);
        }
    }
}