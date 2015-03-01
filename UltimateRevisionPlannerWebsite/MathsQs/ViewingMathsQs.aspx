<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewingMathsQs.aspx.cs" Inherits="UltimateRevisionPlannerWebsite.MathsQs.ViewingMathsQs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/x-mathjax-config">
  MathJax.Hub.Config({tex2jax: {inlineMath: [['$','$'], ['\\(','\\)']]}});
</script>
<script type="text/javascript"
  src="http://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML">
</script>
    <asp:Label ID="question" runat="server" Text="Label"></asp:Label>
    <br /><br />
    <asp:Label ID="answer" runat="server" Text="Label"></asp:Label>
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Add New Question" OnClick="Button1_Click" />
</asp:Content>
