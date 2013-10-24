<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginCookie.aspx.cs" Inherits="_03.LoginCookie.LoginCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelLogin" runat="server" Text="Not logged"></asp:Label>
        <asp:Button ID="ButtonLogin" runat="server" Text="Log In" OnClick="ButtonLogin_Click" />
    </div>
    </form>
</body>
</html>
