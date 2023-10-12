using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class Cart : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] != null)
            {
                int usrID = int.Parse(Session["UserID"].ToString());
                if (Request.QueryString["ADDTOCARTID"] != null)
                {
                    int productID = int.Parse(Request.QueryString["ADDTOCARTID"]);

                    var getproduct = sr.GetSignleProduct(productID);
                    if(getproduct != null)
                    {
                        var addtocart = sr.Addtocart(usrID , productID , (double)getproduct.P_Price , getproduct.P_Img , 1 , DateTime.Now , (double)getproduct.P_Price ,getproduct.P_Name);
                        if(addtocart != null)
                        {
                            Session["DATE"] = addtocart.DateAdded;
                            GenerateCartItems(usrID);
                        }
                    }
                }
                else
                {
                    GenerateCartItems(usrID);
                }
            }
            else
            {
                LBLSHOWSHIPPING.Visible = false;
                generatecartitems.InnerHtml = "Login or register before making purchases";
            }
        }

        private void GenerateCartItems(int userId)
        {
            if(!IsPostBack)
            {
                string display = "";
                var getaddedItems = sr.GetAddedItems(userId);
                if (getaddedItems != null)
                {
                    foreach (ServiceReference1.Cart p in getaddedItems)
                    {
                        if (p != null)
                        {
                            display += "<tr class='table_row'>";
                            display += "    <td class='column-1'>";
                            display += "        <div class='how-itemcart1'>";
                            display += "            <img src='" + p.P_Img + "' alt='IMG'>";
                            display += "        </div>";
                            display += "    </td>";
                            display += "    <td class='column-2'>" + p.ProductName + "</td>";
                            display += "    <td class='column-3'>R" + p.P_Price + "</td>";
                            display += "<td class=\"column - 4\">";
                            display += "<div class=\"wrap-num-product flex-w m-l-auto m-r-0\">";
                            display += "    <div class=\"btn-num-product-down cl8 hov-btn3 trans-04 flex-c-m\">";
                            display += "        <a href='?DECREASE_ID=" + p.C_Id + "'>  -  </a>";
                            display += "    </div>";

                            display += "    <input class=\"mtext-104 cl3 txt-center num-product\" type=\"number\" name=\"num-product2\" value="+p.Quantity+">";

                            display += "    <div class=\"btn-num-product-up cl8 hov-btn3 trans-04 flex-c-m\">";
                            display += "        <a href='?INCREASE_ID=" + p.C_Id + "'>  +  </a>";
                            display += "    </div>";
                            display += "</div>";
                            display += "    </td>";
                            //display += "    <td class='column-4'><a href='?DECREASE_ID="+p.C_Id+ "'>  -  </a><input value=" + p.Quantity + "><a href='?INCREASE_ID=" + p.C_Id + "'>  +  </a></td>";
                            display += "    <td class='column-5'>R" + p.Tot_Price + "</td>";
                            display += "    <td class='column-5'><a href='?REMOVE_ID="+p.C_Id+"'> remove </a></td>";
                            display += "</tr>";
                        }
                        else
                        {
                            generatecartitems.InnerHtml = "Continue shopping";
                        }
                    }
                    int userid = int.Parse(Session["UserID"].ToString());
                    double subtotals = sr.TotalPRICE(userid);
                    lblsubtotal.InnerHtml = "R" + subtotals.ToString();
                    lbltotalprice.InnerHtml = "R" + subtotals.ToString();

                    generatecartitems.InnerHtml = display;
                }
                else
                {
                    int userid = int.Parse(Session["UserID"].ToString());
                    double subtotals = sr.TotalPRICE(userid);
                    lblsubtotal.InnerHtml = "R" + subtotals.ToString();
                    lbltotalprice.InnerHtml = "R" + subtotals.ToString();
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                int userid = int.Parse(Session["UserID"].ToString());
                if (Request.QueryString["DECREASE_ID"] != null)
                {
                    int prodID = int.Parse(Request.QueryString["DECREASE_ID"]);
                    var decreaseQ = sr.DecreaseQuantity(prodID);
                    if (decreaseQ)
                    {
                        GenerateCartItems(userid);
                    }
                }
                else if(Request.QueryString["INCREASE_ID"] != null)
                {
                    int prodID = int.Parse(Request.QueryString["INCREASE_ID"]);
                    var increaseQ = sr.IncreaseQuantity(prodID);
                    if (increaseQ)
                    {
                        GenerateCartItems(userid);
                    }
                }
                else if (Request.QueryString["REMOVE_ID"] != null)
                {
                    int prodID = int.Parse(Request.QueryString["REMOVE_ID"]);
                    var removeItem = sr.RemoveFromCart(prodID);
                    if (removeItem)
                    {
                        GenerateCartItems(userid);
                    }
                }
            }
            else
            {
                LBLSHOWSHIPPING.Visible = false;
            }
        }

        protected void btnUpdatetotals_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                int userid = int.Parse(Session["UserID"].ToString());
                double subtotals = sr.TotalPRICE(userid);
                if (subtotals > 5000)
                {
                    double shipping = subtotals + ((0.05)*subtotals);
                    lbltotalprice.InnerHtml = "R" + shipping.ToString();
                    Session["totalPRICE"] = shipping;
                }
                else
                {
                    double shipping = subtotals + ((0.1)*subtotals);
                    lbltotalprice.InnerHtml = "R" + shipping.ToString();
                    Session["totalPRICE"] = shipping;
                }
            }
            else
            {
                LBLSHOWSHIPPING.Visible = false;
            }
        }

        protected void BtnProceed_Click(object sender, EventArgs e)
        {
            if(Session["UserID"] != null)
            {

                Response.Redirect("checkot.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User should login or register first before shopping')", true);
            }
        }
    }
}