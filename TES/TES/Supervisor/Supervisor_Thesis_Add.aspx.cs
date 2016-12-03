using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Thesis_Add : System.Web.UI.Page
    {
        private _Supervisor supervvisor = new _Supervisor();
        private _Thesis thesis = new _Thesis();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervvisor = Session["supervisorsignin"] as _Supervisor;
            }
            else Response.Redirect("/Home");
        }

        public void AddThesis()
        {
            thesis.Title = txtTitle.Text;
            thesis.Domain = txtDomain.Text;
            thesis.Discription = txtDiscription.Text;
            thesis.Status = "Pending";
            thesis.Supervisor.SupervisorId = supervvisor.SupervisorId;

            supervvisor.AddThesis(thesis);

            Session.Add("success-add", true);
        }

        protected void btnAddThesis_Click(object sender, EventArgs e)
        {
            AddThesis();
            Response.Redirect("/Supervisor/Thesis");
        }
    }
}