using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_View_Thesis : System.Web.UI.Page
    {
        private _Thesis thesis = new _Thesis();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    if (!IsPostBack)
                    {
                        thesis = thesis.GetById(Convert.ToInt64(RouteData.Values["id"]));
                        GetData();
                    }
                }
                else Response.Redirect("/Admin/Thesis");
            }
            else Response.Redirect("/Home");   
        }

        private void GetData()
        {
            lblTitle.Text = "<strong>Title: </strong>" + thesis.Title;
            lblDomain.Text = "<strong>Domain: </strong>" + thesis.Domain;
            lblDiscription.Text = "<strong>Discriptoin: </strong>" + thesis.Discription;
            lblStatus.Text = "<strong>Status: </strong>" + thesis.Status;
            lblSupervisor.Text = "<strong>Supervisor: </strong>" + thesis.Supervisor.User.FullName;
            lblStudent.Text = thesis.Student != null ? "<strong>Student: </strong>" + thesis.Student.User.FullName : "<strong>Student: </strong>Not Assigned";
        }
    }
}