﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TES.Supervisor
{
    public partial class Supervisor_Supervised_Student : System.Web.UI.Page
    {
        private _Supervisor supervisor = new _Supervisor();
        private _Student student = new _Student();

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

        private void GetData()
        {
            gvStudent.DataSource = student.GetAllSupervisedStudent(supervisor.SupervisorId);
            gvStudent.DataBind();
        }

        protected void gvStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStudent.PageIndex = e.NewPageIndex;
            GetData();
        }
    }
}