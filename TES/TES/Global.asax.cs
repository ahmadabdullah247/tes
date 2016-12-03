using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace TES
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routeCollection)
        {
            #region Main Site

            routeCollection.MapPageRoute("Home1", "", "~/Main_Site/Signin.aspx");
            routeCollection.MapPageRoute("Home2", "Home", "~/Main_Site/Signin.aspx");
            
            routeCollection.MapPageRoute("User-SignIn", "SignIn", "~/Main_Site/SignIn.aspx");
            routeCollection.MapPageRoute("User-SignUp", "SignUp", "~/Main_Site/SignUp.aspx");

            routeCollection.MapPageRoute("User-ForgetPassword", "ForgetPassword", "~/Main_Site/ForgetPassword.aspx");
            routeCollection.MapPageRoute("User-ChangePassword", "UpdatePassword/{GUID}", "~/Main_Site/ChangePassword.aspx");

            #endregion

            #region Admin

            routeCollection.MapPageRoute("Admin-Profile", "Admin/Profile", "~/Admin/Admin_Profile.aspx");
            routeCollection.MapPageRoute("Admin-Edit", "Admin/Edit", "~/Admin/Admin_Edit.aspx");
            routeCollection.MapPageRoute("Admin-Password", "Admin/Password", "~/Admin/Admin_Password.aspx");

            routeCollection.MapPageRoute("Admin-Thesis", "Admin/Thesis", "~/Admin/Admin_Thesis.aspx");
            routeCollection.MapPageRoute("Admin-View-Thesis", "Admin/Thesis/{id}", "~/Admin/Admin_View_Thesis.aspx");


            routeCollection.MapPageRoute("Admin-Student", "Admin/Student", "~/Admin/Admin_Student.aspx");
            routeCollection.MapPageRoute("Admin-Edit-Student", "Admin/Student/Edit/{id}", "~/Admin/Admin_Edit_Student.aspx");
            routeCollection.MapPageRoute("Admin-Delete-Student", "Admin/Student/{id}", "~/Admin/Admin_Student.aspx");

            routeCollection.MapPageRoute("Admin-Faculty", "Admin/Faculty", "~/Admin/Admin_Faculty.aspx");
            routeCollection.MapPageRoute("Admin-Edit-Faculty", "Admin/Faculty/Edit/{id}", "~/Admin/Admin_Eidt_Faculty.aspx");
            routeCollection.MapPageRoute("Admin-Delete-Faculty", "Admin/Faculty/{id}", "~/Admin/Admin_Faculty.aspx");

            routeCollection.MapPageRoute("Admin-Schedualer", "Admin/Schedualer", "~/Admin/Admin_Schedualer.aspx");
            routeCollection.MapPageRoute("Admin-Schedualer-EventCalendar", "Admin/Schedualer/EventCalendar", "~/Admin/Admin_Schedualer_Event.aspx");
            routeCollection.MapPageRoute("Admin-Synopsis", "Admin/Schedualer/Synopsis", "~/Admin/Admin_Synopsis_Schedual.aspx");
            routeCollection.MapPageRoute("Admin-Schedualer-Synopsis", "Admin/Schedual/Synopsis", "~/Admin/Admin_Schedual_Synopsis.aspx");
        
            routeCollection.MapPageRoute("Admin-Report-Meeting", "Admin/Report/Meeting", "~/Admin/Admin_Report_MeetingMinutes.aspx");
            routeCollection.MapPageRoute("Admin-Report", "Admin/Reports/{id}", "~/Admin/Admin_Report.aspx");
            routeCollection.MapPageRoute("Admin-Report-GTC", "Admin/Report/Review", "~/Admin/Admin_GTCReview.aspx");
            routeCollection.MapPageRoute("Admin-Report-GTC-Detail", "Admin/Report/Review/{id}", "~/Admin/Admin_GTCReview_Detail.aspx");


            routeCollection.MapPageRoute("Admin-Assign-Document", "Admin/AssignDocument", "~/Admin/Admin_AssignDocument.aspx");
            routeCollection.MapPageRoute("Admin-Assign-Document-GTC", "Admin/AssignDocument/{id}", "~/Admin/Admin_Assign_Document.aspx");

            #endregion

            #region Supervisor

            routeCollection.MapPageRoute("Supervisor-Profile", "Supervisor/Profile", "~/Supervisor/Supervisor_Profile.aspx");
            routeCollection.MapPageRoute("Supervisor-Edit", "Supervisor/Edit", "~/Supervisor/Supervisor_Edit.aspx");
            routeCollection.MapPageRoute("Supervisor-Password", "Supervisor/Password", "~/Supervisor/Supervisor_Password.aspx");

            routeCollection.MapPageRoute("Supervisor-Student", "Supervisor/Student", "~/Supervisor/Supervisor_Student.aspx");
            routeCollection.MapPageRoute("Supervisor-Student-Profile", "Supervisor/Student/{id}", "~/Supervisor/Supervisor_Student_Profile.aspx");
            routeCollection.MapPageRoute("Supervisor-Supervised-Student", "Supervisor/Supervised/Student", "~/Supervisor/Supervisor_Supervised_Student.aspx");

            routeCollection.MapPageRoute("Supervisor-Thesis", "Supervisor/Thesis", "~/Supervisor/Supervisor_Thesis.aspx");
            routeCollection.MapPageRoute("Supervisor-Thesis-Add", "Supervisor/Thesis/Add", "~/Supervisor/Supervisor_Thesis_Add.aspx");
            routeCollection.MapPageRoute("Supervisor-Thesis-Edit", "Supervisor/Thesis/Edit/{id}", "~/Supervisor/Supervisor_Thesis_Edit.aspx");
            routeCollection.MapPageRoute("Supervisor-Thesis-Delete", "Supervisor/Thesis/{id}", "~/Supervisor/Supervisor_Thesis.aspx");
            routeCollection.MapPageRoute("Supervisor-Thesis-Submission", "Supervisor/Submission/{id}", "~/Supervisor/Supervisor_Thesis_Submission.aspx");
            routeCollection.MapPageRoute("Supervisor-Thesis-Download", "Supervisor/Submission/Downlaod/{id}", "~/Supervisor/Supervisor_Thesis_Submission.aspx");
            routeCollection.MapPageRoute("Supervisor-Thesis-Review", "Supervisor/Submission/Review/{id}", "~/Supervisor/Supervisor_Thesis_Review.aspx");

            routeCollection.MapPageRoute("Supervisor-Schedualer", "Supervisor/Schedualer", "~/Supervisor/Supervisor_Schedualer.aspx");
            routeCollection.MapPageRoute("Supervisor-Report", "Supervisor/Reports", "~/Supervisor/Supervisor_Report.aspx");
            routeCollection.MapPageRoute("Supervisor-Synopsis", "Supervisor/Synopsis/Schedual", "~/Supervisor/Supervisor_Synopsis_Schedual.aspx");


            routeCollection.MapPageRoute("Supervisor-Meeting-Request", "Supervisor/Meeting", "~/Supervisor/Supervisor_Meeting_Request.aspx");
            routeCollection.MapPageRoute("Supervisor-Meeting", "Supervisor/Meeting/{id}", "~/Supervisor/Supervisor_Meeting.aspx");
            routeCollection.MapPageRoute("Supervisor-Meeting-History", "Supervisor/History/Meeting", "~/Supervisor/Supervisor_Meeting_History.aspx");
            routeCollection.MapPageRoute("Supervisor-Meeting-Histo", "Supervisor/History/Meeting/{id}", "~/Supervisor/Supervisor_Meeting_History_Minutes.aspx");
            routeCollection.MapPageRoute("Supervisor-Add-Meeting", "Supervisor/Add/Meeting", "~/Supervisor/Supervisor_Add_Meeting.aspx");

            routeCollection.MapPageRoute("GTC-Submission", "GTC/Submission/", "~/Supervisor/GTC_Thesis_Submission.aspx");
            routeCollection.MapPageRoute("GTC-Submission-Downlaod", "GTC/Submission/Download/{id}", "~/Supervisor/GTC_Thesis_Submission.aspx");
            routeCollection.MapPageRoute("GTC-Submission-Review", "GTC/Submission/{id}", "~/Supervisor/GTC_Thesis_Review.aspx");

            
            #endregion

            #region Student

            routeCollection.MapPageRoute("Student-Profile", "Student/Profile", "~/Student/Student_Profile.aspx");
            routeCollection.MapPageRoute("Student-Edit", "Student/Edit", "~/Student/Student_Edit.aspx");
            routeCollection.MapPageRoute("Student-Password", "Student/Password", "~/Student/Student_Password.aspx");

            routeCollection.MapPageRoute("Student-Supervisor-Select", "Student/Supervisor", "~/Student/Student_Supervisor_Select.aspx");

            routeCollection.MapPageRoute("Student-Thesis", "Student/Thesis", "~/Student/Student_Thesis.aspx");
            routeCollection.MapPageRoute("Student-Thesis-History", "Student/Thesis/History", "~/Student/Student_Thesis_History.aspx");
            routeCollection.MapPageRoute("Student-Thesis-Download", "Student/Submission/Downlaod/{id}", "~/Student/Student_Thesis_History.aspx");
            routeCollection.MapPageRoute("Student-Thesis-Review", "Student/Submission/Review/{id}", "~/Student/Student_Thesis_Review.aspx");
            routeCollection.MapPageRoute("Student-Thesis-Assigned", "Student/Thesis/Assign", "~/Student/Student_Thesis_Assign.aspx");

            routeCollection.MapPageRoute("Student-Schedualer-Event", "Student/Schedule/Event", "~/Student/Student_Schedualer_Event.aspx");
            routeCollection.MapPageRoute("Student-Schedualer-Synopsis", "Student/Schedule/Synopsis", "~/Student/Student_Schedualer_Synopsis.aspx");
            
            
            routeCollection.MapPageRoute("Student-Thesis-GTCReview", "Student/Thesis/GTCReview", "~/Student/Student_Thesis_GTCReview.aspx");

            routeCollection.MapPageRoute("Student-Meeting-History", "Student/Meeting/", "~/Student/Student_Meeting.aspx");
            routeCollection.MapPageRoute("Student-Meeting-Minutes", "Student/Meeting/{id}", "~/Student/Student_Meeting_Minutes.aspx");


            #endregion
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}