<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_06.WebCalculator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-unit">
        <h1>Calculator</h1>
        <asp:Panel  ID="Panel1" runat="server" Height="291px" Width="276px">
            <asp:TextBox AutoPostBack="false" ID="TextBoxScreen" runat="server"></asp:TextBox>
            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" 
 ControlToValidate="TextBoxScreen" ErrorMessage="Value must be a whole number" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="1" Width="50px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="2" Width="50px" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="3" Width="50px" OnClick="Button3_Click" />
            <asp:Button ID="ButtonAdd" runat="server" Text="+" Width="50px" OnClick="ButtonAdd_Click" />     
            <asp:Button ID="Button4" runat="server" Text="4" Width="50px" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" Text="5" Width="50px" OnClick="Button5_Click" />
            <asp:Button ID="Button6" runat="server" Text="6" Width="50px" OnClick="Button6_Click" />
            <asp:Button ID="ButtonSubstract" runat="server" Text="-" Width="50px" OnClick="ButtonSubstract_Click" />
            <asp:Button ID="Button7" runat="server" Text="7" Width="50px" OnClick="Button7_Click"/>
            <asp:Button ID="Button8" runat="server" Text="8" Width="50px" OnClick="Button8_Click" />
            <asp:Button ID="Button9" runat="server" Text="9" Width="50px" OnClick="Button9_Click" />
            <asp:Button ID="ButtonMultiply" runat="server" Text="x" Width="50px" OnClick="ButtonMultiply_Click" />
            <asp:Button ID="ButtonClear" runat="server" Text="Clear" Width="50px" OnClick="ButtonClear_Click" />
            <asp:Button ID="Button0" runat="server" Text="0" Width="50px" OnClick="Button0_Click" />
            <asp:Button ID="ButtonDivide" runat="server" Text="/" Width="50px" OnClick="ButtonDivide_Click" />
            <asp:Button ID="ButtonSquareRoot" runat="server" Text="√" Width="50px" OnClick="ButtonSquareRoot_Click" />
            <asp:Button ID="ButtonEquals" runat="server" Text="=" Width="216px" OnClick="ButtonEquals_Click" />
            <asp:Label ID="LabelFirstNumber" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="LabelOperation" runat="server" Text="" Visible="false"></asp:Label>

        </asp:Panel>
    </div>

</asp:Content>

