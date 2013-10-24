<%@ Page Title="Course Details" Language="C#" MasterPageFile="~/Lecturer/Lecturer.master" AutoEventWireup="true" CodeBehind="Lecture.aspx.cs" Inherits="Forum.Lecture" %>

<asp:Content ID="ContentLecture" ContentPlaceHolderID="ContentPlaceHolderLecturer" runat="server">
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
    <asp:GridView ID="GridViewLectures" runat="server" ItemType="Forum.Models.Lecture" ShowFooter="true"
        SelectMethod="GridViewLectures_GetData" UpdateMethod="GridViewLectures_UpdateItem" DataKeyNames="Id" DeleteMethod="GridViewLectures_DeleteItem"
        AutoGenerateColumns="false" AllowPaging="true" PageSize="2"
        CssClass="table table-bordered table-hover">
        <EmptyDataTemplate>
            <table border="1">
                <tr>
                    <th>Title</th>
                    <th>Location</th>
                    <th>Homework due date</th>
                    <th>Actions</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBoxEmptyLectureTitleInsert" runat="server" Text=""></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmptyLectureTitleInsert"
                            ErrorMessage="The lecture title is required." Display="Dynamic" CssClass="text-error" ValidationGroup="InsertLecture" />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxEmptyLectureLocationInsert" runat="server" Text=""></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmptyLectureLocationInsert"
                            ErrorMessage="The lecture location is required." Display="Dynamic" CssClass="text-error" ValidationGroup="InsertLecture" />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxEmptyHomeworkDue" runat="server" Text="" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmptyHomeworkDue"
                            ErrorMessage="The lecture homework due date is required." Display="Dynamic" CssClass="text-error" ValidationGroup="InsertLecture" />
                    </td>
                    <td>
                    <td>
                        <asp:LinkButton ID="LinkButtonEmptyLectureInsert" runat="server"
                            OnClick="LinkButtonEmptyLectureInsert_Click" CommandName="Insert">Insert</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="LabelTitle" runat="server" Text="<%#: Item.Title %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxEditTitle" runat="server" Text="<%# BindItem.Title %>" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEditTitle"
                        ErrorMessage="The lecture title is required." Display="Dynamic" CssClass="text-error" ValidationGroup="EditLecture" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxInsertTitle" runat="server" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxInsertTitle"
                        ErrorMessage="The lecture title is required." Display="Dynamic" CssClass="text-error" ValidationGroup="InsertLecture" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Location">
                <ItemTemplate>
                    <asp:Label ID="LabelLocation" runat="server" Text="<%#: Item.Location %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxEditLocation" runat="server" Text="<%# BindItem.Location %>" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEditLocation"
                        ErrorMessage="The lecture location is required." Display="Dynamic" CssClass="text-error" ValidationGroup="EditLecture" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxInsertLocation" runat="server" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxInsertLocation"
                        ErrorMessage="The lecture location is required." Display="Dynamic" CssClass="text-error" ValidationGroup="InsertLecture" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Homework due date">
                <ItemTemplate>
                    <asp:Label ID="LabelHomeworkDueDate" runat="server" Text='<%#: Item.HomeworkDueDate.ToString("dd.MM.yyyy") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxEditHomeworkDue" runat="server" Text='<%# BindItem.HomeworkDueDate %>' TextMode="Date" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEditHomeworkDue"
                        ErrorMessage="The lecture homework due date is required." Display="Dynamic" CssClass="text-error" ValidationGroup="EditLecture" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxInsertHomeworkDue" runat="server" TextMode="Date" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxInsertHomeworkDue"
                        ErrorMessage="The lecture homework due date is required." Display="Dynamic" CssClass="text-error" ValidationGroup="InsertLecture" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Resources">
                <ItemTemplate>
                    <asp:Repeater ID="RepeaterResources" runat="server" DataSource="<%# Item.Resources %>" ItemType="Forum.Models.Resource">
                        <HeaderTemplate>
                            <ul class="rem-bullets">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:Image ImageUrl="~/img/resource.png" runat="server" />
                                <asp:HyperLink runat="server" NavigateUrl="<%# Item.Url %>" Text="<%#: Item.Description %>" />
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Repeater ID="RepeaterResourcesEdit" runat="server" DataSource="<%# Item.Resources %>" ItemType="Forum.Models.Resource">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:Image ImageUrl="~/img/resource.png" runat="server" />
                                <asp:HyperLink runat="server" NavigateUrl="<%# Item.Url %>" Text="<%#: Item.Description %>" />
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:LinkButton ID="LinkButtonAddResource" runat="server" OnClick="LinkButtonAddResource_Click" Text="Add" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton ID="ButtonEditLecture" runat="server" CommandName="Edit" Text="Edit" CausesValidation="false" />
                    <asp:LinkButton ID="ButtonDeleteLecture" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" ValidationGroup="EditLecture" CausesValidation="true" />
                    <asp:LinkButton ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="ButtonInsertLecture" runat="server" Text="Insert"
                        OnClick="ButtonInsertLecture_Click" ValidationGroup="InsertLecture" CausesValidation="true" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
