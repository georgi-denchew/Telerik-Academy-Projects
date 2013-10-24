<%@ Page Title="Homeworks" Language="C#" MasterPageFile="~/Lecturer/Lecturer.master" AutoEventWireup="true" CodeBehind="Homeworks.aspx.cs" Inherits="Forum.Lecturer.Homeworks" %>

<asp:Content ID="ContentHomeworks" ContentPlaceHolderID="ContentPlaceHolderLecturer" runat="server">

    <asp:DropDownList ID="DropDownListCourses" DataTextField="Title" DataValueField="Id" runat="server" AutoPostBack="true"
        SelectMethod="DropDownListCourses_GetData" OnSelectedIndexChanged="DropDownListCourses_SelectedIndexChanged">
    </asp:DropDownList>

    <asp:GridView ID="GridViewHomeworks" runat="server" CssClass="table table-hover"
        ItemType="Forum.Models.Homework"
        SelectMethod="GridViewHomeworks_GetData"
        UpdateMethod="GridViewHomeworks_UpdateItem"
        DeleteMethod="GridViewHomeworks_DeleteItem"
        AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Student">
                <ItemTemplate>
                    <asp:Label ID="LabelStudent" runat="server" Text="<%#: new Forum.Models.AcademyDbContext().Users.Find(Item.StudentId).FullName %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Homework">
                <ItemTemplate>
                    <asp:Label ID="LabelTitle" runat="server" Text="<%#: Item.HomeworkPath%>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
