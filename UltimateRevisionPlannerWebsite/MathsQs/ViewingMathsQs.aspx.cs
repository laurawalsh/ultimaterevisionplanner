using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UltimateRevisionPlannerWebsite.MathsQs
{
    public partial class ViewingMathsQs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Question> questions = Question.GetQuestions();
            foreach (Question currentQuestion in questions)
            {
                question.Text = currentQuestion.question;
                answer.Text = currentQuestion.answer;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MathsQs/AddingMathsQs");
        }
    }
}