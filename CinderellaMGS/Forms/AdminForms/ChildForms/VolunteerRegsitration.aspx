<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VolunteerRegsitration.aspx.cs" Inherits="Forms_AdminForms_GodMotherRegsitration" %>


<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Volunteer Registration</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="SuccessLabel" runat="server" Font-Bold="True" ForeColor="Green" Text="Label" Visible="False"></asp:Label>
    <br />
    <script type="text/javascript">
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=SuccessLabel.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };
    </script>
    <br />
    <asp:Label ID="VolunteerInfoLabel" runat="server" Font-Bold="True" Font-Size="Large" Text="Volunteer Information:"></asp:Label>
        <br />
        <br />
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="errorLabel" headertext="There were errors on the page:" />
        <table style="width:50%;" id="VolunteerInfoTable">
            <tr>
                <td class="auto-style3" >
                    *First Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="FirstTextBox" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server"
                     ControlToValidate="FirstTextBox"
                     ErrorMessage="First Name is required!" Display="Dynamic"><font color="red">Please enter a first name!</font>
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    *Last Name:</td>
                <td class="TableInputCell"><asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="LastNameValidator" runat="server"
                     ControlToValidate="LastNameTextBox"
                     ErrorMessage="Last Name is required!" Display="Dynamic"><font color="red">Please enter a last name!</font>
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    *Email:</td>
                <td class="TableInputCell"><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                 <asp:RequiredFieldValidator ID="EmailValidator" runat="server"
                     ControlToValidate="EmailTextBox"
                     ErrorMessage="Email is required!" Display="Dynamic"><font color="red">Please enter an Email!</font>
                     </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Must be a valid e-mail address." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailTextBox" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    Phone:</td>
                <td class="TableInputCell"><asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator ID="PhoneRegularExpressionValidator" runat="server" ErrorMessage="Phone number must be 7 to 10 digits long (dash seperated)." ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ControlToValidate="PhoneTextBox" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    Address:</td>
                <td class="TableInputCell">

                    <asp:TextBox ID="AddresstextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    City:</td>
                <td class="TableInputCell"><asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    State:</td>
                <td class="TableInputCell"><asp:TextBox ID="StateTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    Zip Code:</td>
                <td class="TableInputCell"><asp:TextBox ID="ZipCodeTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                
                <td>
                    <asp:RegularExpressionValidator ID="ZipCodeRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid US zipcode." ForeColor="Red" ValidationExpression="\d{5}(-\d{4})?" ControlToValidate="ZipCodeTextBox" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Role For Friday:</td>
                <td>
                    <asp:DropDownList ID="FridayRolesDropDownList" runat="server">
                        <asp:ListItem>Alterations</asp:ListItem>
                        <asp:ListItem>Check-In</asp:ListItem>
                        <asp:ListItem>Check-Out</asp:ListItem>
                        <asp:ListItem>Not Volunteering</asp:ListItem>
                        <asp:ListItem>Personal Shopper</asp:ListItem>
                        <asp:ListItem>Undecided</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style3">Role For Saturday:</td>
                <td>
                    <asp:DropDownList ID="SaturdayRolesDropDownList" runat="server">
                        <asp:ListItem>Alterations</asp:ListItem>
                        <asp:ListItem>Check-In</asp:ListItem>
                        <asp:ListItem>Check-Out</asp:ListItem>
                        <asp:ListItem>Not Volunteering</asp:ListItem>
                        <asp:ListItem>Personal Shopper</asp:ListItem>
                        <asp:ListItem>Undecided</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="TableInputCell">
                    <asp:Button ID="RegisterFormButton" runat="server" Text="Register" OnClick="RegisterFormButton_Click" OnClientClick="javascript:window.scrollTo(0,0);"/>
                </td>
            </tr>
        </table>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {
            font-size: small;
            text-align: right;
        }
        .auto-style3 {
            text-align: right;
        }
    </style>
</asp:Content>


