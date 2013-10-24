﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Forum.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>       
    <//hgroup>
    <p class="text-error">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset class="form-horizontal">
        <legend>Create a new account.</legend>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="control-label">User name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="UserName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-error" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-error" ErrorMessage="The password field is required." />
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>

         <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxFirstName" CssClass="control-label">First name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="TextBoxFirstName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxFirstName"
                    CssClass="text-error" ErrorMessage="The first name field is required." />
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxLastName" CssClass="control-label">Last name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="TextBoxLastName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxLastName"
                    CssClass="text-error" ErrorMessage="The last name field is required." />
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxEmail" CssClass="control-label" >Email</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" TextMode="Email" ID="TextBoxEmail" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail"
                    CssClass="text-error" ErrorMessage="The email field is required." />
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="FileUploadAvatar" CssClass="control-label">Avatar (max 100 KB, allowed formats: jpg, gif, png)</asp:Label>
            <div class="controls">
                <asp:FileUpload ID="FileUploadAvatar" runat="server" />
            </div>
        </div>

        <div class="form-actions no-color">
            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn" />
        </div>
    </fieldset>

</asp:Content>
