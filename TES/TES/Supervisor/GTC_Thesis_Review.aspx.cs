using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class GTC_Thesis_Review : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();
        private _Thesis thesis = new _Thesis();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervisor = Session["supervisorsignin"] as _Supervisor;
                if (RouteData.Values["id"] != null)
                {
                    GetData();
                }
                else Response.Redirect("/GTC/Submission/");// Previous page
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            thesis = thesis.GetGTCSubmissionById(Convert.ToInt64(RouteData.Values["id"]));
            var review=thesis.GTCReviews.Where(x=>x.gtc_id==supervisor.SupervisorId).FirstOrDefault();
            if (review.gtc_review1!= "")
            {
                btnReview.Visible = false;
                txtReview.Text = review.gtc_review1;
                txtReview.ReadOnly = true;
            }
        }

        private void SetData()
        {
            try
            {
                if (txtReview.Text != "")
                {
                    thesis.AddGTCReview(txtReview.Text, supervisor.SupervisorId);
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
            Response.Redirect("/GTC/Submission/");
        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            SetData();
        }
    }
}