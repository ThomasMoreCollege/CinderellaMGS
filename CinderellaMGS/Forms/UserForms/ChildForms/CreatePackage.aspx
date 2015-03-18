<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreatePackage.aspx.cs" Inherits="Forms_UserForms_Checkout" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Create Package</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="CinderellaCheckPackageGrid" style="width: 100%; float: left; overflow-x:hidden;">
        <table id="CheckoutTable">
            <tr>
                <th>Cinderellas Shopping</th>
                <th>Packages</th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="CinderellaGridView" runat="server"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataSourceID="Cinderella2015"
                        DataKeyNames="CinderellaID" OnSelectedIndexChanged="CinderellaGridView_SelectedIndexChanged" ForeColor="Black">
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
                                    INNER JOIN Package
                                        ON Cinderella.CinderellaID = Package.Cinderella_ID
                                    WHERE Status_Name = 'Shopping' 
                                            AND IsCurrent = 'Y' 
                                            AND CinderellaID NOT IN (SELECT CinderellaID
                                                                        FROM Package)
                                    ORDER BY [LastName]">
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:GridView ID="PackagesGridView" runat="server"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataSourceID="DressDataSource" 
                        DataKeyNames="CinderellaID" ForeColor="Black" OnSelectedIndexChanged="PackagesGridView_SelectedIndexChanged">
                        <Columns>

                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                            <asp:BoundField DataField="dressSize" HeaderText="Dress Size" SortExpression="dressSize" />
                            <asp:BoundField DataField="dressLength" HeaderText="Dress Length" SortExpression="dressLength" />
                            <asp:BoundField DataField="dressColor" HeaderText="Dress Color" SortExpression="dressColor" />
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
                    <asp:SqlDataSource ID="DressDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                       SelectCommand="SELECT [CinderellaID], 
                                            [LastName], 
                                            [FirstName],
                                            [DressSize],
                                            [DressColor],
                                            [DressLength]
                                    FROM [Cinderella] 
                                    INNER JOIN Package 
                                        ON Cinderella.CinderellaID = Package.Cinderella_ID 
                                    WHERE InAlterations = 'Y' OR InPackaging = 'Y'
                                    ORDER BY [LastName]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
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
                                <asp:DropDownList ID="DressSizeDropDown" runat="server" DataSourceID="DressSizeDataSource" DataTextField="dressSize" DataValueField="dressSize">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DressSizeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [dressSize] FROM [DressSize]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:RequiredFieldValidator ID="DressSizeValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DressSizeDropDown" ForeColor="Red" Display="Dynamic">*Please select a dress size</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Dress Length:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DressLengthDropDown" runat="server" DataSourceID="DressLength" DataTextField="dressLength" DataValueField="dressLength">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DressLength" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [dressLength] FROM [DressLength]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:RequiredFieldValidator ID="DressLengthValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DressLengthDropDown" ForeColor="Red" Display="Dynamic">*Please select a dress length</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Dress Color:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DressColorDropDown" runat="server" DataSourceID="DressColorDataSource" DataTextField="dressColor" DataValueField="dressColor">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DressColorDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [dressColor] FROM [DressColor]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:RequiredFieldValidator ID="DressColorValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DressColorDropDown" ForeColor="Red" Display="Dynamic">*Please select a dress color</asp:RequiredFieldValidator></td>
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
                                <asp:DropDownList ID="ShoeSizeDropDown" runat="server" DataSourceID="ShoeSizeDataSource" DataTextField="shoeSize" DataValueField="shoeSize">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="ShoeSizeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [shoeSize] FROM [ShoeSize]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:RequiredFieldValidator ID="ShoeSizeValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ShoeSizeDropDown" ForeColor="Red" Display="Dynamic">*Please select a shoe size</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Shoe Color:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ShoeColorDropDown" runat="server" DataSourceID="ShoeColorDataSource" DataTextField="shoeColor" DataValueField="shoeColor">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="ShoeColorDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [shoeColor] FROM [ShoeColor]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:RequiredFieldValidator ID="ShoeColorValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ShoeColorDropDown" ForeColor="Red" Display="Dynamic">*Please select a shoe color</asp:RequiredFieldValidator></td>
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
        <asp:Button ID="CheckoutButton" runat="server" Text="Check Package in to Packaging" OnClick="CheckoutButton_Click" Enabled="False" />
    </p>

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #form1 {
            height: 1076px;
            width: 1600px;
        }
    </style>
</asp:Content>


