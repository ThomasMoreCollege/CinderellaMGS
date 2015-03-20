<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="Forms_DefaultForms_About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 1151px;
        }
        .auto-style2 {
            width: 19px;
        }
        .auto-style7 {
        width: 547px;
    }
    .auto-style8 {
        width: 547px;
        height: 30px;
    }
    .auto-style9 {
        width: 183px;
    }
    .auto-style10 {
        width: 183px;
        height: 30px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>About</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <td colspan="2" class="auto-style2">

                &nbsp;</td>
        </tr>
        <tr>
            <td style="padding: 10px 5px 5px 5px;" class="auto-style7">
                <asp:Image ID="Image1" runat="server" Height="283px" ImageUrl="~/Images/TMCshield.png" Width="303px" />
            </td>
            <td class="auto-style9">&nbsp;</td>
            <td style="padding: 10px 5px 5px 5px;" class="auto-style1"><strong>Creators:</strong><br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Jake Pindela<br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tommy Arnzen<br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dan Schoettelotte</td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style10"></td>
            <td><strong>Visual Layout Consultant:</strong><br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Jacob Condon<br />
            </td>
        </tr>
        <tr>
            <td class="auto-style7"><strong>Cinderella&#39;s Closet Management System</strong></td>
            <td class="auto-style9" >&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Version: Spring 2015</strong></td>
            <td class="auto-style9">&nbsp;</td>
        </tr>

        <tr>
            <td colspan="2" class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2"></td>
        </tr>
    </table>
</asp:Content>

