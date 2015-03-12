﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Alterations.aspx.cs" Inherits="Forms_UserForms_Alterations" %>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Alterations</h2>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
        <table style="width:100%;">
            <tr>
                <td colspan="4" class="auto-style1" ><strong>Cinderellas Currently Shopping</strong></td>
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
                    <asp:ListBox ID="CinderellasInAlterationListBox" runat="server" AutoPostBack="True" Height="139px" OnSelectedIndexChanged="CinderellasInAlterationListBox_SelectedIndexChanged1" Width="312px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" rowspan="3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ListBox ID="shoppingCinderellaListBox" runat="server" AutoPostBack="True" Height="141px" OnSelectedIndexChanged="shoppingCinderellaListBox_SelectedIndexChanged1" Width="244px" style="margin-left: 0px"></asp:ListBox>
                </td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10" ></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="StrapsCheckBox" runat="server" Text="Straps Add/Adjust" CssClass="auto-style2" Enabled="False" />
                </td>
                <td class="auto-style2">
                    Notes:</td>
            </tr>
            <tr>
                <td class="auto-style12">Size :</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DressSizeDropDownList" runat="server" style="text-align: center" Enabled="False" DataSourceID="DressSizeLengthDS" DataTextField="sizeLength" DataValueField="sizeLength">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DressSizeLengthDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT * FROM [DressSizeLength]"></asp:SqlDataSource>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style10"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="GeneralMendingCheckBox" runat="server" Text="General Mending" CssClass="auto-style13" style="font-size: small" Enabled="False" />
                </td>
                <td rowspan="2">
                    <asp:TextBox ID="notesTextBox" runat="server" Width="194px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    Color:</td>
                <td>
                    <asp:DropDownList ID="DressColorDropDownList" runat="server" Enabled="False" style="width: 95px" DataSourceID="DressColorDS" DataTextField="dressColor" DataValueField="dressColor">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DressColorDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT * FROM [DressColor]"></asp:SqlDataSource>
                </td>
                <td class="auto-style3" >
                    &nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="GeneralTakeinCheckBox" runat="server" Text="General Take In" CssClass="auto-style13" style="font-size: small" Enabled="False" />
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">
                    Length:</td>
                <td  class="auto-style5">
                    <asp:DropDownList ID="DressLengthDropDownList" runat="server" Enabled="False" DataSourceID="DressSizeLengthDS" DataTextField="sizeLength" DataValueField="sizeLength">
                    </asp:DropDownList>
                </td>
                <td  class="auto-style3"></td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style11">
                    <asp:CheckBox ID="FixZipperCheckBox" runat="server" Text="Fix Zipper" CssClass="auto-style13" style="font-size: small" Enabled="False" />
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
                    <asp:CheckBox ID="DartsCheckBox" runat="server" Text="Darts" CssClass="auto-style13" style="font-size: small" Enabled="False" />
                </td>
                <td class="auto-style69">
                    <asp:DropDownList ID="SeamstressDropDownList" runat="server" DataSourceID="VolunteerNameDS" DataTextField="LastName" DataValueField="LastName" Enabled="False">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="VolunteerNameDS" runat="server" ConnectionString="<%$ ConnectionStrings:CinderellaMGS2015TestingConnectionString %>" SelectCommand="SELECT Volunteer.LastName
FROM Volunteer
	INNER JOIN VolunteerRoleRecord
	 ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID
WHERE VolunteerRoleRecord.Role_Name = 'Alterations' AND VolunteerRoleRecord.IsCurrent = 'Y'"></asp:SqlDataSource>
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
                    <asp:CheckBox ID="BustCheckBox" runat="server" Text="Bust" CssClass="auto-style13" style="font-size: small" Enabled="False" />
                    </td>
                <td class="auto-style82" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style5"></td>
                <td>&nbsp;</td>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="HemCheckBox" runat="server" Text="Hem" CssClass="auto-style13" style="font-size: small" Enabled="False" />
                    </td>
                <td>
                    <asp:Button ID="submitDressButton" runat="server" Text="Submit" Enabled="False" OnClick="submitDressButton_Click" />
                </td>
                
            </tr>
            <tr><td>
                <asp:Label ID="updateSuccessLabel" runat="server" Enabled="False" Text="Success!" Visible="False"></asp:Label>
                </td><td>
                    <asp:Label ID="nameDisplaySuccessMessage" runat="server" Enabled="False" Text="Label" Visible="False"></asp:Label>
                </td></tr>
            
        </table>

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


