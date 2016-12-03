using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Edit : System.Web.UI.Page
    {
        private _Admin admin = new _Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                admin = Session["adminsignin"] as _Admin;
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            txtCnic.Text = admin.User.CNIC;
            txtContact.Text = admin.User.Contact.ToString();
            txtEmail.Text = admin.User.Email;
            txtFname.Text = admin.User.FullName;
            rblGender.SelectedIndex = admin.User.Gender=="Male"?0:1;
        }

        private  void SetData()
        {
            try
            {
                admin.User.CNIC = txtCnic.Text;
                admin.User.Contact = txtContact.Text;
                admin.User.Email = txtEmail.Text;
                admin.User.FullName = txtFname.Text;
                admin.User.Gender = rblGender.SelectedIndex == 0 ? "Male" : "Female";

                admin.EditProfile();

                Session.Add("success", true);
            }
            catch
            {
                Session.Add("fail", true);
            }
            Response.Redirect("/Admin/Profile");
        }
        protected void btnUpdte_Click(object sender, EventArgs e)
        {
            SetData();
        }
    }
}