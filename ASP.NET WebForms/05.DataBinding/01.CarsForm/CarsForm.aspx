<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarsForm.aspx.cs" Inherits="_01.CarsForm.CarsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelProducers" AssociatedControlID="DropDownListProducers" runat="server" Text="Producer:"></asp:Label>
        <asp:DropDownList ID="DropDownListProducers" OnSelectedIndexChanged="DropDownListProducers_SelectedIndexChanged"
             runat="server" DataTextField="Name" AutoPostBack="true">
        </asp:DropDownList>

        <asp:Label ID="LabelModels" AssociatedControlID="DropDownListModels" runat="server" Text="Model:"></asp:Label>
        <asp:DropDownList ID="DropDownListModels" runat="server"></asp:DropDownList>

        <br />

        <asp:Label ID="LabelExtras" AssociatedControlID="CheckBoxListExtras" runat="server" Text="Extras:"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxListExtras" DataTextField="Name" runat="server"></asp:CheckBoxList>
        
        <asp:Label ID="LabelEngine" AssociatedControlID="RadioButtonListEngine" runat="server" Text="Engine Size:"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonListEngine" AutoPostBack="true" DataSource="<%# this.Engines %>" runat="server"></asp:RadioButtonList>
        <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" />

        <br />
        
        <asp:Literal ID="LiteralInformation" Mode="Encode" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
