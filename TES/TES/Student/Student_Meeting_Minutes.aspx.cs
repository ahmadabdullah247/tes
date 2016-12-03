using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Meeting_Minutes : System.Web.UI.Page
    {
        private _Meeting meeting = new _Meeting();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    GetData();
                }
                else Response.Redirect("/Student/Meeting");// Previous page
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            meeting = meeting.GetById(Convert.ToInt64(RouteData.Values["id"]));

            if (meeting.MeetingTime == "")
            {
                Response.Redirect("/Student/Meeting/");
            }
            else if (meeting.MeetingMin != null)
            {
                txtMeetingMin.Text = meeting.MeetingMin;
                txtMeetingMin.Enabled = false;
            }
        }

    }
}