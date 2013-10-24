<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumber.aspx.cs" Inherits="_01.HtmlControlsRandomNumbers.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Random number generator</h1>
    <form id="form1" runat="server">
    <div>
        <label for="TextFirstNumber" id="LabelFirstNumber" runat="server">Minimal random number:</label>
        <input id="TextFirstNumber" type="text"  runat="server"/>
        <br />
        <label for="TextSecondNumber" id="LabelSecondNumber" runat="server">Maximal random number:</label>
        <input id="TextSecondNumber" runat="server" type="text" />
        <br />
        <input id="ButtonNumberGenerator" onserverclick="ButtonNumberGenerator_ServerClick" type="button" runat="server" value="Generate Button" />
        <br />
        <div id="ResultContainer" runat="server"></div>
        
    </div>
    </form>
</body>
</html>
