using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TES
{
    public class _Student
    {
        public long? StudentId { get; set; }
        public string RegistrationNo { get; set; }
        public string Semester { get; set; }
        public _User User { get; set; }


        #region Self

        // Constructor
        public _Student()
        {
            User = new _User();
        }

        // Sign In
        public _Student Signin()
        {
            User = User.Signin();
            if (User != null)
            {
                using (var db = new TESDataContext())
                {
                    var log = (from s in db.Student_Informations
                               where s.user_id == User.UserId
                               select new _Student
                               {
                                   StudentId = (int)s.student_id,
                                   RegistrationNo = s.student_reg_no,
                                   Semester = s.student_smester,
                                   User = User,
                               }).FirstOrDefault();

                    if (log != null)
                    {
                        return log;
                    }
                }
            }
            return null;
        }

        // Sign Up 
        public void Signup()
        {
            long? id = User.Signup();
            if (id != 0)
            {
                using (var db = new TESDataContext())
                {
                    var student = new Student_Information
                    {
                        student_reg_no = this.RegistrationNo,
                        student_smester = this.Semester,
                        user_id = id,
                    };

                    db.Student_Informations.InsertOnSubmit(student);
                    db.SubmitChanges();
                }
            }
            // Create folder for thesis uplaod
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/_Files/"+id));
        }

        // Edit
        public void EditProfile()
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Student_Informations
                           where s.student_id == this.StudentId
                           select s).FirstOrDefault();

                User.Edit(log.user_id);
                log.student_reg_no = this.RegistrationNo;
                log.student_smester = this.Semester;

                db.SubmitChanges();
            }
        }

        // Delete
        public void DeleteProfile(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Student_Informations
                           where s.student_id == id
                           select s).FirstOrDefault();

                db.Student_Informations.DeleteOnSubmit(log);
                db.SubmitChanges();
                User.Delete(log.user_id);

            }
        }

        public List<_Student> GetAll()
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Student_Informations
                           select new _Student
                           {
                               StudentId = s.student_id,
                               RegistrationNo = s.student_reg_no,
                               Semester = s.student_smester,
                               User = User.GetById(s.user_id),
                           }).ToList();
                return log;
            }
        }

        public _Student GetById()
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Student_Informations
                           where s.student_id == this.StudentId
                           select new _Student
                           {
                               StudentId = s.student_id,
                               RegistrationNo = s.student_reg_no,
                               Semester = s.student_smester,
                               User = User.GetById(s.user_id),
                           }).FirstOrDefault();
                return log;
            }
        }

        public _Student GetById(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Student_Informations
                           where s.student_id == id
                           select new _Student
                           {
                               StudentId = s.student_id,
                               RegistrationNo = s.student_reg_no,
                               Semester = s.student_smester,
                               User = User.GetById(s.user_id),
                           }).FirstOrDefault();
                return log;
            }
        }

        public void ChangePassword()
        {
            User.ChangePassword();
        }

        #endregion

        #region Business logic

        // Request Supervisor
        public void SelectSupervisor(string email, long? id)
        {
            // Sending Email
            _Mail mail = new _Mail();
            mail.Reciver = email;
            mail.Subject = "Supervisor Request";
            mail.Message = "Will you be my supervisor? <br/>" + this.User.FullName;
            mail.Send();

            // Database Entry
            using (var db = new TESDataContext())
            {
                var log = new Student_Supervisor
                {
                    student_id = this.StudentId,
                    supervisor_id = id,
                    supervise = null,
                };
                db.Student_Supervisors.InsertOnSubmit(log);
                db.SubmitChanges();
            }
        }

        public void SelectCoSupervisor(long? id)
        {
            using(var db =new TESDataContext())
            {
                var log = (from t in db.Thesis
                           where t.student_id == this.StudentId
                           select t).FirstOrDefault();
                if(log!=null)
                {
                    log.cosupervisor_id = id;
                }
                db.SubmitChanges();
            }
        }

        public string CoSupervisorExists()
        {
            _Supervisor s = new _Supervisor();
            using (var db = new TESDataContext())
            {
                var log = (from t in db.Thesis
                           where t.student_id == this.StudentId
                           select t).FirstOrDefault();
                if (log != null)
                {
                    if (log.cosupervisor_id != null)
                    {
                        return s.GetById(log.cosupervisor_id).User.FullName;
                    }                
                }
                return "";
            }
        }
        // Get supervisor name if exist 
        public string SupervisorApprovedStatus()
        {
            using (var db = new TESDataContext())
            {
                // If Supper visor is assigned
                var log = (from ss in db.Student_Supervisors
                           where ss.student_id == this.StudentId && ss.supervise==true
                           select ss.supervisor_id).FirstOrDefault();
                if(log!=null)
                {
                    _Supervisor s = new _Supervisor();
                    return s.GetById(log).User.FullName;
                }
                return "";
            }
        }

        // Get Supervisor selection status true <for selected> false <for not seleted> null <for await>
        public bool? SupervisorAwaitStatus()
        {
            using (var db = new TESDataContext())
            {
                var log = (from ss in db.Student_Supervisors
                           where ss.student_id == this.StudentId
                           select ss).ToList();
                return log.Find(x => x.supervise == null) == null ? false : true;
            }
        }

        // Student requet to supervisor
        public List<_Student> GetAllRequests(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from stu in db.Student_Informations
                           join sup in db.Student_Supervisors
                           on stu.student_id equals sup.student_id
                           where sup.supervisor_id == id && sup.supervise==null
                           select new _Student
                           {
                               StudentId = stu.student_id,
                               RegistrationNo = stu.student_reg_no,
                               Semester = stu.student_smester,
                               User = User.GetById(stu.user_id),
                           }).ToList();
                return log;
            }
        }

        public List<_Student> GetAllSupervisedStudent(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from stu in db.Student_Informations
                           join sup in db.Student_Supervisors
                           on stu.student_id equals sup.student_id
                           where sup.supervisor_id == id && sup.supervise == true
                           select new _Student
                           {
                               StudentId = stu.student_id,
                               RegistrationNo = stu.student_reg_no,
                               Semester = stu.student_smester,
                               User = User.GetById(stu.user_id),
                           }).ToList();
                return log;
            }
        }
        // Students for Spesific Supervisor
        public List<_Student> GetForSupervisor(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from stu in db.Student_Informations
                           join sup in db.Student_Supervisors
                           on stu.student_id equals sup.student_id
                           where sup.supervisor_id == id && sup.supervise == true
                           select new _Student
                           {
                               StudentId = stu.student_id,
                               RegistrationNo = stu.student_reg_no,
                               Semester = stu.student_smester,
                               User = User.GetById(stu.user_id),
                           }).ToList();
                return log;
            }
        }

        // request for meeting 
        public void RequestMeeting(long? stuId, long? supId)
        {
            using (var db = new TESDataContext())
            {
                var log = new Meeting()
                {
                    student_id = stuId,
                    supervisor_id = supId,
                    meeting_time="",
                };
                db.Meetings.InsertOnSubmit(log);
                db.SubmitChanges();
            }
        }

        // Check meeting request submited

        public bool MeetingStatus()
        {
            using (var db = new TESDataContext())
            {
                var log = db.Meetings.Where(x=>x.student_id==this.StudentId).OrderByDescending(x => x.meeting_id).FirstOrDefault();

                if(log!=null)
                {
                    if (log.meeting_time != "")
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public long? GetSupervisorId()
        { 
            using(var db =new TESDataContext())
            {
                var log=(from s in db.Student_Supervisors
                            where s.supervise==true
                             select s).FirstOrDefault();
                return log.supervisor_id;
            }
        }

        #endregion


    }
}