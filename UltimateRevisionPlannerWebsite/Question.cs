using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using UltimateRevisionPlannerWebsite;

namespace UltimateRevisionPlannerWebsite
{
    public class Question
    {
        public int ID { get; set; }
        public int topicID { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        internal static int AddQuestion(int topicID, string question, string answer)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@topicID", topicID),
                new SqlParameter("@question", question),
                new SqlParameter("@answer", answer)
            };
            return Convert.ToInt32(SqlHelper.ExecuteSqlStoredProcedureReturnValue("AddQuestion", new List<SqlParameter>(parameters)));
        }

        private static Question GenerateQuestion(DataRow row)
        {
            Question newQuestion = new Question();

            if (row["ID"] != null)
            {
                newQuestion.ID = Convert.ToInt32(row["ID"].ToString());
            }
            if (row["topicID"] != null)
            {
                newQuestion.topicID = Convert.ToInt32(row["topicID"].ToString());
            }
            if (row["question"] != null)
            {
                newQuestion.question = row["question"].ToString();
            }
            if (row["answer"] != null)
            {
                newQuestion.answer = row["answer"].ToString();
            }

            return newQuestion;
        }

        internal static List<Question> GetQuestions()
        {
            DataTable QuestionDataTable = SqlHelper.ExecuteSqlStoredProcedureReturnDataTable("GetQuestions", null);
            List<Question> Questions = new List<Question>();

            foreach (DataRow row in QuestionDataTable.Rows)
            {
                Questions.Add(GenerateQuestion(row));
            }

            return Questions;
        }

        internal static List<Question> GetQuestionsByTopic(int topicID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@topicID", topicID)
            };

            DataTable QuestionDataTable = SqlHelper.ExecuteSqlStoredProcedureReturnDataTable("GetQuestionsByTopic", new List<SqlParameter>(parameters));
            List<Question> Questions = new List<Question>();

            foreach (DataRow row in QuestionDataTable.Rows)
            {
                Questions.Add(GenerateQuestion(row));
            }

            return Questions;
        }

        internal static Question GetQuestion(int questionID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", questionID)
            };

            DataTable QuestionDataTable = SqlHelper.ExecuteSqlStoredProcedureReturnDataTable("GetQuestionsByTopic", new List<SqlParameter>(parameters));
            Question newQuestion;

            newQuestion = (GenerateQuestion(QuestionDataTable.Rows[0]));

            return newQuestion;
        }
    }
}