using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Thesis_Assign : System.Web.UI.Page
    {
        private _Student student = new _Student();
        private _Thesis thesis = new _Thesis();
        public _Thesis Thesis { get { return thesis; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                student = Session["studentsignin"] as _Student;
                if(!IsPostBack)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            thesis.Student.StudentId = student.StudentId;
            thesis = thesis.GetByStudentId();
        }
    }
}