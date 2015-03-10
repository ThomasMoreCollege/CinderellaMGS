<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestPage.aspx.cs" Inherits="Forms_UserForms_TestPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Test Page</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <div style ="height:600px; width:650px; overflow:auto;">
        <asp:GridView ID="CinderellaGridView" runat="server" 
            AllowSorting="True" 
            AutoGenerateColumns="False" 
            DataSourceID="Cinderella2015" 
            DataKeyNames="CinderellaID">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                <asp:BoundField DataField="AppointmentDateTime" HeaderText="Appointment Time" SortExpression="AppointmentDateTime" />
            </Columns>
            <SelectedRowStyle BackColor="Fuchsia" />
        </asp:GridView>
        <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
            SelectCommand="SELECT [CinderellaID], 
                                    [LastName], 
                                    [FirstName], 
                                    [AppointmentDateTime] 
                            FROM [Cinderella] 
                            INNER JOIN CinderellaStatusRecord 
                                ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID 
                            WHERE Status_Name = 'Waiting for Godmother' AND IsCurrent = 'Y'
                            ORDER BY [AppointmentDateTime]"></asp:SqlDataSource>
    </div>

    <p>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Grab Cinderella" />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </p>

</asp:Content>

