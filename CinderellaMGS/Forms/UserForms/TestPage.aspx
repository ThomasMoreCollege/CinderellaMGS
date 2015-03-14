<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestPage.aspx.cs" Inherits="Forms_UserForms_TestPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Test Page</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:GridView ID="CinderellaGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="CinderellasToBeQueuedSqlDataSource" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="VolunteerGridView_SelectedIndexChanged" DataKeyNames="VolunteerID">

                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="VolunteerID" HeaderText="VolunteerID" InsertVisible="False" ReadOnly="True" SortExpression="VolunteerID" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
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
                <asp:SqlDataSource ID="CinderellasToBeQueuedSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Volunteer.VolunteerID, Volunteer.FirstName, Volunteer.LastName FROM Volunteer INNER JOIN VolunteerStatusRecord ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID INNER JOIN VolunteerRoleRecord ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID WHERE (VolunteerStatusRecord.Status_Name = 'Ready') AND (VolunteerStatusRecord.IsCurrent = 'Y') AND (VolunteerRoleRecord.Role_Name = 'Godmother') AND (VolunteerRoleRecord.IsCurrent = 'Y')"></asp:SqlDataSource>
            </td>
            
        </tr>

        <tr>
            <td>

                Priority of Selected Cinderella:

                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonPop" runat="server" Text="Pop" OnClick="ButtonPop_Click" Width="37px" />
            &nbsp; &nbsp; &nbsp;<asp:Button ID="AddToFrontButton" runat="server" Text="Add to front" OnClick="AddToFrontButton_Click" />
               &nbsp; &nbsp; &nbsp; <asp:Button ID="RecalibrateButton" runat="server" Text="Recalibrate" OnClick="RecalibrateButton_Click" />
            </td>
        </tr>
        <tr>
            <td>

                <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>

            &nbsp;&nbsp;
                <asp:Button ID="SelectivePopButton" runat="server" OnClick="SelectivePopButton_Click" Text="SelectivePop" />

            </td>
        </tr>
        <tr>
            <td>
                Number of Volunteers in Queue:&nbsp;&nbsp;<asp:Label ID="NumofCinLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Volunteer in front:&nbsp;&nbsp;<asp:Label ID="FrontCinLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

