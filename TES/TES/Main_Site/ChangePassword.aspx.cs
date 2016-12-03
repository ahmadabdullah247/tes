using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Main_Site
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private _User user = new _User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["GUID"] == null)
            {
                Response.Redirect("/Home");
            }
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
           if(txtPassword.Text!="")
           {
               user.ForgetPassword(txtPassword.Text, RouteData.Values["GUID"].ToString());
               pnlResponseSuccess.Visible = true;
           }
        }
    }
}