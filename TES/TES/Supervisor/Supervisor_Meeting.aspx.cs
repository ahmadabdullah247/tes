using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Meeting : System.Web.UI.Page
    {
        private _Supervisor supervvisor = new _Supervisor();
        private _Meeting meeting = new _Meeting();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervvisor = Session["supervisorsignin"] as _Supervisor;
                if (RouteData.Values["id"] != null)
                {
                    GetData();

                    if (!IsPostBack)
                    {
                        DateTime dt = DateTime.Parse("12:35 PM");
                        MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
                        if (dt.ToString("tt") == "AM")
                        {
                            am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                        }
                        else
                        {
                            am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                        }
                        tsMeeting.SetTime(dt.Hour, dt.Minute, am_pm);
                    }
                }
                else Response.Redirect("/Supervisor/Meeting");
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            meeting = meeting.GetById(Convert.ToInt64(RouteData.Values["id"]));
        }

        private void SetData()
        {
            string time = tsMeeting.Hour + ":" + tsMeeting.Minute + ":" + tsMeeting.Second+" "+tsMeeting.AmPm;
            string date = calMeeting.SelectedDate.Year + "/" + calMeeting.SelectedDate.Month + "/" + calMeeting.SelectedDate.Day;

                meeting.MeetingTime = date + " " + time;
                meeting.Edit();
        }

        protected void btnSetMeeting_Click(object sender, EventArgs e)
        {
            SetData();
            Response.Redirect("/Supervisor/History/Meeting");
        }
    }
}