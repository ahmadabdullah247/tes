using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Password : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervisor = Session["supervisorsignin"] as _Supervisor;
                // Check If Password Updated
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

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (supervisor.User.Password == txtCurrentPassword.Text)
                {
                    supervisor.User.Password = txtPassword.Text;
                    supervisor.ChangePassword();
                    Session.Add("success", true);
                }
                else
                {
                    pnlResponseFail.Visible = true;
                    Session.Add("fail", true);
                }
            }
            catch
            {
                Session.Add("fail", true);
            }
            // Update session
            Session["supervisorsignin"] = supervisor;
            Response.Redirect("/Supervisor/Password");
        }
    }
}