<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddAccount.aspx.cs" Inherits="Forms_AdminForms_ChildForms_AddAccount" %>


<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Add Account</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
            <div id="AddAcctTable" style="width: 40%; float: left;">
                <table id="NewUserTable">
                    <tr>
                        <td colspan="2" class="auto-style3">
                            <strong>Create New Account:</strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">*New Username:</td>
                        <td >
                            <asp:TextBox ID="NewUserNameTextBox" runat="server"></asp:TextBox>
                            <asp:Label ID="Label" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" >*Password:</td>
                        <td >
                            <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" >*Confirm Password:</td>
                        <td >
                            <asp:TextBox ID="ConfirmPasswordTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" >*Permissions:</td>
                        <td >
                            <asp:CheckBoxList ID="RolesCheckBoxList" runat="server" Style="font-size: small; text-align: left;" DataSourceID="RoleNameSqlDataSource" DataTextField="RoleName" DataValueField="RoleName">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="RoleNameSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [RoleName] FROM [RoleType]"></asp:SqlDataSource>
                        </td>

                    </tr>
                    <tr>
                        <td ></td>
                        <td >
                            <asp:Button ID="CreateAccButton" runat="server" Text="Create Account" Width="116px" OnClick="CreateAccButton_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="ExistingUsernamesTable" style="width: 40%; float: left;">
                <table>
                    <tr>
                        <td>
                            Existing Usernames:
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="ExistingUsernamesSqlDataSource" DataTextField="Username" DataValueField="Username" Height="143px" Width="131px"></asp:ListBox>
                            <asp:SqlDataSource ID="ExistingUsernamesSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Username] FROM [Accounts]"></asp:SqlDataSource>

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
        }
        .auto-style3
        {
            text-align: center;
        }
    </style>
</asp:Content>


