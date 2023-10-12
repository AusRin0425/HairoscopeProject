using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblregister.Visible = true;
            lbllogin.Visible = true;
            lblProductManagement.Visible = false;
            lblReport.Visible = false;
            lblabout.Visible = true;
            lblcontact.Visible = true;
            lbllogout.Visible = false;
            lblwishlist.Visible = false;
            lblinvoiceview.Visible = false;

            if (Session["UserID"] != null && Session["UserType"].Equals("Manager"))
            {
                lblregister.Visible = true;
                lbllogin.Visible = false;
                lblProductManagement.Visible = true;
                lblReport.Visible = true;
                lblabout.Visible = false;
                lblcontact.Visible = false;
                lbllogout.Visible = true;
                lblwishlist.Visible = false;
                lblinvoiceview.Visible = false;
            }
            else if(Session["UserID"] != null && Session["UserType"].Equals("Customer"))
            {
                lblregister.Visible = false;
                lbllogin.Visible = false;
                lblProductManagement.Visible = false;
                lblReport.Visible = false;
                lblabout.Visible = true;
                lblcontact.Visible = true;
                lbllogout.Visible = true;
                lblwishlist.Visible = true;
                lblinvoiceview.Visible = true;
            }
        }
    }
}