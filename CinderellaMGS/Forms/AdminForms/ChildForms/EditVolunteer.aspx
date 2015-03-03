<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditVolunteer.aspx.cs" Inherits="Forms_AdminForms_ChildForms_EditVolunteer" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Edit Volunteer</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">        
        <table id="EditVolunTable" style="width:100%;">
            <tr>
                <th >
                    
                    <asp:Label ID="SuccessLabel" runat="server" Text="Update Successful!" ForeColor="#009900" style="font-weight: 700" Visible="False"></asp:Label>
                    
                </th>
                <th class="auto-style11"></th>
                <th class="auto-style4">Current Information:</th>
                <th>New Information:</th>
            </tr>
            <tr>
                <td rowspan="16" class="auto-style5">
                    <asp:GridView ID="VolunteerGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="VolunteersToBeEdittedSqlDataSource" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="VolunteerGridView_SelectedIndexChanged" DataKeyNames="VolunteerID">
                        <AlternatingRowStyle BackColor="pink" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="VolunteerID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="VolunteerID" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="HotPink" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="VolunteersToBeEdittedSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [VolunteerID], [LastName], [FirstName] FROM [Volunteer]"></asp:SqlDataSource>
                </td>
                <td class="auto-style14">First Name:</td>
                <td class="auto-style16">
                    <asp:Label ID="FirstNameLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="auto-style2" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style4"></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style14">Last Name:</td>
                <td class="auto-style16">
                    <asp:Label ID="LastNameLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="LastNameTextBox" runat="server" CssClass="auto-style2" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style4"></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style14">Email: </td>
                <td class="auto-style16">
                    <asp:Label ID="EmailLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="EmailTextBox" runat="server" CssClass="auto-style2" Enabled="False" OnTextChanged="EmailTextBox_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style4"></td>
                <td>
                    <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server" ControlToValidate="EmailTextBox" CssClass="auto-style2" Display="Dynamic" Enabled="False" ErrorMessage="Must use a valid email address." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">Phone: </td>
                <td class="auto-style16">
                    <asp:Label ID="PhoneLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="auto-style2" Enabled="False" OnTextChanged="PhoneTextBox_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style4"></td>
                <td>
                    <asp:RegularExpressionValidator ID="PhoneRegularExpressionValidator" runat="server" ControlToValidate="PhoneTextBox" CssClass="auto-style2" Display="Dynamic" Enabled="False" ErrorMessage="Phone number must be 7 to 10 digits long (dash seperated)." ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">Address: </td>
                <td class="auto-style16">
                    <asp:Label ID="AddressLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="AddressTextBox" runat="server" CssClass="auto-style2" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style4"></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style10">City: </td>
                <td class="auto-style8">
                    <asp:Label ID="CityLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="CityTextBox" runat="server" CssClass="auto-style2" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style4"></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style14">State: </td>
                <td class="auto-style6">
                    <asp:Label ID="StateLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="StateTextBox" runat="server" CssClass="auto-style2" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style4"></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style14">Zip Code: </td>
                <td class="auto-style16">
                    <asp:Label ID="ZipcodeLabel" runat="server" Text="--"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="ZipcodeTextBox" runat="server" CssClass="auto-style2" Enabled="False" OnTextChanged="ZipcodeTextBox_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style4"></td>
                <td>
                    <asp:RegularExpressionValidator ID="ZipcodeRegularExpressionValidator" runat="server" ControlToValidate="ZipcodeTextBox" CssClass="auto-style2" Display="Dynamic" Enabled="False" ErrorMessage="Must be a valid US zip code." ForeColor="Red" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style11"></td>
                <td class="auto-style15"></td>
                <td class="auto-style17">
                    <asp:Button ID="EditVolunterFormButton" runat="server" Text="Save Changes" Enabled="False" style="text-align: center" OnClick="EditVolunterFormButton_Click" />
                </td>
                <td class="auto-style18"> 
                    <asp:Button ID="CancelButton" runat="server" CausesValidation="False" Enabled="False" OnClick="CancelButton_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
        .auto-style2 {
            font-size: small;
        }
        .auto-style4 {
            width: 268px;
        }
        .auto-style5 {
            height: 32px;
            width: 184px;
        }
        .auto-style6 {
            height: 32px;
            width: 268px;
            text-align: left;
        }
        .auto-style7 {
            height: 33px;
            font-size: small;
        }
        .auto-style8 {
            width: 268px;
            height: 33px;
            text-align: left;
        }
        .auto-style9 {
            text-align: right;
            width: 96px;
            height: 33px;
        }
        .auto-style10 {
            height: 33px;
            text-align: right;
            width: 164px;
        }
        .auto-style11 {
            font-size: small;
            width: 164px;
            height: 33px;
        }
    .auto-style14
    {
            text-align: right;
            width: 164px;
        }
    .auto-style15
    {
        width: 268px;
            text-align: center;
            height: 33px;
        }
        .auto-style16
        {
            width: 268px;
            text-align: left;
        }
        .auto-style17
        {
            height: 33px;
            font-size: small;
            text-align: center;
        }
        .auto-style18
        {
            height: 33px;
        }
        .auto-style19
        {
            width: 164px;
        }
    </style>
</asp:Content>


