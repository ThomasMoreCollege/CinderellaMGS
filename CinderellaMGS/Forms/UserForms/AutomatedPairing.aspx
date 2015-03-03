<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AutomatedPairing.aspx.cs" Inherits="Forms_UserForms_AutomatedPairing" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Automated Pairings</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        <table id="AutoPairTable">
            <tr>
                <th>Godmothers</th>
                <th>Cinderellas</th>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="GodmotherListBox" runat="server" Height="400px" Width="350px"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="CinderellaListBox" runat="server" Height="400px" Width="350px"></asp:ListBox>
                </td>
            </tr>
        </table>
</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #form1 {
            height: 480px;
        }
    </style>
</asp:Content>


