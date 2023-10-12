using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class wishlist : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                int userID = int.Parse(Session["UserID"].ToString());
                if (Request.QueryString["WISHLISTID"] != null)
                {
                    int productID = int.Parse(Request.QueryString["WISHLISTID"]);
                    var getprod = sr.GetSignleProduct(productID);
                    if (getprod != null)
                    {
                        var addtowishlist = sr.AddtowishList(productID, getprod.P_Name, userID, getprod.P_Img, (double)getprod.P_Price, getprod.P_Description, DateTime.Now);
                        if (addtowishlist)
                        {
                            GeneratewishlistItems(userID);
                        }
                    }
                }
                else
                {
                    GeneratewishlistItems(userID);
                }
            }
        }

        private void GeneratewishlistItems(int userId)
        {
            if (!IsPostBack)
            {
                string display = "";
                var getaddedItems = sr.GetWishListItems(userId);
                if (getaddedItems != null)
                {
                    foreach (ServiceReference1.WishLIst p in getaddedItems)
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
                            display += "    <td class='column-3'>R" + p.P_Price + "</td>";
                            display += "    <td class='column-3'><a href='?REMOVE_ID=" + p.Id + "'>Remove</a></td>";
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

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                int userID = int.Parse(Session["UserID"].ToString());
                if (Request.QueryString["REMOVE_ID"] != null)
                {
                    int removeIProduct = int.Parse(Request.QueryString["REMOVE_ID"]);
                    var removeProd = sr.RemoveItemonwishlist(removeIProduct);
                    if (removeProd)
                    {
                        GeneratewishlistItems(userID);
                    }
                    else
                    {
                        GeneratewishlistItems(userID);
                    }
                }
                else
                {
                    GeneratewishlistItems(userID);
                }
            }
        }
    }
}