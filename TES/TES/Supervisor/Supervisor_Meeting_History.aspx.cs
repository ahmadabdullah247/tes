﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Meeting_History : System.Web.UI.Page
    {
        private _Supervisor supervvisor = new _Supervisor();
        private _Meeting meeting = new _Meeting();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervvisor = Session["supervisorsignin"] as _Supervisor;

                meeting.Supervisor.SupervisorId = supervvisor.SupervisorId;
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
        }

        private void GetData()
        {
            gvMeeting.DataSource = meeting.GetAllForSupervisor().Where(x => x.MeetingTime != null);
            gvMeeting.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvMeeting.PageIndex = e.NewPageIndex;
            GetData();
        }
    }
}