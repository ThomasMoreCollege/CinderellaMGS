<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Querying.aspx.cs" Inherits="Forms_AdminForms_Querying" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>Querying</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="form1" runat="server">
        <table id="QueryTable">
            <tr>
                <td colspan ="3">
                    <asp:TextBox ID="QueryTextBox" runat="server" Height="150px" TextMode="MultiLine" ViewStateMode="Disabled" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                    <asp:Button ID="ExecuteButton" runat="server" OnClick="ExecuteButton_Click" Text="Execute Query" />

                </td>
                <td>
                    <asp:Button ID="ClearButton" runat="server" OnClick="ClearButton_Click" Text="Clear" />
                </td>
                <td>
                    <asp:Button ID="TableNameButton" runat="server" OnClick="TableNameButton_Click" Text="List Table Names" />
                </td>
            </tr>
        </table>
       
    </form>

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
    #form1 {
        height: 290px;
    }
</style>
</asp:Content>


