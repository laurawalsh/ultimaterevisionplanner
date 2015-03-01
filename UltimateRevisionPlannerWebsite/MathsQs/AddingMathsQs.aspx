<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddingMathsQs.aspx.cs" Inherits="UltimateRevisionPlannerWebsite.MathsQs.AddingMathsQs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="http://cdn.mathjax.org/mathjax/latest/MathJax.js"></script>
    <script type="text/javascript" src="http://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML"></script>
    Question: <asp:TextBox ID="questionInput" runat="server" Width="581px"></asp:TextBox>
    <br />
    Answer: <asp:TextBox ID="answerInput" runat="server" Width="593px"></asp:TextBox>
    <br />
    Topic ID: <asp:TextBox ID="topicIDInput" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
</asp:Content>
