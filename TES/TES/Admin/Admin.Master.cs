using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["adminsignin"]==null)
            {
                Response.Redirect("/Home");
            }
        }

        protected void lbSignOut_Click(object sender, EventArgs e)
        {
            Session.Remove("adminsignin");
            Response.Redirect("/Home");
        }
    }
}