<%@ Page Title="Users" Language="C#" MasterPageFile="~/Lecturer/Lecturer.master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Forum.Users" %>

<asp:Content ID="ContentUsers" ContentPlaceHolderID="ContentPlaceHolderLecturer" runat="server">
    <h2>Manage users</h2>

    <asp:GridView
        ID="GridViewUsers"
        runat="server"
        ItemType="Forum.Models.ApplicationUser"
        AutoGenerateColumns="false"
        DataKeyNames="Id"
        SelectMethod="GridViewUsers_GetData"
        UpdateMethod="GridViewUsers_UpdateItem"
        DeleteMethod="GridViewUsers_DeleteItem"
        AllowPaging="true"
        AllowSorting="true"
        CssClass="table table-bordered table-hover"
        PageSize="5" Width="870px">
        <Columns>
            <asp:BoundField HeaderText="Username" DataField="Username" SortExpression="Username" ControlStyle-Width="100px" />
            <asp:BoundField HeaderText="First name" DataField="FirstName" SortExpression="FirstName" ControlStyle-Width="100px" />
            <asp:BoundField HeaderText="Last name" DataField="LastName" SortExpression="LastName" ControlStyle-Width="100px" />
            <asp:BoundField HeaderText="Email" DataField="Email" SortExpression="Email" ControlStyle-Width="160px" />
            <asp:TemplateField HeaderText="Lecturer">
                <ItemTemplate>
                    <asp:Label ID="LabelIsLecturer" runat="server"
                        Text='<%#: Item.Roles.FirstOrDefault() != null ? "Yes" : "No" %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBoxIsLecturer" runat="server"
                        Checked="<%# Convert.ToBoolean(Item.Roles.FirstOrDefault() != null) %>" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Banned">
                <ItemTemplate>
                    <asp:Label ID="LabelDisableLogIn" runat="server" Text='<%#: Item.Management.DisableSignIn ? "Yes" : "No" %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckboxDisableLogin" runat="server" Checked="<%# BindItem.Management.DisableSignIn %>" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
