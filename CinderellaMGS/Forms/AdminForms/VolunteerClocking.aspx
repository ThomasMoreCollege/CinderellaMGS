<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VolunteerClocking.aspx.cs" Inherits="Forms_AdminForms_GodmotherClocking" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Volunteer Clockin/Clockout</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        <table id="ClockingTable">
            <tr>
                <th>Volunteers on Break</th>
                <th>Working Volunteers</th>
            </tr>
            <tr>
                <td>
                    <div style ="height:300px; overflow:auto;">
                        <asp:GridView ID="VolunteerOnBreakGridView" runat="server" 
                            AllowSorting="True" 
                            AutoGenerateColumns="False" 
                            DataSourceID="SqlDataSource1"
                            DataKeyNames="VolunteerID">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                            </Columns>
                            <SelectedRowStyle BackColor="Fuchsia" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                            SelectCommand="SELECT [VolunteerID],
                                                    [LastName], 
                                                    [FirstName] 
                                            FROM [Volunteer] 
                                            INNER JOIN VolunteerStatusRecord 
                                                ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID 
                                            WHERE Status_Name = 'On Break' AND IsCurrent = 'Y'
                                            ORDER BY [LastName]">
                        </asp:SqlDataSource>
                    </div>
                </td>
                <td>
                    <div style ="height:300px; overflow:auto;">
                        <asp:GridView ID="VolunteerOffBreakGridView" runat="server" 
                            AllowSorting="True" 
                            AutoGenerateColumns="False" 
                            DataSourceID="SqlDataSource2"
                            DataKeyNames="VolunteerID">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                            </Columns>
                            <SelectedRowStyle BackColor="Fuchsia" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" 
                            SelectCommand="SELECT [VolunteerID], 
                                                    [LastName], 
                                                    [FirstName] 
                                            FROM [Volunteer]
                                            INNER JOIN VolunteerStatusRecord
                                            ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID
                                            WHERE Status_Name != 'On Break' AND IsCurrent = 'Y'
                                            ORDER BY [LastName]">
                        </asp:SqlDataSource>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align:center">
                    <asp:Button ID="TakeOffBreakButton" runat="server" Text="Take off Break" OnClick="TakeOffBreakButton_Click" />
                        
                </td>
                <td style="text-align:center">
                    <asp:Button ID="SendOnBreakButton" runat="server" Text="Send on Break" OnClick="SendOnBreakButton_Click" />
                </td>
            </tr>
        </table>   
</asp:Content>