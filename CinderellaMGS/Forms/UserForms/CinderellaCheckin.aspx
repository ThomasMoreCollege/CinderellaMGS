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

    <form id="form1" runat="server">
        
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
                                WHERE Status_Name = 'Pending' AND IsCurrent = 'Y'
                                ORDER BY [AppointmentDateTime]"></asp:SqlDataSource>
        </div>

        <p>
            <asp:Button ID="CheckInButton" runat="server" OnClick="CheckInButton_Click" Text="Check-In" Width="70px" />
        </p>
    </form>

</asp:Content>

