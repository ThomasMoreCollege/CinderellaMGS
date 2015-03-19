<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageShopping.aspx.cs" Inherits="Forms_UserForms_ManageShopping" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Manage Shopping</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
        <table style="width:100%;">
            <tr>
                <td><strong>Paired Cinderellas/Volunteers</strong></td>
                <td>

                </td>
                <td><strong>Currently Shopping</strong></td>
            </tr>
            <tr>
                <td rowspan="2" class="auto-style2">
                    <div style="height: 300px;" >
                        <asp:GridView ID="PairedCinderellaGridView" runat="server" 
                            AllowSorting="True" 
                            AutoGenerateColumns="False" 
                            DataSourceID="CinderellaPairedDataSource" 
                            DataKeyNames="CinderellaID" Width="100%" Height="100px" OnSelectedIndexChanged="PairedCinderellaGridView_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Cinderella" HeaderText="Cinderella" ReadOnly="True" SortExpression="Cinderella" />
                            <asp:BoundField DataField="Column1" ReadOnly="True" SortExpression="Column1">
                            <ItemStyle Font-Bold="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Volunteer" HeaderText="Volunteer" ReadOnly="True" SortExpression="Volunteer" />
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
                    <asp:SqlDataSource ID="CinderellaPairedDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                        SelectCommand="SELECT CinderellaID, Cinderella.FirstName + ' ' + Cinderella.LastName AS Cinderella, 'Is Paired With', Volunteer.FirstName + ' ' + Volunteer.LastName AS Volunteer
                                        FROM Cinderella 
                                         INNER JOIN Volunteer 
	                                        ON Cinderella.Volunteer_ID = Volunteer.VolunteerID 
                                         INNER JOIN CinderellaStatusRecord 
	                                        ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID 
                                        WHERE (Cinderella.Volunteer_ID IS NOT NULL) 
                                            AND (CinderellaStatusRecord.Status_Name = 'Paired') 
                                            AND (CinderellaStatusRecord.IsCurrent = 'Y')
                                        ORDER BY CinderellaStatusRecord.StartTime DESC">
                    </asp:SqlDataSource>
                    </div>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="GoShoppingButton" runat="server" Text="Go Shopping" OnClick="GoShoppingButton_Click" />
                </td>
                <td rowspan="2" class="auto-style2">
                    <div style="height: 300px;">
                        <asp:GridView ID="ShoppingGridView" runat="server" 
                            AllowSorting="True" 
                            AutoGenerateColumns="False" 
                            DataSourceID="CinderellaShoppingDataSource" 
                            DataKeyNames="CinderellaID" Width="100%" Height="100px" OnSelectedIndexChanged="ShoppingGridView_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="Cinderella" HeaderText="Cinderella" ReadOnly="True" SortExpression="Cinderella" />
                                <asp:BoundField DataField="Column1" ReadOnly="True" SortExpression="Column1">
                                <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Volunteer" HeaderText="Volunteer" ReadOnly="True" SortExpression="Volunteer" />
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
                        <asp:SqlDataSource ID="CinderellaShoppingDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                            SelectCommand="SELECT CinderellaID, Cinderella.FirstName + ' ' + Cinderella.LastName AS Cinderella, 'Is Shopping With', Volunteer.FirstName + ' ' + Volunteer.LastName AS Volunteer
                                            FROM Cinderella 
                                             INNER JOIN Volunteer 
	                                            ON Cinderella.Volunteer_ID = Volunteer.VolunteerID 
                                             INNER JOIN CinderellaStatusRecord 
	                                            ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID 
                                            WHERE (Cinderella.Volunteer_ID IS NOT NULL) 
                                                AND (CinderellaStatusRecord.Status_Name = 'Shopping') 
                                                AND (CinderellaStatusRecord.IsCurrent = 'Y')
                                            ORDER BY CinderellaStatusRecord.StartTime DESC">
                        </asp:SqlDataSource>
                    </div>
                </td>
            </tr>
            <tr>

                <td class="auto-style1">
                    <asp:Button ID="UndoShoppingButton" runat="server" Text="Undo Shoppping" OnClick="UndoShoppingButton_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td><strong>Needs Manual Pairing</strong></td>
                <td></td>
                <td><strong>Volunteers to be Paired</strong></td>
            </tr>
            <tr>
                <td rowspan="2" class="auto-style2">
                    <asp:GridView ID="ManualCinderellaGridView" runat="server" 
                        AllowSorting="True" 
                        AutoGenerateColumns="False" 
                        DataSourceID="Cinderella2015" 
                        DataKeyNames="CinderellaID" ForeColor="Black">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
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
                    </asp:GridView>
                    <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                        SelectCommand="SELECT [CinderellaID], 
                                                [LastName], 
                                                [FirstName]
                                        FROM [Cinderella] 
                                        INNER JOIN CinderellaStatusRecord 
                                            ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID 
                                        WHERE Status_Name = 'Waiting for Godmother' 
                                            AND IsCurrent = 'Y'
                                            AND IsManuallyPaired = 'Y'
                                        ORDER BY [StartTime]">
                    </asp:SqlDataSource>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="GoShoppingButton2" runat="server" Text="Go Shopping" />
                </td>
                <td rowspan="2">
                    <asp:GridView ID="VolunteerPairingGridView" runat="server" 
                        AllowSorting="True" 
                        AutoGenerateColumns="False" 
                        DataSourceID="VolunteerPairDataSource" 
                        DataKeyNames="VolunteerID" ForeColor="Black">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
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
                    </asp:GridView>
                    <asp:SqlDataSource ID="VolunteerPairDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                        SelectCommand="SELECT [VolunteerID], 
                                                [LastName], 
                                                [FirstName]
                                        FROM [Volunteer] 
                                        INNER JOIN VolunteerStatusRecord 
                                            ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID 
                                        INNER JOIN VolunteerRoleRecord
                                            ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID
                                        WHERE (Status_Name = 'Paired' OR Status_Name = 'Ready')
                                            AND VolunteerStatusRecord.IsCurrent = 'Y'
                                            AND Role_Name = 'Godmother'
                                            AND VolunteerRoleRecord.IsCurrent = 'Y'
                                            AND IsValid = 'Y'
                                        ORDER BY VolunteerStatusRecord.StartTime">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="UndoButton2" runat="server" Text="Undo" />
                </td>
            </tr>
        </table>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1
        {
            text-align: center;
        }
        .auto-style2
        {
            width: 166px;
        }
    </style>
</asp:Content>


