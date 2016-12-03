using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Schedualer : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorsignin"] != null)
            {
                supervisor = Session["supervisorsignin"] as _Supervisor;
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");
        }
        public void GetData()
        {
            using (var db = new TESDataContext())
            {
                var log = (from ed in db.Event_Dates select ed).FirstOrDefault();

                if (log != null)
                {
                    lblEventDate0.Text = log.event_date0;
                    lblEventDate1.Text = log.event_date1;
                    lblEventDate2.Text = log.event_date2;
                    lblEventDate3.Text = log.event_date3;
                    lblEventDate4.Text = log.event_date4;
                    lblEventDate5.Text = log.event_date5;
                    lblEventDate6.Text = log.event_date6;
                    lblEventDate7.Text = log.event_date7;
                    lblEventDate8.Text = log.event_date8;
                    lblHeaderDate.Text = log.header_date;
                    lblSpringDate.Text = log.spring_date;
                    lblFallDate.Text = log.fall_date;
                }
            }
        }
    }
}