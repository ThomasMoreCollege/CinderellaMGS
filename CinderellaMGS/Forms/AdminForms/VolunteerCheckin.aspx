<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VolunteerCheckin.aspx.cs" Inherits="Forms_UserForms_VolunteerCheckin" %>

<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>Volunteer Check-In</h2>
</asp:Content>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">

    <form id="form1" runat="server">
        <div style ="height:600px; width:650px; overflow:auto;">
            <asp:GridView ID="VolunteerGridView" runat="server" 
                AllowSorting="True" 
                AutoGenerateColumns="False" 
                DataSourceID="Cinderella2015"
                DataKeyNames ="VolunteerID">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                </Columns>
                <SelectedRowStyle BackColor="Fuchsia" />
            </asp:GridView>
            <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                SelectCommand="SELECT [VolunteerID],
                                        [LastName], 
                                        [FirstName], 
                                        [Email] 
                                FROM [Volunteer] 
                                INNER JOIN VolunteerStatusRecord 
                                    ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID 
                                INNER JOIN VolunteerShiftRecord 
                                    ON Volunteer.VolunteerID = VolunteerShiftRecord.Volunteer_ID
                                WHERE Status_Name = 'Pending' AND IsCurrent = 'Y' AND Shift_Name = 'Friday'
                                ORDER BY [LastName]"></asp:SqlDataSource>
        </div>
        <p>
            <asp:Button ID="CheckInButton" runat="server" OnClick="CheckinButton_Click" Text="Check-In" Width="70px" />
        </p>
    </form>

</asp:Content>

