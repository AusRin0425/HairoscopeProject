using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class Login : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var UserLogin = sr.Login(useremail.Value , userpassword.Value);
            if(UserLogin != null)
            {
                Session["UserID"] = UserLogin.US_Id;
                Session["Username"] = UserLogin.US_Name;
                Session["UserType"] = UserLogin.US_Type;
                Session["UserEmail"] = UserLogin.US_Email;
                Response.Redirect("Product.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrect credentials , Try Login again')", true);
            }
        }
    }
}