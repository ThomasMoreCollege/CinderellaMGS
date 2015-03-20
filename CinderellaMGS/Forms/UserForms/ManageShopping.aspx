<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageShopping.aspx.cs" Inherits="Forms_UserForms_ManageShopping" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" runat="Server">
    <h2>Manage Shopping</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">

    <table style="width: 90%;">
        <tr>
            <td>
                <strong style="font-size: x-large; text-align: left; font-style: italic;">GO SHOPPING</strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <strong>Paired Cinderellas/Volunteers</strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="height: 300px; border-bottom: 1px solid #999999;">
                    <asp:GridView ID="PairedCinderellaGridView" runat="server"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataSourceID="CinderellaPairedDataSource"
                        DataKeyNames="CinderellaID" Width="100%" Height="100px" OnSelectedIndexChanged="PairedCinderellaGridView_SelectedIndexChanged" ForeColor="Black">
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
                                        ORDER BY CinderellaStatusRecord.StartTime DESC"></asp:SqlDataSource>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" class="auto-style5" colspan="2">

                <asp:Button ID="GoShoppingButton" runat="server" Text="Go Shopping" OnClick="GoShoppingButton_Click" Style="text-align: right" />

            </td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2">

                <asp:Button ID="UndoShoppingButton" runat="server" Text="Undo Shoppping" OnClick="UndoShoppingButton_Click" />

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <strong>Currently Shopping</strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="height: 300px; border-bottom: 1px solid #999999;">
                    <asp:GridView ID="ShoppingGridView" runat="server"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataSourceID="CinderellaShoppingDataSource"
                        DataKeyNames="CinderellaID" Width="100%" Height="100px" OnSelectedIndexChanged="ShoppingGridView_SelectedIndexChanged" ForeColor="Black">
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
                                            ORDER BY CinderellaStatusRecord.StartTime DESC"></asp:SqlDataSource>
                </div>
            </td>
        </tr>
    </table>

    <table style="width: 100%;">
        <tr>
            <td>
                <strong style="font-size: x-large; font-style: italic;">Manual Pairing</strong>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="NotificationLabel" runat="server" Text="Cinderella XXX and Volunter YYY successfully ZZZ" ForeColor="Green" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Cinderellas</strong></td>
            <td></td>
            <td><strong>Volunteers</strong></td>
        </tr>
        <tr>
            <td>
                <table style="width:100%">
                    <tr>
                        <td style="width: 5%;background-color:#ff7474">
                            
                        </td>
                        <td>
                            = Requested manual pairing/waiting for more than one hour.
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%;background-color:#ffe85f">

                        </td>
                        <td >

                            = Requested manual pairing/waiting for less than an one hour. </td>
                    </tr>
                    <tr>
                        <td style="width: 5%;background-color:#50e153">

                        </td>
                        <td>

                            = Have not requestd manual pairing</td>
                    </tr>
                </table>
            </td>
            <td>

            </td>
            <td>
                <table style="width:100%">
                    <tr>
                        <td style="width: 5%;background-color:#ffe85f">

                        </td>
                        <td >

                            = Currently paired, but not yet shopping. </td>
                    </tr>
                    <tr>
                        <td style="width: 5%;background-color:#50e153">

                        </td>
                        <td>

                            = Are available.</td>
                    </tr>
                    <tr>
                        <td style="width: 5%;background-color:#fff">

                        </td>
                        <td style="color:white;">a</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td rowspan="2" class="auto-style2">
                <div style="overflow: auto; height: 300px;">
                    <asp:GridView ID="ManualCinderellaGridView" runat="server"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        OnRowDataBound="ManualCinderellaGridView_DataBound"
                        DataSourceID="Cinderella2015"
                        DataKeyNames="CinderellaID" ForeColor="Black" OnSelectedIndexChanged="ManualCinderellaGridView_SelectedIndexChanged">
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
                </div>
                <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    SelectCommand="SELECT [CinderellaID], 
                                                [LastName], 
                                                [FirstName]
                                        FROM [Cinderella] 
                                        INNER JOIN CinderellaStatusRecord 
                                            ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID 
                                        WHERE (Status_Name = 'Waiting for Godmother' OR Status_Name = 'Paired') 
                                            AND IsCurrent = 'Y'
                                        ORDER BY [StartTime]"></asp:SqlDataSource>
            </td>
            <td class="auto-style1">
                <asp:Button ID="ManualPairButton" runat="server" Enabled="False" OnClick="ManualPairButton_Click" Text="Pair" Font-Size="X-Large" Height="63px" Width="93px" />
            </td>
            <td rowspan="2">
                <div style="overflow: auto; height: 300px;">
                    <asp:GridView ID="VolunteerPairingGridView" runat="server"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        OnRowDataBound="AllVolunteersGridView_DataBound"
                        DataSourceID="VolunteerPairDataSource"
                        DataKeyNames="VolunteerID" ForeColor="Black" OnSelectedIndexChanged="VolunteerPairingGridView_SelectedIndexChanged">
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
                </div>
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
                                        ORDER BY VolunteerStatusRecord.StartTime"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
        </tr>
    </table>

</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 166px;
            text-align: center;
        }

        .auto-style2 {
            height: 32px;
        }

        .auto-style3 {
            height: 49px;
            text-align: center;
        }

        .auto-style5 {
            height: 45px;
            text-align: center;
        }
    </style>
</asp:Content>


