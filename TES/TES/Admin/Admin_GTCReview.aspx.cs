using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_GTCReview : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();
        private _Thesis thesis = new _Thesis();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            gvGTC.DataSource = thesis.GetAll().Where(x => x.Status == "Ok").ToList();//supervisor.GetAll().Where(x => x.GTC == "Yes").ToList();
            gvGTC.DataBind();
        }

        protected void gvGTC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGTC.PageIndex = e.NewPageIndex;
            GetData();
        }
    }
}