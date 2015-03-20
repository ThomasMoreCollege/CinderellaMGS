<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<%-- Links Page to Master page --%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>


<asp:Content runat="server" ID="HeaderTitle" ContentPlaceHolderID="HeaderTitle">
    <h2>Welcome to Cinderellas Closet</h2>
</asp:Content>

<%--<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">

</asp:Content>--%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <asp:Image ID="Image1" runat="server" Height="374px" ImageUrl="~/Images/1556267_574330925975951_232391270_o.jpg" Width="482px" />
    <br />
    <span class="auto-style1" style="color: rgb(0, 0, 0); font-family: Verdana, Arial, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">Cinderella&#39;s Closet provides formal wear to girls who could not otherwise afford to attend their prom. Through donations of new and gently used formal dresses and accessories, we are able to &quot;Turn Dresses Into Dreams&quot; for juniors and seniors referred to our organization by their school, community organization or social care agency.&nbsp; Even more than a dress, Cinderella&#39;s Closet provides an unforgettable, amazing experience.&nbsp; From the moment our princesses dance through our doors they are greeted with an environment of grace, love and respect. &nbsp;It is our 
    mission that they leave knowing they are cherished.</span><br />
    <br />
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</asp:Content>

