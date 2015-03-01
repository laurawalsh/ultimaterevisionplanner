using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using UltimateRevisionPlannerWebsite.Models;

namespace UltimateRevisionPlannerWebsite.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        private List<RevisionPlan> _revisionPlans;

        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
            _revisionPlans = RevisionPlan.GetRevisionPlans(Context.User.Identity.GetUserId());
            if (_revisionPlans.Count > 0)
            {
                viewPlan.Visible = true;
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected void viewPlanButton_Click(object sender, EventArgs e)
        {
            int revisionPlanID = _revisionPlans.FirstOrDefault().Id;
            Session["RevisionPlanID"] = revisionPlanID;
            Response.Redirect("~/Account/RevisionPlanView.aspx");
        }

        protected void generateRevisionPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/GenerateRevisionPlan.aspx");
        }

    }
}