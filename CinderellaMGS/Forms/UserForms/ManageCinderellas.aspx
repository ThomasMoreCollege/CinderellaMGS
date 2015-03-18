<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageCinderellas.aspx.cs" Inherits="Forms_UserForms_ManageCinderellas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 55px;
        }
        .auto-style2 {
            height: 60px;
        }
        .auto-style3 {
            height: 56px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <table id="CinMangTable" style="width: 70%;">
        <tr>
            <td class="auto-style1">
                <asp:Button ID="RegisterButton" runat="server" Text="Registration" Height="31px" Width="139px" PostBackUrl="~/Forms/UserForms/ChildForms/CinderellaRegistration.aspx" />
            </td>
            <td class="auto-style1">Register a cinderella.</td>
        </tr>
        <tr id="middleBorder1Row">
            <td class="auto-style1">
                <asp:Button ID="EditCinderellaButton" runat="server" Text="Edit Info" Height="31px" Width="141px" PostBackUrl="~/Forms/UserForms/ChildForms/EditCinderella.aspx" />
            </td>
            <td class="auto-style1">Edit information regarding to a registered cinderella.</td>
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
        <tr id="middleBorder2Row">
            <td class="auto-style2">
                <asp:Button ID="CinderellaCheckin" runat="server" Height="32px" Text="Check-in" Width="140px" PostBackUrl="~/Forms/UserForms/ChildForms/CinderellaCheckin.aspx" />
            </td>
            <td class="auto-style2">Check-in a cinderella to start making dreams come true!</td>
        </tr>
        <tr >
            <td class="auto-style3">
                <asp:Button ID="ManageAppointmentsButton" runat="server" Height="32px" Text="Manage Appointments" Width="140px" PostBackUrl="~/Forms/UserForms/ChildForms/ManageAppointment.aspx" />
            </td>
            <td class="auto-style3">Change a cinderella's scheduled appointment.</td>
        </tr>
    </table>
</asp:Content>


