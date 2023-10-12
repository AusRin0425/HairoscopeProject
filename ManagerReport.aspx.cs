using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class ManagerReport : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] != null && Session["UserType"].Equals("Manager"))
            {
                GenereteTableItems();
            }
        }

        private void GenereteTableItems()
        {
            string display = "";
            var getallitems = sr.GetProductList();
            if (getallitems != null)
            {
                foreach (ServiceReference1.Product p in getallitems)
                {
                    if (p != null)
                    {
                        display += "<tr class='table_row'>";
                        display += "    <td class='column-1'>";
                        display += "        <div class='how-itemcart1'>";
                        display += "            <img src='" + p.P_Img + "' alt='IMG'>";
                        display += "        </div>";
                        display += "    </td>";
                        display += "    <td class='column-2'>" + p.P_Name + "</td>";
                        display += "<td class='column-3'>" + p.P_Quantity + "</td>";
                        display += "    <td class='column-3'>" + p.P_Category + "</td>";
                        display += "</tr>";
                    }
                    else
                    {
                        generatecartitems.InnerHtml = "No products inside the database table";
                    }
                }
                generatecartitems.InnerHtml = display;
            }
            numberproductsold.InnerHtml = sr.countSoldPROD().ToString();
        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            var filter = sr.GetProductByCategory(filteroption.Value);
            string display = "";
            if (filter != null)
            {
                foreach(ServiceReference1.Product p in filter)
                {
                    if(p != null)
                    {
                        display += "<tr class='table_row'>";
                        display += "    <td class='column-1'>";
                        display += "        <div class='how-itemcart1'>";
                        display += "            <img src='" + p.P_Img + "' alt='IMG'>";
                        display += "        </div>";
                        display += "    </td>";
                        display += "    <td class='column-2'>" + p.P_Name + "</td>";
                        display += "<td class='column-3'>" + p.P_Quantity + "</td>";
                        display += "    <td class='column-3'>" + p.P_Category + "</td>";
                        display += "</tr>";
                    }
                    else
                    {
                        generatecartitems.InnerHtml = "No products inside the database table";
                    }
                }
                generatecartitems.InnerHtml = display;
            }
        }
    }
}