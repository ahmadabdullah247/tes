using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TES
{
    public class _Meeting
    {
        public long MeetingId { get; set; }
        public string MeetingMin { get; set; }
        public string MeetingTime { get; set; }
        public _Supervisor Supervisor { get; set; }
        public _Student Student { get; set; }

        public _Meeting()
        {
            Supervisor = new _Supervisor();
            Student=new _Student();
        }

        public void Create()
        {
            using(var db=new TESDataContext())
            {
                var log = new Meeting
                {
                    meeting_min=this.MeetingMin,
                    meeting_time=this.MeetingTime,
                    supervisor_id=this.Supervisor.SupervisorId,
                    student_id=this.Student.StudentId,
                };

                db.Meetings.InsertOnSubmit(log);
                db.SubmitChanges();
            }
        }

        public void Edit()
        {
            using (var db = new TESDataContext())
            {
                var log = (from m in db.Meetings
                           where m.meeting_id == this.MeetingId
                           select m).FirstOrDefault();
                if(log!=null)
                {
                    log.meeting_min = this.MeetingMin;
                    log.meeting_time = this.MeetingTime;
                    log.student_id = this.Student.StudentId;
                    log.supervisor_id = this.Supervisor.SupervisorId;
                }
                db.SubmitChanges();
            }
        }

        public void Delete()
        {
            using (var db = new TESDataContext())
            {
                var log = (from m in db.Meetings
                           where m.meeting_id == this.MeetingId
                           select m).FirstOrDefault();
                if (log != null)
                {
                    db.Meetings.DeleteOnSubmit(log);        
                }
                db.SubmitChanges();
            }
        }

        public _Meeting GetById(long id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from m in db.Meetings
                           where m.meeting_id == id
                           select new _Meeting 
                           { 
                            MeetingId=m.meeting_id,
                            MeetingMin=m.meeting_min,
                            MeetingTime=m.meeting_time,
                            Supervisor=Supervisor.GetById(m.supervisor_id),
                            Student=Student.GetById(m.student_id),
                           }).FirstOrDefault();
                if (log != null)
                {
                    return log;
                }
            }
            return null;
        }

        public List<_Meeting> GetAll()
        {
            using (var db = new TESDataContext())
            {
                var log = (from m in db.Meetings
                           select new _Meeting
                           {
                               MeetingId = m.meeting_id,
                               MeetingMin = m.meeting_min,
                               MeetingTime = m.meeting_time,
                               Supervisor = Supervisor.GetById(m.supervisor_id),
                               Student = Student.GetById(m.student_id),
                           }).ToList();
                if (log != null)
                {
                    return log;
                }
            }
            return null;
        }

        public List<_Meeting> GetAllForSupervisor()
        {
            using (var db = new TESDataContext())
            {
                var log = (from m in db.Meetings
                           where m.supervisor_id==this.Supervisor.SupervisorId
                           select new _Meeting
                           {
                               MeetingId = m.meeting_id,
                               MeetingMin = m.meeting_min,
                               MeetingTime = m.meeting_time,
                               Supervisor = Supervisor.GetById(m.supervisor_id),
                               Student = Student.GetById(m.student_id),
                           }).ToList();
                if (log != null)
                {
                    return log;
                }
            }
            return null;
        }
        
        public List<_Meeting> GetAllForStudent(long?  id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from m in db.Meetings
                           where  m.student_id==id
                           select new _Meeting
                           {
                               MeetingId = m.meeting_id,
                               MeetingMin = m.meeting_min,
                               MeetingTime = m.meeting_time,
                               Supervisor = Supervisor.GetById(m.supervisor_id),
                               Student = Student.GetById(m.student_id),
                           }).ToList();
                if (log != null)
                {
                    return log;
                }
            }
            return null;
        }
    
        public void AddMeetingMin(string meetingMin)
        {
            using (var db = new TESDataContext())
            {
                var log = (from m in db.Meetings
                           where m.meeting_id == this.MeetingId
                           select m).FirstOrDefault();
                if (log != null)
                {
                    log.meeting_min = meetingMin;
                }
                db.SubmitChanges();
            }
        }

        public List<_Meeting> GetMeetingsByThesisId(long? id)
        {
            using(var db=new TESDataContext())
            {
                var log = (from t in db.Thesis
                           join m in db.Meetings on t.student_id equals m.student_id
                           where t.thesis_id == id
                           select new _Meeting 
                           { 
                                MeetingId=m.meeting_id,
                                MeetingMin=m.meeting_min,
                                MeetingTime=m.meeting_time,
                                Supervisor=Supervisor.GetById(m.supervisor_id),
                                Student=Student.GetById(m.student_id)
                           }).ToList();
                if(log!=null)
                {
                    return log;
                }
                return null;
            }
        }
    }
}