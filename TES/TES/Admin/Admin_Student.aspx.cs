using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Student : System.Web.UI.Page
    {
        private _Student student = new _Student();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                if (!IsPostBack)
                {
                    GetData();
                }
                // Delete
                if (RouteData.Values["id"] != null)
                {
                    student.DeleteProfile(Convert.ToInt64(RouteData.Values["id"]));
                    Session.Add("delete", true);
                    Response.Redirect("/Admin/Student");
                }
                if(Session["delete"]!=null)
                {
                    pnlDeleteSuccess.Visible = true;
                    Session.Remove("delete");
                }
                // Check If Profile Updated
                if (Session["success"] != null)
                {
                    pnlResponseSuccess.Visible = true;
                    Session.Remove("success");
                }
                else if (Session["fail"] != null)
                {
                    pnlResponseFail.Visible = true;
                    Session.Remove("fail");
                }
            }
            else Response.Redirect("/Home");      
        }

        private void GetData()
        {
            gvStudent.DataSource = student.GetAll();
            gvStudent.DataBind();
        }

        protected void gvStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStudent.PageIndex = e.NewPageIndex;
            GetData();
        }
    }
}