using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace UltimateRevisionPlannerWebsite.Account
{
    public partial class RevisionPlanViewCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get revision plan IDs for this member
            List<RevisionPlan> revisionPlans = RevisionPlan.GetRevisionPlans(Context.User.Identity.GetUserId());
            //if there are no revision plans
            if (revisionPlans.Count == 0)
            {
                // redirect to generate page
                Response.Redirect("~/Account/GenerateRevisionPlan.aspx");
            }
            //if there are more than one then get the member to select which one - dont do this check yet - for now members are only shown their last plan
            else
            {
                int revisionPlanID = revisionPlans.FirstOrDefault().Id;
                Session["RevisionPlanID"] = revisionPlanID;
                Response.Redirect("~/Account/RevisionPlanView.aspx");
            }
        }
    }
}