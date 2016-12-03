using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Report : System.Web.UI.Page
    {
        public _Thesis thesis = new _Thesis();
        private _Meeting meeting = new _Meeting();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    if (!IsPostBack)
                    {
                        thesis = thesis.GetById(Convert.ToInt64(RouteData.Values["id"]));
                        GetData();
                    }
                }
                else Response.Redirect("/Admin/Report/Meeting");
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            gvThesisMeeting.DataSource = meeting.GetMeetingsByThesisId(thesis.ThesisID);
            gvThesisMeeting.DataBind();
        }

        protected void btnPrintPage_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "PrintOperation", "print()", true);
        }
    }
}