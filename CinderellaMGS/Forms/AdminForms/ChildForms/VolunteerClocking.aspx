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
                            DataKeyNames="VolunteerID" ForeColor="Black">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="VolunteerID" HeaderText="Volunteer ID" SortExpression="VolunteerID" InsertVisible="False" ReadOnly="True" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                            SelectCommand="SELECT Volunteer.VolunteerID, Volunteer.LastName, Volunteer.FirstName 
                                            FROM Volunteer 
                                            INNER JOIN VolunteerStatusRecord 
                                                ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID 
                                            WHERE (VolunteerStatusRecord.Status_Name = 'On Break') AND (VolunteerStatusRecord.IsCurrent = 'Y') AND (Volunteer.IsValid = 'Y') ORDER BY Volunteer.LastName">
                        </asp:SqlDataSource>
                    </div>
                </td>
                <td>
                    <div style ="height:300px; overflow:auto;">
                        <asp:GridView ID="VolunteerOffBreakGridView" runat="server" 
                            AllowSorting="True" 
                            AutoGenerateColumns="False" 
                            DataSourceID="SqlDataSource2"
                            DataKeyNames="VolunteerID" ForeColor="Black">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="VolunteerID" HeaderText="Volunteer ID" SortExpression="VolunteerID" InsertVisible="False" ReadOnly="True" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
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
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" 
                            SelectCommand="SELECT Volunteer.VolunteerID, Volunteer.LastName, Volunteer.FirstName 
                                            FROM Volunteer 
                                            INNER JOIN VolunteerStatusRecord 
                                                ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID 
                                            WHERE (VolunteerStatusRecord.Status_Name != 'On Break') AND (VolunteerStatusRecord.IsCurrent = 'Y') AND (Volunteer.IsValid = 'Y') AND (VolunteerStatusRecord.Status_Name != 'Pending') ORDER BY Volunteer.LastName">
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