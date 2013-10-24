using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanetWebApplication
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["continentID"] = (sender as ListBox).SelectedItem.Value;
        }

        protected void ButtonContinentAdd_Click(object sender, EventArgs e)
        {
            PlanetDatabaseEntities context = new PlanetDatabaseEntities();
            string continentName = this.TextBoxContinentName.Text;

            var existing = context.Continents.FirstOrDefault(cont => cont.Name == continentName);

            if (existing == null)
            {
                Continent continentToInsert = new Continent
                {
                    Name = continentName
                };

                context.Continents.Add(continentToInsert);
                context.SaveChanges();

                Response.Redirect("index.aspx");
            }
        }

        protected void ButtonDeleteContinent_Click(object sender, EventArgs e)
        {
            int continentID = int.Parse(this.ListBoxContinents.SelectedValue);

            PlanetDatabaseEntities context = new PlanetDatabaseEntities();
            var existing = context.Continents.FirstOrDefault(cont => cont.ContinentID == continentID);

            if (existing != null)
            {
                context.Continents.Remove(existing);
                context.SaveChanges();
            }

            Response.Redirect("index.aspx");
        }

        protected void ButtonContinentEdit_Click(object sender, EventArgs e)
        {
            ViewState["continentId"] = int.Parse(this.ListBoxContinents.SelectedValue);
            int id = (int)ViewState["continentId"];
            PlanetDatabaseEntities context = new PlanetDatabaseEntities();
            var existing = context.Continents.FirstOrDefault(cont => cont.ContinentID == id);
            this.TextBoxContinentNameEdit.Text = existing.Name;

            this.PanelContinentEdit.Visible = true;

            this.ButtonContinentEdit.Visible = false;
        }

        protected void ButtonContinentEditSave_Click(object sender, EventArgs e)
        {
            string newName = TextBoxContinentNameEdit.Text;
            int id = (int)ViewState["continentId"];

            PlanetDatabaseEntities context = new PlanetDatabaseEntities();
            var existing = context.Continents.FirstOrDefault(cont => cont.ContinentID == id);
            existing.Name = newName;
            context.SaveChanges();

            (sender as Button).Parent.Visible = false;

            this.ButtonContinentEdit.Visible = true;

            this.ListBoxContinents.DataBind();
        }


        protected void GridViewCountries_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string countryName = ((sender as GridView).Rows[e.RowIndex].FindControl("TextBoxCountryEdit") as TextBox).Text;
            string language = ((sender as GridView).Rows[e.RowIndex].FindControl("TextBoxCountryLanguageEdit") as TextBox).Text;
            int population = int.Parse(((sender as GridView).Rows[e.RowIndex].FindControl("TextBoxCountryPopulationEdit") as TextBox).Text);
            var image = ((sender as GridView).Rows[e.RowIndex].FindControl("FileUploadImageEdit") as FileUpload).FileBytes;
            int id = (int)e.Keys["CountryID"];
            
            PlanetDatabaseEntities context = new PlanetDatabaseEntities();

            var existingCountry = context.Countries.FirstOrDefault(c => c.Name == countryName);

            if (existingCountry == null)
            {
                throw new InvalidOperationException("Country does not exist");
            }

            var existingLanguage = context.Languages.FirstOrDefault(lang => lang.Name == language);
            var countryToUpdate = context.Countries.FirstOrDefault(c => c.CountryID == id);

            if (existingLanguage == null)
            {
                Language newLanguage = new Language { Name = language };
                context.Languages.Add(newLanguage);
                countryToUpdate.Language = newLanguage;
            }
            else
            {
                countryToUpdate.Language = existingLanguage;
            }

            countryToUpdate.Name = countryName;
            countryToUpdate.Population = population;
            countryToUpdate.Flag = image;
            context.SaveChanges();

            e.Cancel = true;
            (sender as GridView).EditIndex = -1;
        }

        protected void GridViewCountries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)e.Keys["CountryID"];
            PlanetDatabaseEntities context = new PlanetDatabaseEntities();
            var existingCountry = context.Countries.FirstOrDefault(c => c.CountryID == id);

            context.Countries.Remove(existingCountry);
            context.SaveChanges();



            e.Cancel = true;
            (sender as GridView).DataBind();
        }

        protected void LinkButtonCountryInsert_Click(object sender, EventArgs e)
        {
            int continentID = int.Parse((string)ViewState["continentID"]);
            string name = (this.GridViewCountries.FooterRow.FindControl("TextBoxCountryNameInsert") as TextBox).Text;
            string language = (this.GridViewCountries.FooterRow.FindControl("TextBoxCountryLanguageInsert") as TextBox).Text;
            var image = (this.GridViewCountries.FooterRow.FindControl("FileUploadImageInsert") as FileUpload).FileBytes;
            int population = int.Parse((this.GridViewCountries.FooterRow.FindControl("TextBoxCountryPopulationInsert") as TextBox).Text);

            PlanetDatabaseEntities context = new PlanetDatabaseEntities();

            var existingCountry = context.Countries.FirstOrDefault(c => c.Name == name);

            if (existingCountry != null)
            {
                throw new InvalidOperationException("Country exists");
            }

            var existingLanguage = context.Languages.FirstOrDefault(l => l.Name == language);

            if (existingLanguage == null)
            {
                existingLanguage = new Language() { Name = language };
            }

            var continent = context.Continents.FirstOrDefault(cont => cont.ContinentID == continentID);

            if (continent == null)
            {
                throw new InvalidOperationException("Continent does not exists");
            }

            if (image == null)
            {
                throw new InvalidOperationException("No flag was selected");
            }

            var countryToInsert = new Country() 
            { 
                Name = name, 
                Language = existingLanguage,
                Population = population,
                Flag = image
            };

            continent.Countries.Add(countryToInsert);

            context.SaveChanges();

            this.GridViewCountries.DataBind();
        }

        protected void ButtonInsertTown_Click(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.LastItem;
            
            (sender as Button).Visible = false;
        }

        protected void GridViewCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["countryID"] = (int)(sender as GridView).SelectedDataKey.Value;
        }

        protected void ListViewTowns_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int countryID = (int)ViewState["countryID"];
            string townName = ((sender as ListView).InsertItem.FindControl("TextBoxTownName") as TextBox).Text;
            int townPopulation = int.Parse(((sender as ListView).InsertItem.FindControl("TextBoxTownPopulation") as TextBox).Text);

            PlanetDatabaseEntities context = new PlanetDatabaseEntities();

            var existingCountry = context.Countries.FirstOrDefault(country => country.CountryID == countryID);

            if (existingCountry == null)
            {
                throw new InvalidOperationException("ko?ne!");
            }

            Town townToInsert = new Town() { Name = townName, Population = townPopulation };
            existingCountry.Towns.Add(townToInsert);
            context.SaveChanges();

            this.ListViewTowns.InsertItemPosition = InsertItemPosition.None;

            (sender as ListView).FindControl("ButtonInsertTown").Visible = true;

            e.Cancel = true;
        }

        protected void ButtonContinentEditCancel_Click(object sender, EventArgs e)
        {
            (sender as Button).Parent.Visible = false;

            this.ButtonContinentEdit.Visible = true;
        }

        protected void LinkButtonEmptyCountryInsert_Click(object sender, EventArgs e)
        {
            int id = int.Parse((string)ViewState["continentID"]);
            var table = (sender as LinkButton).Parent;
            string countryName = (table.FindControl("TextBoxEmptyCountryNameInsert") as TextBox).Text;
            string languageName = (table.FindControl("TextBoxEmptyCountryLanguageInsert") as TextBox).Text;
            var image = (table.FindControl("FileUploadEmptyCountryFlagInsert") as FileUpload).FileBytes;
            int population = int.Parse((table.FindControl("TextBoxEmptyCountryPopulationInsert") as TextBox).Text);

            PlanetDatabaseEntities context = new PlanetDatabaseEntities();

            var language = context.Languages.FirstOrDefault(lang => lang.Name == languageName);

            if (language == null)
            {
                language = new Language() { Name = languageName };
            }

            var country = context.Countries.FirstOrDefault(c => c.Name == countryName);

            if (country != null)
            {
                throw new InvalidOperationException("Country with that name already exists");
            }

            country = new Country() 
            { 
                Name = countryName, 
                Language = language, 
                Population = population,
                Flag = image
            };

            var continent = context.Continents.FirstOrDefault(cont => cont.ContinentID == id);

            if (continent == null)
            {
                throw new InvalidOperationException("Continent does not exists");
            }

            continent.Countries.Add(country);
            context.SaveChanges();

            this.GridViewCountries.DataBind();
        }

        protected void ButtonPictureUpload_Click(object sender, EventArgs e)
        {
            

        }
    }
}