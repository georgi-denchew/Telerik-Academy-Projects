<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="_02.EmployeesGridView.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView ID="DetailsViewEmployee" runat="server" Height="50px" Width="125px">
        </asp:DetailsView>
        <asp:HyperLink ID="HyperLinkEmployees" NavigateUrl="~/EmployeesPage.aspx" runat="server">All Employees</asp:HyperLink>
        
    </div>
    </form>
</body>
</html>
