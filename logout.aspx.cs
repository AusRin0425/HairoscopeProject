using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Session["Username"] = null;
            Session["UserType"] = null;
            Session["totalPRICE"] = null;
            Session["UserEmail"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}