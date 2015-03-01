using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using UltimateRevisionPlannerWebsite;

namespace UltimateRevisionPlannerWebsite
{
    public class RevisionPlan
    {
        public int Id { get; set; }
        public string MemberID { get; set; }

        public RevisionPlan() { }

        private static string _memberID;

        internal static void AddRevisionPlan(string memberID)
        {
            _memberID = memberID;
            AddRevisionPlan();
        }

        internal static void AddRevisionPlan(string memberID, DateTime StartDate, DateTime EndDate, DateTime StartTime, DateTime EndTime, 
                                             DateTime LunchStartTime, DateTime LunchEndTime, DateTime TeaStartTime, DateTime TeaEndTime,
                                             string fORwWeek)
        {
            _memberID = memberID;
            int revisionPlanID = AddRevisionPlan();
            RevisionPlanSlot.GenerateRevisionPlanSlots(StartDate, EndDate, StartTime, EndTime, LunchStartTime, LunchEndTime, 
                                                       TeaStartTime, TeaEndTime, revisionPlanID, fORwWeek);
        }

        private static int AddRevisionPlan()
        {
            if (!string.IsNullOrEmpty(_memberID))
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MemberID", _memberID)
                };
                return Convert.ToInt32(SqlHelper.ExecuteSqlStoredProcedureReturnValue("AddRevisionPlan", new List<SqlParameter>(parameters)));
            }
            return 0;
        }

        private static RevisionPlan GenerateRevisionPlan(DataRow row)
        {
            RevisionPlan newRevisionPlan = new RevisionPlan();

            if (row["ID"] != null)
            {
                newRevisionPlan.Id = Convert.ToInt32(row["ID"].ToString());
            }
            if (row["MemberID"] != null)
            {
                newRevisionPlan.MemberID = row["MemberID"].ToString();
            }

            return newRevisionPlan;
        }

        internal static List<RevisionPlan> GetRevisionPlans(string memberID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MemberID", memberID)
            };
            DataTable revisionPlanDataTable 
                = SqlHelper.ExecuteSqlStoredProcedureReturnDataTable("GetRevisionPlans", new List<SqlParameter>(parameters));
            List<RevisionPlan> revisionPlans = new List<RevisionPlan>();

            foreach (DataRow row in revisionPlanDataTable.Rows)
            {
                revisionPlans.Add(GenerateRevisionPlan(row));
            }
            revisionPlans.Reverse();
            return revisionPlans;
        }

        internal static void AddRevisionPlan(string memberID, DateTime StartDate, DateTime EndDate, DateTime StartTime, DateTime EndTime, 
                                             DateTime LunchStartTime, DateTime LunchEndTime, DateTime TeaStartTime, DateTime TeaEndTime, 
                                             string fORwWeek, List<commitment> commitments)
        {
            _memberID = memberID;
            int revisionPlanID = AddRevisionPlan();
            commitment.AddCommitments(_memberID, commitments, revisionPlanID);
            RevisionPlanSlot.GenerateRevisionPlanSlots(StartDate, EndDate, StartTime, EndTime, LunchStartTime, LunchEndTime, 
                                                       TeaStartTime, TeaEndTime, revisionPlanID, fORwWeek, commitments);
        }
    }
}