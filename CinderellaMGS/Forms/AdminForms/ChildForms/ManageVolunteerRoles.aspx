<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageVolunteerRoles.aspx.cs" Inherits="Forms_AdminForms_ChildForms_ManageVolunteerRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
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
                        <asp:SqlDataSource ID="VolunteerDisplayDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT Volunteer.Lastname
FROM Volunteer
	INNER JOIN VolunteerRoleRecord
		on Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID
WHERE VolunteerRoleRecord.isCurrent = 'Y'"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:Label ID="currentRoleTitleTextLabel" runat="server" Text="Current Volunteer Role:  "></asp:Label>
                        <asp:Label ID="currentRoleDisplay" runat="server" Text=" ---"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="dropDownLabel" runat="server" Text="Select a Role:"></asp:Label>
                        <asp:DropDownList ID="roleDropDownList" runat="server" AutoPostBack="True" DataValueField="&quot;SELECT RoleType.RoleName FROM RoleType WHERE RoleType.RoleName &lt;&gt; 'Administrator' AND RoleType.RoleName &lt;&gt; (SELECT RoleType.RoleName FROM RoleType INNER JOIN VolunteerRoleRecord ON RoleType.RoleName = VolunteerRoleRecord.Role_Name INNER JOIN Volunteer ON VolunteerRoleRecord.Volunteer_ID = Volunteer.VolunteerID WHERE VolunteerRoleRecord.IsCurrent = 'Y' AND Volunteer.LastName = '&quot; + volunteerListBox.SelectedItem.Text + &quot;')&quot;" Enabled="False" OnSelectedIndexChanged="roleDropDownList_SelectedIndexChanged1">
                         <asp:ListItem Text="Select Role" Value="0" />
                        </asp:DropDownList>
                    </td>
               </tr>
                <tr>
                    <td>
                     <asp:Button ID="changeRoleButton" runat="server" Text="Change Role" OnClick="changeRoleButton_Click" Enabled="False" />
                    </td>
                    <td>
                        <asp:Label ID="userNorificationLabel" runat="server" Enabled="False" BorderColor="Lime"></asp:Label>
&nbsp;</td>
                </tr>
                </table>
                </div>
</asp:Content>

