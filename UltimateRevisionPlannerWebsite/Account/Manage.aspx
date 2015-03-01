<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="UltimateRevisionPlannerWebsite.Account.Manage" %>

<%@ Register assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <hr />
        <asp:PlaceHolder runat="server" ID="viewPlan" Visible="false">
            <div class="col-md-12">
                <div class="form-horizontal">
                    <asp:Button ID="viewPlanButton" runat="server" Text="View Revision Plan" OnClick="viewPlanButton_Click" />
                </div>
            </div>
            <hr />
        </asp:PlaceHolder>
        
        <asp:PlaceHolder runat="server" ID="generatePlan">
            <div class="col-md-12">
                <div class="form-horizontal">
                    <asp:Button ID="generateRevisionPlan" runat="server" Text="Generate Revision Plan" OnClick="generateRevisionPlan_Click" />
                </div>
            </div>
        </asp:PlaceHolder>
        <hr />
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Change your account settings</h4>
                
                <dl class="dl-horizontal">
                    <dt>Password:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                </dl>
            </div>
        </div>
    </div>

</asp:Content>
