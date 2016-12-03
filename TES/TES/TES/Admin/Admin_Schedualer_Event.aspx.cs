using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Admin
{
    public partial class Admin_Schedualer_Event : System.Web.UI.Page
    {
        private _Admin admin = new _Admin();
        private _Mail mail = new _Mail();
        private _User user = new _User();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is sign in
            if (Session["adminsignin"] != null)
            {
                admin = Session["adminsignin"] as _Admin;
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            else Response.Redirect("/Home");

            if(Session["success"]!=null)
            {
                pnlResponseSuccess.Visible = true;
                Session["success"] = null;
            }
            else
            {
                pnlResponseSuccess.Visible = false;
            }
        }

        public void GetData()
        {
            using(var db=new TESDataContext())
            {
                var log = (from ed in db.Event_Dates select ed).FirstOrDefault();

                if(log!=null)
                {
                    txtEventDate0.Text = log.event_date0;//DateTime.Now.ToString("yyyy-MM-dd");
                    txtEventDate1.Text = log.event_date1;//DateTime.Now.ToString("yyyy-MM-dd");
                    txtEventDate2.Text = log.event_date2;//DateTime.Now.ToString("yyyy-MM-dd");
                    txtEventDate3.Text = log.event_date3;//DateTime.Now.ToString("yyyy-MM-dd");
                    txtEventDate4.Text = log.event_date4;//DateTime.Now.ToString("yyyy-MM-dd");
                    txtEventDate5.Text = log.event_date5;//DateTime.Now.ToString("yyyy-MM-dd");
                    txtEventDate6.Text = log.event_date6;//DateTime.Now.ToString("yyyy-MM-dd");
                    txtEventDate7.Text = log.event_date7;//DateTime.Now.ToString("yyyy-MM-dd");
                    txtEventDate8.Text = log.event_date8;//DateTime.Now.ToString("yyyy-MM-dd");
                    txtspringDate.Text = log.spring_date;
                    txtFallDate.Text = log.fall_date;
                    txtHeader_Date.Text = log.header_date;
                }
            }
        }
        public void SetData()
        {
            using (var db = new TESDataContext())
            {
                var log = (from ed in db.Event_Dates select ed).FirstOrDefault();

                if (log != null)
                {
                    log.event_date0 = txtEventDate0.Text;//DateTime.Now.ToString("yyyy-MM-dd");
                    log.event_date1 = txtEventDate1.Text;//DateTime.Now.ToString("yyyy-MM-dd");
                    log.event_date2 = txtEventDate2.Text;//DateTime.Now.ToString("yyyy-MM-dd");
                    log.event_date3 = txtEventDate3.Text;//DateTime.Now.ToString("yyyy-MM-dd");
                    log.event_date4 = txtEventDate4.Text;//DateTime.Now.ToString("yyyy-MM-dd");
                    log.event_date5 = txtEventDate5.Text;//DateTime.Now.ToString("yyyy-MM-dd");
                    log.event_date6 = txtEventDate6.Text;//DateTime.Now.ToString("yyyy-MM-dd");
                    log.event_date7 = txtEventDate7.Text;//DateTime.Now.ToString("yyyy-MM-dd");
                    log.event_date8 = txtEventDate8.Text;//DateTime.Now.ToString("yyyy-MM-dd");
                    log.spring_date = txtspringDate.Text;
                    log.fall_date = txtFallDate.Text;
                    log.header_date = txtHeader_Date.Text;
                }
                db.SubmitChanges();
            }
            Session.Add("success", true);
            // Send email
            var users = user.GetAll();
            foreach(var u in users)
            {
                mail.Subject="New Event calender";
                mail.Reciver = u.Email;
                mail.Message = "Please check you event calender";
                mail.Send();
            }
        }
        protected void btnUpdateSchedual_Click(object sender, EventArgs e)
        {
            SetData();
            Response.Redirect("/Admin/Schedualer/EventCalendar");
        }
    }
}