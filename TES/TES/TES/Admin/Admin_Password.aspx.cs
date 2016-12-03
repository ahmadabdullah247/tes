using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Password : System.Web.UI.Page
    {
        private _Admin admin = new _Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                admin = Session["adminsignin"] as _Admin;

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
                if (admin.User.Password == txtCurrentPassword.Text)
                {
                    admin.User.Password = txtPassword.Text;
                    admin.ChangePassword();
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
            Session["adminsignin"] = admin;
            Response.Redirect("/Admin/Password");
        }
    }
}