<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerateRevisionPlan.aspx.cs" Inherits="UltimateRevisionPlannerWebsite.Account.GenerateRevisionPlan" %>
<%@ Register assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div>
        <asp:PlaceHolder runat="server" ID="failMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-danger"><%: FailMessage %></p>
        </asp:PlaceHolder>
    </div>

    <table style="width:100%;">
        <tr>
            <td style="width: 255px">From Date:<dx:ASPxDateEdit ID="fromDate" runat="server">
                </dx:ASPxDateEdit>
            </td>
            <td>To Date:<dx:ASPxDateEdit ID="toDate" runat="server">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td style="width: 255px">Start Working at:<dx:ASPxTimeEdit ID="startTime" runat="server">
                </dx:ASPxTimeEdit>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 255px">Lunch Time Start:<dx:ASPxTimeEdit ID="lunchStartTime" runat="server">
                </dx:ASPxTimeEdit>
            </td>
            <td>Lunch Time End:<dx:ASPxTimeEdit ID="lunchEndTime" runat="server">
                </dx:ASPxTimeEdit>
            </td>
        </tr>
        <tr>
            <td style="width: 255px">Tea Time Start:<dx:ASPxTimeEdit ID="teaStartTime" runat="server">
                </dx:ASPxTimeEdit>
            </td>
            <td>Tea Time End:<dx:ASPxTimeEdit ID="teaEndTime" runat="server">
                </dx:ASPxTimeEdit>
            </td>
        </tr>
        <tr>
            <td>End Working at:<dx:ASPxTimeEdit ID="endTime" runat="server">
                </dx:ASPxTimeEdit>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                Work for the:
                <asp:RadioButtonList ID="fORwWeek" runat="server">
                    <asp:ListItem>Full Week</asp:ListItem>
                    <asp:ListItem>Work Week</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>Commitment From: 
                <dx:ASPxDateEdit ID="commitmentDateFrom" runat="server"></dx:ASPxDateEdit>
                <dx:ASPxTimeEdit ID="commitmentTimeFrom" runat="server"></dx:ASPxTimeEdit>
            </td>
            <td>
                Commitment To: 
                <dx:ASPxDateEdit ID="commitmentDateTo" runat="server"></dx:ASPxDateEdit>
                <dx:ASPxTimeEdit ID="commitmentTimeTo" runat="server"></dx:ASPxTimeEdit>
            </td>
            <td>
                Commitment Description: <asp:TextBox ID="commitmentDescription" runat="server"></asp:TextBox>
                <asp:Button ID="btnAddCommitment" runat="server" Text="Add Commitment" OnClick="btnAddCommitment_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Commitments: 
                <asp:GridView ID="GridView1" runat="server" OnRowDeleting="gridView1RowDeleting_RowDeleting">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
            <td></td>
        </tr>
    </table>

    <hr />

    <asp:Button ID="generateRevisionPlanButton" Text="Generate Revision Plan" runat="server" OnClick="generateRevisionPlanButton_Click" />

</asp:Content>