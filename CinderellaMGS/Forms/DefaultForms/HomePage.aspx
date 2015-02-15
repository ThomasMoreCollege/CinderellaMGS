<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<%-- Links Page to Master page --%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>


<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>Welcome to Cinderellas Closet</h2>
</asp:Content>

<%--<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">

</asp:Content>--%>
