<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageVolunteers.aspx.cs" Inherits="Forms_AdminForms_ManageVolunteers" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Manage Volunteers</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <table id="VolMangTable" style="width:60%;">
        <tr>
            <td class="auto-style7">
                <asp:Button ID="RegisterButton" runat="server" Text="Registration" Height="31px" Width="125px" PostBackUrl="~/Forms/AdminForms/ChildForms/VolunteerRegsitration.aspx" />
            </td>
            <td class="auto-style8">Register a person and assign them a role.</td>
        </tr>
        <tr id="middleRow">
            <td class="auto-style7">
                <asp:Button ID="EditVolunteerButton" runat="server" Text="Edit Info" Height="31px" Width="125px" PostBackUrl="~/Forms/AdminForms/ChildForms/EditVolunteer.aspx"/>
            </td>
            <td class="auto-style8">Edit information regarding to a registered volunteer.</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="Button3" runat="server" Text="Delete Volunteer" Height="31px" Width="125px" PostBackUrl="~/Forms/AdminForms/ChildForms/DeleteVolunteer.aspx"/>
            </td>
            <td class="auto-style8">Remove a registered volunteer.</td>
        </tr>
    </table>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style7 {
            height: 51px;
        }
        .auto-style8 {
            font-size: small;
            height: 51px;
        }
    </style>
</asp:Content>


