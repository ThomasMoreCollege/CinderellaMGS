<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddAccount.aspx.cs" Inherits="Forms_AdminForms_ChildForms_AddAccount" %>


<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Add Account</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
            <div id="AddAcctTable" style="width: 40%; float: left;">
                <table id="NewUserTable" style="width: 100%;">
                    <tr>
                        <td colspan="2" class="auto-style3">
                            <strong>Create New Account:</strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">*New Username:</td>
                        <td >
                            <asp:TextBox ID="NewUserNameTextBox" runat="server" OnTextChanged="NewUserNameTextBox_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="UserNameErrorLabel" runat="server" ForeColor="Red" Text="Label" Visible="False" CssClass="auto-style4"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Username is required." ForeColor="Red" style="font-size: small" ControlToValidate="NewUserNameTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" >*Password:</td>
                        <td >
                            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" OnTextChanged="PasswordTextBox_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="A password is required." ForeColor="Red" CssClass="auto-style4" ControlToValidate="PasswordTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PasswordTextBox" Display="Dynamic" ErrorMessage="Password must be at least eight characters and/or numbers long." ForeColor="Red" style="font-size: small" ValidationExpression="^[a-zA-Z0-9]{8,}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" >*Confirm Password:</td>
                        <td >
                            <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password" OnTextChanged="ConfirmPasswordTextBox_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match." ForeColor="Red" style="font-size: small" ControlToCompare="PasswordTextBox" ControlToValidate="ConfirmPasswordTextBox" Display="Dynamic"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" >*Account Type:</td>
                        <td rowspan="5">
                            <asp:RadioButtonList ID="AccountTypesRadioButtonList" runat="server">
                                <asp:ListItem>Administrator</asp:ListItem>
                                <asp:ListItem>Standard</asp:ListItem>
                                <asp:ListItem>Pairing</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>

                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="auto-style6"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="AccountTypesRadioButtonList" ErrorMessage="Account type must be selected." ForeColor="Red" style="font-size: small" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="auto-style5" ></td>
                        <td >
                            <asp:Button ID="CreateAccButton" runat="server" Text="Create Account" Width="116px" OnClick="CreateAccButton_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="ExistingUsernamesTable" style="width: 40%; float: left;">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <strong>Existing Usernames:</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            
                            

                            <asp:ListBox ID="ExistingUserNamesListBox" runat="server" DataSourceID="ExistingUserNamesSqlDataSource" DataTextField="Username" DataValueField="Username" Height="167px" Width="146px"></asp:ListBox>
                            <asp:SqlDataSource ID="ExistingUserNamesSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Username] FROM [Accounts]"></asp:SqlDataSource>

                            
                            

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="AddedAccountLabel" runat="server" Text="Account Created Succesfully" ForeColor="#006600" style="font-weight: 700" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
    </form>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2
        {
            text-align: right;
            width: 165px;
        }
        .auto-style3
        {
            text-align: left;
        }
        .auto-style4 {
            font-size: small;
            text-align: justify;
        }
        .auto-style5 {
            width: 165px;
        }
        .auto-style6 {
            height: 28px;
        }
    </style>
</asp:Content>


