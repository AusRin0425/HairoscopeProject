using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class Invoiceview : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                int userID = int.Parse(Session["UserID"].ToString());
                GeneratewishlistItems(userID);
            }
        }

        private void GeneratewishlistItems(int userId)
        {
            string display = "";
            var getinvoicerecord = sr.GetRecord(userId);
            if (getinvoicerecord != null)
            {
                foreach (ServiceReference1.Invoice p in getinvoicerecord)
                {
                    if (p != null)
                    {
                        display += "<tr class='table_row'>";
                        display += "    <td class='column-1'>";
                        display += "        <div class='how-itemcart1'>";
                        display += "            <img src='" + p.PROD_IMAGE + "' alt='IMG'>";
                        display += "        </div>";
                        display += "    </td>";
                        display += "    <td class='column-2'>" + sr.GetSignleProduct(p.PROD_ID).P_Name + "</td>";
                        display += "    <td class='column-3'>R" + p.PROD_PRICE + "</td>";
                        display += "    <td class='column-3'><a href='SingleProductInvoice.aspx?VIEWID=" + p.Id+"'>View Invoice</a></td>";
                        display += "</tr>";
                    }
                    else
                    {
                        generatecartitems.InnerHtml = "Continue shopping";
                    }
                }
                generatecartitems.InnerHtml = display;
            }
        }
    }
}