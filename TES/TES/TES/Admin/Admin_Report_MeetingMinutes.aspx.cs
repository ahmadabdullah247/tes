using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Report_MeetingMinutes : System.Web.UI.Page
    {
        private _Thesis thesis = new _Thesis();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                //if (RouteData.Values["id"] != null)
                //{
                //   thesis = thesis.GetById(Convert.ToInt64(RouteData.Values["id"]));
                if (!IsPostBack)
                {
                    GetData();
                }
                //}
                //else Response.Redirect("/Admin/Faculty");
            }
            else Response.Redirect("/Home");

        }

        private void GetData()
        {
            gvThesisReport.DataSource = thesis.GetAll();
            gvThesisReport.DataBind();
        }
    }
}