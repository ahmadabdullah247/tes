using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TES
{

    public class _User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Gender { get; set; }
        public string CNIC { get; set; }
        public string PasswordRecovery { get; set; }

        public _User Signin()
        {
            using (var db = new TESDataContext())
            {
                var log = (from u in db.User_Informations
                           where u.user_name == this.Username && u.user_password == this.Password
                           select new _User
                           {
                               UserId = (int)u.user_id,
                               FullName = u.full_name,
                               Username = u.user_name,
                               Email = u.user_email,
                               Password = u.user_password,
                               Contact = u.user_contact_no,
                               Gender = u.user_gender,
                               CNIC = u.user_cnic_no

                           }).FirstOrDefault();
                if (log != null)
                {
                    return log;
                }
            }
            return null;
        }

        public long? Signup()
        {
            using (var db = new TESDataContext())
            {
                var user = new User_Information
                {
                    full_name = this.FullName,
                    user_name = this.Username,
                    user_email = this.Email,
                    user_password = this.Password,
                    user_contact_no = this.Contact,
                    user_gender = this.Gender,
                    user_cnic_no = this.CNIC
                };
                db.User_Informations.InsertOnSubmit(user);
                db.SubmitChanges();

                return (from u in db.User_Informations where u.user_name == this.Username select u.user_id).FirstOrDefault();
            }
        }

        public void Edit(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from u in db.User_Informations
                           where u.user_id==id
                           select u).FirstOrDefault();

                log.full_name = this.FullName;
                log.user_email = this.Email;
                log.user_contact_no = this.Contact;
                log.user_gender = this.Gender;
                log.user_cnic_no = this.CNIC;

                db.SubmitChanges();
            }
        }

        public void Delete(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from u in db.User_Informations
                           where u.user_id == id
                           select u).FirstOrDefault();


                db.User_Informations.DeleteOnSubmit(log);
                db.SubmitChanges();
            }
        }

        public void ChangePassword()
        {
            using (var db = new TESDataContext())
            {
                var log = (from u in db.User_Informations
                           where u.user_id == this.UserId
                           select u).FirstOrDefault();

                log.user_password = this.Password;

                db.SubmitChanges();
            }
        }

        public _User GetById(long? id)
        {
            using (var db = new TESDataContext())
            {
                var log = (from u in db.User_Informations
                           where u.user_id == id
                           select new _User
                           {
                               UserId = (int)u.user_id,
                               FullName = u.full_name,
                               Username = u.user_name,
                               Email = u.user_email,
                               Password = u.user_password,
                               Contact = u.user_contact_no,
                               Gender = u.user_gender,
                               CNIC = u.user_cnic_no

                           }).FirstOrDefault();
                if (log != null)
                {
                    return log;
                }
            }
            return null;
        }

        public List<_User> GetAll()
        {
            using (var db = new TESDataContext())
            {
                var log = (from u in db.User_Informations
                           select new _User
                           {
                               UserId = (int)u.user_id,
                               FullName = u.full_name,
                               Username = u.user_name,
                               Email = u.user_email,
                               Password = u.user_password,
                               Contact = u.user_contact_no,
                               Gender = u.user_gender,
                               CNIC = u.user_cnic_no

                           }).ToList();
                if (log != null)
                {
                    return log;
                }
            }
            return null;
        }

        public bool UserExists(string name)
        {
            using(var db=new TESDataContext())
            {
                var log = (from u in db.User_Informations
                           where u.user_name == name
                           select u).FirstOrDefault();
                if(log!=null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool UserRegExists(string Reg)
        {
            using (var db = new TESDataContext())
            {
                var log = (from s in db.Student_Informations
                           where s.student_reg_no == Reg
                           select s).FirstOrDefault();
                if (log == null)
                {
                    return true;
                }
                return false;
            }
        }

        public _User CheckEmailExists(string email)
        {
            using (var db = new TESDataContext())
            {
                var log = (from u in db.User_Informations
                           where u.user_email == email
                           select new _User 
                           {
                               UserId = (int)u.user_id,
                           }).FirstOrDefault();
                if (log != null)
                {
                    return log;
                }
                return null;
            }
        }

        public bool ForgetPassword_Email(string email)
        {
            var user=CheckEmailExists(email);
            var recovery=GenerateKey();
            if(user!=null)
            {
                // Sending Email
                _Mail mail = new _Mail();
                mail.Reciver = email;
                mail.Subject = "Password Recovery";
                mail.Message = "Use the following link to recover <br/>" +
                                "Link: http://localhost:52189/UpdatePassword/" + recovery;
                mail.Send();

                // Database Entry
                using (var db = new TESDataContext())
                {
                    var log = (from u in db.User_Informations
                               where u.user_id == user.UserId
                               select u).FirstOrDefault();
                    log.password_recovery = recovery;
                    db.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        private static string GenerateKey()
        {
            int length = 7;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void ForgetPassword(string password, string GUID)
        {
            using (var db = new TESDataContext())
            {
                var log = (from u in db.User_Informations
                           where u.password_recovery == GUID
                           select u).FirstOrDefault();
                if(log!=null)
                {
                    log.user_password = password;
                    log.password_recovery = null;
                    db.SubmitChanges();
                }
            }
        }
    }

}