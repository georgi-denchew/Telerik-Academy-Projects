<%@ Page Title="Home Page" Language="C#"
     MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="_02.WebFormsIntro._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-unit">
        <asp:Label ID="LabelName" AssociatedControlID="TextBoxName" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" CssClass="btn btn-info" Text="Submit" OnClick="ButtonSubmit_Click" />
        <asp:Panel ID="PanelHello" runat="server">
            </asp:Panel>
    </div>
</asp:Content>
