<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlEscaping.aspx.cs" Inherits="_03.HtmlEscaping.HtmlEscaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="LabelInput" runat="server" AssociatedControlID="TextBoxInput" Text="Input:"></asp:Label>
        <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        <br />
        <span>Result: </span>
        <asp:Literal ID="LiteralOutput" Mode="Encode" runat="server"></asp:Literal>
    </form>
</body>
</html>