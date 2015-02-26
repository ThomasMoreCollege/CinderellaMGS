<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CinderellaRegistration.aspx.cs" Inherits="Forms_UserForms_CinderellaRegistration" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Cinderella Registration</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="errorLabel" headertext="There were errors on the page:" />
        <table style="width:50%;" id="RegistrationTable">

            <tr>
                <td colspan="2" class="auto-style1">

                    <strong>Cinderella Information:
                </strong>

                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server"
                     ControlToValidate="FirstTextBox"
                     ErrorMessage="First Name is required!"><font color="red">*Please enter a first name!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3" >
                    *First Name:</td>
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
                <td class="auto-style3">
                    *Last Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                 <asp:RequiredFieldValidator ID="PhoneNumberValidator" runat="server"
                     ControlToValidate="PhoneNumberTextBox"
                     ErrorMessage="Phone Number is required!"><font color="red">*Please enter a Phone Number!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    *Phone Number:</td>
                <td class="TableInputCell"><asp:TextBox ID="PhoneNumberTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="EmailValidator" runat="server"
                     ControlToValidate="EmailTextBox"
                     ErrorMessage="Email is required!"><font color="red">*Please enter an Email!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    *Email:</td>
                <td class="TableInputCell"><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style3">
                    Appointment Date:</td>
                <td class="TableInputCell">

                    <asp:Calendar ID="appointmentSelectDateCalender" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>     
                <td><!-- Spacing. --></td>
                <asp:RegularExpressionValidator ID="rev"
                    runat="server" ErrorMessage="Appointment Time must be  valid time! (E.g. 3:45)" 
                    ControlToValidate="AppTimeTextBox0"
                    ValidationExpression="^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$">
                </asp:RegularExpressionValidator>
                <td class="auto-style3">
                    Appointment Time:</td>
                <td class="TableInputCell"><asp:TextBox ID="AppTimeTextBox0" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td></td>
            </tr>
             <tr>
                <td colspan="2" class="auto-style1">
                    <strong>Referral Information:</strong>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style1"><em>*Cinderella must have a referral</em></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:RadioButton ID="ExistingReferralRadioButton" runat="server" Text="Existing Referral" GroupName="Referrals" OnCheckedChanged="ExistingReferralRadioButton_CheckedChanged" />
                </td>
                <td>
                    <asp:RadioButton ID="NewReferralRadioButton" runat="server" Text="New Referral" GroupName="Referrals" OnCheckedChanged="NewReferralRadioButton_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style3" >
                    Existing Referral:</td>
                <td class="TableInputCell">
                    <asp:DropDownList ID="ExistingReferralDropDownList" runat="server" Enabled="False">
                        <asp:ListItem>All Existing Referrals</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="NewReferalFirstNameValidator" runat="server"
                     ControlToValidate="NewReferralFirstNameTextBox"
                     ErrorMessage="Referral First Name is required!"><font color="red">*Please enter a referral first name!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    New Referral First Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewReferralFirstNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="NewReferalLastNameValidator" runat="server"
                     ControlToValidate="NewReferralLastNameTextBox"
                     ErrorMessage="Referral Last Name is required!"><font color="red">*Please enter a referral Last name!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    New Referral Last Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewReferralLastNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="NewReferalPhoneValidator" runat="server"
                     ControlToValidate="NewReferralPhoneTextBox"
                     ErrorMessage="Referral Phone Number is required!"><font color="red">*Please enter a referral phone number!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    New Referral Phone Number:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewReferralPhoneTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="NewReferalEmailValidator" runat="server"
                     ControlToValidate="NewReferralEmailTextBox"
                     ErrorMessage="Referral Email is required!"><font color="red">*Please enter a referral Email!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    New Referral Email:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewReferralEmailTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:RequiredFieldValidator ID="NewSchoolAgengyValidator" runat="server"
                     ControlToValidate="NewSchoolAgencyTextBox"
                     ErrorMessage="Referral School/Agency is required!"><font color="red">*Please enter a referral school/agency!</font>
                     </asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    &nbsp;New Referral School/Agency:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewSchoolAgencyTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td class="auto-style3">
                    Notes:</td>
                <td class="TableInputCell">
                    <asp:TextBox ID="ReferralNotesTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="RegisterCinderellaButton" runat="server" Text="Register" OnClick="RegisterCinderellaButton_Click1" />
                </td>
            </tr>
        </table>
            
</form>
</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1
        {
            text-align: left;
        }
        .auto-style2
        {
            width: 443px;
        }
        .auto-style3
        {
            width: 443px;
            text-align: right;
        }
        #TextArea1
        {
            height: 93px;
            width: 180px;
        }
    </style>
</asp:Content>
