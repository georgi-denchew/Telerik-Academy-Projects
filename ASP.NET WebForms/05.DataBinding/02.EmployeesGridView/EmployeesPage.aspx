<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesPage.aspx.cs" Inherits="_02.EmployeesGridView.EmployeesPage" %>

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
             runat="server">
            <Columns>
                <asp:HyperLinkField HeaderText="First name" DataTextField="FirstName" DataNavigateUrlFields="EmployeeId" 
                    DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" />
                
                <asp:HyperLinkField HeaderText="Last name" DataTextField="LastName" DataNavigateUrlFields="EmployeeId" 
                    DataNavigateUrlFormatString="EmpDetails.aspx?id={0}"/>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
