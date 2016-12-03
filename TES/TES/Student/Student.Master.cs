using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Student
{
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentsignin"] == null)
            {
                Response.Redirect("/Home");
            }
        }

        protected void lbSignOut_Click(object sender, EventArgs e)
        {
            Session.Remove("studentsignin");
            Response.Redirect("/Home");
        }
    }
}