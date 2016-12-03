using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Thesis_Submission : System.Web.UI.Page
    {
        private _Thesis thesis = new _Thesis();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                // Check Downlaod request for File ID
                if (Request.Url.AbsolutePath.Contains("Supervisor/Submission/Downlaod/"))
                {
                    if (RouteData.Values["id"] != null)
                    {
                        DownloadFile(Convert.ToInt64(RouteData.Values["id"]));
                        //redirect back
                    }
                }
                else
                {
                    // Get Submission for Thesis ID
                    if (RouteData.Values["id"] != null)
                    {
                        thesis = thesis.GetById(Convert.ToInt64(RouteData.Values["id"]));
                        if (!IsPostBack)
                        {
                            GetData();
                        }
                    }
                    else
                    {
                        Response.Redirect("/Supervisor/Thesis");
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
                    Session["fail"]=null;
                }
                if(Session["approved"]!=null)
                {
                    pnlApprovedmsg.Visible = true;
                    Session["approved"] = null;
                }
                if (Session["disapproved"] != null)
                {
                    pnlDisApprovedmsg.Visible = true;
                    Session["disapproved"] = null;
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
            if(thesis.Status!="Ok")
            {
                pnlApproved.Visible = true;
                pnlDisApproved.Visible = false;
            }
            else
            {
                pnlApproved.Visible = false;
                pnlDisApproved.Visible = true;
            }

            gvThesis.DataSource = thesis.GetAllSubmission(thesis.ThesisID);
            gvThesis.DataBind();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            thesis.Approve("Ok");
            Session["approved"] = true;
            Response.Redirect("/Supervisor/Submission/" + RouteData.Values["id"]);
        }

        protected void btnDisApprove_Click(object sender, EventArgs e)
        {
            thesis.Approve("Pending");
            Session["disapproved"] = true;
            Response.Redirect("/Supervisor/Submission/" + RouteData.Values["id"]);
        }
    }
}