using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Profile : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervisor = Session["supervisorsignin"] as _Supervisor;
                if (!IsPostBack)
                {
                    GetData();
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

        public void GetData()
        {
            if (supervisor != null)
            {
                ltrfname.Text = supervisor.User.FullName;
                ltruname.Text = supervisor.User.Username;
                ltrcontact.Text = supervisor.User.Contact;
                ltrcnic.Text = supervisor.User.CNIC;
                ltremail.Text = supervisor.User.Email;
                ltrgender.Text = supervisor.User.Gender;
                ltrGTC.Text = supervisor.GTC;
                ltrJobTitle.Text = supervisor.Title;

                if(supervisor.GTC=="Yes")
                {
                    lblHeader.Text = "GTC";
                }
            }
        }
    }
}