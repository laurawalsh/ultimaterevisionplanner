using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using UltimateRevisionPlannerWebsite;

namespace UltimateRevisionPlannerWebsite
{
    public class commitment
    {
        public int memberID { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public string details { get; set; }
        public int revisionPlanID { get; set; }

        public commitment(DateTime newStartDateTime, DateTime newEndDateTime, string newDetails)
        {
            startDateTime = newStartDateTime;
            endDateTime = newEndDateTime;
            details = newDetails;
        }

        private static int AddCommitment(string memberID, DateTime startDateTime, DateTime endDateTime, string details, int revisionPlanID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@memberID", memberID),//Context.User.Identity.GetUserId()#
                new SqlParameter("@startDateTime", startDateTime),
                new SqlParameter("@endDateTime", endDateTime),
                new SqlParameter("@details", details),
                new SqlParameter("@revisionPlanID", revisionPlanID)
            };
            return Convert.ToInt32(SqlHelper.ExecuteSqlStoredProcedureReturnValue("AddCommitment", new List<SqlParameter>(parameters)));
        }

        internal static void AddCommitments(string memberID, List<commitment> commitments, int revisionPlanID)
        {
            foreach (commitment newcommitment in commitments)
            {
                AddCommitment(memberID, newcommitment.startDateTime, newcommitment.endDateTime, newcommitment.details, revisionPlanID);
            }
        }
    }
}