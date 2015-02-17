<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CinderellaRegistration.aspx.cs" Inherits="Forms_UserForms_CinderellaRegistration" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Cinderella Registration</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
<asp:Label ID="CinderellaInfoLabel" runat="server" Font-Bold="True" Font-Size="Large" Text="Cinderella Information:"></asp:Label>
        <br />
        <br />
        <table style="width:40%;" id="CinderellaInfoTable">
            <tr>
                <td class="TableLabelCell" >
                    First Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="FirstTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    Last Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    Appointment Date:</td>
                <td class="TableInputCell">

                    &nbsp;</td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    Appointment Time:</td>
                <td class="TableInputCell"><asp:TextBox ID="AppTimeTextBox0" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="ReferralInfoLabel" runat="server" Font-Bold="True" Font-Size="Large" Text="Referral Information:"></asp:Label>
        <br />
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Existing Referral" />
&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" Text="New Referral" />
        <br />
        <br />
        <table style="width:40%;" id="ReferralInfoTable">
            <tr>
                <td class="TableLabelCell" >
                    Existing Referral:</td>
                <td class="TableInputCell"><asp:TextBox ID="FirstTextBox0" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    New Referral Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="LastNameTextBox0" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    &nbsp;New Referral School/Agency:</td>
                <td class="TableInputCell"><asp:TextBox ID="AppTimeTextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    Notes:</td>
                <td class="TableInputCell"><asp:TextBox ID="AppTimeTextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
&nbsp;<br />
        <br />
&nbsp;<br />
        <br />
&nbsp;<br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;</form>
</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style8 {
        width: 249px;
        text-align: right;
    }
    </style>
</asp:Content>
