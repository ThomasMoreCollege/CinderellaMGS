<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestPage.aspx.cs" Inherits="Forms_UserForms_TestPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Test Page</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:GridView ID="CinderellaGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="CinderellasToBeQueuedSqlDataSource" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="VolunteerGridView_SelectedIndexChanged">

                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="CinderellaID" HeaderText="CinderellaID" InsertVisible="False" ReadOnly="True" SortExpression="CinderellaID" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="AppointmentDateTime" HeaderText="AppointmentDateTime" SortExpression="AppointmentDateTime" />
                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" />
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
                <asp:SqlDataSource ID="CinderellasToBeQueuedSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Cinderella.CinderellaID, Cinderella.FirstName, Cinderella.LastName, Cinderella.AppointmentDateTime, CinderellaStatusRecord.StartTime FROM Cinderella INNER JOIN CinderellaStatusRecord ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID WHERE (CinderellaStatusRecord.Status_Name = 'Waiting for Godmother') AND (CinderellaStatusRecord.EndTime IS NULL) AND (CinderellaStatusRecord.IsCurrent = 'Y')"></asp:SqlDataSource>
            </td>
            
        </tr>

        <tr>
            <td>

                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonPop" runat="server" Text="Pop" OnClick="ButtonPop_Click" />
            &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Number of Cinderellas in Queue:&nbsp;&nbsp;<asp:Label ID="NumofCinLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Cinderella in front:&nbsp;&nbsp;<asp:Label ID="FrontCinLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>

