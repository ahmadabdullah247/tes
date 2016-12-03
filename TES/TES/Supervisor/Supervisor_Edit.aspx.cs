using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Edit : System.Web.UI.Page
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
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            txtCnic.Text = supervisor.User.CNIC;
            txtContact.Text = supervisor.User.Contact;
            txtEmail.Text = supervisor.User.Email;
            txtFname.Text = supervisor.User.FullName;
            txtJobTitle.Text = supervisor.Title;
            rblGender.SelectedIndex = supervisor.User.Gender == "Male" ? 0 : 1;
        }

        private void SetData()
        {
            try
            {
                supervisor.User.CNIC = txtCnic.Text;
                supervisor.User.Contact = txtContact.Text;
                supervisor.User.Email = txtEmail.Text;
                supervisor.User.FullName = txtFname.Text;
                supervisor.User.Gender = rblGender.SelectedIndex == 0 ? "Male" : "Female";
                supervisor.Title = txtJobTitle.Text;

                supervisor.EditProfile();
                Session.Add("success", true);
            }
            catch
            {
                Session.Add("fail", true);
            }

            Response.Redirect("/Supervisor/Profile");
        }
        protected void btnUpdte_Click(object sender, EventArgs e)
        {
            SetData();
        }
    }
}