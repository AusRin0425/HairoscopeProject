using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class checkot : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] != null)
            {
                int UserId = int.Parse(Session["UserID"].ToString());
                var getAddedItems = sr.GetAddedItems(UserId);
                string display = "";
                if(getAddedItems != null)
                {
                    double totalWithVat = double.Parse(Session["totalPRICE"].ToString()) + (double.Parse(Session["totalPRICE"].ToString()) * (0.15));
                    int getAddedcounted = sr.count(UserId);
                    display += "<h4>Cart <span class=\"price\" style=\"color: black\"><i class=\"fa fa-shopping-cart\"></i><b>"+ getAddedcounted + "</b></span></h4>";
                    foreach (ServiceReference1.Cart c in getAddedItems)
                    {
                        display += "<p><a href='singleProduct.aspx?SINGLEPRODID="+c.P_Id+"'>"+c.ProductName+"</a> <span class=\"price\">R" + c.P_Price+"</span></p>";
                    }
                    display += "<hr>";
                    display += "<p>Total<span class=\"price\" style=\"color: black\"><b>R"+ totalWithVat + "</b></span></p>";

                    lblcartproducts.InnerHtml = display;
                }
                fname.Value = Session["Username"].ToString();
                email.Value = Session["UserEmail"].ToString();
            }
            else
            {
                lblcartproducts.InnerHtml = "Login or register first to shop with us!";
            }
        }

        static bool IsNumeric(string input)
        {
            foreach(char c in input)
            {
                if(!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public string GenerateChar()
        {
            Random random = new Random();

            return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))).ToString();
        }

        public string GenerateChar(int count)
        {
            string randomString = "";

            for (int i = 0; i < count; i++)
            {
                randomString += GenerateChar();
            }

            return randomString;
        }

        protected void BtnGenerateInvoice_Click(object sender, EventArgs e)
        {
            int UserId = int.Parse(Session["UserID"].ToString());
            var getAddedItems = sr.GetAddedItems(UserId);

            if (cname.Value == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Provide your card name!')", true);
            }
            else
            {
                if (ccnum.Value.Length != 16 && IsNumeric(ccnum.Value))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid card number')", true);
                }
                else
                {
                    double totalWithVat = double.Parse(Session["totalPRICE"].ToString()) + (double.Parse(Session["totalPRICE"].ToString()) * (0.15));

                    ServiceReference1.Invoice generateInvoice = null;
                    foreach (ServiceReference1.Cart c in getAddedItems)
                    {
                        generateInvoice = sr.GenerateInvoice((double)c.Tot_Price , UserId , DateTime.Now , c.P_Img , (double)c.P_Price , c.P_Id);
                    }
                    if (generateInvoice != null)
                    {
                        Session["InvoiceID"] = generateInvoice.Id;
                        Session["ADDRESS"] = adr.Value;
                        Session["USERCITY"] = city.Value;
                        Session["USERContact"] = contact.Value;
                        Session["TOTAL_PRICE"] = totalWithVat;
                        Response.Redirect("Invoice.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Couldn't generate an invoice')", true);
                    }
                }
            }
        }
    }
}