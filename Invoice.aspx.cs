using HairoScope.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairoScope
{
    public partial class Invoice : System.Web.UI.Page
    {
        IhairoscropeClient sr = new IhairoscropeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                int userID = int.Parse(Session["UserID"].ToString());
                generateInvoiceItems(userID);
            }

        }

        private void generateInvoiceItems(int userID)
        {
            if(Session["InvoiceID"] != null)
            {
                var getProdCart = sr.GetAddedItems(userID);
                StringBuilder display = new StringBuilder();

                if (getProdCart != null)
                {
                    // Add CSS class to style the table
                    itemm.CssClass = "invoice-table";

                    TableRow headerRow = new TableRow();

                    // Correct the column header texts
                    TableCell nameHeader = new TableCell();
                    nameHeader.Text = "Description";
                    headerRow.Cells.Add(nameHeader);

                    TableCell quantityHeader = new TableCell();
                    quantityHeader.Text = "Quantity";
                    headerRow.Cells.Add(quantityHeader);

                    TableCell unitPriceHeader = new TableCell();
                    unitPriceHeader.Text = "Unit Price";
                    headerRow.Cells.Add(unitPriceHeader);

                    TableCell totalPriceHeader = new TableCell();
                    totalPriceHeader.Text = "Total";
                    headerRow.Cells.Add(totalPriceHeader);

                    itemm.Rows.Add(headerRow);

                    foreach (ServiceReference1.Cart s in getProdCart)
                    {
                        TableRow row = new TableRow();

                        // Correct the row cell assignments
                        TableCell namecell = new TableCell();
                        namecell.Text = s.ProductName;
                        row.Cells.Add(namecell);

                        TableCell quantitycell = new TableCell();
                        quantitycell.Text = s.Quantity.ToString();
                        row.Cells.Add(quantitycell);

                        TableCell unitPricecell = new TableCell();
                        unitPricecell.Text = s.P_Price.ToString();
                        row.Cells.Add(unitPricecell);

                        TableCell totalcell = new TableCell();
                        totalcell.Text = s.Tot_Price.ToString();
                        row.Cells.Add(totalcell);

                        itemm.Rows.Add(row);
                    }

                    clientNAME.InnerHtml = "Client Name: " + Session["Username"].ToString();
                    clientADDRESS.InnerHtml = "Client Address: " + Session["ADDRESS"].ToString();
                    clientCITY.InnerHtml = "Client City: " + Session["USERCITY"].ToString();
                    clientEMAIL.InnerHtml = "Client Contact: " + Session["USERContact"].ToString();

                    INV_ID.InnerHtml = "INV - 0" + Session["InvoiceID"].ToString();
                    INV_DATE.InnerHtml = DateTime.Now.ToString();
                    totalprice.InnerHtml = "Total Price: R" + Session["TOTAL_PRICE"].ToString();
                }
            }
        }
    }
}