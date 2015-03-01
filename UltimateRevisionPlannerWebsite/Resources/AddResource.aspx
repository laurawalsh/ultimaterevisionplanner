<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddResource.aspx.cs" Inherits="UltimateRevisionPlannerWebsite.Resources.AddResource" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Description:<asp:TextBox ID="descriptionText" runat="server"></asp:TextBox>
    <br />
    Link:<asp:TextBox ID="linkText" runat="server"></asp:TextBox>
    <br />
    Length:<asp:TextBox ID="lengthText" runat="server"></asp:TextBox>
    <br />
    Type IDs (comma seperated list):<asp:TextBox ID="typeText" runat="server"></asp:TextBox>
    <br />
    Topic IDs (comma seperated list):<asp:TextBox ID="topicText" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="AddResourceButton" runat="server" Text="Add Resource" OnClick="AddResourceButton_Click" />
    <br /><br /><br />
    Types: 1 - text, 2 - practice, 3 - video
    <br />
    Topics: 1 - intro, 2 - operations, 3- polar form, 4 - solving equations, 5 - argand diagrams
</asp:Content>
