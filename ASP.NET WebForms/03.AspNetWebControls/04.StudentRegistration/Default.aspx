<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_04.StudentRegistration._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-unit">
        <h1>Student Register</h1>
    </div>

    <asp:Label ID="LabelFirstName" runat="server" AssociatedControlID="TextBoxFirstName" Text="First name:"></asp:Label>
    <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>

    <asp:Label ID="LabelLastName" runat="server" AssociatedControlID="TextBoxLastName" Text="Last name:"></asp:Label>
    <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>

    <asp:Label ID="LabelFacultyNumber" runat="server" AssociatedControlID="TextBoxFacultyNumber" Text="Faculty number:"></asp:Label>
    <asp:TextBox ID="TextBoxFacultyNumber" runat="server"></asp:TextBox>

    <asp:Label ID="LabelUniversity" runat="server" AssociatedControlID="DropDownListUniversity" Text="University:"></asp:Label>
    <asp:DropDownList ID="DropDownListUniversity" runat="server">
        <asp:ListItem Value="1">Sofia University</asp:ListItem>
        <asp:ListItem Text="Technical University" Value="2" />
        <asp:ListItem Text="UNWE" Value="3" />
    </asp:DropDownList>

    <asp:Label ID="LabelSpecialty" runat="server" AssociatedControlID="DropDownListSpecialty" Text="Specialty:"></asp:Label>
    <asp:DropDownList ID="DropDownListSpecialty" runat="server">
        <asp:ListItem Value="1">Software Engineering</asp:ListItem>
        <asp:ListItem Text="Computer Science" Value="2" />
        <asp:ListItem Text="Informatics" Value="3" />
    </asp:DropDownList>

    <asp:Label ID="LabelCourses" runat="server" AssociatedControlID="ListBoxCourses" Text="Courses:"></asp:Label>
    <asp:ListBox ID="ListBoxCourses" SelectionMode="Multiple" runat="server">
        <asp:ListItem Value="1">Asp.NET</asp:ListItem>
        <asp:ListItem Text="Web Services" Value="2" />
        <asp:ListItem Text="Asp.NET MVC" Value="3" />
    </asp:ListBox>
    <br />
    <asp:Button ID="ButtonSubmit" CssClass="btn btn-info" OnClick="ButtonSubmit_Click" runat="server" Text="Submit" />

    <asp:Label ID="LabelContainer" AssociatedControlID="PanelInfoContainer" runat="server" Text="Result:"></asp:Label>
    <asp:Panel ID="PanelInfoContainer" runat="server"></asp:Panel>
</asp:Content>
