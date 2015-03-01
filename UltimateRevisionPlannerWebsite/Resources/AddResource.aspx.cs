using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UltimateRevisionPlannerWebsite.Resources
{
    public partial class AddResource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddResourceButton_Click(object sender, EventArgs e)
        {
            List<int> topicIDs = topicText.Text.Split(',').Select(int.Parse).ToList();
            List<int> typeIDs = typeText.Text.Split(',').Select(int.Parse).ToList();
            Resource.AddResource(descriptionText.Text, linkText.Text, Convert.ToInt32(lengthText.Text), topicIDs, typeIDs);
            Response.Redirect("~/Resources/AddResource");
        }
    }
}