using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UltimateRevisionPlannerWebsite.MathsQs
{
    public partial class AnsweringMathsQs : System.Web.UI.Page
    {
        Question question;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Question> questions = Question.GetQuestions();
            foreach (Question currentQuestion in questions)
            {
                question = currentQuestion;
                questionLabel.Text = currentQuestion.question;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string answer = String.Concat("$", DropDownList1.Text.Trim('$'), real.Text, " ", DropDownList2.Text.Trim('$')," ", imaginary.Text, "i$");
            if (answer == question.answer)
            {
                correctOrIncorrect.Text = "correct";
            }
            else
            {
                correctOrIncorrect.Text = "incorrect";
            }
        }
    }
}