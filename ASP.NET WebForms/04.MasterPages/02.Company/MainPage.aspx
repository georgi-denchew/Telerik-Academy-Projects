<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="_02.Company.MainPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <h1>Main Page</h1>
    <asp:HyperLink ID="UKLink" NavigateUrl="~/UK/UKHome.aspx" runat="server">United Kingdom</asp:HyperLink>
    <br />
    <asp:HyperLink ID="BGLink" NavigateUrl="~/BG/BGHome.aspx" runat="server">Bulgaria</asp:HyperLink>
    <br />
    <asp:HyperLink ID="DELink" NavigateUrl="~/DE/DEHome.aspx" runat="server">Deutschland</asp:HyperLink>
</asp:Content>