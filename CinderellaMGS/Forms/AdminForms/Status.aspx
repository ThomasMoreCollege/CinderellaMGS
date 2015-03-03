<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Status.aspx.cs" Inherits="Forms_AdminForms_ChildForms_Status" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Statuses</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    <table id="CinderellaStatusTable">
        <tr>
            <th>Cinderella Status</th>
            <th>Total</th>
        </tr>
        <tr>
            <td>Pending for Today</td>
            <td>
                <asp:Label ID="CinderellaPendingLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Waiting for Godmother</td>
            <td>
                <asp:Label ID="WaitingForGodmotherLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Shopping</td>
            <td>
                <asp:Label ID="CinderellaShoppingLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Waiting for Package</td>
            <td>
                <asp:Label ID="WaitingForPackageLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Dress In Alterations</td>
            <td>
                <asp:Label ID="DressAlterationsLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Checked Out</td>
            <td>
                <asp:Label ID="CinderellaCheckedOutLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>

    <table id="VolunteerStatusTable">
        <tr>
            <th>Volunteer Status</th>
            <th>Total</th>
        </tr>
        <tr>
            <td>Volunteers Pending for Today</td>
            <td>
                <asp:Label ID="VolunteerPendingLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Godmothers Ready for Cinderella</td>
            <td>
                <asp:Label ID="VolunteerReadyLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Godmothers Shopping</td>
            <td>
                <asp:Label ID="VolunteerShoppingLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Volunteers&nbsp; On Break</td>
            <td>
                <asp:Label ID="VolunteerOnBreakLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>

    <table id="PackageStatusTable">
        <tr>
            <th>Package Status</th>
            <th>Total</th>
        </tr>
        <tr>
            <td>In Packaging</td>
            <td>
                <asp:Label ID="PackagingLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Checked Out</td>
            <td>
                <asp:Label ID="PackageCheckedOutLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</form>
</asp:Content>

