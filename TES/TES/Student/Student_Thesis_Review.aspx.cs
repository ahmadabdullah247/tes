using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Thesis_Review : System.Web.UI.Page
    {
        private _Thesis thesis=new _Thesis();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            thesis = thesis.GetSubmissionById(Convert.ToInt64(RouteData.Values["id"]));
            if(thesis.Review!=null)
            {
                lblReview.Text = thesis.Review;
            }
            else
            {
                Session.Add("review-notadded", true);
                Response.Redirect("/Student/Thesis/History");
            }
        }
    }
}