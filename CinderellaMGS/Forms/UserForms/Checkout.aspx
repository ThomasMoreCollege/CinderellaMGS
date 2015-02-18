<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Forms_UserForms_Checkout" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Checkout</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="form1" runat="server">
        <table id="CheckoutTable" border="1">
            <tr>
                <th>Cinderellas</th>
                <th>Godmothers</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="CinderellaSearchTextBox" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="CinderellaSearchButton" runat="server" Text="Search By: " />
                    &nbsp;<asp:DropDownList ID="CinderellaSearchDropDown" runat="server">
                        <asp:ListItem>First Name</asp:ListItem>
                        <asp:ListItem>Last Name</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="GodmotherSearchTextBox" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="GodmotherSearchButton" runat="server" Text="Search By:" />
                    &nbsp;<asp:DropDownList ID="GodmotherSearchDropDown" runat="server">
                        <asp:ListItem>First Name</asp:ListItem>
                        <asp:ListItem>Last Name</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="CinderellaListBox" runat="server" Height="200px" Width="150px"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="GodmotherListBox" runat="server" Height="200px" Width="150px"></asp:ListBox>
                </td>
            </tr>
        </table>
        <table id="DressCheckoutTable" border="1">
            <tr>
                <th colspan="3">Dress</th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Dress Size:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="DressSizeDropDown" runat="server">
                        <asp:ListItem>Small</asp:ListItem>
                        <asp:ListItem>Medium</asp:ListItem>
                        <asp:ListItem>Large</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Dress Length:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="DressLengthDropDown" runat="server">
                        <asp:ListItem>RANGE OF NUMBERS</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Dress Color:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="DressColorDropDown" runat="server">
                        <asp:ListItem>VARIETY OF COLORS</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

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

        <table id="ShoeCheckoutTable" border="1">
            <tr>
                <th colspan="2">Shoes</th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Shoe Size:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ShoeSizeDropDown" runat="server">
                        <asp:ListItem>RANGE OF NUMBERS</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Shoe Color:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ShoeColorDropDown" runat="server">
                        <asp:ListItem>VARIETY OF COLORS</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

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


