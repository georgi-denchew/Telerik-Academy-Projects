<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumber.aspx.cs" Inherits="_02.WebControlsRandomNumber.RandomNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="LabelFirstNumber" AssociatedControlID="TextBoxFirstNumber" runat="server" Text="Minimal Number:"></asp:Label>
        <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelSecondNumber" AssociatedControlID="TextBoxSecondNumber" runat="server" Text="Maximal Number:"></asp:Label>
        <asp:TextBox ID="TextBoxSecondNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonNumberGenerator" runat="server" Text="Generate Button" OnClick="ButtonNumberGenerator_Click" />
        <br />
        <asp:Label ID="LabelResultNumber" runat="server" Text="Random Number:"></asp:Label>
        <asp:TextBox ID="TextBoxResultNumber" runat="server"></asp:TextBox>
    </form>
</body>
</html>
