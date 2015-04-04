<%@ Page Title="" 
    Language="C#" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" 
    CodeFile="ManageAppointment.aspx.cs" 
    Inherits="Forms_UserForms_ManageAppointment" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Appointment Manager</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <th>Cinderella</th>
        </tr>
    </table>
    <div style ="height:400px; width:80%; overflow:auto; border-bottom:1px solid #999999;">
        <asp:Label ID="UserNotificationLabel" runat="server" Text="Label" Font-Bold="True" ForeColor="Green" Visible="False"></asp:Label>
        <table id="AppMngTable" style="width:70%;">
            <tr >
                <td>
                    <asp:GridView ID="CinderellaGridView" runat="server"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        DataSourceID="Cinderella2015"
                        DataKeyNames="CinderellaID" Width="409px" OnSelectedIndexChanged="CinderellaGridView_SelectedIndexChanged" ForeColor="Black">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="CinderellaID" HeaderText="Cinderella ID" SortExpression="CinderellaID" InsertVisible="False" ReadOnly="True" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                            <asp:BoundField DataField="AppointmentDateTime" HeaderText="Appointment_Date/Time" SortExpression="AppointmentDateTime" />
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
                    <asp:SqlDataSource ID="Cinderella2015" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [CinderellaID], [LastName], [FirstName], [AppointmentDateTime] FROM [Cinderella]"></asp:SqlDataSource>

                </td>
            </tr>

        </table>
    </div>
    <table id="AppMngTable2" style="width: 70%;">
        <tr>
            <th>New Appointment Date</th>
            <th>New Appointment Time</th>
        </tr>

        <tr>
            <td rowspan="7">
                <asp:Calendar ID="NewDateCalendar" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" AutoPostBack="False">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="Pink" />
                </asp:Calendar>
            </td>
            <td>
                <asp:DropDownList ID="ddlStartTimeHr" runat="server" CssClass="DropDown" Width="44px">
                    <asp:ListItem Text="1" Value="1" Selected="True" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" />
                    <asp:ListItem Text="6" Value="6" />
                    <asp:ListItem Text="7" Value="7" />
                    <asp:ListItem Text="8" Value="8" />
                    <asp:ListItem Text="9" Value="9" />
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="11" Value="11" />
                    <asp:ListItem Text="12" Value="12" />
                </asp:DropDownList>
                <asp:DropDownList ID="ddlStartTimeMin" runat="server" CssClass="DropDown" Width="44px">
                    <asp:ListItem Text="00" Value="0" Selected="True" />
                    <asp:ListItem Text="05" Value="05" />
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="15" Value="15" />
                    <asp:ListItem Text="20" Value="20" />
                    <asp:ListItem Text="25" Value="25" />
                    <asp:ListItem Text="30" Value="30" />
                    <asp:ListItem Text="35" Value="35" />
                    <asp:ListItem Text="40" Value="40" />
                    <asp:ListItem Text="45" Value="45" />
                    <asp:ListItem Text="50" Value="50" />
                    <asp:ListItem Text="55" Value="55" />
                </asp:DropDownList>
                <asp:DropDownList ID="ddlStartTimeAMPM" runat="server" CssClass="DropDown" Width="44px">
                    <asp:ListItem Text="AM" Value="AM" Selected="True" />
                    <asp:ListItem Text="PM" Value="PM" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>

                <asp:Button ID="ChangeAppointmentButton" runat="server" OnClick="ChangeAppointmentButton_Click" Text="Change Appointment Time" Enabled="False" OnClientClick="javascript:window.scrollTo(0,0);"/>

            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>

</asp:Content>


