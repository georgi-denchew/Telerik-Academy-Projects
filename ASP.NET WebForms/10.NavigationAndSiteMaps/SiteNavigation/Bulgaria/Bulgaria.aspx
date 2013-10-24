<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bulgaria.aspx.cs" Inherits="SiteNavigation.Bulgaria.Bulgaria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Bulgaira</h1>
    <h3>Cities:</h3>
    <asp:Menu runat="server" ID="NavigationMenu" EnableViewState="false" DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" ShowStartingNode="false" StartingNodeUrl="~/Bulgaria/Bulgaria.aspx" />
</asp:Content>
