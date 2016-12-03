using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] == null)
            {
                Response.Redirect("/Home");
            }
            else
            {
                var supervisor = Session["supervisorsignin"] as _Supervisor;
                if (supervisor.GTC == "Yes")
                {
                    litGTCReviw.Visible = true;
                }
                else litGTCReviw.Visible = false;
            }
        }

        protected void lbSignOut_Click(object sender, EventArgs e)
        {
            Session.Remove("supervisorsignin");
            Response.Redirect("/Home");
        }
    }
}