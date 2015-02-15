<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CinderellaCheckin.aspx.cs" Inherits="Forms_CinderellaCheckin" %>


<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>Cinderella Check-In</h2>
</asp:Content>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">

    <form id="form1" runat="server">
        <p>
            <asp:Button ID="SortAlphabeticallyButton" runat="server" OnClick="SortAlphabeticallyButton_Click" Text="Sort Alphabetically" Width="165px" />
        </p>
        <p>
            <asp:Button ID="SortAppointmentsButton" runat="server" OnClick="SortAppointmentsButton_Click" Text="Sort by Appointments" Width="165px" />
            <br />
        </p>
        <p>
            <asp:ListBox ID="CinderellaListBox" runat="server" Height="209px" Width="275px"></asp:ListBox>
        </p>
        <p>
            <asp:Button ID="CheckInButton" runat="server" OnClick="CheckinButton_Click" Text="Check-In" Width="70px" />
        </p>
    </form>

</asp:Content>

