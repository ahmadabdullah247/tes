using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TES
{
    public class _Presentation
    {
        public long PresentationID { get; set; }
        public string DateTime { get; set; }
        public _Thesis Thesis { get; set; }
        public string PresentationTime { get; set; }

        public List<string> PresentationTimeSet { get; set; }
        private int PresentationCount = 14;


        public _Presentation()
        {
            Thesis = new _Thesis();
            PresentationTimeSet = new List<string>()
                {
                    "14:00-14:15",
                    "14:16-14:30",
                    "14:31-14:45",
                    "14:46-15:00",
                    "15:01-15:15",
                    "15:16-15:30",
                    "15:31-15:45",
                    "15:46-16:00",
                    "16:01-16:15",
                    "16:16-16:30",
                    "16:31-16:45",
                    "16:46-17:00",
                    "17:01-17:15",
                    "17:16-17:30",
                };
        }

        public void Create(DateTime date)
        {
            using (var db = new TESDataContext())
            {
                if (date.DayOfWeek.ToString() == "Saturday")
                {
                    date = date.AddDays(2);
                }
                else if (date.DayOfWeek.ToString() == "Sunday")
                {
                    date = date.AddDays(1);
                }
                ///Delete all before records
                var per = (from p in db.Presentation_Schedules select p).ToList();
                db.Presentation_Schedules.DeleteAllOnSubmit(per);

                //Add new records
                var theses = (from t in db.Thesis select t).ToList();
                if(theses!=null)
                {
                    int count = 0;
                    foreach(var thesis in theses)
                    {
                        var log = new Presentation_Schedule()
                        {
                            thesis_id=thesis.thesis_id,
                            date_time = date.DayOfWeek + " " + date.Day + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month), 
                        };
                        if(count==14)
                        {
                            count = 0;
                            if (date.DayOfWeek.ToString() == "Saturday")
                            {
                                date = date.AddDays(2);
                            }
                            else date = date.AddDays(1);
                        }
                        count++;
                        db.Presentation_Schedules.InsertOnSubmit(log);
                        db.SubmitChanges();
                    }
                }
            }
        }

        public _Presentation GetById(long? id)
        {
            using(var db=new TESDataContext())
            {
                var log = (from p in db.Presentation_Schedules
                           where p.presentation_schedule_Id == id
                           select new _Presentation
                           {
                               PresentationID = p.presentation_schedule_Id,
                               DateTime = p.date_time,
                               Thesis = Thesis.GetById(p.thesis_id),
                           }).FirstOrDefault();
                if(log!=null)
                {
                    return log;
                }
                return null;
            }
        }

        public List<_Presentation> GetAll()
        {
            using (var db = new TESDataContext())
            {
                var logs = (from p in db.Presentation_Schedules
                           select new _Presentation
                           {
                               PresentationID = p.presentation_schedule_Id,
                               DateTime = p.date_time,
                               Thesis = Thesis.GetById(p.thesis_id),
                           }).ToList();
           
                if (logs != null)
                {
                    int i = 0;
                    foreach(var log in logs)
                    {
                        if(i==14)
                        {
                            i=0;
                        }
                        log.PresentationTime = PresentationTimeSet[i];
                        i++;
                    }

                    return logs;
                }
                return null;
            }
        }
    }
}