using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Profile : System.Web.UI.Page
    {
        private _Admin admin=new _Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                // Get Data
                if (!IsPostBack)
                {
                    GetData();
                }
                // Check If Profile Updated
                if(Session["success"]!=null)
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

        public void GetData()
        {
            admin = Session["adminsignin"] as _Admin;

            if (admin != null)
            {
                ltrfname.Text = admin.User.FullName;
                ltruname.Text = admin.User.Username;
                ltrcontact.Text = admin.User.Contact;
                ltrgender.Text = admin.User.Gender;
                ltrcnic.Text = admin.User.CNIC;
                ltremail.Text = admin.User.Email;
            }
        }
    }
}