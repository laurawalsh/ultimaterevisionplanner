using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UltimateRevisionPlannerWebsite;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace UltimateRevisionPlannerWebsite.Account
{
    public partial class GenerateRevisionPlan : System.Web.UI.Page
    {
        protected string FailMessage
        {
            get;
            private set;
        }

        private string commitmentListKey = "commitmentListKey";
        private List<commitment> commitments
        {
            get
            {
                if (Session[commitmentListKey] == null)
                    Session[commitmentListKey] = new List<commitment>();
                return (List<commitment>)Session[commitmentListKey];
            }
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = commitments;
            GridView1.DataBind();
        }

        protected void generateRevisionPlanButton_Click(object sender, EventArgs e)
        {
            if (CheckSensibleDatesAndTimes() && CheckSelectedWeekType())
            {
                RevisionPlan.AddRevisionPlan(Context.User.Identity.GetUserId(), fromDate.Date, toDate.Date, startTime.DateTime, 
                                             endTime.DateTime, lunchStartTime.DateTime, lunchEndTime.DateTime, teaStartTime.DateTime, 
                                             teaEndTime.DateTime, fORwWeek.SelectedItem.Text, commitments);
                Session[commitmentListKey] = null;
                Response.Redirect("~/Account/RevisionPlanViewCheck.aspx");   
            }
            else
            {
                FailMessage = "Your times do not run in chronological order! Please check and adjust.";
                failMessage.Visible = true;
            }
        }

        private Boolean CheckSelectedWeekType()
        {
            if (String.IsNullOrEmpty(fORwWeek.SelectedItem.Text))
            {
                return false;
            }
            return true;
        }   

        private Boolean CheckSensibleDatesAndTimes()
        {
            if (toDate.Date < fromDate.Date) return false;
            if (startTime.DateTime < lunchStartTime.DateTime  
                && lunchStartTime.DateTime < lunchEndTime.DateTime  
                && lunchEndTime.DateTime < teaStartTime.DateTime
                && teaStartTime.DateTime < teaEndTime.DateTime
                && teaEndTime.DateTime < endTime.DateTime) return true;
            else return false;
        }

        protected void btnAddCommitment_Click(object sender, EventArgs e)
        {
            DateTime commitmentDatefrom = commitmentDateFrom.Date.Add(commitmentTimeFrom.DateTime.TimeOfDay);
            DateTime commitmentDateto = commitmentDateTo.Date.Add(commitmentTimeTo.DateTime.TimeOfDay);
            if (commitmentDatefrom < commitmentDateto)
            {
                commitments.Add(new commitment(commitmentDatefrom, commitmentDateto, commitmentDescription.Text));
                GridView1.DataBind();
                resetCommitmentFields();
            }
        }

        private void resetCommitmentFields()
        {
            commitmentDateFrom.Date = DateTime.MinValue;
            commitmentDateTo.Date = DateTime.MinValue;
            commitmentTimeFrom.DateTime = DateTime.MinValue;
            commitmentTimeTo.DateTime = DateTime.MinValue;
        }

        protected void gridView1RowDeleting_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            commitments.RemoveAt(e.RowIndex);
            GridView1.DataBind();
        }
    }
}