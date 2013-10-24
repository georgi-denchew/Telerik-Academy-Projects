<%@ Page Title="Course Details"
    Language="C#"
    MasterPageFile="~/Student/Student.master"
    AutoEventWireup="true"
    CodeBehind="Lecture.aspx.cs"
    Inherits="Forum.Student.Lecture" %>

<asp:Content ID="ContentLecture" ContentPlaceHolderID="ContentPlaceHolderStudent" runat="server">
    <asp:FormView ID="FormViewCourse" runat="server" ItemType="Forum.Models.Course" CssClass="well span 8" SelectMethod="FormViewCourse_GetItem">
        <HeaderTemplate>
            <table>
                <tr>
                    <td class="lead">Title: </td>
                    <td><%#: Item.Title %></td>
                </tr>
                <tr>
                    <td class="lead">Description: </td>
                    <td><%#: Item.Description %></td>
                </tr>
                <tr>
                    <td class="lead">Start date: </td>
                    <td><%#: Item.StartDate.ToString("dd.MM.yyyy") %></td>
                </tr>
                <tr>
                    <td class="lead">End date: </td>
                    <td><%#: Item.EndDate.ToString("dd.MM.yyyy") %></td>
                </tr>
                <tr>
                    <td class="lead">Lecturer: </td>
                    <td><%#: Item.Lecturer.FullName %></td>
                </tr>
                <tr>
                    <td class="lead">Contact lecturer: </td>
                    <td><a href="mailto://<%#: Item.Lecturer.Email %>">Contact</a></td>
                </tr>
                <asp:Panel ID="PanelRegisterForCourse" runat="server">
                    <asp:Button ID="ButtonRegisterForCourse" runat="server" Text="Register for this course"
                        Visible="false" CssClass="btn btn-info" OnClick="ButtonRegisterForCourse_Click" />
                </asp:Panel>
            </table>
        </HeaderTemplate>
    </asp:FormView>
    <asp:GridView
        ID="GridViewLectures"
        runat="server"
        ItemType="Forum.Models.Lecture"
        SelectMethod="GridViewLectures_GetData"
        DataKeyNames="Id"
        AutoGenerateColumns="false"
        AllowPaging="true"
        PageSize="2"
        CssClass="table table-bordered table-hover">
        <EmptyDataTemplate>
            <h4>There are no lectures in this course.</h4>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="LabelTitle" runat="server" Text="<%#: Item.Title %>" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Location">
                <ItemTemplate>
                    <asp:Label ID="LabelLocation" runat="server" Text="<%#: Item.Location %>" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Homework due">
                <ItemTemplate>
                    <asp:Label ID="LabelHomeworkDue" runat="server" Text='<%#: Item.HomeworkDueDate.ToString("dd.MM.yyyy HH:mm") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Upload homework">
                <ItemTemplate>
                    <%# GetHomeworkLinks(Item.Id) %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
