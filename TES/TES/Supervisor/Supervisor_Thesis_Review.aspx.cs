using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Thesis_Review : System.Web.UI.Page
    {
        private _Thesis thesis = new _Thesis();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    GetData();
                }
                else Response.Redirect("/Supervisor/Submission/"+thesis.ThesisID);// Previous page
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            thesis = thesis.GetSubmissionById(Convert.ToInt64(RouteData.Values["id"]));

            if(thesis.Review!=null)
            {
                btnReview.Visible = false;
                txtReview.Text = thesis.Review;
                txtReview.ReadOnly = true;
            }
        }

        private void SetData()
        {
            try
            {
                if (txtReview.Text != "")
                {
                    thesis.AddReview(txtReview.Text);
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
            Response.Redirect("/Supervisor/Submission/" + thesis.ThesisID);
        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            SetData();
        }
    }
}