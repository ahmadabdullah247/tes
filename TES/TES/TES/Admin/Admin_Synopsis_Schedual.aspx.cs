using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Synopsis_Schedual : System.Web.UI.Page
    {
        private _Thesis thesis = new _Thesis();
        private _Presentation presentation = new _Presentation();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");
        }

        private void GetData()
        {
            gvPresentationSchedual.DataSource = presentation.GetAll().Where(x => x.Thesis.Status == "Ok").ToList();//thesis.GetAll();
            gvPresentationSchedual.DataBind();
        }
    }
}