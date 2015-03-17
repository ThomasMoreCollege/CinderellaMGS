﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditCinderella.aspx.cs" Inherits="Forms_UserForms_EditCinderella" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style2 {
            font-size: small;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table id="EditVolunTable">
        <tr>
            <th >
                <asp:Label ID="SuccessLabel" runat="server" Text="Update Successful!" ForeColor="#009900" style="font-weight: 700" Visible="False"></asp:Label>
            </th>
            <th class="auto-style11"></th>
            <th class="auto-style4">Current Information:</th>
            <th>New Information:</th>
        </tr>
        <tr>
            <td rowspan="9" class="auto-style5">
                <div id="" style="overflow-y: scroll; height:400px;">
                <asp:GridView ID="CinderellaGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="CinderellaID" DataSourceID="CinderellaDS" Width="100px" OnSelectedIndexChanged="CinderellaGridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="CinderellaID" HeaderText="CinderellaID" InsertVisible="False" ReadOnly="True" SortExpression="CinderellaID" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
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
                <asp:SqlDataSource ID="CinderellaDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT [CinderellaID], [LastName], [FirstName] FROM [Cinderella]"></asp:SqlDataSource>
            </div>
        </td>
            <td class="auto-style14">First Name:</td>
            <td class="auto-style16">
                <asp:Label ID="FirstNameLabel" runat="server" Text="--"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="FirstNameTextBox" runat="server" Enabled="False"></asp:TextBox>
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
                <asp:TextBox ID="LastNameTextBox" runat="server" Enabled="False"></asp:TextBox>
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
                <asp:TextBox ID="EmailTextBox" runat="server" Enabled="False"></asp:TextBox>
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
                <asp:TextBox ID="PhoneTextBox" runat="server" Enabled="False"></asp:TextBox>
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
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style16">
                &nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style11"></td>
            <td class="auto-style8"></td>
            <td class="auto-style17">
                <asp:Button ID="EditCinderellaFormButton" runat="server" Enabled="False" Text="Save Changes" OnClick="EditCinderellaFormButton_Click1" />
                <br />
                <br />
                <asp:Button ID="CancelButton" runat="server" Enabled="False" OnClick="CancelButton_Click" Text="Cancel" />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

