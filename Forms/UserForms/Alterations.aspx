﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Alterations.aspx.cs" Inherits="Forms_UserForms_Alterations" %>

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
                <td class="auto-style2">Search by:</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style13">
                        <asp:ListItem>Last Name</asp:ListItem>
                        <asp:ListItem>FirstName</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="SearchTextBox" runat="server" CssClass="auto-style13"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="SearchShoppingCindButton" runat="server" Text="Search" CssClass="auto-style13" /></td>
                <td class="auto-style10"></td>
                <td colspan="2" rowspan="3">
                    <asp:ListBox ID="CinderellasInAlterationListBox" runat="server" Height="222px" Width="401px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" rowspan="3">
                    <asp:ListBox ID="ShoppingCinderellasListBox" runat="server" Height="206px" Width="400px"></asp:ListBox>
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
                <td class="auto-style2">Size :</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DressSizeDropDownList" runat="server" style="text-align: center">
                    </asp:DropDownList>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style10"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="GeneralMendingCheckBox" runat="server" Text="General Mending" CssClass="auto-style13" style="font-size: small" />
                </td>
                <td rowspan="2">
                    <textarea id="NotesTextArea" name="S1"></textarea></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Color:</td>
                <td>
                    <asp:DropDownList ID="DressColorDropDownList" runat="server">
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
                <td class="auto-style2">
                    Length:</td>
                <td  class="auto-style5">
                    <asp:DropDownList ID="DressLengthDropDownList" runat="server">
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
                <td></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="DartsCheckBox" runat="server" Text="Darts" CssClass="auto-style13" style="font-size: small" />
                </td>
                <td class="auto-style69">
                    <asp:DropDownList ID="SeamstressDropDownList" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style8">
                    <asp:Button ID="AltertationsCheckinButton" runat="server" Text="Check-In to Altertations" style="text-align: center" />
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
                <td class="auto-style8"></td>
                <td class="auto-style5"></td>
                <td></td>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">
                    <asp:CheckBox ID="HemCheckBox" runat="server" Text="Hem" CssClass="auto-style13" style="font-size: small" />
                    </td>
                <td>
                    <asp:Button ID="SubmitDressButton" runat="server" Text="Submit" />
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
        </style>
</asp:Content>


