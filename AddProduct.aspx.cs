using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class AddProduct : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            var addproduct = sr.AddProduct(prodname.Value, prodcolour.Value, double.Parse(prodprice.Value), prodimage.Value, prodtype.Value, prodsize.Value, DateTime.Now, proddescription.Value , prodcategory.Value , int.Parse(stockquantity.Value));
            if (addproduct)
            {
                Response.Redirect("productmanagement.aspx");
            }
        }
    }
}