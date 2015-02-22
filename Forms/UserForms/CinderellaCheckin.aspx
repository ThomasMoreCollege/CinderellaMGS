<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CinderellaCheckin.aspx.cs" Inherits="Forms_CinderellaCheckin" %>


<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>Cinderella Check-In</h2>
</asp:Content>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">

    <form id="form1" runat="server">
        <p>
            <asp:Button ID="SortButton" runat="server" OnClick="SortButton_Click" Text="Sort By:" />
&nbsp;
            <asp:DropDownList ID="SortParameterDropDown" runat="server">
                <asp:ListItem Selected="True">Appointment Time</asp:ListItem>
                <asp:ListItem>Alphabetically</asp:ListItem>
            </asp:DropDownList>
            <br />
        </p>
        <p>
            <asp:ListBox ID="CinderellaListBox" runat="server" Height="209px" Width="275px"></asp:ListBox>
        </p>
        <p>
            <asp:Button ID="CheckInButton" runat="server" OnClick="CheckInButton_Click" Text="Check-In" Width="70px" />
        </p>
    </form>

</asp:Content>

