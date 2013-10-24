<%@ Page Title="Upload Homework" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Homework.aspx.cs" Inherits="Forum.Student.Homework" %>

<asp:Content ID="ContentUploadHomework" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelWrapper" runat="server" CssClass="well span12">
        <asp:FormView ID="FormViewUploadHomework" runat="server"
            ItemType="Forum.Models.Lecture" SelectMethod="FormViewUploadHomework_GetItem">
            <HeaderTemplate>
                <h1>Upload homework for lecture<br />
                    <em>"<asp:Label ID="LabelHeader" runat="server" Text="<%#: Item.Title %>" />"</em></h1>
            </HeaderTemplate>
        </asp:FormView>
        <br />
        <div class="lead">
            Homework:
        <asp:FileUpload ID="FileUploadHomework" runat="server" />
        </div>
        <h5>Max 16 MB, allowed formats: zip, rar</h5>

        <asp:Button ID="ButtonUploadHomework" runat="server" CssClass="btn" Text="Upload homework" OnClick="ButtonUploadHomework_Click" />
    </asp:Panel>
</asp:Content>
