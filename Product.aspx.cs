using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class Product : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            DynamicallyDisplayProducts();
        }

        private String GenerateProducts(ServiceReference1.Product prod)
        {
            if (prod != null)
            {
                String display = "";

                display += "<div class='col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item bob'>";
                display += "<div class='block2'>";
                display += "<div class='block2-pic hov-img0'>";
                display += "<a href='singleProduct.aspx?SINGLEPRODID="+prod.P_Id+"'><img src='" + prod.P_Img+"' alt='IMG-PRODUCT' width='200' height='210'></a>";
                display += "</div>";
                display += "<div class='block2-txt flex-w flex-t p-t-14'>";
                display += "<div class='block2-txt-child1 flex-col-l'>";
                display += "<a href='singleProduct.aspx?SINGLEPRODID=" + prod.P_Id + "' class='stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6'>" + prod.P_Name+"</a>";
                display += "<a href='Cart.aspx?ADDTOCARTID="+prod.P_Id+"' class='stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6'>Add To Cart</a>";
                //display += "<a href='wishlist.aspx?WISHLISTID=" + prod.P_Id + "' class='stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6'>Add to wishlist</a>";
                display += "<span class='stext-105 cl3'>R"+prod.P_Price+"</span>";
                display += "</div>";
                display += "<div class='block2-txt-child2 flex-r p-t-3'>";
                //display += "<a href='wishlist.aspx?WISHLISTID="+prod.P_Id+"' class='btn-addwish-b2 dis-block pos-relative js-addwish-b2'>";
                display += "<a href = 'wishlist.aspx?WISHLISTID=" + prod.P_Id + "' class='stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6'>";
                display += "<img class='icon-heart1 dis-block trans-04' src='images/icons/icon-heart-01.png' alt='ICON'>";
                //display += "<img class='icon-heart2 dis-block trans-04 ab-t-l' src='images/icons/icon-heart-02.png' alt='ICON'>";
                display += "</a>";
                //display += "</a>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</div>";

                return display;
            }
            else
            {
                hairs.InnerHtml = "Products are out of stock";
                return null;
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if(Request.QueryString["ADDTOCARTID"] != null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item was added to a cart!')", true);
            }
        }

        private void DynamicallyDisplayProducts()
        {
            var productsList = sr.GetProductList();
            if (productsList != null)
            {
                String display = "";
                foreach (ServiceReference1.Product prod in productsList)
                {
                    display += GenerateProducts(prod);
                }
                hairs.InnerHtml = display;
            }
            else
            {
                hairs.InnerHtml = "No Products in the database";
            }
        }

        protected void FilterProducts_Click(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;
            String typeID = linkbutton.ID;

            if (typeID.Equals("All"))
            {
                DynamicallyDisplayProducts();
            }
            else if (typeID.Equals("Red") || typeID.Equals("Ginger") || typeID.Equals("black"))
            {
                var getprodbycolour = sr.GetProductByColour(typeID);
                if (getprodbycolour != null)
                {
                    string display = "";
                    foreach (ServiceReference1.Product prd in getprodbycolour)
                    {

                        display += GenerateProducts(prd);
                    }
                    hairs.InnerHtml = display;
                }
                else
                {
                    hairs.InnerHtml = "Products out of stock";
                }
            }
            else if (typeID.Equals("Brazillian") || typeID.Equals("Peruvian"))
            {
                var getprodBytype = sr.GetProductByType(typeID);
                if (getprodBytype != null)
                {
                    string display = "";
                    foreach (ServiceReference1.Product prd in getprodBytype)
                    {

                        display += GenerateProducts(prd);
                    }
                    hairs.InnerHtml = display;
                }
                else
                {
                    hairs.InnerHtml = "Products out of stock";
                }
            }
            else if (typeID.Equals("Curlyy") || typeID.Equals("Fringe") || typeID.Equals("Straight"))
            {
                var getprodbycat = sr.GetProductByCategory(typeID);
                if (getprodbycat != null)
                {
                    string display = "";
                    foreach (ServiceReference1.Product prd in getprodbycat)
                    {

                        display += GenerateProducts(prd);
                    }
                    hairs.InnerHtml = display;
                }
                else
                {
                    hairs.InnerHtml = "Products out of stock";
                }
            }
            else if (typeID.Equals("firstprice"))
            {
                var getprodbyprice = sr.GetProductByPrice(0 , 3500);
                if (getprodbyprice != null)
                {
                    string display = "";
                    foreach (ServiceReference1.Product prd in getprodbyprice)
                    {

                        display += GenerateProducts(prd);
                    }
                    hairs.InnerHtml = display;
                }
                else
                {
                    hairs.InnerHtml = "Products out of stock";
                }
            }
            else if (typeID.Equals("secondprice"))
            {
                var getprodbyprice = sr.GetProductByPrice(3500 , 7000);
                if (getprodbyprice != null)
                {
                    string display = "";
                    foreach (ServiceReference1.Product prd in getprodbyprice)
                    {

                        display += GenerateProducts(prd);
                    }
                    hairs.InnerHtml = display;
                }
                else
                {
                    hairs.InnerHtml = "Products out of stock";
                }
            }
        }
    }
}