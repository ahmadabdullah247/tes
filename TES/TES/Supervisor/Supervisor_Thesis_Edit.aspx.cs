using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Thesis_Edit : System.Web.UI.Page
    {
        private _Supervisor supervvisor = new _Supervisor();
        private _Thesis thesis = new _Thesis();
        private _Student student = new _Student();
        private List<_Student> listStudent = new List<_Student>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervvisor = Session["supervisorsignin"] as _Supervisor;
                if (RouteData.Values["id"] != null)
                {
                    thesis.ThesisID = Convert.ToInt64(RouteData.Values["id"]);
                    thesis = thesis.GetById(Convert.ToInt64(RouteData.Values["id"]));
                    listStudent = student.GetForSupervisor(supervvisor.SupervisorId);
                    if (listStudent.Count < 1)
                    {
                        btnEdit.Enabled = false;
                    }
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
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            txtTitle.Text = thesis.Title;
            txtDomain.Text = thesis.Domain;
            txtDiscription.Text = thesis.Discription;
            
            if(thesis.Status=="Pending")
            {
                ddlStatus.SelectedIndex = 0;
            }
            else if (thesis.Status == "Await")
            {
                ddlStatus.SelectedIndex = 1;
            }
            else
            {
                ddlStatus.SelectedIndex = 2;
            }

            var listStudentNames = listStudent.Select(s => s.User.FullName).ToList();
            ddlStudent.DataSource = listStudentNames;
            ddlStudent.DataBind();

            if (thesis.Student!=null)
            {
                ddlStudent.SelectedValue = listStudentNames.Find(x => x == thesis.Student.User.FullName);
            }
            else
            {
                listStudentNames.Insert(0,"-- Select One --");
            }
        }

        private void SetData()
        {
            thesis.Title = txtTitle.Text;
            thesis.Domain = txtDomain.Text;
            thesis.Discription = txtDiscription.Text;
            thesis.Status = ddlStatus.SelectedValue;
            thesis.Student= listStudent.Find(s=>s.User.FullName==ddlStudent.SelectedValue);

            thesis.Edit();
            Session.Add("success-add", true);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SetData();
            Response.Redirect("/Supervisor/Thesis");
        }
    }
}