using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TES
{
    public class _Supervisor
    {

        public long? SupervisorId { get; set; }
        public string GTC { get; set; }
        public string Title { get; set; }
        public _User User { get; set; }

        public List<_Thesis> Thesis { get; set; }

        #region Self

        public _Supervisor()
        {
            User = new _User();
            Thesis = new List<_Thesis>();
        }

        public _Supervisor Signin()
        {
            User = User.Signin();
            if(User!=null)
            {
                using (var db = new TESDataContext())
                {
                    var log = (from t in db.Supervisor_Informations
                               where t.user_id == User.UserId
                               select new _Supervisor
                               {
                                   GTC = t.supervisor_gtc_member,
                                   Title = t.supervisor_job_title,
                                   SupervisorId = (int)t.supervisor_id,
                                   User=User,
                               }).FirstOrDefault();

                    if (log != null)
                    {
                        return log;
                    }
                }
            }
            return null;
        }

        public void Signup()
        {
            var id = User.Signup();
            if (id != 0)
            {
                using (var db = new TESDataContext())
                {
                    var supervisor = new Supervisor_Information
                    {
                        supervisor_gtc_member = this.GTC,
                        supervisor_job_title = this.Title,
                        user_id = id,
                    };
                    db.Supervisor_Informations.InsertOnSubmit(supervisor);
                    db.SubmitChanges();
                }
            }
        }

        public void EditProfile()
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Supervisor_Informations
                           where s.supervisor_id == this.SupervisorId
                           select s).FirstOrDefault();

                User.Edit(log.user_id);
                log.supervisor_gtc_member = this.GTC;
                log.supervisor_job_title = this.Title;

                db.SubmitChanges();
            }
        }

        public void DeleteProfile(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Supervisor_Informations
                           where s.supervisor_id == id
                           select s).FirstOrDefault();

                db.Supervisor_Informations.DeleteOnSubmit(log);
                db.SubmitChanges();

                User.Delete(log.user_id);
            }
        }

        public List<_Supervisor> GetAll()
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Supervisor_Informations
                           select new _Supervisor
                           {
                               GTC = s.supervisor_gtc_member,
                               SupervisorId = s.supervisor_id,
                               Title = s.supervisor_job_title,
                               User = User.GetById(s.user_id),
                           }).ToList();
                return log;
            }
        }

        public _Supervisor GetById(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Supervisor_Informations
                           where s.supervisor_id==id
                           select new _Supervisor
                           {
                               GTC = s.supervisor_gtc_member,
                               SupervisorId = s.supervisor_id,
                               Title = s.supervisor_job_title,
                               User = User.GetById(s.user_id),
                           }).FirstOrDefault();
                return log;
            }
        }

        public void ChangePassword()
        {
            User.ChangePassword();
        }

        public void AddThesis(_Thesis thesis)
        {
            thesis.Add();
        }

        public List<_Thesis> GetAllThesis()
        {
            _Thesis t = new _Thesis();
            return t.GetAll(this.SupervisorId);
        }

        #endregion 

        #region Business Logic
            
        public void Supervise(long? id)
        {
            using(var db=new TESDataContext())
            {
                var logs = (from s in db.Student_Supervisors where s.student_id == id select s).ToList();
                foreach(var log in logs)
                {
                    if(log.supervisor_id==this.SupervisorId)
                    {
                        // Assign Supervisor
                        log.supervise = true;
                    }
                    else
                    {
                        // Remove request for all other supervisor
                        log.supervise = false;
                    }
                }
                db.SubmitChanges();
            }
        }

        public void DontSupervise(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Student_Supervisors where s.student_id == id select s).FirstOrDefault();
                log.supervise = false;
                db.SubmitChanges();
            }
        }

        public List<Meeting> GetAllMeeting()
        {
            using(var db=new TESDataContext())
            {
                var log = (from m in db.Meetings
                           where m.supervisor_id == this.User.UserId
                           select m).ToList();
                return log;
            }
        }

        #endregion
    }
}