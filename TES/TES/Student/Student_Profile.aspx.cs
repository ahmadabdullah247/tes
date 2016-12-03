using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Profile : System.Web.UI.Page
    {
        private _Student student = new _Student();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                student = Session["studentsignin"] as _Student;
                if (!IsPostBack)
                {
                    GetData();
                }
                // Check If Profile Updated
                if (Session["success"] != null)
                {
                    pnlResponseSuccess.Visible = true;
                    Session.Remove("success");
                    Session["success"] = null;
                }
                else if (Session["fail"] != null)
                {
                    pnlResponseFail.Visible = true;
                    Session.Remove("fail");
                    Session["fail"] = null;
                }
            }
            else Response.Redirect("/Home");
        }

        public void GetData()
        {
            if (student != null)
            {
                ltrfname.Text = student.User.FullName;
                ltruname.Text = student.User.Username;
                ltrcontact.Text = student.User.Contact;
                ltrcnic.Text = student.User.CNIC;
                ltremail.Text = student.User.Email;
                ltrgender.Text = student.User.Gender;
                ltrRegNo.Text = student.RegistrationNo;
                ltrSemester.Text = student.Semester;
            }
        }
    }
}