<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="_06.ListView.EmployeesListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView ID="ListViewEmployees" ItemType="_06.ListView.Models.Employee" runat="server">
            <LayoutTemplate>
                <h3>Employees</h3>
                
                <asp:PlaceHolder runat="server" ID="itemPlaceholder">
                </asp:PlaceHolder>

            </LayoutTemplate>

            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>

            <ItemTemplate>
                <div>
                    <strong>First name:</strong>
                    <span><%#: Item.FirstName %></span>
                    <strong>Last name:</strong>
                    <span><%#: Item.LastName %></span>
                    <strong>Address:</strong>
                    <span><%#: Item.Address %></span>
                    <strong>Birth date:</strong>
                    <span><%#: Item.BirthDate %></span>
                    <strong>Hire date:</strong>
                    <span><%#: Item.HireDate %></span>
                    <strong>Home phone:</strong>
                    <span><%#: Item.HomePhone %></span>
                    <strong>Country:</strong>
                    <span><%#: Item.Country %></span>
                    <strong>City:</strong>
                    <span><%#: Item.City %></span>
                    <strong>Region:</strong>
                    <span><%#: Item.Region %></span>
                    <strong>Title:</strong>
                    <span><%#: Item.Title%></span>
                    <strong>TitleOfCourtesy:</strong>
                    <span><%#: Item.TitleOfCourtesy %></span>
                </div>
            </ItemTemplate>

        </asp:ListView>
    </div>
    </form>
</body>
</html>
