<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditAccount.aspx.cs" Inherits="Forms_AdminForms_ChildForms_EditAccount" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Edit Account</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
        <table id="EditAcctTable" style="width:85%;">
            <tr>
                <th rowspan="6" class="auto-style5"><asp:ListBox ID="CurrentAcctsListBox" runat="server" Height="166px" Width="147px" DataSourceID="AccountsToBeEdittedSqlDataSource" DataTextField="Username" DataValueField="Username" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                    <asp:SqlDataSource ID="AccountsToBeEdittedSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Username] FROM [Accounts]"></asp:SqlDataSource>
                </th>
                <th class="auto-style8"></th>
                <th class="auto-style4">Current Account Information:</th>
                <th></th>
                <th class="auto-style15">New Settings:</th>
                <th></th>
            </tr>
            <tr>
                <td class="auto-style9">Username:</td>
                <td class="auto-style12">
                    <asp:Label ID="UserNameLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:Button ID="EditUserNameButton" runat="server" Text="Edit" OnClick="EditUserNameButton_Click" CausesValidation="False" Enabled="False" />
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="NewUsernameTextBox" runat="server" CssClass="auto-style2" Enabled="False" BackColor="LightGray"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">
                    <asp:TextBox ID="HiddenTextBox1" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style11">
                    &nbsp;</td>
                <td class="auto-style13">
                    <asp:RequiredFieldValidator ID="NewUsernameRequiredFieldValidator" runat="server" ControlToValidate="NewUsernameTextBox" Display="Dynamic" Enabled="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="font-size: small">New username cannot be blank.</asp:RequiredFieldValidator>
                    <br />
                    <%--<asp:Label ID="UserNameErrorLabel" runat="server" ForeColor="Red" style="font-size: small" Text="Label" Visible="False"></asp:Label>--%>
                            <asp:Label ID="UserNameErrorLabel" runat="server" ForeColor="Red" style="font-size: small" Text="Label" Visible="False"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;Account Type:</td>
                <td class="auto-style12">
                    <asp:Label ID="CurrentAcctTypeLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:Button ID="EditAcctTypeButton" runat="server" Text="Edit" OnClick="EditAcctTypeButton_Click" CausesValidation="False" Enabled="False" />
                </td>
                <td rowspan="3" class="auto-style7">
                            <asp:RadioButtonList ID="NewAccountTypeRadioButtonList" runat="server" Enabled="False">
                                <asp:ListItem>Administrator</asp:ListItem>
                                <asp:ListItem>Standard</asp:ListItem>
                                <asp:ListItem>Pairing</asp:ListItem>
                            </asp:RadioButtonList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style10"></td>
                <td class="auto-style11"></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style10"></td>
                <td class="auto-style11"></td>
                <td></td>
            </tr>
            <tr id="PasswordBorder">
                <td>
                    
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td class="auto-style13">
                    <asp:Label ID="NewAcctTypeErrorLabel" runat="server" CssClass="auto-style14" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2" class="auto-style16"><strong style="text-align: center">Change Password:</strong></td>
                <td></td>
                <td class="auto-style7"></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="ChangePasswordButton" runat="server" CausesValidation="False" Enabled="False" OnClick="ChangePasswordButton_Click" Text="Change Password" />
                </td>
                <td></td>
                <td class="auto-style7"></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style16">Current Password:</td>
                <td>
                    <asp:TextBox ID="CurrentPasswordTextBox" runat="server" BackColor="LightGray" Enabled="False" TextMode="Password"></asp:TextBox>
                </td>
                <td></td>
                <td class="auto-style7"></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:RequiredFieldValidator ID="CurrentPasswordRequiredFieldValidator" runat="server" ControlToValidate="CurrentPasswordTextBox" Display="Dynamic" ErrorMessage="Current password is required." ForeColor="Red" style="font-size: small" Enabled="False"></asp:RequiredFieldValidator>
                    <asp:Label ID="InvalidPasswordLabel" runat="server" ForeColor="Red" style="font-size: small" Text="Label" Visible="False"></asp:Label>
                </td>
                <td></td>
                <td class="auto-style7"></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style16">New Password:</td>
                <td>
                    <asp:TextBox ID="NewPasswordTextBox" runat="server" BackColor="LightGray" Enabled="False" TextMode="Password" ></asp:TextBox>
                </td>
                <td></td>
                <td class="auto-style7"></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                            <asp:RequiredFieldValidator ID="NewPasswordRequiredFieldValidator" runat="server" ErrorMessage="New password cannot be empty." ForeColor="Red" CssClass="auto-style17" ControlToValidate="NewPasswordTextBox" Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NewPasswordRegularExpressionValidator" runat="server" ControlToValidate="NewPasswordTextBox" Display="Dynamic" ErrorMessage="New password must be at least eight characters and/or numbers long." ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{8,}$" CssClass="auto-style14" Enabled="False"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="DiffNewPasswordCompareValidator" runat="server" ControlToCompare="CurrentPasswordTextBox" ControlToValidate="NewPasswordTextBox" Display="Dynamic" ErrorMessage="Password cannot be the same as current password." ForeColor="Red" Operator="NotEqual" style="font-size: small"></asp:CompareValidator>
                        </td>
                <td></td>
                <td class="auto-style7"></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="auto-style16">Confirm Password:</td>
                <td>
                    <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" BackColor="LightGray" Enabled="False" TextMode="Password"></asp:TextBox>
                </td>
                <td></td>
                <td class="auto-style7"></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                            <asp:CompareValidator ID="NewPasswordCompareValidator" runat="server" ErrorMessage="Passwords do not match." ForeColor="Red" style="font-size: small" ControlToCompare="NewPasswordTextBox" ControlToValidate="ConfirmPasswordTextBox" Display="Dynamic"></asp:CompareValidator>
                        </td>
                <td></td>
                <td class="auto-style7"></td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Label ID="ChangedAccountLabel" runat="server" Text="Changes Saved Succesfully" ForeColor="#006600" Style="font-weight: 700" Visible="False"></asp:Label>

                </td>
                <td class="auto-style8"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11"></td>
                <td class="auto-style13">
                    <asp:Button ID="EditAccountFormButton" runat="server" Text="Save Changes" OnClick="EditAccountFormButton_Click" style="text-align: center" Enabled="False" />
                &nbsp;</td>
                <td><asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" CausesValidation="False" style="height: 26px" />
                </td>
            </tr>
        </table>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {            text-align: center;
        }
        .auto-style4 {
            width: 225px;
        }
        .auto-style5 {
            width: 157px;
        }
        .auto-style7 {
            width: 253px;
        }
        .auto-style8 {
            width: 120px;
        }
        .auto-style9
        {
            width: 120px;
            text-align: right;
        }
        .auto-style10
        {
            width: 161px;
        }
        .auto-style11
        {
            width: 44px;
        }
        .auto-style12
        {
            width: 161px;
            text-align: center;
        }
        .auto-style13
        {
            width: 253px;
            text-align: center;
        }
        .auto-style14
        {
            font-size: small;
        }
        .auto-style15
        {
            width: 253px;
            text-align: right;
        }
        .auto-style16 {
            text-align: right;
        }
        .auto-style17 {
            width: 225px;
            font-size: small;
        }
    </style>
</asp:Content>


