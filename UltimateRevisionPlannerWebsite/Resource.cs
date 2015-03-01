using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using UltimateRevisionPlannerWebsite;

namespace UltimateRevisionPlannerWebsite
{
    public class Resource
    {
        public int _ID { get; set; }
        public string _description { get; set; }
        public string _link { get; set; }
        public int _lengthMinutes { get; set; }
        public List<int> _topicIDs { get; set; }
        public List<int> _typeIDs { get; set; }

        public Resource() { }

        public Resource(string description, string link, int lengthMinutes, List<int> topicIDS, List<int> typeIDs)
        {
            _description = description;
            _link = link;
            _lengthMinutes = lengthMinutes;
            _topicIDs = topicIDS;
            _typeIDs = typeIDs;
        }

        public static int AddResource(string description, string link, int lengthMinutes, List<int> topicIDS, List<int> typeIDs)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@description", description),
                new SqlParameter("@link", link),
                new SqlParameter("@lengthMinutes", lengthMinutes)
            };
            int resourceID = Convert.ToInt32(SqlHelper.ExecuteSqlStoredProcedureReturnValue("AddResource", new List<SqlParameter>(parameters)));
            if (resourceID > 0)
            {
                AddResourceTopicLinks(resourceID, topicIDS);
                AddResourceTypeLinks(resourceID, typeIDs);
            }
            return resourceID;
        }

        private static void AddResourceTypeLinks(int resourceID, List<int> typeIDs)
        {
            foreach (int typeID in typeIDs)
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@resourceID", resourceID),
                    new SqlParameter("@typeID", typeID)
                };
                    Convert.ToInt32(SqlHelper.ExecuteSqlStoredProcedureReturnValue("AddResourceTypeLink", new List<SqlParameter>(parameters)));
            }
        }

        private static void AddResourceTopicLinks(int resourceID, List<int> topicIDS)
        {
            foreach (int topicID in topicIDS)
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@resourceID", resourceID),
                    new SqlParameter("@topicID", topicID)
                };
                Convert.ToInt32(SqlHelper.ExecuteSqlStoredProcedureReturnValue("AddResourceTopicLink", new List<SqlParameter>(parameters)));
            }
        }

        private static Resource GenerateResource(DataRow row)
        {
            Resource newResource = new Resource();

            if (row["Id"] != null)
            {
                newResource._ID = Convert.ToInt32(row["Id"].ToString());
            }
            if (row["description"] != null)
            {
                newResource._description = row["description"].ToString();
            }
            if (row["link"] != null)
            {
                newResource._link = row["link"].ToString();
            }
            if (row["lengthMinutes"] != null)
            {
                newResource._lengthMinutes = Convert.ToInt32(row["lengthMinutes"].ToString());
            }

            return newResource;
        }

        public static List<Resource> getResourcesByTopicID(int topicID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@topicID", topicID)
            };

            DataTable ResourceDataTable = SqlHelper.ExecuteSqlStoredProcedureReturnDataTable("GetResourcesByTopicID", new List<SqlParameter>(parameters));
            List<Resource> Resources = new List<Resource>();

            foreach (DataRow row in ResourceDataTable.Rows)
            {
                Resources.Add(GenerateResource(row));
            }

            return Resources;
        }
    }
}