using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace UltimateRevisionPlannerWebsite
{
    public class RevisionPlanSlot
    {
        public int _Id { get; set; }
        public DateTime _StartDate { get; set; }
        public DateTime _EndDate { get; set; }
        public string _Subject { get; set; }
        public string _Description { get; set; }
        public string _ReminderInfo { get; set; }
        public int _RevisionPlanID { get; set; }

        public RevisionPlanSlot(DateTime StartDate, DateTime EndDate, string Subject, string Description, int RevisionPlanID)
        {
            _StartDate = StartDate;
            _EndDate = EndDate;
            _Subject = Subject;
            _Description = Description;
            _ReminderInfo = string.Empty;
            _RevisionPlanID = RevisionPlanID;
        }

        internal static void GenerateTestRevisionPlanSlots(int RevisionPlanID)
        {
            AddRevisionPlanSlot(new RevisionPlanSlot(DateTime.Now, DateTime.Now.AddHours(1), "test1", "test description1", RevisionPlanID));
            AddRevisionPlanSlot(new RevisionPlanSlot(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2), "test2", "test description2", RevisionPlanID));
            AddRevisionPlanSlot(new RevisionPlanSlot(DateTime.Now.AddHours(2), DateTime.Now.AddHours(3), "test3", "test descritpion3", RevisionPlanID));
        }

        internal static void GenerateRevisionPlanSlots(DateTime StartDate, DateTime EndDate, 
                                                       DateTime StartTime, DateTime EndTime, 
                                                       DateTime LunchStartTime, DateTime LunchEndTime, 
                                                       DateTime TeaStartTime, DateTime TeaEndTime, 
                                                       int revisionPlanID, string fORwWeek)
        {
            GenerateRevisionPlanSlots(StartDate, EndDate, StartTime, EndTime, LunchStartTime, LunchEndTime, TeaStartTime, TeaEndTime,
                                      revisionPlanID, fORwWeek, null);
        }

        internal static void AddRevisionPlanSlot(RevisionPlanSlot slot)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@StartDate", slot._StartDate),
                new SqlParameter("@EndDate", slot._EndDate),
                new SqlParameter("@Subject", slot._Subject),
                new SqlParameter("@Description", slot._Description),
                new SqlParameter("@RevisionPlanID", slot._RevisionPlanID)
            };
            SqlHelper.ExecuteSqlStoredProcedureReturnValue("AddRevisionPlanSlot", new List<SqlParameter>(parameters));

        }

        internal static void GenerateRevisionPlanSlots(DateTime StartDate, DateTime EndDate, DateTime StartTime, DateTime EndTime,
                                                       DateTime LunchStartTime, DateTime LunchEndTime, DateTime TeaStartTime,
                                                       DateTime TeaEndTime, int revisionPlanID, string fORwWeek, List<commitment> commitments)
        {
            Boolean excludeWeekends = false;
            if (fORwWeek == "Work Week")
            {
                excludeWeekends = true;
            }

            int count = 1;
            //loop all the days from StartDate to EndDate taking into account if it is a work week or full week
            for (DateTime date = StartDate.Date; date <= EndDate.Date; date += TimeSpan.FromDays(1))
            {
                if (CheckWeekends(date, excludeWeekends) && CheckCommitmentsDate(date, commitments))
                {
                    StartTime = new DateTime(date.Year, date.Month, date.Day, StartTime.Hour, StartTime.Minute, StartTime.Second);
                    EndTime = new DateTime(date.Year, date.Month, date.Day, EndTime.Hour, EndTime.Minute, EndTime.Second);
                    //for each day loop through all times from StartTimeToEndTime - in 1 hour periods
                    for (DateTime time = StartTime; time < EndTime; time += TimeSpan.FromHours(1))
                    {
                        if (CheckCommitmentsTime(time, commitments))
                        {
                            LunchStartTime = new DateTime(date.Year, date.Month, date.Day, LunchStartTime.Hour, LunchStartTime.Minute, LunchStartTime.Second);
                            LunchEndTime = new DateTime(date.Year, date.Month, date.Day, LunchEndTime.Hour, LunchEndTime.Minute, LunchEndTime.Second);
                            TeaStartTime = new DateTime(date.Year, date.Month, date.Day, TeaStartTime.Hour, TeaStartTime.Minute, TeaStartTime.Second);
                            TeaEndTime = new DateTime(date.Year, date.Month, date.Day, TeaEndTime.Hour, TeaEndTime.Minute, TeaEndTime.Second);
                            //if not in lunch time or tea time then add revision slot
                            if ((time < LunchStartTime || time >= LunchEndTime) && (time < TeaStartTime || time >= TeaEndTime))
                            {
                                AddRevisionPlanSlot(new RevisionPlanSlot(date.AddHours(time.TimeOfDay.Hours),
                                                                         date.AddHours(time.TimeOfDay.Hours + 1),
                                                                         "Slot: " + count,
                                                                         getRevisionTopic(count % 5),
                                                                         revisionPlanID));
                                count += 1;
                            }
                        }
                    }
                }
            }
        }

        private static string getRevisionTopic(int count)
        {
            switch (count)
            {
                case 1:
                    return "Introduction";
                case 2:
                    return "Operations";
                case 3:
                    return "Polar Form";
                case 4:
                    return "Solving Equations";
                case 0:
                    return "Argand Diagrams";
                default:
                    return "any"; 
            }
        }

        private static Boolean CheckWeekends(DateTime date, Boolean excludeWeekends)
        {
            return ((excludeWeekends && date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday)
                        || (!excludeWeekends));
        }

        private static Boolean CheckCommitmentsTime(DateTime date, List<commitment> commitments)
        {
            foreach (commitment currCommitment in commitments)
            {
                if (date >= currCommitment.startDateTime && date < currCommitment.endDateTime) return false;
            }
            return true;
        }

        private static Boolean CheckCommitmentsDate(DateTime date, List<commitment> commitments)
        {
            foreach (commitment currCommitment in commitments)
            {
                if (date.Date > currCommitment.startDateTime.Date && date < currCommitment.endDateTime.Date) return false;
            }
            return true;
        }
    }
}