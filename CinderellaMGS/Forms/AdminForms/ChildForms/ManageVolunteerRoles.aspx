<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageVolunteerRoles.aspx.cs" Inherits="Forms_AdminForms_ChildForms_ManageVolunteerRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <table id="NewUserTable" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="dropDownLabel" runat="server" Text="Select a Role:"></asp:Label>&nbsp;&nbsp;
                    <asp:DropDownList ID="roleDropDownList" runat="server" AutoPostBack="True" DataValueField="&quot;
                        SELECT RoleType.RoleName 
                        FROM RoleType 
                        WHERE RoleType.RoleName &lt;&gt; 'Administrator' AND RoleType.RoleName &lt;&gt; (SELECT RoleType.RoleName 
                                                                                                        FROM RoleType INNER JOIN VolunteerRoleRecord ON RoleType.RoleName = VolunteerRoleRecord.Role_Name INNER JOIN Volunteer ON VolunteerRoleRecord.Volunteer_ID = Volunteer.VolunteerID WHERE VolunteerRoleRecord.IsCurrent = 'Y' AND Volunteer.LastName = '&quot; + volunteerListBox.SelectedItem.Text + &quot;')&quot;" Enabled="False" OnSelectedIndexChanged="roleDropDownList_SelectedIndexChanged1">
                        <asp:ListItem Text="Select Role" Value="0" />
                    </asp:DropDownList>
                &nbsp;&nbsp;
                    <asp:Button ID="changeRoleButton" runat="server" Text="Change Role" OnClick="changeRoleButton_Click" Enabled="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="userNotificationLabel" runat="server" Enabled="False" BorderColor="Lime"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <strong>Manage Volunteer Roles:</strong>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="VolunteerDisplayDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" 
                    SelectCommand="SELECT Volunteer.VolunteerID, Volunteer.LastName, Volunteer.FirstName, VolunteerRoleRecord.Role_Name 
                                    FROM Volunteer 
                                    INNER JOIN VolunteerRoleRecord 
                                        ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID
                                    INNER JOIN VolunteerStatusRecord
                                        ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID
                                    WHERE VolunteerRoleRecord.IsCurrent = 'Y'
	                                    AND VolunteerRoleRecord.Role_Name != 'Alterations'
	                                    AND Volunteer.IsValid = 'Y' 
	                                    AND (Status_Name = 'Ready' OR Status_Name = 'On Break') 
	                                    AND VolunteerStatusRecord.IsCurrent = 'Y'
                                    GROUP BY  Volunteer.VolunteerID, Volunteer.LastName, Volunteer.FirstName, VolunteerRoleRecord.Role_Name">
                </asp:SqlDataSource>
                <div style="height: 300px; width: 600px; overflow: auto;">
                    <asp:GridView ID="VolunteerGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="VolunteerID" DataSourceID="VolunteerDisplayDS" AllowSorting="True" ForeColor="Black" OnSelectedIndexChanged="VolunteerGridView_SelectedIndexChanged1">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="VolunteerID" HeaderText="Volunteer ID" InsertVisible="False" ReadOnly="True" SortExpression="VolunteerID" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                            <asp:BoundField DataField="Role_Name" HeaderText="Current Role" SortExpression="Role_Name" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                        <AlternatingRowStyle BackColor="pink" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="NOTE: Only Volunteers on break or ready to receive a Cinderella" ></asp:Label></td>
        </tr>
                <tr>
            <td><asp:Label ID="Label2" runat="server" Text="(but NOT currently shopping or paired with a Cinderella) will be shown" ></asp:Label></td>
        </tr>
    </table>

</asp:Content>

