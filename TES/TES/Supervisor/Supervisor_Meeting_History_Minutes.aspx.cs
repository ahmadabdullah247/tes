using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Meeting_History_Minutes : System.Web.UI.Page
    {

        private _Meeting meeting = new _Meeting();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    GetData();
                }
                else Response.Redirect("/Supervisor/History/Meeting");// Previous page
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            meeting = meeting.GetById(Convert.ToInt64(RouteData.Values["id"]));

            if (meeting.MeetingTime == "")
            {
                Response.Redirect("/Supervisor/Meeting/Request");
            }
            else if(meeting.MeetingMin!=null)
            {
                txtMeetingMin.Text = meeting.MeetingMin;
                txtMeetingMin.Enabled = false;
                btnMeetingMin.Visible = false;
            }
        }

        private void SetData()
        {
            try
            {
                if (txtMeetingMin.Text != "")
                {
                    meeting.AddMeetingMin(txtMeetingMin.Text);
                    Session.Add("success", true);
                }
                else
                {
                    Session.Add("fail", true);
                }
            }
            catch
            {
                Session.Add("fail", true);
            }
        }

        protected void btnMeetingMin_Click(object sender, EventArgs e)
        {
            SetData();
            Response.Redirect("/Supervisor/History/Meeting/");
        }
    }
}