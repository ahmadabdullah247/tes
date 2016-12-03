using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TES
{
    public class _Thesis
    {
        public long? ThesisID { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string Discription { get; set; }
        public string Status { get; set; }
        public _Supervisor Supervisor { get; set; }
        public _Student Student { get; set; }

        public long? FileID { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string Review { get; set; }
        public string GTCReview { get; set; }

        public List<GTC_Review> GTCReviews { get; set; }

        public _Thesis()
        {
            Supervisor = new _Supervisor();
            Student = new _Student();
        }

        public void Add()
        {
            using (var db = new TESDataContext())
            {
                var log = new Thesi
                {
                    thesis_title = this.Title,
                    thesis_domain = this.Domain,
                    thesis_discription = this.Discription,
                    thesis_status = this.Status,
                    student_id = null,
                    supervisor_id = this.Supervisor.SupervisorId,
                };

                db.Thesis.InsertOnSubmit(log);
                db.SubmitChanges();
            }
        }

        public void Edit()
        {
            using (var db = new TESDataContext())
            {
                // Update Thesis
                var log = (from t in db.Thesis
                           where t.thesis_id == this.ThesisID
                           select t).FirstOrDefault();

                log.thesis_title = this.Title;
                log.thesis_domain = this.Domain;
                log.thesis_discription = this.Discription;
                log.thesis_status = this.Status;
                log.student_id = this.Student.StudentId;
                log.supervisor_id = this.Supervisor.SupervisorId;

                // Assign thesis
                //var AssignStu = (from t in db.Student_Thesis_Supervisors
                //                 where t.thesis_id == this.ThesisID
                //                 select t).FirstOrDefault();

                //AssignStu.thesis_id = this.ThesisID;
                //AssignStu.supervisor_id = this.Supervisor.SupervisorId;
                //AssignStu.student_id = this.Student.StudentId;


                db.SubmitChanges();
            }
        }

        public void Delete()
        {
            using (var db = new TESDataContext())
            {
                var log = (from t in db.Thesis
                           where t.thesis_id == this.ThesisID
                           select t).FirstOrDefault();

                db.Thesis.DeleteOnSubmit(log);
                db.SubmitChanges();
            }
        }

        public _Thesis GetById(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from t in db.Thesis
                           where t.thesis_id == id
                           select new _Thesis
                           {
                               ThesisID = t.thesis_id,
                               Title = t.thesis_title,
                               Domain = t.thesis_domain,
                               Discription = t.thesis_discription,
                               Status = t.thesis_status,
                               Supervisor = Supervisor.GetById(t.supervisor_id),
                               Student = Student.GetById(t.student_id),
                           }).FirstOrDefault();
                return log;
            }
        }

        // Get All thesis
        public List<_Thesis> GetAll()
        {
            using (var db = new TESDataContext())
            {
                var log = (from t in db.Thesis
                           select new _Thesis
                           {
                               ThesisID = t.thesis_id,
                               Title = t.thesis_title,
                               Domain = t.thesis_domain,
                               Discription = t.thesis_discription,
                               Status = t.thesis_status,
                               Supervisor = Supervisor.GetById(t.supervisor_id),
                               Student = Student.GetById(t.student_id),
                           }).ToList();
                return log;
            }
        }

        // Get All Thesis for supervisor
        public List<_Thesis> GetAll(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from t in db.Thesis
                           where t.supervisor_id == id
                           select new _Thesis
                           {
                               ThesisID = t.thesis_id,
                               Title = t.thesis_title,
                               Domain = t.thesis_domain,
                               Discription = t.thesis_discription,
                               Status = t.thesis_status,
                               Supervisor = Supervisor.GetById(t.supervisor_id),
                               Student = Student.GetById(t.student_id),
                           }).ToList();
                return log;
            }
        }

        public _Thesis GetByStudentId()
        {
            using (var db = new TESDataContext())
            {
                var log = (from t in db.Thesis
                           where t.student_id==this.Student.StudentId
                           select new _Thesis
                           {
                               ThesisID = t.thesis_id,
                               Title = t.thesis_title,
                               Domain = t.thesis_domain,
                               Discription = t.thesis_discription,
                               Status = t.thesis_status,
                               Supervisor = Supervisor.GetById(t.supervisor_id),
                               Student = Student.GetById(t.student_id),
                           }).FirstOrDefault();
                

                if(log!=null)
                {
                    log.GTCReviews = (from gr in db.GTC_Reviews select gr).ToList();
                    var files = (from f in db.Thesis_Files
                                 where f.thesis_id == log.ThesisID
                                 select f).ToList();

                    if(files.Count!=0)
                    {
                        log.GTCReview = files[files.Count - 1].gtc_review;
                    }
                    return log;
                }
                return null;
            }        
        }

        public bool IsAssigned()
        {
            using (var db = new TESDataContext())
            {
                var log = (from sts in db.Thesis
                           where sts.student_id == this.Student.StudentId
                           select sts).FirstOrDefault();
                if (log != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void UploadThesis()
        {
            using(var db=new TESDataContext())
            {
                var log = new Thesis_File
                {
                    thesis_id=Convert.ToInt64(this.ThesisID),
                    file_path=this.FilePath,
                    file_name=this.FileName
                };

                db.Thesis_Files.InsertOnSubmit(log);
                db.SubmitChanges();
            }
        }
        
        public List<_Thesis> GetAllSubmission(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from f in db.Thesis_Files
                           where f.thesis_id == this.ThesisID
                           select new _Thesis
                           {
                               FileID = f.file_Id,
                               ThesisID = this.ThesisID,
                               FilePath = f.file_path,
                               FileName=f.file_name,
                               Review = f.review
                           }).ToList();
                if(log!=null)
                {
                    return log;
                }
                return null;
            }
        }
        
        public _Thesis GetSubmissionById(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from f in db.Thesis_Files
                           join t in db.Thesis on f.thesis_id equals t.thesis_id
                           where f.file_Id == id
                           select new _Thesis
                           {
                               ThesisID = t.thesis_id,
                               Title = t.thesis_title,
                               Domain = t.thesis_domain,
                               Discription = t.thesis_discription,
                               Status = t.thesis_status,

                               FileID = f.file_Id,
                               FilePath = f.file_path,
                               FileName = f.file_name,
                               Review = f.review,
                           }).FirstOrDefault();
                if (log != null)
                {
                    return log;
                }
                return null;
            }
        }

        public _Thesis GetGTCSubmissionById(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from f in db.GTC_Reviews
                           join t in db.Thesis on f.thesis_id equals t.thesis_id
                           where t.thesis_id == id
                           select new _Thesis
                           {
                               ThesisID = t.thesis_id,
                               Title = t.thesis_title,
                               Domain = t.thesis_domain,
                               Discription = t.thesis_discription,
                               Status = t.thesis_status,
                           }).FirstOrDefault();
                if (log != null)
                {
                    log.GTCReviews = (from gr in db.GTC_Reviews
                                  where gr.thesis_id == id
                                  select gr).ToList();
                    return log;
                }
                return null;
            }
        }

        public void AddReview(string msg)
        {
            using(var db =new TESDataContext())
            {
                var log = (from f in db.Thesis_Files
                           where f.file_Id == this.FileID
                           select f).FirstOrDefault();
                log.review = msg;
                db.SubmitChanges();
            }
        }

        public void AddGTCReview(string msg, long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from gr in db.GTC_Reviews
                           where gr.gtc_id == id
                           select gr).FirstOrDefault();
                log.gtc_review1 = msg;
                db.SubmitChanges();
            }
        }

        public void Approve(string status)
        {
            using (var db = new TESDataContext())
            {
                var log = (from t in db.Thesis
                           where t.thesis_id == this.ThesisID
                           select t).FirstOrDefault();
                log.thesis_status = status;
                db.SubmitChanges();
            }
        }

        public List<_Thesis> GetAllGTCSubmission()
        {
            using (var db = new TESDataContext())
            {
                var logs = (from f in db.Thesis_Files
                           join t in db.Thesis on f.thesis_id equals t.thesis_id
                           select new _Thesis
                           {
                               ThesisID = t.thesis_id,
                               Title = t.thesis_title,
                               Domain = t.thesis_domain,
                               Discription = t.thesis_discription,
                               Status = t.thesis_status,

                               FileID = f.file_Id,
                               FilePath = f.file_path,
                               FileName = f.file_name,
                               Review = f.review
                           }).ToList();

                var log = new List<_Thesis>();
                foreach(var t in logs)
                {
                    if(log.Find(x=>x.ThesisID==t.ThesisID)==null && t.Status=="Ok")
                    {
                        var y = logs.Where(x => x.ThesisID == t.ThesisID).Max(x => x.FileID);
                        log.Add(logs.Where(x=>x.FileID==y).FirstOrDefault());
                    }
                }
                if (log != null)
                {
                    return log;
                }
                return null;
            }
        }

        public List<_Thesis> GetAllGTCAssigned()
        {
            using (var db = new TESDataContext())
            {
                var logs = (from f in db.Thesis_Files
                            join t in db.Thesis on f.thesis_id equals t.thesis_id
                            join gr in db.GTC_Reviews on t.thesis_id equals gr.thesis_id
                            where gr.gtc_id==this.Supervisor.SupervisorId
                            select new _Thesis
                            {
                                ThesisID = t.thesis_id,
                                Title = t.thesis_title,
                                Domain = t.thesis_domain,
                                Discription = t.thesis_discription,
                                Status = t.thesis_status,

                                FileID = f.file_Id,
                                FilePath = f.file_path,
                                FileName = f.file_name,
                                Review = f.review
                            }).ToList();

                if (logs != null)
                {
                    return logs;
                }
                return null;
            }
        }

        public List<_Thesis> GetGTCAssignedThesis()
        {
            List<_Thesis> thesis = new List<_Thesis>();
            using (var db = new TESDataContext())
            {
                var logs = (from t in db.GTC_Reviews
                           where t.gtc_id==this.Supervisor.SupervisorId
                           select t).ToList();
                foreach(var log in logs)
                {
                    thesis.Add(this.GetById(log.thesis_id));
                }
                if(thesis.Count!=0)
                {
                    return thesis;
                }
                return null;
            }
        }

        public void AssignToGTC(long? supervisorId,List<string> assignedThesisName, List<string> unAssignedThesisName)
        {
            using(var db=new TESDataContext())
            {
                var theses = (from t in db.Thesis select t).ToList();
                var thesesForGTC = (from gr in db.GTC_Reviews
                                    join t in db.Thesis on gr.thesis_id  equals t.thesis_id
                                    where gr.gtc_id == supervisorId 
                                    select new 
                                    {
                                        t.thesis_id,
                                        t.thesis_status,
                                        t.student_id,
                                        t.supervisor_id,
                                        t.thesis_discription,
                                        t.thesis_domain,
                                        t.thesis_title
                                    }).ToList();

                // Remove unassigned
                foreach(var uatn in unAssignedThesisName)
                {
                    var log = (from gr in db.GTC_Reviews
                                join t in db.Thesis on gr.thesis_id equals t.thesis_id
                                where gr.gtc_id == supervisorId && t.thesis_title==uatn
                                select gr).FirstOrDefault();
                    if (log != null)
                    {
                        db.GTC_Reviews.DeleteOnSubmit(log);
                        db.SubmitChanges();                    
                    }
                }
                // Add assigned
                foreach (var uatn in assignedThesisName)
                {
                    var log = (from gr in db.GTC_Reviews
                               join t in db.Thesis on gr.thesis_id equals t.thesis_id
                               where gr.gtc_id == supervisorId && t.thesis_title == uatn
                               select gr).FirstOrDefault();
                    //if don't exsists add
                    if(log==null)
                    {
                        var l=(from t in db.Thesis where t.thesis_title==uatn select t).FirstOrDefault();
                        if(l!=null)
                        {
                            var val = new GTC_Review
                            {
                                thesis_id=l.thesis_id,
                                gtc_id=Convert.ToInt64(supervisorId),
                                gtc_review1="",
                            };
                            db.GTC_Reviews.InsertOnSubmit(val);
                            db.SubmitChanges();
                        }
                    }
                }
            }
        }

        public dynamic GetThesisGTCReview()
        {
            using(var db=new TESDataContext())
            {
                var log = (from gr in db.GTC_Reviews
                           where gr.thesis_id == this.ThesisID
                           select new _Thesis 
                           { 
                                ThesisID=gr.thesis_id,
                                Supervisor=Supervisor.GetById(gr.gtc_id),
                                GTCReview=gr.gtc_review1
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