<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Alterations.aspx.cs" Inherits="Forms_UserForms_Alterations" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Alterations</h2>
        <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="CinderellasShoppingDiv" style="width: 100%; float: left; overflow-x:hidden;">
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="2"><strong>Cinderellas Currently Shopping</strong></td>
                        </tr>
                        <tr>
                            <td id="CinderellaShoppingTD" colspan="2">
                                <div style ="height:400px;overflow:auto; overflow-x:hidden;">
                                    <asp:GridView ID="CinderellaShoppingGridView" runat="server"
                                        AllowSorting="True"
                                        AutoGenerateColumns="False"
                                        DataSourceID="Cinderella2015"
                                        DataKeyNames="CinderellaID" ForeColor="Black" OnSelectedIndexChanged="CinderellaShoppingGridView_SelectedIndexChanged" HorizontalAlign="Left">
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
                                                        WHERE Status_Name = 'Shopping' AND IsCurrent = 'Y'
                                                        ORDER BY [LastName]">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>Size :</td>
                            <td>
                                <asp:DropDownList ID="DressSizeDropDownList" runat="server" Style="text-align: center" Enabled="False" DataSourceID="DressSizeDS" DataTextField="dressSize" DataValueField="dressSize">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DressSizeDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT [dressSize] FROM [DressSize]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>Color:</td>
                            <td>
                                <asp:DropDownList ID="DressColorDropDownList" runat="server" Enabled="False" Style="width: 95px" DataSourceID="DressColorDS" DataTextField="dressColor" DataValueField="dressColor">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DressColorDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT * FROM [DressColor]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>Length:</td>
                            <td>
                                <asp:DropDownList ID="DressLengthDropDownList" runat="server" Enabled="False" DataSourceID="DressLengthDS" DataTextField="dressLength" DataValueField="dressLength">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DressLengthDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [dressLength] FROM [DressLength]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="AltertationsCheckinButton" runat="server" Text="Check Dress in to Altertations" Style="text-align: center" Enabled="False" OnClick="AltertationsCheckinButton_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table>
                        <tr>
                            <td colspan="2"><strong>Cinderella Dresses in Alterations</strong></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="CinderellaInAlterationsTD" style="height: 400px; overflow: auto; overflow-x:hidden;">
                                    <asp:GridView ID="CinderellaDressAlterationsGridView" runat="server"
                                        AllowSorting="True"
                                        AutoGenerateColumns="False"
                                        DataSourceID="PackageDataSource"
                                        DataKeyNames="CinderellaID" ForeColor="Black" OnSelectedIndexChanged="CinderellaDressAlterationsGridView_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                                            <asp:BoundField DataField="DressSize" HeaderText="Dress Size" SortExpression="DressSize" />
                                            <asp:BoundField DataField="DressColor" HeaderText="Dress Color" SortExpression="DressColor" />
                                            <asp:BoundField DataField="DressLength" HeaderText="Dress Length" SortExpression="DressLength" />
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
                                    <asp:SqlDataSource ID="PackageDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                                        SelectCommand="SELECT [CinderellaID], 
                                                                    [LastName], 
                                                                    [FirstName],
                                                                    [DressSize],
                                                                    [DressColor],
                                                                    [DressLength]
                                                            FROM [Cinderella] 
                                                            INNER JOIN Package 
                                                                ON Cinderella.CinderellaID = Package.Cinderella_ID
                                                            INNER JOIN Alteration
                                                                ON Cinderella.CinderellaID = Alteration.Cinderella_ID
                                                            WHERE InAlterations = 'Y' AND ReadyForPickup = 'N'
                                                            ORDER BY [LastName]">
                                    </asp:SqlDataSource>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Error" runat="server" Text="Please select a volunteer to work on the dress" ForeColor="Red" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">Alterations:</td>
                            <td colspan="2">
                                <asp:CheckBox ID="StrapsCheckBox" runat="server" Text="Straps Add/Adjust" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2">
                                <asp:CheckBox ID="GeneralMendingCheckBox" runat="server" Text="General Mending" CssClass="auto-style13" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2">
                                <asp:CheckBox ID="GeneralTakeinCheckBox" runat="server" Text="General Take In" CssClass="auto-style13" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2">
                                <asp:CheckBox ID="FixZipperCheckBox" runat="server" Text="Fix Zipper" CssClass="auto-style13" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2"><asp:CheckBox ID="DartsCheckBox" runat="server" Text="Darts" CssClass="auto-style13" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2">
                                <asp:CheckBox ID="BustCheckBox" runat="server" Text="Bust" CssClass="auto-style13" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2">
                                <asp:CheckBox ID="HemCheckBox" runat="server" Text="Hem" CssClass="auto-style13" Enabled="False" />
                            </td>
                        </tr>
                                                <tr>
                            <td></td>
                            <td colspan="2">
                                <asp:CheckBox ID="OtherCheckBox" runat="server" Text="Other" CssClass="auto-style13" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                Seamstress:</td>
                            <td>
                                <asp:SqlDataSource ID="VolunteerNameDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>"
                                    SelectCommand="SELECT VolunteerID, (FirstName + ' ' + LastName) as Name
                                        FROM Volunteer
	                                    INNER JOIN VolunteerRoleRecord
	                                        ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID
                                        WHERE VolunteerRoleRecord.Role_Name = 'Alterations' AND VolunteerRoleRecord.IsCurrent = 'Y'"></asp:SqlDataSource>
                                <asp:DropDownList ID="SeamstressDropDownList" runat="server" AppendDataBoundItems="true"
                                    DataSourceID="VolunteerNameDS" DataTextField="Name" DataValueField="VolunteerID" Enabled="False">
                                    <asp:ListItem Text="--SELECT--" Value="1">--SELECT--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                Notes:</td>
                            <td rowspan="3">
                                <asp:TextBox ID="notesTextBox" runat="server" Width="187px" Enabled="False" Height="84px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                Ready for Pickup?
                            </td>
                            <td>
                                <asp:RadioButtonList ID="PickupRadioButtonList" runat="server">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N" Selected ="true">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="submitAlterationsButton" runat="server" Text="Submit Alteration Changes" Enabled="False" OnClick="submitAlterationsButton_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #TextArea1
        {
            height: 49px;
            width: 203px;
        }
        .auto-style13 {
            width: 97px;
            font-size: medium;
        }
        .auto-style14
        {
            text-align: right;
        }
        </style>
</asp:Content>


