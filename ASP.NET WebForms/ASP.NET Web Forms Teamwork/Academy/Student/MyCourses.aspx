<%@ Page Title="Courses" 
    Language="C#"
     MasterPageFile="~/Student/Student.master"
     AutoEventWireup="true" 
    CodeBehind="MyCourses.aspx.cs"
   Inherits="Forum.Student.Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderStudent" runat="server">


    <asp:GridView ID="GridViewMyCourses" runat="server"
        SelectMethod="GridViewMyCourses_GetData"
        ItemType="Forum.Models.Course"
        AutoGenerateColumns="false"
        AllowSorting="true"
        AllowPaging="true"
        DataKeyNames="Id"
        PageSize="5"
        OnSelectedIndexChanged="GridViewMyCourses_SelectedIndexChanged"
        CssClass="table table-bordered table-hover">
        <EmptyDataTemplate>
            <h4>There are no courses available.</h4>
        </EmptyDataTemplate>
        <Columns>
            <asp:CommandField ShowSelectButton="true" HeaderText="Show lectures" SelectText="Show lectures" />
            <asp:TemplateField HeaderText="Course" SortExpression="Title">
                <ItemTemplate>
                    <asp:Label ID="LabelCourseTitle" runat="server" Text="<%#: Item.Title %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Description" ControlStyle-Width="370">
                <ItemTemplate>
                    <asp:Label ID="LabelCourseDescription" runat="server" Text="<%#: Item.Description %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Lecturer">
                <ItemTemplate>
                    <asp:Label ID="LabelLecturerName" runat="server" Text='<%# Item.Lecturer.FullName %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Free places">
                <ItemTemplate>
                    <asp:Label ID="LabelFreePlaces" runat="server" Text="<%#: Item.FreePlaces %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Start date">
                <ItemTemplate>
                    <asp:Label ID="LabelStartDate" runat="server" Text='<%#: Item.StartDate.ToString("dd.MM.yyyy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="End date">
                <ItemTemplate>
                    <asp:Label ID="LabelEndDate" runat="server" Text='<%#: Item.EndDate.ToString("dd.MM.yyyy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
