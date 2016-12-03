using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Thesis_GTCReview : System.Web.UI.Page
    {
        private _Thesis thesis = new _Thesis();
        private _Student student = new _Student();
        public _Supervisor supervisor = new _Supervisor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                student = Session["studentsignin"] as _Student;
                    GetData();
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            thesis.Student = student;
            thesis = thesis.GetByStudentId();
            if(thesis!=null)
            {
                if (thesis.GTCReviews.Count != 0)
                {
                    gvGTCReview.DataSource = thesis.GTCReviews;
                    gvGTCReview.DataBind();
                }
                else
                {
                    Session.Add("review-notadded", true);
                    Response.Redirect("/Student/Thesis/History");
                }
            }
        }
    }
}