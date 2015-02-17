<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VolunteerRegsitration.aspx.cs" Inherits="Forms_AdminForms_GodMotherRegsitration" %>


<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Volunteer Registration</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    <asp:Label ID="VolunteerInfoLabel" runat="server" Font-Bold="True" Font-Size="Large" Text="Volunteer Information:"></asp:Label>
        <br />
        <br />
        <table style="width:40%;" id="VolunteerInfoTable">
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
                    Address:</td>
                <td class="TableInputCell">

                    <asp:TextBox ID="AddresstextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    City:</td>
                <td class="TableInputCell"><asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    State:</td>
                <td class="TableInputCell"><asp:TextBox ID="StateTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    Zip Code:</td>
                <td class="TableInputCell"><asp:TextBox ID="ZipCodeTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    Phone:</td>
                <td class="TableInputCell"><asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableLabelCell">
                    Email:</td>
                <td class="TableInputCell"><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
    </style>
</asp:Content>


