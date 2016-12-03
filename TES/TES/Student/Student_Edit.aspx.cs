using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Edit : System.Web.UI.Page
    {
        private _Student student = new _Student();
        private _User user = new _User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                student = Session["studentsignin"] as _Student;
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            txtCnic.Text = student.User.CNIC;
            txtContact.Text = student.User.Contact.ToString();
            txtEmail.Text = student.User.Email;
            txtFname.Text = student.User.FullName;
            var reg = student.RegistrationNo.Split('-');
            if (reg[0] == "SP")
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
            rblGender.SelectedIndex = student.User.Gender == "Male" ? 0 : 1;
        }

        private void SetData()
        {
            try
            {
                var reg = ddlReg.SelectedValue + "-" + ddlProgram.SelectedValue + "-" + txtRegNo.Text;
                if(user.UserRegExists(reg))
                {
                    student.User.CNIC = txtCnic.Text;
                    student.User.Contact = txtContact.Text;
                    student.User.Email = txtEmail.Text;
                    student.User.FullName = txtFname.Text;
                    student.User.Gender = rblGender.SelectedIndex == 0 ? "Male" : "Female";
                    student.Semester = txtSemester.Text;
                    student.RegistrationNo = reg;

                    student.EditProfile();
                    Session.Add("success", true);
                }
                else
                {
                    Session.Add("fail", true);
                }
            }
            catch
            {
                Session.Add("fail", true);
            }
            Response.Redirect("/Student/Profile");
        }
        protected void btnUpdte_Click(object sender, EventArgs e)
        {
            SetData();
        }
    }
}