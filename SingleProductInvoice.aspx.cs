using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class SingleProductInvoice : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["VIEWID"] != null)
            {
                int prodID = int.Parse(Request.QueryString["VIEWID"]);
                GenerateSingleProduct(prodID);
            }
            else
            {

            }
        }

        private void GenerateSingleProduct(int prodID)
        {
            var getSingleprod = sr.GetsingleItemsininvoice(prodID);
            var display = "";
            if (getSingleprod != null)
            {
                // Title page
                display += "<section class=\"bg-img1 txt-center p-lr-15 p-tb-92\" style=\"background-image: url('images/ppp.jpg');\">";
                display += "  <h2 class=\"ltext-105 cl0 txt-center\">Invoice</h2>";
                display += "</section>";

                // Content page
                display += "<section class=\"bg0 p-t-75 p-b-120\">";
                display += "  <div class=\"container\">";
                display += "    <div class=\"row p-b-148\">";
                display += "      <div class=\"col-md-7 col-lg-8\">";
                display += "        <div class=\"p-t-7 p-r-85 p-r-15-lg p-r-0-md\">";
                display += "          <h3 class=\"mtext-111 cl2 p-b-16\">" + sr.GetSignleProduct(getSingleprod.PROD_ID).P_Name + "</h3>";
                display += "          <p class=\"stext-113 cl6 p-b-26\">R" + getSingleprod.PROD_PRICE + "</p>";
                display += "          <p class=\"stext-113 cl6 p-b-26\">Date : " + getSingleprod.DATE + "</p>";
                display += "        </div>";
                display += "      </div>";
                display += "      <div class=\"col-11 col-md-5 col-lg-4 m-lr-auto\">";
                display += "        <div class=\"how-bor1 \">";
                display += "          <div class=\"hov-img0\">";
                display += "            <img src='" + getSingleprod.PROD_IMAGE + "' alt=\"IMG\" width='250' height='250'>";
                display += "          </div>";
                display += "        </div>";
                display += "      </div>";
                display += "    </div>";
                display += "  </div>";
                display += "</section>";

                lbldisplay.InnerHtml = display;
            }
            else
            {
                display += "Error in displaying a product";
                lbldisplay.InnerHtml = display;
            }
        }
    }
}