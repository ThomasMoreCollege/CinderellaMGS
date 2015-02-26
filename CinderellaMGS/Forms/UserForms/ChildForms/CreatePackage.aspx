<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreatePackage.aspx.cs" Inherits="Forms_UserForms_Checkout" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Checkout</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" forecolor="Red" ID="CinderellaValidator" Visible="False">*Please select a Cinderella</asp:Label><br />

            <table id="CheckoutTable">
                <tr>
                    <th>Cinderellas</th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="CinderellaGridView" runat="server" 
                    AllowSorting="True" 
                    AutoGenerateColumns="False" 
                    DataSourceID="Cinderella2015" 
                    DataKeyNames="CinderellaID">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    </Columns>
                    <SelectedRowStyle BackColor="Fuchsia" />
                </asp:GridView>
                <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                    SelectCommand="SELECT [CinderellaID], 
                                            [LastName], 
                                            [FirstName]
                                    FROM [Cinderella] 
                                    INNER JOIN CinderellaStatusRecord 
                                        ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID 
                                    WHERE Status_Name = 'Shopping' AND IsCurrent = 'Y'
                                    ORDER BY [LastName]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="DressSizeValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DressSizeDropDown" ForeColor="Red" Display="Dynamic">*Please select a dress size</asp:RequiredFieldValidator><br />
            <asp:RequiredFieldValidator ID="DressLengthValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DressLengthDropDown" ForeColor="Red" Display="Dynamic">*Please select a dress length</asp:RequiredFieldValidator><br />
            <asp:RequiredFieldValidator ID="DressColorValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DressColorDropDown" ForeColor="Red" Display="Dynamic">*Please select a dress color</asp:RequiredFieldValidator><br />
            <table id="DressCheckoutTable" border="1">
                <tr>
                    <th colspan="3">Dress</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Dress Size:"></asp:Label>
                        &nbsp;<asp:DropDownList ID="DressSizeDropDown" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Small</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>Large</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Dress Length:"></asp:Label>
                        &nbsp;<asp:DropDownList ID="DressLengthDropDown" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>RANGE OF NUMBERS</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Dress Color:"></asp:Label>
                        &nbsp;<asp:DropDownList ID="DressColorDropDown" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>VARIETY OF COLORS</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <table id="JewelryCheckoutTable" border="1">
                <tr>
                    <th colspan="3">Jewelry</th>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="NecklaceCheckBox" runat="server" Text="Necklace" />
                    </td>
                    <td>
                        <asp:CheckBox ID="RingCheckBox" runat="server" Text="Ring" />
                    </td>
                    <td>
                        <asp:CheckBox ID="BraceletCheckBox" runat="server" Text="Bracelet" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="HeadpieceCheckBox" runat="server" Text="Headpiece" />
                    </td>
                    <td>
                        <asp:CheckBox ID="EarringCheckBox" runat="server" Text="Earring" />
                    </td>
                    <td>
                        <asp:CheckBox ID="OtherCheckBox" runat="server" Text="Other" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <asp:RequiredFieldValidator ID="ShoeSizeValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ShoeSizeDropDown" ForeColor="Red" Display="Dynamic">*Please select a shoe size</asp:RequiredFieldValidator><br />
            <asp:RequiredFieldValidator ID="ShoeColorValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ShoeColorDropDown" ForeColor="Red" Display="Dynamic">*Please select a shoe color</asp:RequiredFieldValidator><br />

            <table id="ShoeCheckoutTable" border="1">
            <tr>
                <th colspan="2">Shoes</th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Shoe Size:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ShoeSizeDropDown" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Shoe Color:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ShoeColorDropDown" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>VARIETY OF COLORS</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        </div>

        <table id="NotesCheckoutTable">
            <tr>
                <th>Notes</th>
            </tr>
            <tr>
                <td><asp:TextBox ID="NotesTextBox" runat="server" Height="218px" TextMode="MultiLine" Width="749px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" /></td>
            </tr>
        </table>

    </form>

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #form1 {
            height: 1076px;
        }
    </style>
</asp:Content>


