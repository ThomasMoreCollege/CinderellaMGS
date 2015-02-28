<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageVolunteerRoles.aspx.cs" Inherits="Forms_AdminForms_ChildForms_ManageVolunteerRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        <div id="AddAcctTable" style="width: 86%; float: left; height: 397px;">
            <table id="NewUserTable" style="width: 100%;">
                <tr>
                        <td class="auto-style3">
                            <strong>Manage Volunteer Roles:</strong>
                        </td>
                </tr>
                <tr>
                    <td>
                    <asp:ListBox ID="VolunteerNamesListBox" runat="server" DataSourceID="VolunteerDS" DataTextField="LastName" DataValueField="LastName" Height="145px" Width="158px" OnSelectedIndexChanged="VolunteerNamesListBox_SelectedIndexChanged"></asp:ListBox>
                    <asp:SqlDataSource ID="VolunteerDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT [LastName] FROM [Volunteer]"></asp:SqlDataSource>
                    </td>
                    <td>
                        Default value is the current volunteer role.
                        <asp:DropDownList ID="VolunteerRolesDropDownList" runat="server" DataSourceID="VolunteerRolesDS" DataTextField="RoleName" DataValueField="RoleName" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="VolunteerRolesDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT RoleName FROM RoleType WHERE (RoleName &lt;&gt; 'Administrator') AND (RoleName &lt;&gt; 'Pairing')"></asp:SqlDataSource>
                    </td>
               </tr>
                <tr>
                    <td>
                     <asp:Button ID="changeRoleButton" runat="server" Text="Change Role" />
                    </td>
                </tr>
                </table>
                </div>
    </form>
</asp:Content>

