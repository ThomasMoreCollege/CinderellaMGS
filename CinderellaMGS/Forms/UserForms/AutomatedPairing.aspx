<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AutomatedPairing.aspx.cs" Inherits="Forms_UserForms_AutomatedPairing" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Automated Pairings</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        <table id="AutoPairTable">
            <tr>
                <asp:GridView ID="GridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="AutomattedPairingSqlDataSource">
                    <Columns>
                        <asp:BoundField DataField="Cinderella" HeaderText="Cinderella" ReadOnly="True" SortExpression="Cinderella" />
                        <asp:BoundField DataField="Column1" ReadOnly="True" SortExpression="Column1">
                        <ItemStyle Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Volunteer" HeaderText="Volunteer" ReadOnly="True" SortExpression="Volunteer" />
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
                <asp:SqlDataSource ID="AutomattedPairingSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Cinderella.FirstName + ' ' + Cinderella.LastName AS Cinderella, 'Is Paired With', Volunteer.FirstName + ' ' + Volunteer.LastName AS Volunteer FROM Cinderella INNER JOIN Volunteer ON Cinderella.Volunteer_ID = Volunteer.VolunteerID INNER JOIN CinderellaStatusRecord ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID WHERE (Cinderella.Volunteer_ID IS NOT NULL) AND (CinderellaStatusRecord.Status_Name = 'Paired') AND (CinderellaStatusRecord.IsCurrent = 'Y')"></asp:SqlDataSource>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

                </td>
            </tr>
        </table>
</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #form1 {
            height: 480px;
        }
    </style>
</asp:Content>


