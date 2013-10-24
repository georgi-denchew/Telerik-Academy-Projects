<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesPage.aspx.cs" Inherits="_04.FormView.EmployeesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:GridView ID="GridViewEmployees" 
            SelectMethod="GridViewEmployees_GetData"
            AutoGenerateColumns="false"
            DataKeyNames="EmployeeId"
            OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged"
             runat="server">
            <Columns>
                <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                <asp:BoundField HeaderText="Last Name" DataField="LastName" />

                <asp:CommandField ShowSelectButton="true" HeaderText="Details" SelectText="View Details" ButtonType="Button" />
            </Columns>
        </asp:GridView>

        <asp:FormView ID="FormViewEmployeeDetails" runat="server">
            <ItemTemplate>
                <h3><%#: Eval("FirstName") + " "+ Eval("LastName") %></h3>
                <table border="1">
                    <tr>
                        <td>Title:</td>
                        <td><%#: Eval("Title")%></td>
                    </tr>
                    <tr>
                        <td>TitleOfCourtesy:</td>
                        <td><%#: Eval("TitleOfCourtesy")%></td>
                    </tr>
                    <tr>
                        <td>BirthDate:</td>
                        <td><%#: Eval("BirthDate")%></td>
                    </tr>
                    <tr>
                        <td>HireDate:</td>
                        <td><%#: Eval("HireDate")%></td>
                    </tr>
                    <tr>
                        <td>Address:</td>
                        <td><%#: Eval("Address")%></td>
                    </tr>
                    <tr>
                        <td>City:</td>
                        <td><%#: Eval("City")%></td>
                    </tr>
                    <tr>
                        <td>Region:</td>
                        <td><%#: Eval("Region")%></td>
                    </tr>
                    <tr>
                        <td>Country:</td>
                        <td><%#: Eval("Country")%></td>
                    </tr>
                    <tr>
                        <td>HomePhone:</td>
                        <td><%#: Eval("HomePhone")%></td>
                    </tr>
                    <tr>
                        <td>Notes:</td>
                        <td><%#: Eval("Notes")%></td>
                    </tr>

            </ItemTemplate>
            <EmptyDataTemplate>
                <p>No Data.</p>
            </EmptyDataTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
