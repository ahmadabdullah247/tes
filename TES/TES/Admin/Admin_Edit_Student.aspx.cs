using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Edit_Student : System.Web.UI.Page
    {
        private _Student student = new _Student();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    student.StudentId = Convert.ToInt64(RouteData.Values["id"]);
                    if (!IsPostBack)
                    {
                        student = student.GetById();
                        GetData();
                    }
                }
                else Response.Redirect("Admin/Student"); 
            }
            else Response.Redirect("/Home");            
        }

        private void GetData()
        {
            txtFname.Text = student.User.FullName;
            txtEmail.Text = student.User.Email;
            rblGender.SelectedIndex = student.User.Gender == "Male" ? 0 : 1;
            txtContact.Text = student.User.Contact.ToString();
            txtCnic.Text = student.User.CNIC;
            var reg=student.RegistrationNo.Split('-');
            if(reg[0]=="SP")
            {
                ddlReg.SelectedIndex = 0;
            }
            else if (reg[0] == "FA")
            {
                ddlReg.SelectedIndex = 1;
            }
            if (reg[1] == "BCS")
            {
                ddlProgram.SelectedIndex = 0;
            }
            else if (reg[1] == "BCE")
            {
                ddlProgram.SelectedIndex = 1;
            }
            txtRegNo.Text = reg[2].ToString();
            txtSemester.Text = student.Semester;
        }

        private void SetData()
        {
            try
            {
                student.User.FullName = txtFname.Text;
                student.User.Email = txtEmail.Text;
                student.User.Gender = rblGender.SelectedIndex == 0 ? "Male" : "Female";
                student.User.Contact = txtContact.Text;
                student.User.CNIC = txtCnic.Text;

                student.RegistrationNo = ddlReg.SelectedValue + "-" + ddlProgram.SelectedValue + "-" + txtRegNo.Text;
                student.Semester = txtSemester.Text;

                student.EditProfile();
    
                Session.Add("success", true);
            }
            catch
            {
                Session.Add("fail", true);
            }
            Response.Redirect("/Admin/Student");
        }

        protected void btnUpdte_Click(object sender, EventArgs e)
        {
            SetData();
        }
    }
}