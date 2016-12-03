using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Eidt_Faculty : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    supervisor = supervisor.GetById(Convert.ToInt64(RouteData.Values["id"]));
                    if (!IsPostBack)
                    {
                        GetData();
                    }
                }
                else Response.Redirect("/Admin/Faculty");
            }
            else Response.Redirect("/Home");  

        }

        private void GetData()
        {
            txtFname.Text = supervisor.User.FullName;
            txtEmail.Text = supervisor.User.Email;
            rblGender.SelectedIndex = supervisor.User.Gender == "Male" ? 0 : 1;
            txtContact.Text = supervisor.User.Contact.ToString();
            txtCnic.Text = supervisor.User.CNIC;
            cbGTC.Checked = supervisor.GTC=="Yes"?true:false;
            txtJobTitle.Text = supervisor.Title;
        }

        private void SetData()
        {
            bool flag = false;
            try
            {
                if (supervisor.GetAll().Where(x => x.GTC == "Yes").ToList().Count() >= 3 && cbGTC.Checked==true)
                {
                    pnlResponseFail.Visible = true;
                }
                else
                {
                    supervisor.User.FullName = txtFname.Text;
                    supervisor.User.Email = txtEmail.Text;
                    supervisor.User.Gender = rblGender.SelectedIndex == 0 ? "Male" : "Female";
                    supervisor.User.Contact = txtContact.Text;
                    supervisor.User.CNIC = txtCnic.Text;
                    supervisor.GTC = cbGTC.Checked == true ? "Yes" : "No";
                    supervisor.Title = txtJobTitle.Text;

                    supervisor.EditProfile();
                    Session.Add("success", true);
                    flag = true;
                }
            }
            catch
            {
                Session.Add("fail", true);
            }
            if(flag) Response.Redirect("/Admin/Faculty");
        }

        protected void btnUpdte_Click(object sender, EventArgs e)
        {
            SetData();
        }
    }
}