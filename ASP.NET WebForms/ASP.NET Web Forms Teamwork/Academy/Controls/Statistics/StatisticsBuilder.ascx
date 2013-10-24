<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatisticsBuilder.ascx.cs" Inherits="Forum.Controls.Statistics.WebUserControl1" %><%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Repeater ID="TotalUsers" runat="server" DataSourceID="TotalUsersDataSource">
    <HeaderTemplate>
        <div>
    </HeaderTemplate>
    <ItemTemplate>
        <p class="lead">Total users: <%# Eval("Total users") %></p>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="TotalLecturers" runat="server" DataSourceID="TotalLecturersDataSource1">
    <HeaderTemplate>
        <div>
    </HeaderTemplate>
    <ItemTemplate>
        <p class="lead"> Total lecturers: <%# Eval("Total lecturers")%></p>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="TotalCourses" runat="server" DataSourceID="TotalCoursesDataSource">
    <HeaderTemplate>
        <div>
    </HeaderTemplate>
    <ItemTemplate>
        <p class="lead"> Total courses: <%# Eval("Total courses") %></p>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="TotalLectures" runat="server" DataSourceID="TotalLecturesDataSource">
    <HeaderTemplate>
        <div>
    </HeaderTemplate>
    <ItemTemplate>
        <p class="lead"> Total lectures: <%# Eval("Total lectures") %></p>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
<asp:Chart ID="LastJoinedUsers" runat="server" DataSourceID="UsersJoinDateDataSource">
    <Series>
        <asp:Series Name="Dates" XValueMember="Date" YValueMembers="Registrations">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
    <Titles>
        <asp:Title Name="User Joins By Date" Text="Last joins by users">
        </asp:Title>
    </Titles>
</asp:Chart>

<asp:SqlDataSource ID="UsersJoinDateDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:AcademyConnectionString %>" 
    SelectCommand="SELECT TOP(10) CONVERT(NVARCHAR(10), JoinDate, 102) [Date], count(JoinDate) [Registrations]
            FROM AspNetUsers
            GROUP BY CONVERT(NVARCHAR(10), JoinDate, 102)"></asp:SqlDataSource>
<br />

<asp:SqlDataSource ID="TotalLecturesDataSource" runat="server" 
    ConnectionString="<%$ ConnectionStrings:AcademyConnectionString %>" 
    SelectCommand="SELECT  count(Title) [Total lectures]
                    FROM Lectures">
</asp:SqlDataSource>

<asp:SqlDataSource ID="TotalCoursesDataSource" runat="server" 
    ConnectionString="<%$ ConnectionStrings:AcademyConnectionString %>" 
    SelectCommand="SELECT  count(Title) [Total courses]
                    FROM Courses">
</asp:SqlDataSource>

<asp:SqlDataSource ID="TotalUsersDataSource" runat="server" 
    ConnectionString="<%$ ConnectionStrings:AcademyConnectionString %>" 
    SelectCommand="SELECT  count(UserName) [Total users]
                    FROM AspNetUsers">
</asp:SqlDataSource>

<asp:SqlDataSource ID="TotalLecturersDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:AcademyConnectionString %>" 
    SelectCommand="SELECT COUNT(RoleId) AS [Total lecturers] 
                    FROM AspNetUserRoles
                    WHERE (RoleId = 1)">
</asp:SqlDataSource>

<%--SELECT CONVERT(NVARCHAR(8), JoinDate, 112) [Date], count(JoinDate) [Registrations]
            FROM AspNetUsers
            GROUP BY CONVERT(NVARCHAR(8), JoinDate, 112)
            ORDER BY [Registrations]--%>


