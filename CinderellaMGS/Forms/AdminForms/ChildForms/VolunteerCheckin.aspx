﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VolunteerCheckin.aspx.cs" Inherits="Forms_UserForms_VolunteerCheckin" %>

<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>Volunteer Check-In</h2>
</asp:Content>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
    
    <table>
        <tr>
            <td>
                <asp:Label ID="ResultLabel" runat="server" Text="Label" ForeColor="Green" Visible="False" Font-Bold="True"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
         <p>
            <asp:Button ID="CheckInButton" runat="server" OnClick="CheckinButton_Click" Text="Check-In" Width="70px" />
        </p>
    <div style ="height:600px; width:80%; overflow:auto; border-bottom:1px solid #999999;"">
            <asp:GridView ID="VolunteerGridView" runat="server" 
                AllowSorting="True" 
                AutoGenerateColumns="False" 
                DataSourceID="Cinderella2015"
                DataKeyNames ="VolunteerID" ForeColor="Black" EmptyDataText="There are no volunteers registered for today.">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="VolunteerID" HeaderText="Volunteer ID" SortExpression="VolunteerID" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="Role_Name" HeaderText="Role" SortExpression="Role_Name" />
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
                <SelectedRowStyle BackColor="Fuchsia" />
            </asp:GridView>
            <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                SelectCommand="SELECT Volunteer.VolunteerID, Volunteer.LastName, Volunteer.FirstName, VolunteerShiftRecord.Role_Name
                                FROM Volunteer 
                                INNER JOIN VolunteerStatusRecord 
                                    ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID 
                                INNER JOIN VolunteerShiftRecord 
                                    ON Volunteer.VolunteerID = VolunteerShiftRecord.Volunteer_ID 
                                WHERE (VolunteerStatusRecord.Status_Name = 'Pending') 
                                        AND (VolunteerStatusRecord.IsCurrent = 'Y') 
                                        AND (VolunteerShiftRecord.Shift_Name = datename(dw,getdate())) 
                                        AND (Volunteer.IsValid = 'Y') ORDER BY Volunteer.LastName"></asp:SqlDataSource>
        </div>

</asp:Content>

