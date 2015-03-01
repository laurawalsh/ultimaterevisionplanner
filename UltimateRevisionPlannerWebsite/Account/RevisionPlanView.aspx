<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RevisionPlanView.aspx.cs" Inherits="UltimateRevisionPlannerWebsite.Account.RevisionPlanView" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>
<%@ Register assembly="DevExpress.XtraScheduler.v14.2.Core, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"><!--
        function RedirectToResources(scheduler) {
        var aptIds = scheduler.GetSelectedAppointmentIds();
        var apt = scheduler.GetAppointmentById(scheduler.GetSelectedAppointmentIds()[0]);
        var win = window.open('Resources/', '_blank'); win.focus();
    }
    //--></script>

    <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="SqlDataSource5" ClientIDMode="AutoID" Start="2015-02-23" ActiveViewType="FullWeek" ClientInstanceName="scheduler">
        <Storage>
            <Appointments AutoRetrieveId="True">
                <Mappings AppointmentId="Id" Description="Description" End="EndDate" Start="StartDate" Subject="Subject" />
            </Appointments>
        </Storage>
        <views>
<DayView><TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
</DayView>

<WorkWeekView><TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
</WorkWeekView>

            <weekview enabled="false">
            </weekview>
            <fullweekview enabled="true">
                <TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
            </fullweekview>
        </views>
        <OptionsCustomization AllowAppointmentCopy="None" AllowAppointmentCreate="None" AllowAppointmentDelete="None" AllowAppointmentDrag="None" AllowAppointmentDragBetweenResources="None" AllowAppointmentEdit="None" AllowAppointmentMultiSelect="False" AllowAppointmentResize="None" />
        <ClientSideEvents AppointmentClick="function(s, e) {var win = window.open('Resources/AllResources', '_blank'); win.focus();}" />
    </dxwschs:ASPxScheduler>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="GetSlotsForDisplay" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="RevisionPlanID" SessionField="RevisionPlanID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="GetSlotsForDisplay" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="RevisionPlanID" SessionField="RevisionPlanID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [RevisionPlanSlots] WHERE [ID] = @original_ID AND (([StartDate] = @original_StartDate) OR ([StartDate] IS NULL AND @original_StartDate IS NULL)) AND (([EndDate] = @original_EndDate) OR ([EndDate] IS NULL AND @original_EndDate IS NULL)) AND (([Subject] = @original_Subject) OR ([Subject] IS NULL AND @original_Subject IS NULL)) AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([RevisionPlanID] = @original_RevisionPlanID) OR ([RevisionPlanID] IS NULL AND @original_RevisionPlanID IS NULL))" InsertCommand="INSERT INTO [RevisionPlanSlots] ([StartDate], [EndDate], [Subject], [Description], [RevisionPlanID]) VALUES (@StartDate, @EndDate, @Subject, @Description, @RevisionPlanID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [StartDate], [EndDate], [Subject], [Description], [RevisionPlanID] FROM [RevisionPlanSlots] WHERE ([RevisionPlanID] = @RevisionPlanID)" UpdateCommand="UPDATE [RevisionPlanSlots] SET [StartDate] = @StartDate, [EndDate] = @EndDate, [Subject] = @Subject, [Description] = @Description, [RevisionPlanID] = @RevisionPlanID WHERE [ID] = @original_ID AND (([StartDate] = @original_StartDate) OR ([StartDate] IS NULL AND @original_StartDate IS NULL)) AND (([EndDate] = @original_EndDate) OR ([EndDate] IS NULL AND @original_EndDate IS NULL)) AND (([Subject] = @original_Subject) OR ([Subject] IS NULL AND @original_Subject IS NULL)) AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([RevisionPlanID] = @original_RevisionPlanID) OR ([RevisionPlanID] IS NULL AND @original_RevisionPlanID IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_StartDate" Type="DateTime" />
            <asp:Parameter Name="original_EndDate" Type="DateTime" />
            <asp:Parameter Name="original_Subject" Type="String" />
            <asp:Parameter Name="original_Description" Type="String" />
            <asp:Parameter Name="original_RevisionPlanID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="EndDate" Type="DateTime" />
            <asp:Parameter Name="Subject" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="RevisionPlanID" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="RevisionPlanID" SessionField="RevisionPlanID" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="EndDate" Type="DateTime" />
            <asp:Parameter Name="Subject" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="RevisionPlanID" Type="Int32" />
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_StartDate" Type="DateTime" />
            <asp:Parameter Name="original_EndDate" Type="DateTime" />
            <asp:Parameter Name="original_Subject" Type="String" />
            <asp:Parameter Name="original_Description" Type="String" />
            <asp:Parameter Name="original_RevisionPlanID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
