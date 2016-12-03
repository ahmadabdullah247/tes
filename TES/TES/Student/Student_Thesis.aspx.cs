using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Thesis : System.Web.UI.Page
    {
        private _Student student = new _Student();
        private _Thesis thesis = new _Thesis();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                student = Session["studentsignin"] as _Student;
                thesis.Student.StudentId = student.StudentId;
                thesis = thesis.GetByStudentId();
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            // Check if Supervisor exsist
            if(student.SupervisorApprovedStatus()=="")
            {
                pnlSelectSuperVisor.Visible = true;
                pnlUnassigned.Visible = false;
                pnlAssigned.Visible = false;
            }
            else
            {
                // Check if Supervisor assigned thesis
                if(thesis==null)
                {
                    pnlSelectSuperVisor.Visible = false;
                    pnlUnassigned.Visible = true;
                    pnlAssigned.Visible = false;
                }
                else if(thesis.IsAssigned())
                {
                    pnlSelectSuperVisor.Visible = false;
                    pnlUnassigned.Visible = false;
                    pnlAssigned.Visible = true;
                }
                else
                {
                    pnlSelectSuperVisor.Visible = false;
                    pnlUnassigned.Visible = true;
                    pnlAssigned.Visible = false;
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuThesis.PostedFile!=null && Path.GetExtension(fuThesis.PostedFile.FileName) == ".docx")
            {
                // get all files in folder
                string[] files = Directory.GetFiles(Server.MapPath("~/_Files/" + student.User.UserId + "/"));
                thesis.FileName = thesis.Title + (files.Count()) + Path.GetExtension(fuThesis.PostedFile.FileName);
                thesis.FilePath = "~/_Files/" + student.User.UserId + "/" + thesis.FileName;
                thesis.UploadThesis();
                // Save file
                fuThesis.PostedFile.SaveAs(Server.MapPath(thesis.FilePath));

                Response.Redirect("/Student/Thesis/History");
            }
        }
    }
}