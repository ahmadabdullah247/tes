using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Thesis_History : System.Web.UI.Page
    {
        private _Student student = new _Student();
        private _Thesis thesis = new _Thesis();

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlResponseFail.Visible = false;
            if (Session["studentsignin"] != null)
            {
                if (Request.Url.AbsolutePath.Contains("Student/Submission/Downlaod/"))
                {
                    if (RouteData.Values["id"] != null)
                    {
                        DownloadFile(Convert.ToInt64(RouteData.Values["id"]));
                        //redirect back
                    }
                }
                else
                {
                    student = Session["studentsignin"] as _Student;
                    thesis.Student.StudentId = student.StudentId;
                    thesis = thesis.GetByStudentId();

                    if (thesis != null)
                    {
                        GetData();
                    }
                    else
                    {
                        Response.Redirect("/Student/Thesis");
                    }

                    if(Session["review-notadded"]!=null)
                    {
                        pnlResponseFail.Visible = true;
                        Session.Remove("review-notadded");
                    }
                }
            }
            else Response.Redirect("/Home");
        }
        private void GetData()
        {
            lblStatus.Text = "Status: " + thesis.Status;
            gvThesis.DataSource = thesis.GetAllSubmission(thesis.ThesisID);
            gvThesis.DataBind();
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

        protected void gvThesis_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvThesis.PageIndex = e.NewPageIndex;
            GetData();
        }
    }
}