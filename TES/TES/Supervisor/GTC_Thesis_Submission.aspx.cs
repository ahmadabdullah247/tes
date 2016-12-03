using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class GTC_Thesis_Submission : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();
        private _Thesis thesis = new _Thesis();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervisor=Session["supervisorsignin"] as _Supervisor;
                // Check Downlaod request for File ID
                if (Request.Url.AbsolutePath.Contains("/GTC/Submission/Download"))
                {
                    if (RouteData.Values["id"] != null)
                    {
                        DownloadFile(Convert.ToInt64(RouteData.Values["id"]));
                        //redirect back
                    }
                }
                else
                {
                    if (!IsPostBack)
                    {
                        GetData();
                    }

                }
                if (Session["success"] != null)
                {
                    pnlResponseSuccess.Visible = true;
                    Session["success"] = null;
                }
                else if (Session["fail"] != null)
                {
                    pnlResponseFail.Visible = true;
                    Session["fail"] = null;
                }
            }
            else Response.Redirect("/Home");
        }

        private void DownloadFile(long? id)
        {
            thesis = thesis.GetSubmissionById(id);

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + thesis.FileName);
            Response.TransmitFile(Server.MapPath(thesis.FilePath));
            Response.Flush();
            Response.End();
        }

        private void GetData()
        {
            thesis.Supervisor = supervisor;
            gvThesis.DataSource = thesis.GetAllGTCAssigned();//thesis.GetAllGTCSubmission();
            gvThesis.DataBind();
        }

        protected void gvThesis_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvThesis.PageIndex = e.NewPageIndex;
            GetData();
        }
    }
}