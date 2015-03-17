<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlteredDressReady.aspx.cs" Inherits="Forms_UserForms_ChildForms_AlteredDressReady" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Mark Dresses as Ready for Pickup</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="DressesInAlterations" style="height: 400px; overflow: auto; overflow-x:hidden;">
        <asp:GridView ID="CinderellaDressAlterationsGridView" runat="server"
            AllowSorting="True"
            AutoGenerateColumns="False"
            DataSourceID="PackageDataSource"
            DataKeyNames="CinderellaID" ForeColor="Black" OnSelectedIndexChanged="CinderellaDressAlterationsGridView_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                <asp:BoundField DataField="DressSize" HeaderText="Dress Size" SortExpression="DressSize" />
                <asp:BoundField DataField="DressColor" HeaderText="Dress Color" SortExpression="DressColor" />
                <asp:BoundField DataField="DressLength" HeaderText="Dress Length" SortExpression="DressLength" />
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
        <asp:SqlDataSource ID="PackageDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
            SelectCommand="SELECT [CinderellaID], 
                                        [LastName], 
                                        [FirstName],
                                        [DressSize],
                                        [DressColor],
                                        [DressLength]
                                FROM [Cinderella] 
                                INNER JOIN Package 
                                    ON Cinderella.CinderellaID = Package.Cinderella_ID
                                INNER JOIN Alteration
                                    ON Cinderella.CinderellaID = Alteration.Cinderella_ID
                                WHERE InAlterations = 'Y' AND ReadyForPickup = 'N'
                                ORDER BY [LastName]">
        </asp:SqlDataSource>
    </div>

    <p>
        <asp:Button ID="MarkDressAsReadyButton" runat="server" Text="Ready for Pickup" Enabled="False" OnClick="MarkDressAsReadyButton_Click" />
    </p>
</asp:Content>

