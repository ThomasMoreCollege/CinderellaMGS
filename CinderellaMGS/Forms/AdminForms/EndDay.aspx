<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EndDay.aspx.cs" Inherits="Forms_AdminForms_EndDay" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderTitle" Runat="Server">
    <h2>End the Day</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        <asp:Button ID="EndDayButton" runat="server" Text="End the Day" OnClick="EndDayButton_Click" />
</asp:Content>

