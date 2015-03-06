<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageVolunteers.aspx.cs" Inherits="Forms_AdminForms_ManageVolunteers" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Manage Volunteers</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <table id="VolMangTable" style="width:70%;">
        <tr>
            <td class="auto-style7">
                <asp:Button ID="RegisterButton" runat="server" Text="Registration" Height="31px" Width="139px" PostBackUrl="~/Forms/AdminForms/ChildForms/VolunteerRegsitration.aspx" />
            </td>
            <td class="auto-style7">Register a person and assign them a role.</td>
        </tr>
        <tr id="middleRow">
            <td class="auto-style7">
                <asp:Button ID="EditVolunteerButton" runat="server" Text="Edit Info" Height="31px" Width="141px" PostBackUrl="~/Forms/AdminForms/ChildForms/EditVolunteer.aspx"/>
            </td>
            <td class="auto-style7">Edit information regarding to a registered volunteer.</td>
        </tr>
        <tr id="mgeRoleRow">
            <td class="auto-style7">
                <asp:Button ID="ManageVolunteerRoles" runat="server" Height="32px" Text="Manage Roles" Width="140px" PostBackUrl="~/Forms/AdminForms/ChildForms/ManageVolunteerRoles.aspx" />
            </td >
            <td class="auto-style7">Change the role of a volunteer.</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="Button3" runat="server" Text="Delete Volunteer" Height="31px" Width="142px" PostBackUrl="~/Forms/AdminForms/ChildForms/DeleteVolunteer.aspx"/>
            </td>
            <td class="auto-style7">Remove a registered volunteer.</td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
            <td></td>
        </tr>
        <tr id="VolChckInRow">
            <td class="auto-style7">
                <asp:Button ID="CheckInButton" runat="server" Text="Volunteer Check-In" Height="30px" Width="143px" PostBackUrl="~/Forms/AdminForms/ChildForms/VolunteerCheckin.aspx" /></td>
            <td class="auto-style7">Check in volunteers for the day when they arrive.</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Button ID="BreakButton" runat="server" Text="Break Manager" Height="30px" PostBackUrl="~/Forms/AdminForms/ChildForms/VolunteerClocking.aspx" Width="141px" /></td>
            <td class="auto-style7">Manage when a volunteer is available/on break.</td>
        </tr>
    </table>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style7 {
            height: 51px;
        }
        </style>
</asp:Content>


