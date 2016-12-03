using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Faculty : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                if (!IsPostBack)
                {
                    GetData();
                }
                if (RouteData.Values["id"] != null)
                {
                    supervisor.DeleteProfile(Convert.ToInt64(RouteData.Values["id"]));
                    Session.Add("delete", true);
                    Response.Redirect("/Admin/Faculty");
                }
                if (Session["delete"] != null)
                {
                    pnlDeleteSuccess.Visible = true;
                    Session.Remove("delete");
                }
                // Check If Profile Updated
                if (Session["success"] != null)
                {
                    pnlResponseSuccess.Visible = true;
                    Session.Remove("success");
                }
                else if (Session["fail"] != null)
                {
                    pnlResponseFail.Visible = true;
                    Session.Remove("fail");
                }
            }
            else Response.Redirect("/Home");  
        }

        private void GetData()
        {
            gvStudent.DataSource = supervisor.GetAll();
            gvStudent.DataBind();
        }
    }
}