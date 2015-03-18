<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditPackage.aspx.cs" Inherits="Forms_UserForms_ChildForms_EditPackage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Edit Package</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style ="height:300px; width:1345px; overflow:auto;">
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
                                    [FirstName],
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
</asp:Content>

