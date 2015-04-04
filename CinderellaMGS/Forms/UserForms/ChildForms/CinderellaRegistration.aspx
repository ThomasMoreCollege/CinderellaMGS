<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CinderellaRegistration.aspx.cs" Inherits="Forms_UserForms_CinderellaRegistration" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Cinderella Registration</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="errorLabel" headertext="There were errors on the page:" />
        <table style="width:70%;" id="RegistrationTable">

            <tr>
                <td colspan="3" class="auto-style1">

                    <strong>Cinderella Information:
                    <br />
                    <br />
                </strong><em>*Required Fields</em></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style3" >
                    *First Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="FirstTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server"
                     ControlToValidate="FirstTextBox"
                     ErrorMessage="First Name is required!" Display="Dynamic"><font color="red">Please enter a first name.</font>
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style3">
                    *Last Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="LastNameValidator" runat="server"
                     ControlToValidate="LastNameTextBox"
                     ErrorMessage="Last Name is required!" Display="Dynamic"><font color="red">Please enter a last name.</font>
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style3">
                    Email:</td>
                <td class="TableInputCell"><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="EmailExpressionValidator" runat="server" ErrorMessage="Please enter a valid email address." Display="Dynamic" ForeColor="Red" ControlToValidate="EmailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style3">
                    Phone Number:</td>
                <td class="TableInputCell"><asp:TextBox ID="PhoneNumberTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="PhoneExpressionValidator" runat="server" Display="Dynamic" ErrorMessage="Phone number must be 7 to 10 digits long (dash seperated)." ForeColor="Red" ControlToValidate="PhoneNumberTextBox" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style4">Manually Paired:</td>
                <td>
                    <asp:RadioButton ID="YesRadioButton" runat="server" GroupName="ManuallyPaired" Text="Yes" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:RadioButton ID="NoRadioButton" runat="server" Checked="True" GroupName="ManuallyPaired" Text="No" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style3">
                    Appointment Date:</td>
                <td class="TableInputCell">

                    <asp:Calendar ID="appointmentSelectDateCalender" runat="server" OnSelectionChanged="appointmentSelectDateCalender_SelectionChanged" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" AutoPostBack="False">
                         <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="Pink" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:CustomValidator ID="dateCustVal" OnServerValidate="DateCustVal_Validate" runat="server" ErrorMessage="Please select a date." Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                </td>
            </tr>
            <tr>     
                <td><!-- Spacing. --></td>
                
                <td class="auto-style3">
                    Appointment Time:</td>
                <td class="TableInputCell">
                    <asp:DropDownList ID="ddlStartTimeHr" runat="server" CssClass="DropDown" Width="44px" >
                        <asp:ListItem Text="1" Value="1" Selected="True" />
                        <asp:ListItem Text="2" Value="2" />
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="4" Value="4" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="6" Value="6" />
                        <asp:ListItem Text="7" Value="7" />
                        <asp:ListItem Text="8" Value="8" />
                        <asp:ListItem Text="9" Value="9" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="11" Value="11" />
                        <asp:ListItem Text="12" Value="12" />
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlStartTimeMin" runat="server" CssClass="DropDown" Width="44px" >
                        <asp:ListItem Text="00" Value="00" Selected="True" />
                        <asp:ListItem Text="05" Value="05" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="15" Value="15" />
                        <asp:ListItem Text="20" Value="20" />
                        <asp:ListItem Text="25" Value="25" />
                        <asp:ListItem Text="30" Value="30" />
                        <asp:ListItem Text="35" Value="35" />
                        <asp:ListItem Text="40" Value="40" />
                        <asp:ListItem Text="45" Value="45" />
                        <asp:ListItem Text="50" Value="50" />
                        <asp:ListItem Text="55" Value="55" />
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlStartTimeAMPM" runat="server" CssClass="DropDown" Width="44px" >
                        <asp:ListItem Text="AM" Value="AM" Selected="True" />
                        <asp:ListItem Text="PM" Value="PM" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <br />
                </td>
                <td></td>
                <td></td>
            </tr>
             <tr>
                <td colspan="3" class="auto-style1">
                    <strong>Referral Information:</strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="auto-style1"><em>Note: Cinderellas must have a referral</em></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButton ID="ExistingReferralRadioButton" runat="server" AutoPostBack="True" GroupName="ReferralGroup" OnCheckedChanged="ExistingReferralRadioButton_CheckedChanged" Text="Existing Referral " />
                </td>
                <td>
                    <asp:RadioButton ID="NewReferralRadioButton" runat="server" AutoPostBack="True" GroupName="ReferralGroup" OnCheckedChanged="NewReferralRadioButton_CheckedChanged" Text="New Referral" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style3" >
                    Existing Referral:</td>
                <td class="TableInputCell">
                    <asp:DropDownList ID="referralDropDownList" runat="server" DataSourceID="ReferralDS" DataTextField="Agency" DataValueField="Agency" BackColor="LightGray">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="ReferralDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString2 %>" SelectCommand="SELECT [Agency] FROM [Referrals]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style3">
                    *New Referral First Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewReferralFirstNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="NewReferalFirstNameValidator" runat="server"
                     ControlToValidate="NewReferralFirstNameTextBox"
                     ErrorMessage="Referral First Name is required!" Display="Dynamic"><font color="red">Please enter a referral first name.</font>
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style3">
                    *New Referral Last Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewReferralLastNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="NewReferalLastNameValidator" runat="server"
                     ControlToValidate="NewReferralLastNameTextBox"
                     ErrorMessage="Referral Last Name is required!" Display="Dynamic"><font color="red">Please enter a referral last name.</font>
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style3">
                    *New Referral Phone Number:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewReferralPhoneTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="NewReferalPhoneValidator" runat="server"
                     ControlToValidate="NewReferralPhoneTextBox"
                     ErrorMessage="Referral Phone Number is required!" Display="Dynamic"><font color="red">Please enter a referral phone number.</font>
                     </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="Phone number must be 7 to 10 digits long (dash seperated)." ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ControlToValidate="NewReferralPhoneTextBox"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style3">
                    *New Referral Email:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewReferralEmailTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="NewReferalEmailValidator" runat="server"
                     ControlToValidate="NewReferralEmailTextBox"
                     ErrorMessage="Referral Email is required!" Display="Dynamic"><font color="red">Please enter a referral Email.</font>
                     </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ErrorMessage="Please enter a valid email." ForeColor="Red" ControlToValidate="NewReferralEmailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;*New Referral School/Agency:</td>
                <td class="TableInputCell"><asp:TextBox ID="NewSchoolAgencyTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="NewSchoolAgengyValidator" runat="server"
                     ControlToValidate="NewSchoolAgencyTextBox"
                     ErrorMessage="Referral School/Agency is required!" Display="Dynamic"><font color="red">Please enter a referral school/agency.</font>
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td class="auto-style3">
                    Notes:</td>
                <td class="TableInputCell">
                    <asp:TextBox ID="ReferralNotesTextBox" runat="server" Height="107px" TextMode="MultiLine" Width="301px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="RegisterCinderellaButton" runat="server" Text="Register" OnClick="RegisterCinderellaButton_Click1" OnClientClick="javascript:window.scrollTo(0,0);"/>
                </td>
            </tr>
        </table>
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
        .auto-style4 {
            text-align: right;
        }
    </style>
</asp:Content>
