<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditPackage.aspx.cs" Inherits="Forms_UserForms_ChildForms_EditPackage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" runat="Server">
    <h2>Edit Package</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">

    <div style="border-bottom: 1px solid #999999;">

        <table>
            <tr>
                <td><strong>Complete Packages</strong></td>
                <td><strong>Dresses Ready In Alterations</strong></td>
            </tr>
            <tr>
                <td>
                    <div style="height: 300px; overflow: auto;">
                        <asp:GridView ID="CinderellaPackageGridView" runat="server"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataSourceID="Cinderella2015"
                            DataKeyNames="CinderellaID" OnSelectedIndexChanged="CinderellaPackageGridView_SelectedIndexChanged" ForeColor="Black">
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
                                        FROM [Package]
                                        INNER JOIN Cinderella 
                                            ON Package.Cinderella_ID = Cinderella.CinderellaID 
                                        WHERE InPackaging = 'Y' AND InAlterations = 'N'
                                        ORDER BY [LastName]"></asp:SqlDataSource>

                </td>
                <td>

                    <asp:SqlDataSource ID="DressDeliveryDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        SelectCommand="SELECT [CinderellaID],
                                                [LastName],
                                                [FirstName],
                                                [DressSize],
                                                [DressColor],
                                                [DressLength]
                                        FROM [Package]
                                        INNER JOIN Cinderella 
                                            ON Package.Cinderella_ID = Cinderella.CinderellaID 
                                        INNER JOIN Alteration
                                            ON Alteration.Cinderella_ID = Cinderella.CinderellaID
                                        WHERE InPackaging = 'Y' AND InAlterations = 'Y' AND ReadyForPickup = 'Y'
                                        ORDER BY [LastName]"></asp:SqlDataSource>
                    <div style="height: 300px; overflow: auto;">
                        <asp:GridView ID="DressDeliveryGridView" runat="server"
                            AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataSourceID="DressDeliveryDataSource"
                            DataKeyNames="CinderellaID" OnSelectedIndexChanged="DressDeliveryGridView_SelectedIndexChanged" ForeColor="Black">
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
                    </div>
                </td>
            </tr>
            <tr>
                <td>

                    <asp:Button ID="EditPackageButton" runat="server" Text="Edit Package Information" OnClick="EditPackageButton_Click" />

                </td>
                <td>

                    <asp:Button ID="DressDeliveredButton" runat="server" Text="Add Dress to Package" OnClick="DressDeliveredButton_Click" />

                </td>
            </tr>
        </table>
    </div>
    <div style="border-bottom: 1px solid #999999;">
        <div style="height: 30%; width: 40%; float: left; border-right: 1px solid #999999;">
            <table>
                <tr>
                    <th colspan="3">Dress</th>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="DressSizeErrorLabel" runat="server" Text="Please select a dress size" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Dress Size:"></asp:Label>
                        &nbsp;</td>
                    <td>
                        <asp:DropDownList ID="DressSizeDropDown" runat="server" AppendDataBoundItems="true"
                            DataSourceID="DressSizeDataSource" DataTextField="dressSize" DataValueField="dressSize">
                            <asp:ListItem Text="--SELECT--" Value="1">--SELECT--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DressSizeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                            SelectCommand="SELECT [dressSize] 
                                                    FROM [DressSize]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="DressLengthErrorLabel" runat="server" Text="Please select a dress length" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Dress Length:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DressLengthDropDown" runat="server" AppendDataBoundItems="true"
                            DataSourceID="DressLength" DataTextField="dressLength" DataValueField="dressLength">
                            <asp:ListItem Text="--SELECT--" Value="1">--SELECT--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DressLength" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                            SelectCommand="SELECT [dressLength] 
                                                    FROM [DressLength]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="DressColorErrorLabel" runat="server" Text="Please select a dress color" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Dress Color:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DressColorDropDown" runat="server" AppendDataBoundItems="true"
                            DataSourceID="DressColorDataSource" DataTextField="dressColor" DataValueField="dressColor">
                            <asp:ListItem Text="--SELECT--" Value="1">--SELECT--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DressColorDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                            SelectCommand="SELECT [dressColor] 
                                                    FROM [DressColor]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </div>
        <div style="height: 30%; width: 40%; float: left;">
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

        </div>
    </div>
    <div>
        <div style="height: 30%; width: 40%; float: left; border-right: 1px solid #999999;">
            <table>
                <tr>
                    <th colspan="2">Shoes</th>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="ShoeSizeErrorLabel" runat="server" Text="Please select a dress size" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Shoe Size:"></asp:Label>
                        &nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ShoeSizeDropDown" runat="server" AppendDataBoundItems="true"
                            DataSourceID="ShoeSizeDataSource" DataTextField="shoeSize" DataValueField="shoeSize">
                            <asp:ListItem Text="--SELECT--" Value="1">--SELECT--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="ShoeSizeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                            SelectCommand="SELECT [shoeSize] 
                                                    FROM [ShoeSize]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="ShoeColorErrorLabel" runat="server" Text="Please select a dress size" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Shoe Color:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ShoeColorDropDown" runat="server" AppendDataBoundItems="true"
                            DataSourceID="ShoeColorDataSource" DataTextField="shoeColor" DataValueField="shoeColor">
                            <asp:ListItem Text="--SELECT--" Value="1">--SELECT--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="ShoeColorDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                            SelectCommand="SELECT [shoeColor] 
                                                    FROM [ShoeColor]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </div>
        <div style="height: 30%; width: 40%; float: left;">
            <table>
                <tr>
                    <th>Notes</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="NotesTextBox" runat="server" Height="112px" TextMode="MultiLine" Width="314px"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="head">
</asp:Content>


