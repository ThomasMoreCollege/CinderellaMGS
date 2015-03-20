<%@ Page Title="" 
    Language="C#" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" 
    CodeFile="CinderellaCheckin.aspx.cs" 
    Inherits="Forms_CinderellaCheckin" %>

<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>Cinderella Check-In</h2>
</asp:Content>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
        <table>
            <tr forecolor="Green">
                <td>
                    <asp:Label ID="SuccessLabel" runat="server" Text="Label" ForeColor="Green" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <p>
            <asp:Button ID="CheckInButton" runat="server" OnClick="CheckInButton_Click" Text="Check-In" Width="70px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="needsManualPairingCheckBox" runat="server" Enabled="False" Text="Cinderella Needs Manual Pairing" />
        </p>
        <div style ="height:600px; width:80%; overflow:auto;">
            <asp:GridView ID="CinderellaGridView" runat="server" 
                AllowSorting="True" 
                AutoGenerateColumns="False" 
                DataSourceID="Cinderella2015" 
                DataKeyNames="CinderellaID" OnSelectedIndexChanged="CinderellaGridView_SelectedIndexChanged" ForeColor="Black">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="AppointmentDateTime" HeaderText="Appointment Time" SortExpression="AppointmentDateTime" />
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
            <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                SelectCommand="SELECT [CinderellaID], 
                                        [LastName], 
                                        [FirstName], 
                                        [AppointmentDateTime] 
                                FROM [Cinderella] 
                                INNER JOIN CinderellaStatusRecord 
                                    ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID 
                                WHERE Status_Name = 'Pending' AND IsCurrent = 'Y'
                                ORDER BY [AppointmentDateTime]">
            </asp:SqlDataSource>
        </div>

</asp:Content>

