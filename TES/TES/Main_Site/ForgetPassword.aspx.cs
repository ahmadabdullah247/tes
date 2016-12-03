using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Main_Site
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        private _User user = new _User();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecover_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text!="")
            {
                if (user.ForgetPassword_Email(txtEmail.Text))
                {
                    pnlResponseSuccess.Visible = true;
                }
                else
                {
                    pnlErrorMessage.Visible = true;
                }
            }
        }
    }
}