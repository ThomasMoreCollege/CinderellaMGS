<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagePackaging.aspx.cs" Inherits="Forms_UserForms_ManagePackaging" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Manage Packaging</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <table id="PackMangTable" style="width:60%;">
        <tr>
            <td class="auto-style7">
                <asp:Button ID="CreatePackageButton" runat="server" Text="Create Package" Height="31px" Width="125px" PostBackUrl="~/Forms/UserForms/ChildForms/CreatePackage.aspx" />
            </td>
            <td class="auto-style8">Enter in a Cinderella's package information</td>
        </tr>
        <tr id="middleRow">
            <td class="auto-style7">
                <asp:Button ID="PackageCheckoutButton" runat="server" Text="Checkout Package" Height="31px" Width="125px" PostBackUrl="~/Forms/UserForms/ChildForms/PackageCheckout.aspx"/>
            </td>
            <td class="auto-style8">Marks a package as ready to be sent out</td>
        </tr>
    </table>
</asp:Content>

