<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UK.aspx.cs" Inherits="SiteNavigation.UK.UK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>This is The UK</h1>
    <h3>Cities</h3>
    <asp:Menu ID="UKMenu" runat="server" IncludeStyleBlock="false" EnableViewState="false" DataSourceID="SiteMapDataSource"></asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" ShowStartingNode="false" StartingNodeUrl="~/UK/UK.aspx" />
</asp:Content>
