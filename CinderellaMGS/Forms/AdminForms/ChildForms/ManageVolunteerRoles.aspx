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
                        <asp:ListBox ID="volunteerListBox" runat="server" AutoPostBack="True" DataSourceID="VolunteerDisplayDS" DataTextField="LastName" DataValueField="LastName" Height="141px" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged" Width="165px"></asp:ListBox>
                        <asp:SqlDataSource ID="VolunteerDisplayDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT [LastName] FROM [Volunteer]"></asp:SqlDataSource>
                    </td>
                    <td>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="dropDownLabel" runat="server" Text="Select a Role:"></asp:Label>
                        <asp:DropDownList ID="roleDropDownList" runat="server" AutoPostBack="True" DataValueField="&quot;SELECT RoleType.RoleName FROM RoleType WHERE RoleType.RoleName &lt;&gt; 'Administrator' AND RoleType.RoleName &lt;&gt; (SELECT RoleType.RoleName FROM RoleType INNER JOIN VolunteerRoleRecord ON RoleType.RoleName = VolunteerRoleRecord.Role_Name INNER JOIN Volunteer ON VolunteerRoleRecord.Volunteer_ID = Volunteer.VolunteerID WHERE VolunteerRoleRecord.IsCurrent = 'Y' AND Volunteer.LastName = '&quot; + volunteerListBox.SelectedItem.Text + &quot;')&quot;">
                        </asp:DropDownList>
                    </td>
               </tr>
                <tr>
                    <td>
                     <asp:Button ID="changeRoleButton" runat="server" Text="Change Role" OnClick="changeRoleButton_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table>
                </div>
    </form>
</asp:Content>

