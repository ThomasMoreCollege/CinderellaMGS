<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VolunteerCheckin.aspx.cs" Inherits="Forms_UserForms_VolunteerCheckin" %>

<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>Volunteer Check-In</h2>
</asp:Content>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">

    <form id="form1" runat="server">
        <p>
            <asp:ListBox ID="VolunteerListBox" runat="server" Height="209px" Width="275px"></asp:ListBox>
        </p>
        <p>
            <asp:Button ID="CheckInButton" runat="server" OnClick="CheckinButton_Click" Text="Check-In" Width="70px" />
        </p>
    </form>

</asp:Content>

