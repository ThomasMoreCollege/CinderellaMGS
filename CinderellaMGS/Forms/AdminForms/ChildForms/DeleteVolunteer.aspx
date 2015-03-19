<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteVolunteer.aspx.cs" Inherits="Forms_AdminForms_ChildForms_DeleteVolunteer" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" runat="Server">
    <h2>Delete Volunteer</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">

    <div>
        <table>
            <tr>
                <td>Current Information
                </td>
            </tr>
            <tr>
                <td>
                    <div style="height: 400px; width: 100%; overflow: auto; border-bottom: 1px solid #999999;">
                        <asp:GridView ID="VolunteerGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="VolunteersToBeDeletedSqlDataSource" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="VolunteerGridView_SelectedIndexChanged" DataKeyNames="VolunteerID">
                            <AlternatingRowStyle BackColor="pink" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="VolunteerID" HeaderText="Volunteer ID" SortExpression="VolunteerID" InsertVisible="False" ReadOnly="True" />
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
                    </div>
                    <asp:SqlDataSource ID="VolunteersToBeDeletedSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [VolunteerID], [LastName], [FirstName] FROM [Volunteer] WHERE ([IsValid] = @IsValid)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Y" Name="IsValid" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                </td>
            </tr>
        </table>
    </div>

    <div>
        <table id="DeleteVolTable" style="width: 80%;">
            <tr>
                <td class="auto-style2">First Name:</td>
                <td>
                    <asp:Label ID="FisrtNameLabel" runat="server" Text="--"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Last Name:</td>
                <td>
                    <asp:Label ID="LastNameLabel" runat="server" Text="--"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Phone:</td>
                <td>
                    <asp:Label ID="PhoneLabel" runat="server" Text="--"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email:</td>
                <td>
                    <asp:Label ID="EmailLabel" runat="server" Text="--"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Address:</td>
                <td>
                    <asp:Label ID="AddressLabel" runat="server" Text="--"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">City:</td>
                <td>
                    <asp:Label ID="CityLabel" runat="server" Text="--"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">State:</td>
                <td>
                    <asp:Label ID="StateLabel" runat="server" Text="--"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Zip Code:</td>
                <td>
                    <asp:Label ID="ZipcodeLabel" runat="server" Text="--"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td>
                    <asp:Button ID="DeleteVoluntFormButton" runat="server" Text="Delete" Enabled="False" OnClick="DeleteVoluntFormButton_Click" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 439px;
        }

        .auto-style2 {
            width: 172px;
            text-align: right;
        }

        .auto-style3 {
            width: 172px;
            font-size: small;
            text-align: right;
        }
    </style>
</asp:Content>


