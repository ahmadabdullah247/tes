using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Main_Site
{
    public partial class SignIn : System.Web.UI.Page
    {
        private _Admin admin = new _Admin();
        private _Supervisor supervisor = new _Supervisor();
        private _Student student = new _Student();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["adminsignin"]!=null)
            {
                Response.Redirect("/Admin/Profile");
            }
            else if(Session["supervisorsignin"]!=null)
            {
                Response.Redirect("/Supervisor/Profile");
            }
            else if(Session["studentsignin"]!=null)
            {
                Response.Redirect("/Student/Profile");
            }
            else if(Session["success"]!=null)
            {
                pnlResponseSuccess.Visible = true;
                Session.Remove("success");
                Session["success"]=null;
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (ddlUser.SelectedValue == "Student")
            {
                student.User.Username = txtUsername.Text;
                student.User.Password = txtPassword.Text;

                Session.Add("studentsignin", student.Signin());

                if (Session["studentsignin"]!=null)
                {
                    Response.Redirect("/Student/Profile");
                }
                pnlErrorMessage.Visible = true;
            }
            else if (ddlUser.SelectedValue == "Supervisor")
            {
                supervisor.User.Username = txtUsername.Text;
                supervisor.User.Password = txtPassword.Text;

                Session.Add("supervisorsignin", supervisor.Signin());

                if (Session["supervisorsignin"] != null)
                {
                    Response.Redirect("/Supervisor/Profile");
                }
                pnlErrorMessage.Visible = true;
            }
            else
            {
                admin.User.Username = txtUsername.Text;
                admin.User.Password = txtPassword.Text;

                Session.Add("adminsignin", admin.Signin());

                if (Session["adminsignin"] != null)
                {
                    Response.Redirect("/Admin/Profile");
                }
                pnlErrorMessage.Visible = true;
            }
        }
    }
}