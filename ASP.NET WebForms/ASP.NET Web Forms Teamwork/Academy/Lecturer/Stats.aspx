<%@ Page Title="Stats" Language="C#" MasterPageFile="~/Lecturer/Lecturer.master" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="Forum.Stats" %>
<%@ Register Src="~/Controls/Statistics/StatisticsBuilder.ascx" TagPrefix="chrysoberyl" TagName="StatisticsBuilder" %>

<asp:Content ID="ContentStats" ContentPlaceHolderID="ContentPlaceHolderLecturer" runat="server">
    <h1>Stats</h1>
    <chrysoberyl:StatisticsBuilder runat="server" ID="StatisticsBuilder" />
</asp:Content>
