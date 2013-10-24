<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesRepeater.aspx.cs" Inherits="_05.Repeater.EmployeesRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="RepeaterEmployees" runat="server">
            <HeaderTemplate>
                <h1>Employeees</h1>
                 <table border="1">
                    <tr>
                        <th>
                            First Name:
                        </th>
                        <th>
                            Last Name:
                        </th>
                        <th>
                            Title:
                        </th>
                        <th>
                            TitleOfCourtesy:
                        </th>
                        <th>
                            BirthDate:
                        </th>
                        <th>
                            HireDate:
                        </th>
                        <th>
                            Address:
                        </th>
                        <th>
                            City:
                        </th>
                        <th>
                            Country:
                        </th>
                        <th>
                            Region:
                        </th>
                    </tr>
                
            </HeaderTemplate>

            <ItemTemplate>
                    <tr>
                        <td><%#: Eval("FirstName") %></td>
                        <td><%#: Eval("LastName") %></td>
                        <td><%#: Eval("Title") %></td>
                        <td><%#: Eval("TitleOfCourtesy") %></td>
                        <td><%#: Eval("BirthDate") %></td>
                        <td><%#: Eval("HireDate") %></td>
                        <td><%#: Eval("Address") %></td>
                        <td><%#: Eval("City") %></td>
                        <td><%#: Eval("Country") %></td>
                        <td><%#: Eval("Region") %></td>
                    </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
                2013 Northwind.
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
