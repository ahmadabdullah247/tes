using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Thesis : System.Web.UI.Page
    {
        private _Supervisor supervvisor = new _Supervisor();
        private _Thesis thesis = new _Thesis();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervvisor = Session["supervisorsignin"] as _Supervisor;
                if (supervvisor != null)
                {
                    if (!IsPostBack)
                    {
                        GetData();
                    }
                }
                if (RouteData.Values["id"] != null)
                {
                    thesis.ThesisID = Convert.ToInt64(RouteData.Values["id"]);
                    thesis.Delete();
                    Response.Redirect("/Supervisor/Thesis");
                }
                if(Session["success-add"]!=null)
                {
                    pnlResponseSuccess.Visible = true;
                    Session.Remove("success-add");
                }
                else
                {
                    pnlResponseSuccess.Visible = false;
                }
                if (Session["success-update"] != null)
                {
                    pnlResponseFail.Visible = true;
                    Session.Remove("success-update");
                }
                else
                {
                    pnlResponseFail.Visible = false;
                }
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            gvThesis.DataSource = supervvisor.GetAllThesis();
            gvThesis.DataBind();
        }
    }
}