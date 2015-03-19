<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PackageCheckout.aspx.cs" Inherits="Forms_UserForms_ChildForms_PackageCheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Package Checkout</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        <div style ="height:300px; overflow-y:auto; overflow-x:hidden;">
            <asp:GridView ID="CinderellaPackageGridView" runat="server" 
                AllowSorting="True" 
                AutoGenerateColumns="False" 
                DataSourceID="Cinderella2015"
                DataKeyNames ="Cinderella_ID" OnSelectedIndexChanged="CinderellaPackageGridView_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                </Columns>
                <SelectedRowStyle BackColor="Fuchsia" />
            </asp:GridView>
            <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                SelectCommand="SELECT [Cinderella_ID],
                                        [LastName],
                                        [FirstName]
                                FROM [Package] 
                                INNER JOIN Cinderella 
                                     ON Package.Cinderella_ID = Cinderella.CinderellaID 
                                WHERE InPackaging = 'Y' AND InAlterations = 'N'
                                ORDER BY [LastName]">
            </asp:SqlDataSource>
        </div>
    <div id="FullPackageTable" style="width: 100%; float: left; overflow-x:hidden;">
        <table id="FullPackage" border="1">
            <tr>
                <td>
                    <table>
                        <tr>
                            <th colspan="3">Dress</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Dress Size:"></asp:Label>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="DressSizeLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Dress Length:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="DressLengthLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Dress Color:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="DressColorLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                   </table>
                </td>
                <td>
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
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th colspan="2">Shoes</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Shoe Size:"></asp:Label>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="ShoeSizeLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Shoe Color:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="ShoeColorLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table>
                        <tr>
                            <th>Notes</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="NotesTextBox" runat="server" Height="218px" TextMode="MultiLine" Width="500px"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
        <p>
            <asp:label runat="server" Visible =" false" ForeColor="Red" ID="SelectionValidationLabel">*Please select a Cinderella's Package</asp:label><br />
            <asp:Button ID="CheckOutButton" runat="server" Text="Check-Out Package" OnClick="CheckOutButton_Click" />
        </p>
</asp:Content>

