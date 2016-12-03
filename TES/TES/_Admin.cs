using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TES
{
    public class _Admin
    {
        public long AdminID { get; set; }
        public _User User { get; set; }

        public _Admin()
        {
            User = new _User();
        }

        public _Admin Signin()
        {
            User=User.Signin();

            if(User!=null)
            {
                using (var db = new TESDataContext())
                {
                    var log = (from a in db.Admin_Informations
                               where a.user_id == User.UserId 
                               select new _Admin
                               {
                                   AdminID = a.admin_id,
                                   User=User
                               }).FirstOrDefault();
                    if (log != null)
                    {
                        return log;
                    }
                }
            }
            return null;
        }

        public void EditProfile()
        {
            using(var db=new TESDataContext())
            {
                var log = (from a in db.Admin_Informations
                           where a.admin_id == this.AdminID
                           select a).FirstOrDefault();
                User.Edit(log.user_id);
            }
        }

        public void ChangePassword()
        {
            User.ChangePassword();
        }

        //public void Signout()
        //{

        //}
        //public _Admin ViewProfile()
        //{
        //    using (var db = new TESDataClassesDataContext())
        //    {
        //        var log = (from a in db.Admin_Informations
        //                   where a.user_id == User.UserId
        //                   select new _Admin
        //                   {
        //                       AdminID = a.admin_id,
        //                       User = User
        //                   }).FirstOrDefault();
        //        if (log != null)
        //            return log;
        //    }
        //    return null;

        //}

        //public void ManageUser()
        //{
        //    using (var db = new TESDataClassesDataContext())
        //    {
        //        var log = (from u in db.User_Informations
        //                   where u.user_id == this.UserID
        //                   select u).ToList();

        //    }
        //}


        //public void changepassword(string newpassword)
        //{
        //    using (var db = new TESDataClassesDataContext())
        //    {
        //        var log = (from y in db.User_Informations
        //                   join z in db.Admin_Informations on y.user_id equals z.user_id
        //                   where y.user_id == this.UserID
        //                   select y).First();
        //        log.user_password = newpassword;
        //        db.SubmitChanges();
        //    }
        //}
        //public void ResetPassword(String p)
        //{

        //}

        //internal object getAdmin(long p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}