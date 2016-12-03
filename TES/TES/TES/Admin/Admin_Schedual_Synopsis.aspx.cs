using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Schedual_Synopsis : System.Web.UI.Page
    {
        private _Thesis thesis = new _Thesis();
        private _Presentation presentation = new _Presentation();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] == null)
            {
                Response.Redirect("/Home");
            }
        }

        protected void btnSynopsisSchedual_Click(object sender, EventArgs e)
        {
            SetData();
            Response.Redirect("/Admin/Schedualer/Synopsis");
        }

        private void SetData()
        {
            DateTime val = new DateTime();
            val = calSynopsisDate.SelectedDate;
            presentation.Create(val);
        }
    }
}