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
                            <asp:TextBox ID="NewUserNameTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="UserNameErrorLabel" runat="server" ForeColor="Red" Text="Label" Visible="False" CssClass="auto-style4"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" >*Password:</td>
                        <td >
                            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="Password1ErrorLabel" runat="server" ForeColor="Red" Text="Label" Visible="False" CssClass="auto-style4"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" >*Confirm Password:</td>
                        <td >
                            <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="Password2ErrorLabel" runat="server" ForeColor="Red" Text="Label" Visible="False" CssClass="auto-style4"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" >*Permissions:</td>
                        <td >
                            <asp:CheckBox ID="AdminCheckBox" runat="server" Text="Administrator" AutoPostBack="True" OnCheckedChanged="AdminCheckBox_CheckedChanged" />
                        </td>

                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:CheckBox ID="AlterationsCheckBox" runat="server" Text="Alterations" AutoPostBack="True" />

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:CheckBox ID="CheckInCheckBox" runat="server" Text="Check-In" AutoPostBack="True" />

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:CheckBox ID="CheckOutCheckBox" runat="server" Text="Check-Out" AutoPostBack="True" />

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:CheckBox ID="PairingCheckBox" runat="server" Text="Pairing" AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="PermissionsErrorLabel" runat="server" ForeColor="Red" Text="Label" Visible="False" CssClass="auto-style4"></asp:Label>
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
        }
        .auto-style5 {
            width: 165px;
        }
    </style>
</asp:Content>


