<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PackageCheckout.aspx.cs" Inherits="Forms_UserForms_ChildForms_PackageCheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Package Checkout</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        <div style ="height:600px; width:1345px; overflow:auto;">
            <asp:GridView ID="CinderellaPackageGridView" runat="server" 
                AllowSorting="True" 
                AutoGenerateColumns="False" 
                DataSourceID="Cinderella2015"
                DataKeyNames ="Cinderella_ID">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="DressSize" HeaderText="Dress Size" SortExpression="DressSize" />
                    <asp:BoundField DataField="DressLength" HeaderText="Dress Length" SortExpression="DressLength" />
                    <asp:BoundField DataField="DressColor" HeaderText="Dress Color" SortExpression="DressColor" />
                    <asp:BoundField DataField="ShoeSize" HeaderText="Shoe Size" SortExpression="ShoeSize" />
                    <asp:BoundField DataField="ShoeColor" HeaderText="Shoe Color" SortExpression="ShoeColor" />
                    <asp:BoundField DataField="Necklace" HeaderText="Necklace" SortExpression="Necklace" />
                    <asp:BoundField DataField="Ring" HeaderText="Ring" SortExpression="Ring" />
                    <asp:BoundField DataField="Bracelet" HeaderText="Bracelet" SortExpression="Bracelet" />
                    <asp:BoundField DataField="Headpiece" HeaderText="Headpiece" SortExpression="Headpiece" />
                    <asp:BoundField DataField="Earrings" HeaderText="Earrings" SortExpression="Earrings" />
                    <asp:BoundField DataField="Other" HeaderText="Other" SortExpression="Other" />
                </Columns>
                <SelectedRowStyle BackColor="Fuchsia" />
            </asp:GridView>
            <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                SelectCommand="SELECT [Cinderella_ID],
                                        [LastName],
                                        [FirstName],
                                        [DressSize],
                                        [DressLength],
                                        [DressColor],
                                        [ShoeSize],
                                        [ShoeColor],
                                        [Necklace],
                                        [Ring],
                                        [Bracelet],
                                        [Headpiece],
                                        [Earrings],
                                        [Other]
                                FROM [Package] 
                                INNER JOIN Cinderella 
                                     ON Package.Cinderella_ID = Cinderella.CinderellaID 
                                WHERE InPackaging = 'Y'
                                ORDER BY [LastName]"></asp:SqlDataSource>
        </div>
        <p>
            <asp:label runat="server" Visible =" false" ForeColor="Red" ID="SelectionValidationLabel">*Please select a Cinderella's Package</asp:label><br />
            <asp:Button ID="CheckOutButton" runat="server" Text="Check-Out Package" OnClick="CheckOutButton_Click" />
        </p>
</asp:Content>

