using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class updateproduct : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int prodid = int.Parse(Request.QueryString["UPDATE_ID"]);
                var getsingleprod = sr.GetSignleProduct(prodid);
                if (getsingleprod != null)
                {
                    prodname.Value = getsingleprod.P_Name;
                    prodcolour.Value = getsingleprod.P_Colour;
                    prodprice.Value = getsingleprod.P_Price.ToString();
                    prodimage.Value = getsingleprod.P_Img;
                    prodtype.Value = getsingleprod.P_Type;
                    prodsize.Value = getsingleprod.P_Size;
                    prodcategory.Value = getsingleprod.P_Category;
                    proddescription.Value = getsingleprod.P_Description;
                    stockquantity.Value = getsingleprod.P_Quantity.ToString();
                }
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["UPDATE_ID"] != null)
            {
                int prodId = int.Parse(Request.QueryString["UPDATE_ID"]);
                var editproduct = sr.EditProduct(prodId , prodname.Value , prodcolour.Value , double.Parse(prodprice.Value) , prodimage.Value , prodtype.Value , prodsize.Value , proddescription.Value, prodcategory.Value , int.Parse(stockquantity.Value));
                if(editproduct)
                {
                    Response.Redirect("productmanagement.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unsuccesfull product update')", true);
                }
            }
        }
    }
}