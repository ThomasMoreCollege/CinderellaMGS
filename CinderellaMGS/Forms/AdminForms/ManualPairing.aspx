<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManualPairing.aspx.cs" Inherits="Forms_AdminForms_ManualPairing" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Manual Pairing</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server" >
        <table id="ManualPairTable" border="1" style="width:100%;">
            <tr>
                <th>Cinderellas</th>
                <th>Godmothers</th>
            </tr>
            <tr>
                <td>
                    <div style ="height:600px; overflow:auto;">
                        <asp:GridView ID="CinderellaGridView" runat="server" 
                            AllowSorting="True" 
                            AutoGenerateColumns="False" 
                            DataSourceID="CinderellaDataSource">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                            </Columns>
                            <SelectedRowStyle BackColor="Fuchsia" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="CinderellaDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                            SelectCommand="SELECT [LastName], 
                                                    [FirstName] 
                                            FROM [Cinderella] 
                                            INNER JOIN CinderellaStatusRecord 
                                                ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID 
                                            WHERE Status_Name = 'Waiting' AND IsCurrent = 'Y'
                                            ORDER BY [LastName]"></asp:SqlDataSource>
                    </div>
                </td>
                <td>
                    <div style ="height:600px; overflow:auto;">
                        <asp:GridView ID="GodmotherGridView" runat="server" 
                            AllowSorting="True" 
                            AutoGenerateColumns="False" 
                            DataSourceID="GodmotherDataSource">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                            </Columns>
                            <SelectedRowStyle BackColor="Fuchsia" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="GodmotherDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                            SelectCommand="SELECT [VolunteerID],
                                                    [LastName], 
                                                    [FirstName], 
                                                    [Email] 
                                            FROM [Volunteer] 
                                            INNER JOIN VolunteerRoleRecord 
                                                ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID 
                                            WHERE Role_Name = 'Godmother' AND IsCurrent = 'Y'
                                            ORDER BY [LastName]"></asp:SqlDataSource>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2"><asp:Button ID="MatchButton" runat="server" Text="Match!" OnClick="MatchButton_Click" /></td>
            </tr>
        </table>
    </form>
</asp:Content>



<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #form1 {
            height: 445px;
        }
    </style>
</asp:Content>




