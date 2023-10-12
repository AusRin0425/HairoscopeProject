using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class managerRegistration : System.Web.UI.Page
    {

        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var userExist = sr.userExistence(useremail.Value);
            if (userExist == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Manager already exists , Login to contiue')", true);
            }
            else
            {
                if (usercpass.Value != userpass.Value)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Passwords do not match')", true);
                }
                else
                {
                    var userRegistration = sr.Register(username.Value, usersurname.Value, useremail.Value, userpass.Value, "Manager", managerIDnum.Value , DateTime.Parse(managerdateofbirth.Value) , managerContacts.Value);
                    if (userRegistration != null)
                    {
                        Session["UserID"] = userRegistration.US_Id;
                        Session["Username"] = userRegistration.US_Name;
                        Session["UserType"] = userRegistration.US_Type;
                        Session["UserEmail"] = userRegistration.US_Email;
                        Response.Redirect("Product.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Couldn't register a client')", true);
                    }
                }
            }
        }
    }
}