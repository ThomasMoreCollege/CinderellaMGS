<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Alterations.aspx.cs" Inherits="Forms_UserForms_Alterations" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Alterations</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td colspan="4" class="auto-style1" ><strong>Cinderelas Currently Shopping</strong></td>
                <td class="auto-style10">&nbsp;</td>
                <td colspan="4" class="auto-style1"><strong>Cinderellas in Alterations</strong></td>
            </tr>
            <tr>
                <td class="auto-style12">Search Last Name:</td>
                
                <td class="auto-style3">
                    <asp:TextBox ID="searchTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="searchShoppingCindButton" runat="server" OnClick="searchShoppingCindButton_Click1" Text="Search" />
                </td>
                <td class="auto-style10"></td>
                <td></td>
                <td colspan="2" rowspan="3">
                    <asp:ListBox ID="CinderellasInAlterationListBox" runat="server" Height="222px" Width="401px"></asp:ListBox>
                </td>
            </tr>
            <tr><td class="auto-style15">
                <asp:Label ID="noSearchLabel" runat="server" Font-Size="Smaller" Text="No Search"></asp:Label>
                </td><td></td><td>
                <asp:Label ID="searchLabel" runat="server" Font-Size="Smaller" Text="Search"></asp:Label>
                </td></tr>
            <tr>
                <td colspan="4" rowspan="3">
&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="noSearchTextBox" runat="server" Height="134px"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:ListBox ID="shoppingCinderellaListBox" runat="server" AutoPostBack="True" Height="141px" OnSelectedIndexChanged="shoppingCinderellaListBox_SelectedIndexChanged1" Width="122px"></asp:ListBox>
                </td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10" ></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="StrapsCheckBox" runat="server" Text="Straps Add/Adjust" CssClass="auto-style2" />
                </td>
                <td class="auto-style2">
                    Notes:</td>
            </tr>
            <tr>
                <td class="auto-style12">Size :</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DressSizeDropDownList" runat="server" style="text-align: center" Enabled="False">
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style10"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="GeneralMendingCheckBox" runat="server" Text="General Mending" CssClass="auto-style13" style="font-size: small" />
                </td>
                <td rowspan="2">
                    <asp:TextBox ID="notesTextBox" runat="server" Width="194px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    Color:</td>
                <td>
                    <asp:DropDownList ID="DressColorDropDownList" runat="server" Enabled="False" style="width: 95px">
                        <asp:ListItem>Brown</asp:ListItem>
                        <asp:ListItem>Yellow</asp:ListItem>
                        <asp:ListItem>Orange</asp:ListItem>
                        <asp:ListItem>Coral</asp:ListItem>
                        <asp:ListItem>Pink</asp:ListItem>
                        <asp:ListItem>Red</asp:ListItem>
                        <asp:ListItem>Green</asp:ListItem>
                        <asp:ListItem>Aqua/Green</asp:ListItem>
                        <asp:ListItem>Purple</asp:ListItem>
                        <asp:ListItem>Aqua/Blue</asp:ListItem>
                        <asp:ListItem>Blue</asp:ListItem>
                        <asp:ListItem>Silver</asp:ListItem>
                        <asp:ListItem>Grey</asp:ListItem>
                        <asp:ListItem>Black</asp:ListItem>
                        <asp:ListItem>White</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style3" >
                    &nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="GeneralTakeinCheckBox" runat="server" Text="General Take In" CssClass="auto-style13" style="font-size: small" />
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">
                    Length:</td>
                <td  class="auto-style5">
                    <asp:DropDownList ID="DressLengthDropDownList" runat="server" Enabled="False">
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td  class="auto-style3"></td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style11">
                    <asp:CheckBox ID="FixZipperCheckBox" runat="server" Text="Fix Zipper" CssClass="auto-style13" style="font-size: small" />
                </td>
                <td class="auto-style2" >
                    Seamstress:</td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="DartsCheckBox" runat="server" Text="Darts" CssClass="auto-style13" style="font-size: small" />
                </td>
                <td class="auto-style69">
                    <asp:DropDownList ID="SeamstressDropDownList" runat="server" DataSourceID="VolunteerNameDS" DataTextField="LastName" DataValueField="LastName">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="VolunteerNameDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT [LastName] FROM [Volunteer]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style8">
                    <asp:Button ID="AltertationsCheckinButton" runat="server" Text="Check-In to Altertations" style="text-align: center" Enabled="False" OnClick="AltertationsCheckinButton_Click" />
                </td>
                <td></td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style11">
                    <asp:CheckBox ID="BustCheckBox" runat="server" Text="Bust" CssClass="auto-style13" style="font-size: small" />
                    </td>
                <td class="auto-style82" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style5"></td>
                <td></td>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="HemCheckBox" runat="server" Text="Hem" CssClass="auto-style13" style="font-size: small" />
                    </td>
                <td>
                    <asp:Button ID="submitDressButton" runat="server" Text="Submit" />
                </td>
            </tr>
            
        </table>
    </form>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1
        {
            text-align: center;
        }
        .auto-style2
        {
            font-size: small;
        }
        .auto-style3
        {
            width: 64px;
        }
        .auto-style5
        {
            width: 27px;
        }
        .auto-style8
        {
            width: 96px;
        }
        #TextArea1
        {
            height: 49px;
            width: 203px;
        }
        .auto-style9
        {
            width: 9px;
        }
        .auto-style10
        {
            width: 87px;
        }
        .auto-style11
        {
            text-align: left;
        }
        .auto-style12 {
            font-size: small;
            width: 120px;
        }
        .auto-style13 {
            width: 97px;
        }
        .auto-style15 {
            width: 120px;
        }
        </style>
</asp:Content>


