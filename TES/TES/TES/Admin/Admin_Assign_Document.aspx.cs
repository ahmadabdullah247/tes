using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Assign_Document : System.Web.UI.Page
    {
        public _Supervisor supervisor = new _Supervisor();
        private _Thesis thesis = new _Thesis();
        private List<string> assignedThesisName = new List<string>();
        private List<string> unAssignedThesisName = new List<string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                if (RouteData.Values["id"] != null)
                {
                    supervisor = supervisor.GetById(Convert.ToInt64(RouteData.Values["id"]));
                    thesis.Supervisor = supervisor;
                    if (!IsPostBack)
                    {
                        GetData();
                    }
                    if(Session["success"] != null)
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
                else Response.Redirect("/Admin/AssignDocument");
            }
            else Response.Redirect("/Home");

        }

        private void GetData()
        {
            assignedThesisName = thesis.GetGTCAssignedThesis() == null ? null : thesis.GetGTCAssignedThesis().Select(x => x.Title).ToList();
            if (assignedThesisName != null)
            {
                unAssignedThesisName = thesis.GetAll().Select(x => x.Title).ToList().Except(assignedThesisName).ToList();

                lbAssigned.DataSource = assignedThesisName;
                lbAssigned.DataBind();
                lbUnassigned.DataSource = unAssignedThesisName;
                lbUnassigned.DataBind();
            }
            else
            {
                lbUnassigned.DataSource = thesis.GetAll().Select(x => x.Title).ToList();
                lbUnassigned.DataBind();
            }
        }

        protected void btnLtoR_Click(object sender, EventArgs e)
        {
            lbAssigned.Items.Add(lbUnassigned.SelectedValue);
            lbUnassigned.Items.Remove(lbUnassigned.SelectedValue);
        }

        protected void btnRtoL_Click(object sender, EventArgs e)
        {
            lbUnassigned.Items.Add(lbAssigned.SelectedValue);
            lbAssigned.Items.Remove(lbAssigned.SelectedValue);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in lbAssigned.Items)
                {
                    assignedThesisName.Add(item.ToString());
                }
                foreach (var item in lbUnassigned.Items)
                {
                    unAssignedThesisName.Add(item.ToString());
                }
                thesis.AssignToGTC(supervisor.SupervisorId, assignedThesisName, unAssignedThesisName);
                Session["success"] = true;
            }
            catch
            {
                Session["fail"] = true;
            }
            Response.Redirect("/Admin/AssignDocument/"+supervisor.SupervisorId);
        }
    }
}