<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnsweringMathsQs.aspx.cs" Inherits="UltimateRevisionPlannerWebsite.MathsQs.AnsweringMathsQs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/x-mathjax-config">
  MathJax.Hub.Config({tex2jax: {inlineMath: [['$','$'], ['\\(','\\)']]}});
</script>
<script type="text/javascript"
  src="http://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML">
</script>
    <asp:Label ID="questionLabel" runat="server" Text="Label"></asp:Label>
    <br /><br />
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>$+$</asp:ListItem>
        <asp:ListItem>$-$</asp:ListItem>
        <asp:ListItem>$\pm$</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="real" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>$+$</asp:ListItem>
        <asp:ListItem>$-$</asp:ListItem>
        <asp:ListItem>$\pm$</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="imaginary" runat="server"></asp:TextBox>
    $i$
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Submit Answer" OnClick="Button1_Click" />
    <br />
    <asp:Label ID="correctOrIncorrect" runat="server" Text="Label"></asp:Label>
</asp:Content>
