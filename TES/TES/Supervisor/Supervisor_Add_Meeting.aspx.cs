using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Add_Meeting : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();
        private _Meeting meeting = new _Meeting();
        private _Thesis thesis = new _Thesis();
        private List<_Thesis> theses = new List<_Thesis>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervisor = Session["supervisorsignin"] as _Supervisor;
                theses = thesis.GetAll(supervisor.SupervisorId);
                if(!IsPostBack)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            List<string> thesesName=theses.Select(x => x.Title).ToList();
            thesesName.Insert(0,"-- Select One --");
            ddlThesis.DataSource = thesesName;
            ddlThesis.DataBind();
        }
        private void SetData()
        {
            var t = theses.Find(x => x.Title == ddlThesis.SelectedValue);
            string time = tsMeeting.Hour + ":" + tsMeeting.Minute + ":" + tsMeeting.Second + " " + tsMeeting.AmPm;
            string date = calMeeting.SelectedDate.Year + "/" + calMeeting.SelectedDate.Month + "/" + calMeeting.SelectedDate.Day;

            meeting.MeetingMin = "";
            meeting.Student = t.Student;
            meeting.Supervisor = supervisor;
            meeting.MeetingTime = date + " " + time;

            meeting.Create();
        }

        protected void btnAddMeeting_Click(object sender, EventArgs e)
        {
            SetData();
            Response.Redirect("/Supervisor/History/Meeting");
        }

        protected void ddlThesis_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name=theses.Find(x => x.Title == ddlThesis.SelectedValue).Student.User.FullName;
            lblStudent.Text=name!=null?name:"";
        }
    }
}