<%@ Page Title="Courses" Language="C#" MasterPageFile="~/Lecturer/Lecturer.master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="Forum.Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLecturer" runat="server">


    <asp:GridView ID="GridViewCourses" runat="server"
        SelectMethod="GridViewCourses_GetData"
        DeleteMethod="GridViewCourses_DeleteItem"
        OnRowUpdating="GridViewCourses_RowUpdating"
        OnRowEditing="GridViewCourses_RowEditing"
        OnRowDeleting="GridViewCourses_RowDeleting"
        ItemType="Forum.Models.Course"
        AutoGenerateColumns="false"
        AllowSorting="true"
        ShowFooter="true"
        AllowPaging="true"
        DataKeyNames="Id"
        PageSize="5"
        OnRowDataBound="GridViewCourses_RowDataBound"
        OnSelectedIndexChanged="GridViewCourses_SelectedIndexChanged"
        CssClass="table table-bordered table-hover">
        <EmptyDataTemplate>
            <table border="1">
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Lecturer</th>
                    <th>Free places</th>
                    <th>Start date</th>
                    <th>End date</th>
                    <th>Actions</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBoxEmptyCourseNameInsert" runat="server" Text=""></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmptyCourseNameInsert" Display="Dynamic"
                            CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The name field is required." />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxEmptyCourseDescriptionInsert" runat="server" Text="" TextMode="MultiLine" Rows="7"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmptyCourseDescriptionInsert" Display="Dynamic"
                            CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The description field is required." />
                    </td>
                    <td>
                        <asp:DropDownList Width="140px" ID="DropDownListEmptyLecturerInsert" runat="server" ItemType="Forum.Models.ApplicationUser"
                            SelectMethod="DropDownListLecturer_GetData" DataTextField="FullName" DataValueField="Id" />
                    </td>
                    <td>
                        <asp:TextBox Width="70px" ID="TextBoxEmptyCourseFreePlacesInsert" runat="server" Text=""></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmptyCourseFreePlacesInsert" Display="Dynamic"
                            CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The course free places field is required." />
                        <asp:RangeValidator
                            ID="RangeValidatorFreePlacesQuantity" runat="server"
                            ControlToValidate="TextBoxEmptyCourseFreePlacesInsert"
                            ValidationGroup="InsertCourse"
                            Display="Dynamic"
                            ErrorMessage="Invalid range. Number should be between 0 and 2000"
                            ForeColor="Red"
                            MaximumValue="2000"
                            MinimumValue="0"
                            Type="Integer" />
                    </td>
                    <td>
                        <asp:TextBox Width="70px" ID="TextBoxEmptyCourseStartDateInsert" runat="server" Text="" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmptyCourseStartDateInsert" Display="Dynamic"
                            CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The course start date field is required." />
                    </td>
                    <td>
                        <asp:TextBox Width="70px" ID="TextBoxEmptyCourseEndDateInsert" runat="server" Text="" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmptyCourseEndDateInsert" Display="Dynamic"
                            CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The course end date field is required." />
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButtonEmptyCourseInsert" ValidationGroup="InsertCourse" runat="server" 
                            OnClick="LinkButtonEmptyCourseInsert_Click" CommandName="Insert">Insert</asp:LinkButton>
                    </td>

                </tr>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:CommandField ShowSelectButton="true" HeaderText="Show lectures" SelectText="Show lectures" />

            <asp:TemplateField HeaderText="Course" SortExpression="Title">
                <ItemTemplate>
                    <asp:Label ID="LabelCourseTitle" runat="server" Text="<%#: Item.Title %>"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox Width="140px" ID="TextBoxCourseTitleEdit" runat="server" Text="<%# Item.Title %>"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCourseTitleEdit" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="EditCourse" ErrorMessage="The course title field is required." />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox Width="140px" ID="TextBoxCourseTitleInsert" runat="server" Text="">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCourseTitleInsert" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The course title field is required." />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Description" ControlStyle-Width="270">
                <ItemTemplate>
                    <asp:Label ID="LabelCourseDescription" runat="server" Text="<%#: Item.Description %>"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox Width="270" ID="TextBoxCourseDescriptionEdit" runat="server" Text="<%# Item.Description %>" TextMode="MultiLine" Rows="7"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCourseDescriptionEdit" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="EditCourse" ErrorMessage="The course description field is required." />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox Width="270" ID="TextBoxCourseDescriptionInsert" runat="server" Text="" TextMode="MultiLine" Rows="7"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCourseDescriptionInsert" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The course description field is required." />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Lecturer">
                <ItemTemplate>
                    <asp:Label ID="LabelLecturerName" runat="server" Text='<%#: Item.Lecturer.FullName %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList Width="140px" ID="DropDownListLecturerEdit" runat="server" ItemType="Forum.Models.ApplicationUser"
                        SelectMethod="DropDownListLecturer_GetData" DataTextField="FullName" DataValueField="Id" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList Width="140px" ID="DropDownListLecturersInsert" DataTextField="FullName" DataValueField="Id" runat="server"
                        SelectMethod="DropDownListLecturer_GetData">
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Free places">
                <ItemTemplate>
                    <asp:Label ID="LabelFreePlaces" runat="server" Text="<%#: Item.FreePlaces %>"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox Width="70px" ID="TextBoxFreePlacesEdit" runat="server" Text='<%# Item.FreePlaces %>'></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxFreePlacesEdit" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="EditCourse" ErrorMessage="The course free places field is required." />
                    <asp:RangeValidator
                        ID="RangeValidatorFreePlacesQuantityEdit" runat="server" CssClass="text-error"
                        ControlToValidate="TextBoxFreePlacesEdit"
                        ValidationGroup="EditCourse"
                        Display="Dynamic"
                        ErrorMessage="Invalid range. Number should be between 0 and 2000"
                        MaximumValue="2000"
                        MinimumValue="0"
                        Type="Integer" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox Width="70px" ID="TextBoxFreePlacesInsert" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxFreePlacesInsert" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The course free places field is required." />
                    <asp:RangeValidator
                        ID="RangeValidatorFreePlacesQuantityInsert" runat="server" CssClass="text-error"
                        ControlToValidate="TextBoxFreePlacesInsert"
                        ValidationGroup="InsertCourse"
                        Display="Dynamic"
                        ErrorMessage="Invalid range. Number should be between 0 and 2000"
                        MaximumValue="2000"
                        MinimumValue="0"
                        Type="Integer" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Start date">
                <ItemTemplate>
                    <asp:Label ID="LabelStartDate" runat="server" Text='<%#: Item.StartDate.ToString("dd.MM.yyyy") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox Width="70px" ID="TextBoxStartDateEdit" runat="server" Text='<%# Item.StartDate.ToString("dd.MM.yyyy") %>' TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxStartDateEdit" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="EditCourse" ErrorMessage="The course start date field is required." />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox Width="70px" ID="TextBoxStartDateInsert" runat="server" Text="" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxStartDateInsert" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The course start date field is required." />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="End date">
                <ItemTemplate>
                    <asp:Label ID="LabelEndDate" runat="server" Text='<%#: Item.EndDate.ToString("dd.MM.yyyy") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox Width="70px" ID="TextBoxEndDateEdit" runat="server" Text='<%# Item.EndDate.ToString("dd.MM.yyyy") %>' TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEndDateEdit" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="EditCourse" ErrorMessage="The course end date field is required." />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox Width="70px" ID="TextBoxEndDateInsert" runat="server" Text="" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEndDateInsert" Display="Dynamic"
                        CssClass="text-error" ValidationGroup="InsertCourse" ErrorMessage="The course end date field is required." />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonCourseEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonCourseDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButtonCourseUpdate" ValidationGroup="EditCourse" runat="server" CausesValidation="true" 
                        CommandName="Update" Text="Update"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonCourseUpdateCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="LinkButtonCourseInsert" runat="server" OnClick="LinkButtonCourseInsert_Click" CommandName="Insert"
                        ValidationGroup="InsertCourse">Insert</asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
