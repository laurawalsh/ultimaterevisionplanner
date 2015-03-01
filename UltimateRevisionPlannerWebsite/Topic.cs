using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using UltimateRevisionPlannerWebsite;

namespace UltimateRevisionPlannerWebsite
{
    public class Topic
    {
        public int ID { get; set; }
        public string Title { get; set; }

        private static Topic GenerateTopic(DataRow row)
        {
            Topic newTopic = new Topic();

            if (row["ID"] != null)
            {
                newTopic.ID = Convert.ToInt32(row["ID"].ToString());
            }
            if (row["Title"] != null)
            {
                newTopic.Title = row["Title"].ToString();
            }

            return newTopic;
        }

        internal static List<Topic> GetTopics()
        {
            DataTable topicDataTable = SqlHelper.ExecuteSqlStoredProcedureReturnDataTable("GetTopics", null);
            List<Topic> Topics = new List<Topic>();

            foreach (DataRow row in topicDataTable.Rows)
            {
                Topics.Add(GenerateTopic(row));
            }
            
            return Topics;
        }
    }
}