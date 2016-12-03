using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Meeting : System.Web.UI.Page
    {
        private _Student student = new _Student();
        private _Meeting meeting = new _Meeting();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                student = Session["studentsignin"] as _Student;
                GetData();

            }
            else Response.Redirect("/Home");

            if (Session["success"] != null)
            {
                pnlResponseSuccess.Visible = true;
                Session["success"] = null;
                Session.Remove("success");
            }
            else
            {
                pnlResponseFail.Visible = false;
            }
            if (Session["fail"] != null)
            {
                pnlResponseFail.Visible = true;
                Session["fail"] = null;
                Session.Remove("fail");
            }
            else
            {
                pnlResponseFail.Visible = false;
            }
            if (student.MeetingStatus())
            {
                btnRequestMeeting.Enabled = true;
            }
            else
            {
                btnRequestMeeting.Enabled = false;
            }
        }

        private void GetData()
        {
            //check if supervisor exsists
            if (student.SupervisorApprovedStatus()!="")
            {
                pnlSupervisorExsists.Visible = true;
            }
            else pnlSupervisorExsists.Visible = false;



            gvMeeting.DataSource = meeting.GetAllForStudent(student.StudentId).Where(x => x.MeetingTime != null);
            gvMeeting.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvMeeting.PageIndex = e.NewPageIndex;
            GetData();
        }
        protected void btnRequestMeeting_Click(object sender, EventArgs e)
        {
            student.RequestMeeting(student.StudentId, student.GetSupervisorId());
            pnlResponseSuccess.Visible = true;
        }

        protected void gvMeeting_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMeeting.PageIndex = e.NewPageIndex;
            GetData();
        }
    }
}