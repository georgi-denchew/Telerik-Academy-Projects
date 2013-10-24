<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PlanetWebApplication.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:EntityDataSource
                ID="EntityDataSourceContinents"
                ConnectionString="name=PlanetDatabaseEntities"
                DefaultContainerName="PlanetDatabaseEntities"
                EntitySetName="Continents"
                runat="server">
            </asp:EntityDataSource>

            <h2>Continents:</h2>
            <asp:ListBox
                ID="ListBoxContinents"
                DataSourceID="EntityDataSourceContinents"
                OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged"
                DataTextField="Name" DataValueField="ContinentID"
                AutoPostBack="true"
                runat="server">
            </asp:ListBox>

            <br />
            <asp:Label ID="LabelContinentName" AssociatedControlID="TextBoxContinentName" runat="server" Text="ContinentName:"></asp:Label>

            <asp:TextBox AutoPostBack="false" ID="TextBoxContinentName" runat="server"></asp:TextBox>

            <asp:Button ID="ButtonContinentAdd" runat="server" OnClick="ButtonContinentAdd_Click" Text="Add continent" />

            <br />
            <asp:Button ID="ButtonDeleteContinent" OnClick="ButtonDeleteContinent_Click" runat="server" Text="Delete" />

            <br />
            <asp:Button ID="ButtonContinentEdit" OnClick="ButtonContinentEdit_Click"
                runat="server" Text="Edit" />

            <asp:Panel ID="PanelContinentEdit" Visible="false" runat="server">
                <asp:Label ID="LabelContinentNameEdit" AssociatedControlID="TextBoxContinentNameEdit" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="TextBoxContinentNameEdit" runat="server"></asp:TextBox>

                <asp:Button ID="ButtonContinentEditSave" OnClick="ButtonContinentEditSave_Click"
                    runat="server" Text="Save" />
                <asp:Button ID="ButtonContinentEditCancel"
                    runat="server" Text="Cancel" CommandName="Cancel" OnClick="ButtonContinentEditCancel_Click" />
            </asp:Panel>
            <h2>Countries:</h2>

            <asp:EntityDataSource
                ID="EntityDataSourceCountries"
                ConnectionString="name=PlanetDatabaseEntities"
                DefaultContainerName="PlanetDatabaseEntities"
                EntitySetName="Countries" Include="Towns, Language"
                EnableDelete="true"
                EnableUpdate="true"
                EnableInsert="true"
                Where="it.ContinentID=@ContID"
                EnableViewState="true"
                EnableFlattening="false"
                runat="server">
                <WhereParameters>
                    <asp:ControlParameter
                        Name="ContID"
                        DefaultValue=""
                        Type="Int32"
                        ControlID="ListBoxContinents" />
                </WhereParameters>
            </asp:EntityDataSource>

            <asp:GridView
                ID="GridViewCountries"
                DataSourceID="EntityDataSourceCountries"
                DataKeyNames="CountryID"
                AllowPaging="true"
                PageSize="5"
                AllowSorting="true"
                AutoGenerateColumns="false"
                OnRowUpdating="GridViewCountries_RowUpdating"
                OnRowDeleting="GridViewCountries_RowDeleting"
                OnSelectedIndexChanged="GridViewCountries_SelectedIndexChanged"
                ItemType="PlanetWebApplication.Country"
                ShowFooter="true"
                runat="server">
                <EmptyDataTemplate>
                    <table border="1">
                        <tr>
                            <th>Insert</th>
                            <th>Name</th>
                            <th>Language</th>
                            <th>Population</th>
                            <th>Flag</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButtonEmptyCountryInsert" runat="server" OnClick="LinkButtonEmptyCountryInsert_Click" CommandName="Insert">Insert</asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxEmptyCountryNameInsert" runat="server" Text=""></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxEmptyCountryLanguageInsert" runat="server" Text=""></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxEmptyCountryPopulationInsert" runat="server" Text=""></asp:TextBox>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUploadEmptyCountryFlagInsert" runat="server" AllowMultiple="false" />
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>
                    <asp:CommandField ShowSelectButton="true" HeaderText="Show towns" SelectText="Show towns" />
                    <asp:TemplateField HeaderText="Operations">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonCountryEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonCountryDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButtonCountryUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonCountryUpdateCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButtonCountryInsert" runat="server" OnClick="LinkButtonCountryInsert_Click" CommandName="Insert">Insert</asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Country" SortExpression="Name">
                        <ItemTemplate>
                            <asp:Label ID="LabelCountryName" runat="server" Text="<%#: Item.Name %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxCountryEdit" runat="server" Text="<%#: Item.Name %>"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxCountryNameInsert" runat="server" Text="">
                            </asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Language" SortExpression="Language.Name">
                        <ItemTemplate>
                            <asp:Label ID="LabelCountryLanguage" runat="server" Text="<%#: Item.Language.Name %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxCountryLanguageEdit" runat="server" Text="<%#: Item.Language.Name %>"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxCountryLanguageInsert" runat="server" Text=""></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Population" SortExpression="Population">
                        <ItemTemplate>
                            <asp:Label ID="LabelCountryPopulation" runat="server" Text="<%#: Item.Population %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxCountryPopulationEdit" runat="server" Text="<%#: Item.Population %>"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxCountryPopulationInsert" runat="server" Text=""></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField ControlStyle-Height="50px" ItemStyle-Width="50px" HeaderText="Flag">
                        <ItemTemplate>
                            <asp:Image  ID="ImageFlag" runat="server" ImageUrl='<%#: string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(Item.Flag)) %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:FileUpload ID="FileUploadImageEdit" runat="server" AllowMultiple="false" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:FileUpload ID="FileUploadImageInsert" runat="server" AllowMultiple="false" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:EntityDataSource
                ID="EntityDataSourceTowns"
                runat="server"
                ConnectionString="name=PlanetDatabaseEntities"
                DefaultContainerName="PlanetDatabaseEntities"
                EntitySetName="Towns"
                Where="it.CountryID=@CountryID"
                EnableUpdate="true"
                EnableDelete="true"
                EnableInsert="true"
                EnableFlattening="false">
                <WhereParameters>
                    <asp:ControlParameter Name="CountryID" Type="Int32"
                        ControlID="GridViewCountries" />
                </WhereParameters>
            </asp:EntityDataSource>

            <h3>Towns</h3>

            <asp:ListView
                ID="ListViewTowns"
                runat="server"
                DataSourceID="EntityDataSourceTowns"
                ItemType="PlanetWebApplication.Town"
                OnItemInserting="ListViewTowns_ItemInserting"
                DataKeyNames="TownID">

                <LayoutTemplate>
                    <span runat="server" id="itemPlaceholder"></span>
                    <asp:Button ID="ButtonInsertTown" Text="Add new Town" runat="server"
                        OnClick="ButtonInsertTown_Click" />
                </LayoutTemplate>

                <EmptyDataTemplate>
                    <p>No towns.</p>
                    <asp:Button ID="ButtonInsertTown" Text="Add new Town" runat="server"
                        OnClick="ButtonInsertTown_Click" />
                </EmptyDataTemplate>

                <ItemTemplate>
                    <div class="town">
                        <strong>Town Name:</strong> <span><%#: Item.Name  %> </span>
                        <strong>Town Population:</strong> <span><%#: Item.Population  %> people</span>
                        <asp:Button ID="ButtonTownEdit" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="ButtonTownDelete" runat="server" CommandName="Delete" Text="Delete" />
                    </div>
                </ItemTemplate>

                <EditItemTemplate>
                    <div class="town-edit">
                        <strong>Town Name: </strong>
                        <asp:TextBox ID="TextBoxTownName" runat="server" Text="<%#: BindItem.Name %>"></asp:TextBox>
                        <strong>Population: </strong>
                        <asp:TextBox ID="TextBoxTownPopulation" runat="server" Text="<%#: BindItem.Population %>"></asp:TextBox>
                        <asp:Button ID="ButtonTownUpdate" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="ButtonTownUpdateCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                    </div>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <div class="town-insert">
                        <strong>Town Name: </strong>
                        <asp:TextBox ID="TextBoxTownName" runat="server" Text="<%#: BindItem.Name %>"></asp:TextBox>
                        <strong>Population: </strong>
                        <asp:TextBox ID="TextBoxTownPopulation" runat="server" Text="<%#: BindItem.Population %>"></asp:TextBox>
                        <asp:Button ID="ButtonTownInsert" runat="server" CommandName="Insert" Text="Insert" />
                </InsertItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
