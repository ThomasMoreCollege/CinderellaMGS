<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VolunteerRegsitration.aspx.cs" Inherits="Forms_AdminForms_GodMotherRegsitration" %>


<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Volunteer Registration</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    <asp:Label ID="VolunteerInfoLabel" runat="server" Font-Bold="True" Font-Size="Large" Text="Volunteer Information:"></asp:Label>
        <br />
        <br />
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="errorLabel" headertext="There were errors on the page:" />
        <table style="width:40%;" id="VolunteerInfoTable">
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server"
                     ControlToValidate="FirstTextBox"
                     ErrorMessage="First Name is required!"><font color="red">*Please enter a first name!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2" >
                    First Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="FirstTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="LastNameValidator" runat="server"
                     ControlToValidate="LastNameTextBox"
                     ErrorMessage="Last Name is required!"><font color="red">*Please enter a last name!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2">
                    Last Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="AddressFieldValidator" runat="server"
                     ControlToValidate="AddresstextBox"
                     ErrorMessage="Address is required!"><font color="red">*Please enter an Address!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2">
                    Address:</td>
                <td class="TableInputCell">

                    <asp:TextBox ID="AddresstextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="CityFieldValidator" runat="server"
                     ControlToValidate="CitytextBox"
                     ErrorMessage="City is required!"><font color="red">*Please enter a City!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2">
                    City:</td>
                <td class="TableInputCell"><asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="StateFieldValidator" runat="server"
                     ControlToValidate="StatetextBox"
                     ErrorMessage="State is required!"><font color="red">*Please enter a State!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2">
                    State:</td>
                <td class="TableInputCell"><asp:TextBox ID="StateTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="ZipCodeFieldValidator" runat="server"
                     ControlToValidate="ZipCodeTextBox"
                     ErrorMessage="ZipCode is required!"><font color="red">*Please enter a Zip Code!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2">
                    Zip Code:</td>
                <td class="TableInputCell"><asp:TextBox ID="ZipCodeTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="PhoneNumberValidator" runat="server"
                     ControlToValidate="PhoneTextBox"
                     ErrorMessage="Phone Number is required!"><font color="red">*Please enter a Phone Number!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2">
                    Phone:</td>
                <td class="TableInputCell"><asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="EmailValidator" runat="server"
                     ControlToValidate="EmailTextBox"
                     ErrorMessage="Email is required!"><font color="red">*Please enter an Email!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2">
                    Email:</td>
                <td class="TableInputCell"><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="TableInputCell">
                    <asp:Button ID="RegisterFormButton" runat="server" Text="Register" OnClick="RegisterFormButton_Click" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {
            font-size: small;
            text-align: right;
        }
    </style>
</asp:Content>


