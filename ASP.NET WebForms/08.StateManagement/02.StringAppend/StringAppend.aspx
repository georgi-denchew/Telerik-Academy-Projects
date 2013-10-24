<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StringAppend.aspx.cs" Inherits="_02.StringAppend.StringAppend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBoxStringAppend" runat="server"></asp:TextBox><asp:Button ID="ButtonAppend" runat="server" Text="Append" OnClick="ButtonAppend_Click" />
        <asp:Label ID="LabelOutput" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
