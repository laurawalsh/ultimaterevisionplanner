using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UltimateRevisionPlannerWebsite.MathsQs
{
    public partial class AddingMathsQs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            Question.AddQuestion(Convert.ToInt32(topicIDInput.Text), questionInput.Text, answerInput.Text);
            Response.Redirect("~/MathsQs/ViewingMathsQs");
        }
    }
}