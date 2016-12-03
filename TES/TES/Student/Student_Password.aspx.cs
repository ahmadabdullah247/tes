using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Password : System.Web.UI.Page
    {
        private _Student student = new _Student();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                student = Session["studentsignin"] as _Student;

                // Check If Password Updated
                if (Session["success"] != null)
                {
                    pnlResponseSuccess.Visible = true;
                    Session.Remove("success");
                }
                else if (Session["fail"] != null)
                {
                    pnlResponseFail.Visible = true;
                    Session.Remove("fail");
                }
            }
            else Response.Redirect("/Home");
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (student.User.Password == txtCurrentPassword.Text)
                {
                    student.User.Password = txtPassword.Text;
                    student.ChangePassword();
                    Session.Add("success", true);
                }
                else
                {
                    pnlResponseFail.Visible = true;
                    Session.Add("fail", true);
                }
            }
            catch
            {
                Session.Add("fail", true);
            }
            // Update session
            Session["studentsignin"] = student;
            Response.Redirect("/Student/Password");
        }
    }
}