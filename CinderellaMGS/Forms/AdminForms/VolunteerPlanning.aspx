<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VolunteerPlanning.aspx.cs" Inherits="Forms_AdminForms_VolunteerPlanning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    Please select a working day:
    <asp:DropDownList ID="selectDayDropDownListBox" runat="server" OnSelectedIndexChanged="selectDayDropDownListBox_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
        <asp:ListItem Text="Select Day"/>
        <asp:ListItem Text="Friday"/>
        <asp:ListItem Text="Saturday"/>
    </asp:DropDownList>
    <br />
    <br />
    <br />
    <asp:Label ID="alterationsLabel" runat="server" Font-Bold="True" Font-Italic="True" Text="Alterations" Visible="False"></asp:Label>
    <br />
    <br />
    <br />
    <asp:GridView ID="alterationsGridView" runat="server" AutoGenerateColumns="False" DataSourceID="SaturdayAlterationsDS" Visible="False" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                        <AlternatingRowStyle BackColor="pink" />
    </asp:GridView>
    <asp:SqlDataSource ID="SaturdayAlterationsDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Saturday = 'Alterations'"></asp:SqlDataSource>
    <asp:SqlDataSource ID="FridayAlterationDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Friday = 'Alterations'"></asp:SqlDataSource>
    <br />
    <asp:Label ID="dressOrganizersLabel" runat="server" Font-Bold="True" Font-Italic="True" Text="Dress Organizers" Visible="False"></asp:Label>
    <br />
    <br />
    <br />
    <asp:GridView ID="dressOrganizersGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SaturdayDressOrganizerDS" Visible="False">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                        <AlternatingRowStyle BackColor="pink" />
    </asp:GridView>
    <asp:SqlDataSource ID="SaturdayDressOrganizerDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Saturday = 'Dress Organizer'"></asp:SqlDataSource>
    <asp:SqlDataSource ID="FridayDressOrganizersDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Friday = 'Dress Organizer'"></asp:SqlDataSource>
    <br />
    <asp:Label ID="personalShoppersLabel" runat="server" Font-Bold="True" Font-Italic="True" Text="Personal Shoppers" Visible="False"></asp:Label>
    <br />
    <br />
    <br />
    <asp:GridView ID="personalShoppersGridView" runat="server" AutoGenerateColumns="False" DataSourceID="SaturdayPersonalShoppersDS" AllowSorting="True" Visible="False">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                        <AlternatingRowStyle BackColor="pink" />
    </asp:GridView>
    <asp:SqlDataSource ID="SaturdayPersonalShoppersDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Saturday = 'Personal Shopper'"></asp:SqlDataSource>
    <asp:SqlDataSource ID="FridayPersonalShoppersDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Friday = 'Personal Shopper'"></asp:SqlDataSource>
    <br />
    <asp:Label ID="noRoleReportedLabel" runat="server" Font-Bold="True" Font-Italic="True" Text="No Role Reported" Visible="False"></asp:Label>
    <br />
    <br />

&nbsp;<asp:GridView ID="noRoleReportedGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SaturdayNoRoleDS" Visible="False" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
        </Columns>
    <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                        <AlternatingRowStyle BackColor="pink" />
    </asp:GridView>
    <asp:SqlDataSource ID="SaturdayNoRoleDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Saturday IS NULL"></asp:SqlDataSource>
    <asp:SqlDataSource ID="FridayNoRoleDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Friday IS NULL"></asp:SqlDataSource>
    <br />
    <asp:Label ID="notVolunteeringLabel" runat="server" Font-Bold="True" Font-Italic="True" Text="Not Volunteering" Visible="False"></asp:Label>
    <br />
    <br />
    <br />
    <asp:GridView ID="notVolunteeringGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SaturdayNotVolunteeringDS" Visible="False">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                        <AlternatingRowStyle BackColor="pink" />
    </asp:GridView>
    <asp:SqlDataSource ID="SaturdayNotVolunteeringDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Saturday = 'Not Volunteering'"></asp:SqlDataSource>
    <asp:SqlDataSource ID="FridayNotVolunteeringDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT FirstName, LastName
FROM Volunteer
WHERE Friday = 'Not Volunteering'"></asp:SqlDataSource>
    <br />
</asp:Content>

