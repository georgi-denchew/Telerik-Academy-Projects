<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Sumator.aspx.cs"
    Inherits="_02.Sumator.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sumator</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="hero-unit">
        <h1>Calculator</h1>
        <form id="formSumator" runat="server">
            <asp:Label ID="LabelTextBoxFirstNumber" AssociatedControlID="TextBoxFirstNumber" runat="server" Text="First Number:"></asp:Label>
            <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
            <asp:Label ID="LabelTextBoxSecondNumber" AssociatedControlID="TextBoxSecondNumber" runat="server" Text="Second Number:"></asp:Label>
            <asp:TextBox ID="TextBoxSecondNumber" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonSumator" OnClick="ButtonSumator_Click" CssClass="btn btn-info" runat="server" Text="Calculate Sum" />
            <asp:Label ID="LabelTextBoxSum" runat="server" AssociatedControlID="TextBoxSum" Text="Sum:"></asp:Label>
            <asp:TextBox ID="TextBoxSum" runat="server"></asp:TextBox>
        </form>
    </div>
</body>
</html>
