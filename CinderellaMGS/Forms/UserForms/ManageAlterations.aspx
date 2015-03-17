<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageAlterations.aspx.cs" Inherits="Forms_UserForms_ManageAlterations" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Manage Alterations</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <table id="AltMangTable" style="width:60%;">
        <tr>
            <td class="auto-style7">
                <asp:Button ID="CreateAlterationsButton" runat="server" Text="Create Alterations" Height="31px" Width="140px" PostBackUrl="~/Forms/UserForms/ChildForms/Alterations.aspx" />
            </td>
            <td class="auto-style8">Sets the alterations needed for a Cinderella's dress</td>
        </tr>
        <tr id="middleRow">
            <td class="auto-style7">
                <asp:Button ID="DressReadyButton" runat="server" Text="Mark Dress as Ready" Height="31px" Width="140px" PostBackUrl="~/Forms/UserForms/ChildForms/AlteredDressReady.aspx"/>
            </td>
            <td class="auto-style8">Marks a dress in Alterations as ready to be picked up</td>
        </tr>
    </table>
</asp:Content>
