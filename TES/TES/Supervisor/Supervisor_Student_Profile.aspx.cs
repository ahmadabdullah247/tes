using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Student_Profile : System.Web.UI.Page
    {
        private _Student student = new _Student();
        private _Supervisor supervisor = new _Supervisor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    supervisor = Session["supervisorsignin"] as _Supervisor;
                    student = student.GetById(Convert.ToInt64(RouteData.Values["id"]));
                    if (!IsPostBack)
                    {
                        GetData();
                    }
                }
                else
                {
                    Response.Redirect("/Supervisor/Student");
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

        protected void btnSupervise_Click(object sender, EventArgs e)
        {
            supervisor.Supervise(student.StudentId);
            Session.Add("success", true);
            Response.Redirect("/Supervisor/Student");
        }

        protected void btnDontSupervise_Click(object sender, EventArgs e)
        {
            supervisor.DontSupervise(student.StudentId);
            Session.Add("fail", true);
            Response.Redirect("/Supervisor/Student");
        }
    }
}