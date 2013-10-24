<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RegistrationForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label runat="server" AssociatedControlID="TextBoxUserName" Text="Username"></asp:Label>
    <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" ControlToValidate="TextBoxUserName" runat="server" Display="None" ErrorMessage="Username is required"/>
    <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidatorUserName" ControlToValidate="TextBoxUserName" ValidationExpression="^[a-zA-Z0-9]+([a-zA-Z0-9](_|-| )[a-zA-Z0-9])*[a-zA-Z0-9]+$" runat="server" ErrorMessage="Invalid username"></asp:RegularExpressionValidator>
    
    <asp:Label Text="Password" runat="server" AssociatedControlID="TextBoxPassword" />
    <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator  Display="None" ID="RequiredFieldValidatorPassword" ControlToValidate="TextBoxPassword" runat="server" ErrorMessage="Password is required" ForeColor="Red"/>

    <asp:Label Text="Confirm password" runat="server" AssociatedControlID="TextBoxConfirmPassword" />
    <asp:TextBox ID="TextBoxConfirmPassword" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidatorConfirmPassword" ControlToValidate="TextBoxConfirmPassword" runat="server" ErrorMessage="Password confirmation is required" ForeColor="Red"/>
    <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Passwords don't match" ControlToCompare="TextBoxPassword"
        ControlToValidate="TextBoxConfirmPassword" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>

    <asp:Label Text="First name" runat="server" AssociatedControlID="TextBoxFirstName" />
    <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidatorFirstName" ControlToValidate="TextBoxFirstName" runat="server" ErrorMessage="First name is required"/>
    <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidatorFirstName" ControlToValidate="TextBoxFirstName" ValidationExpression="[a-zA-Z]*" runat="server" ErrorMessage="Invalid first name"></asp:RegularExpressionValidator>

    <asp:Label Text="Last name" runat="server" AssociatedControlID="TextBoxLastName" />
    <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidatorLastName" ControlToValidate="TextBoxLastName" runat="server" ErrorMessage="Last name is required"/>
    <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidatorLastName" ControlToValidate="TextBoxLastName" ValidationExpression="[a-z ,.'-]*" runat="server" ErrorMessage="Invalid last name" />
    
    <asp:Label Text="Age" runat="server" AssociatedControlID="TextBoxAge" />
    <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidatorAge" ControlToValidate="TextBoxLastName" runat="server" ErrorMessage="Last name is required"/>
    <asp:RangeValidator Display="None" ID="RangeValidatorAge" ControlToValidate="TextBoxAge" MinimumValue="18" MaximumValue="81" runat="server" ErrorMessage="Age should be between 18 and 81" />

    <asp:Label Text="Email" runat="server" AssociatedControlID="TextBoxEmail" />
    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidatorEmail" ControlToValidate="TextBoxEmail" runat="server" ErrorMessage="Email is required"/>
    <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="TextBoxEmail" ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" ErrorMessage="Invalid email"></asp:RegularExpressionValidator>

    <asp:Label Text="Address" runat="server" AssociatedControlID="TextBoxLocalAddress" />
    <asp:TextBox ID="TextBoxLocalAddress" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidatorAddress" ControlToValidate="TextBoxLocalAddress" runat="server" ErrorMessage="Address is required"/>

    <asp:Label Text="Phone" runat="server" AssociatedControlID="TextBoxPhone" />
    <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidatorPhone" ControlToValidate="TextBoxPhone" runat="server" ErrorMessage="Phone is required"/>
    <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidatorPhone" ValidationExpression="^[0-9]{10}" ControlToValidate="TextBoxPhone" runat="server" ErrorMessage="Invalid phone number"></asp:RegularExpressionValidator>

    <asp:Label Text="I Accept" runat="server" AssociatedControlID="CheckBoxAccept" />
    <asp:CheckBox ID="CheckBoxAccept" runat="server" />
    <asp:CustomValidator Display="None" ID="CustomValidatorAccept" runat="server" EnableClientScript="false" OnServerValidate="CustomValidatorAccept_ServerValidate" ErrorMessage="Acceptance is required">Acceptance is required</asp:CustomValidator>
    <br />
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" />
    <asp:ValidationSummary ID="ValidationSummary" DisplayMode="List" ForeColor="Red" ValidateRequestMode="Enabled" runat="server" />
</asp:Content>
