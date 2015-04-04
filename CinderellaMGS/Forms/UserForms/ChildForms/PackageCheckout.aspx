<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PackageCheckout.aspx.cs" Inherits="Forms_UserForms_ChildForms_PackageCheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" runat="Server">
    <h2>Package Checkout</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="border-bottom: 1px solid #999999;">
        <table>
            <tr>
                <td><strong>Cinderellas Ready For Check-Out</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="height: 300px; overflow-y: auto; overflow-x: hidden;">
                        <asp:GridView ID="CinderellaPackageGridView" runat="server"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataSourceID="Cinderella2015"
                            DataKeyNames="Cinderella_ID" OnSelectedIndexChanged="CinderellaPackageGridView_SelectedIndexChanged" ForeColor="Black">
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
                            <SelectedRowStyle BackColor="Fuchsia" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                            SelectCommand="SELECT [Cinderella_ID],
                                        [LastName],
                                        [FirstName]
                                FROM [Package] 
                                INNER JOIN Cinderella 
                                     ON Package.Cinderella_ID = Cinderella.CinderellaID 
                                WHERE InPackaging = 'Y' AND (InAlterations = 'N' OR InAlterations IS NULL)
                                ORDER BY [LastName]">
                        </asp:SqlDataSource>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div style="border-bottom: 1px solid #999999;">
        <div style="height: 30%; width: 40%; float: left;">
            <table>
                <tr>
                    <th colspan="3">Dress</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Dress Size:"></asp:Label>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="DressSizeLabel" runat="server">--</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Dress Length:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="DressLengthLabel" runat="server">--</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Dress Color:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="DressColorLabel" runat="server">--</asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="height: 30%; width: 40%; float: left; border-left: 1px solid #999999;">
            <table>
                <tr>
                    <th colspan="2">Jewelry</th>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="NecklaceCheckBox" runat="server" Text="Necklace" />
                    </td>
                    <td>
                        <asp:CheckBox ID="RingCheckBox" runat="server" Text="Ring" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="HeadpieceCheckBox" runat="server" Text="Headpiece" />
                    </td>
                    <td>
                        <asp:CheckBox ID="EarringCheckBox" runat="server" Text="Earring" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="BraceletCheckBox" runat="server" Text="Bracelet" />
                    </td>
                    <td>
                        <asp:CheckBox ID="OtherCheckBox" runat="server" Text="Other" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <div style="height: 30%; width: 40%; float: left;">
            <table>
                <tr>
                    <th colspan="2">Shoes</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Shoe Size:"></asp:Label>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="ShoeSizeLabel" runat="server">--</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Shoe Color:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="ShoeColorLabel" runat="server">--</asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="height: 30%; width: 40%; float: left; border-left: 1px solid #999999;">
            <table>
                <tr>
                    <th>Notes</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="NotesTextBox" runat="server" Height="129px" TextMode="MultiLine" Width="318px"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </div>
    <p>
        <asp:Label runat="server" Visible=" false" ForeColor="Red" ID="SelectionValidationLabel">*Please select a Cinderella's Package</asp:Label><br />
        <asp:Button ID="CheckOutButton" runat="server" Text="Check-Out Package" OnClick="CheckOutButton_Click" />
    </p>
</asp:Content>

