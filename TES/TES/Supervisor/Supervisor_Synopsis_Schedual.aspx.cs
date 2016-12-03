using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Synopsis_Schedual : System.Web.UI.Page
    {
        private _Presentation presentation = new _Presentation();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["supervisorsignin"] != null)
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
            gvPresentationSchedual.DataSource = presentation.GetAll().Where(x => x.Thesis.Status == "Ok").ToList();//thesis.GetAll();
            gvPresentationSchedual.DataBind();
        }

        protected void gvPresentationSchedual_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPresentationSchedual.PageIndex = e.NewPageIndex;
            GetData();
        }
    }
}