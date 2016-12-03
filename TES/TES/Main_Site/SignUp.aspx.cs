using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Main_Site
{
    public partial class SignUp : System.Web.UI.Page
    {
        private _User user = new _User();
        private _Student student = new _Student();
        private _Supervisor supervisor = new _Supervisor();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUser.SelectedIndex == 0)
            {
                pnlStudent.Visible = true;
                pnlTeacher.Visible = false;
            }
            else
            {
                pnlStudent.Visible = false;
                pnlTeacher.Visible = true;
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //if (IsValid)
            //{
            if (!user.UserExists(txtUsername.Text))
            {
                if (ddlUser.SelectedIndex == 0)
                {
                    var reg = ddlReg.SelectedValue + "-" + ddlProgram.SelectedValue + "-" + txtRegNo.Text;
                    if (user.UserRegExists(reg))
                    {
                        student.User.FullName = txtFname.Text;
                        student.User.Username = txtUsername.Text.ToLower();
                        student.User.Email = txtEmail.Text;
                        student.User.Password = txtPassword.Text;
                        student.User.Contact = txtNumber.Text;
                        student.User.Gender = ddlUser.SelectedIndex == 0 ? "Male" : "Female";//Conditional statment
                        student.User.CNIC = txtCNIC.Text;

                        student.RegistrationNo = reg;
                        student.Semester = txtSemester.Text;
                        student.Signup();

                        Session.Add("success", true);
                        Response.Redirect("/SignIn");
                    }
                    else
                    {
                        pnlRegError.Visible = true;
                    }
                }
                else
                {
                    supervisor.User.FullName = txtFname.Text;
                    supervisor.User.Username = txtUsername.Text;
                    supervisor.User.Email = txtEmail.Text;
                    supervisor.User.Password = txtPassword.Text;
                    supervisor.User.Contact = txtNumber.Text;
                    supervisor.User.Gender = ddlUser.SelectedIndex == 0 ? "Male" : "Female";//Conditional statment
                    supervisor.User.CNIC = txtCNIC.Text;
                    supervisor.GTC = "No";
                    supervisor.Title = txtTitle.Text;
                    supervisor.Signup();

                    Session.Add("success", true);
                    Response.Redirect("/SignIn");
                }
            }
            else
            {
                // Error Username already exsists
                pnlResponseError.Visible = true;
            }
            //}
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCNIC.Text = "";
            txtEmail.Text = "";
            txtFname.Text = "";
            txtNumber.Text = "";
            txtPassword.Text = "";
            txtRegNo.Text = "";
            txtSemester.Text = "";
            txtTitle.Text = "";
            txtUsername.Text = "";
        }
    }
}