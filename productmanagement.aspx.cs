using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class productmanagement : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] != null && Session["UserType"].Equals("Manager"))
            {
                GenereteTableItems();
            }
            else
            {
                generatecartitems.InnerHtml = "Only managers are allowed to access this page";
            }
        }

        private void GenereteTableItems()
        {
            string display = "";
            var getallitems = sr.GetProductList();
            if(getallitems != null)
            {
                foreach(ServiceReference1.Product p in  getallitems)
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
                        display += "<td class='column-3'>"+p.P_Quantity+"</td>";
                        display += "    <td class='column-4'>" + p.P_Category + "</td>";
                        display += "    <td class='column-5'><a href='?REMOVE_ID=" + p.P_Id + "'> Delete </a></td>";
                        display += "    <td class='column-5'><a href='updateproduct.aspx?UPDATE_ID="+p.P_Id+"'> Edit </a></td>";
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

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if(Request.QueryString["REMOVE_ID"] != null)
            {
                int prodID = int.Parse(Request.QueryString["REMOVE_ID"]);
                var deleteProd = sr.DeleteProduct(prodID);
                if(deleteProd)
                {
                    GenereteTableItems();
                }
                else
                {
                    GenereteTableItems();
                }
            }
        }

        protected void BtnAddproduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }
    }
}