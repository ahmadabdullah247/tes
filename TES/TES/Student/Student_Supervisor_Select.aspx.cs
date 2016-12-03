using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student_Supervisor_Select : System.Web.UI.Page
    {
        private _Student student = new _Student();
        private _Supervisor supervisor = new _Supervisor();
        private List<_Supervisor> listSupervisor = new List<_Supervisor>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] != null)
            {
                listSupervisor = supervisor.GetAll();
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
            var ListOfNames = listSupervisor.Select(s => s.User.FullName).ToList();
            ListOfNames.Insert(0, "-- Selet One --");
            //Check Cosupervisro Exsists
            var coName=student.CoSupervisorExists();
            // Check if Supervisor Status is approved
            var name=student.SupervisorApprovedStatus();
            var status = student.SupervisorAwaitStatus();
            if (coName != "")
            {
                pnlSelectCoSupervisoer.Visible = true;
                List<string>cosup=new List<string>();
                cosup.Add(coName);
                ddlCoSupervisor.DataSource = cosup;
                ddlCoSupervisor.DataBind();
                ddlCoSupervisor.Enabled = false;
                btnSelectCoSupervisor.Visible = false;
            }
            else
            {
                pnlSelectCoSupervisoer.Visible = true;

                ListOfNames.Remove(name);

                ddlCoSupervisor.DataSource = ListOfNames;
                ddlCoSupervisor.DataBind();
            }
            if(name!="")
            {
                lblSupervisor.Text = name;
                pnlApproved.Visible = true;
                pnlAwait.Visible = false;
                pnlSelect.Visible = false;
            }
            // Check if it is await
            else if(status==true)
            {
                pnlApproved.Visible = false;
                pnlAwait.Visible = true;
                pnlSelect.Visible = false;
            }
            else
            {
                pnlApproved.Visible = false;
                pnlAwait.Visible = false;
                pnlSelect.Visible = true;

                ddlSupervisor.DataSource = ListOfNames;
                ddlSupervisor.DataBind();
            }

        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if(ddlSupervisor.SelectedValue!="-- Selet One --")
            {
               supervisor= listSupervisor.Find(s=>s.User.FullName==ddlSupervisor.SelectedValue);
               student.SelectSupervisor(supervisor.User.Email,supervisor.SupervisorId);
            }
            Response.Redirect("/Student/Supervisor");
        }

        protected void btnSelectCoSupervisor_Click(object sender, EventArgs e)
        {
            if (ddlSupervisor.SelectedValue != "-- Selet One --")
            {
                supervisor = listSupervisor.Find(s => s.User.FullName == ddlCoSupervisor.SelectedValue);
                student.SelectCoSupervisor(supervisor.SupervisorId);
            }
            Response.Redirect("/Student/Supervisor");
        }
    }
}