<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagePackaging.aspx.cs" Inherits="Forms_UserForms_ManagePackaging" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Manage Packaging</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <table id="PackMangTable" style="width:60%;">
        <tr>
            <td class="auto-style1" style="border-bottom: 1px solid #999999;">
                <asp:Button ID="CreatePackageButton" runat="server" Text="Create Package" Height="31px" Width="125px" PostBackUrl="~/Forms/UserForms/ChildForms/CreatePackage.aspx" />
            </td>
            <td class="auto-style1" style="border-bottom: 1px solid #999999;" >Enter in a Cinderella's package information</td>
        </tr>
        <tr id="mgeRoleRow">
            <td class="auto-style2" style="border-bottom: 1px solid #999999;">
                <asp:Button ID="EditPackageButton" runat="server" Text="Edit Package" Height="31px" Width="125px" PostBackUrl="~/Forms/UserForms/ChildForms/EditPackage.aspx"/>
            </td>
            <td class="auto-style2" style="border-bottom: 1px solid #999999;">Edits the information of a complete package</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="PackageCheckoutButton" runat="server" Text="Checkout Package" Height="31px" Width="125px" PostBackUrl="~/Forms/UserForms/ChildForms/PackageCheckout.aspx"/>
            </td>
            <td class="auto-style3">Marks a package as ready to be sent out</td>
        </tr>

    </table>
</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 57px;
        }
        .auto-style2 {
            height: 56px;
        }
        .auto-style3 {
            height: 55px;
        }
    </style>
</asp:Content>


