using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace Hairoscope_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "hairoscrope" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select hairoscrope.svc or hairoscrope.svc.cs at the Solution Explorer and start debugging.
    public class hairoscrope : Ihairoscrope
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static string HashPassword(string password)
        {
            SHA1 algorithm = SHA1.Create();
            byte[] byteArray = null;
            byteArray = algorithm.ComputeHash(Encoding.Default.GetBytes(password));
            string hashedPassword = "";
            for (int i = 0; i < byteArray.Length; i++)
            {
                hashedPassword += byteArray[i].ToString("x2");
            }
            return hashedPassword;
        }

        public bool AddProduct(string prodname, string colour, double prodPrice, string prodImage, string prodType, string size, DateTime date , string prodDesc, string category, int stockquantity)
        {
            var prodExist = (from e in db.Products where e.P_Img == prodImage select e).FirstOrDefault();
            if (prodExist != null)
            {
                prodExist.P_Name = prodname;
                prodExist.P_Colour = colour;
                prodExist.P_Price = (decimal)prodPrice;
                prodExist.P_Img = prodImage;
                prodExist.P_Type = prodType;
                prodExist.P_Size = size;
                prodExist.P_Date = date;
                prodExist.P_Description = prodDesc;
                prodExist.P_Category = category;
                prodExist.P_Quantity = stockquantity;
                db.SubmitChanges();

                return true;
            }
            else
            {
                var addToProduct = new Product
                {
                    P_Name = prodname,
                    P_Colour = colour,
                    P_Price = (decimal)prodPrice,
                    P_Img = prodImage,
                    P_Type = prodType,
                    P_Size = size,
                    P_Date = date,
                    P_Description = prodDesc,
                    P_Category = category,
                    P_Quantity = stockquantity
                };
                db.Products.InsertOnSubmit(addToProduct);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
        }

        public Cart Addtocart(int userid, int productid, double ProdPrice, string prodImage, int quantity, DateTime dateaddedce, double totalPrice, string prodname)
        {
            var productexitsincart = (from e in db.Carts where e.Us_ID == userid && e.P_Id == productid select e).FirstOrDefault();
            if (productexitsincart != null)
            {
                productexitsincart.Quantity += quantity;
                return productexitsincart;
            }
            else
            {
                var addToCart = new Cart()
                {
                    Us_ID = userid,
                    P_Id = productid,
                    P_Price = (decimal)ProdPrice,
                    P_Img = prodImage,
                    Quantity = quantity,
                    DateAdded = dateaddedce,
                    Tot_Price = (decimal)totalPrice,
                    ProductName = prodname
                };
                db.Carts.InsertOnSubmit(addToCart);
                try
                {
                    db.SubmitChanges();
                    return addToCart;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return null;
                }
            }
        }

        public bool AddtowishList(int productId, string prodname, int userID, string prodImage, double prodPrice, string prodDescription, DateTime date)
        {
            var wishlistItem = (from e in db.WishLIsts where e.Id == productId select e).FirstOrDefault();
            if (wishlistItem != null)
            {
                wishlistItem.Id = productId;
                wishlistItem.P_Name = prodname;
                wishlistItem.User_ID = userID;
                wishlistItem.P_Img = prodImage;
                wishlistItem.P_Price = (decimal)prodPrice;
                wishlistItem.P_Description = prodDescription;
                wishlistItem.DateAdded = date;

                db.SubmitChanges();
                return true;
            }
            else
            {
                var addToWishlist = new WishLIst
                {
                    P_Id = productId,
                    P_Name = prodname,
                    User_ID = userID,
                    P_Img = prodImage,
                    P_Price = (decimal)prodPrice,
                    P_Description = prodDescription,
                    DateAdded = date,
                };
                db.WishLIsts.InsertOnSubmit(addToWishlist);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
        }

        public bool DecreaseQuantity(int id)
        {
            var getProd = (from g in db.Carts where (g.C_Id == id) select g).FirstOrDefault();
            if (getProd != null)
            {
                if (getProd.Quantity <= 1)
                {
                    getProd.Quantity = 1;
                    getProd.Tot_Price = (decimal)(getProd.P_Price) * (getProd.Quantity);
                    db.SubmitChanges();
                    return false;
                }
                else
                {
                    int qunt = (getProd.Quantity--) - 1;
                    getProd.Tot_Price = (decimal)(getProd.P_Price) * qunt;
                    db.SubmitChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProduct(int prodID)
        {
            var getITEm = (from t in db.Products where t.P_Id == prodID select t).FirstOrDefault();
            if (getITEm != null)
            {
                db.Products.DeleteOnSubmit(getITEm);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditProduct(int prodid, string prodname, string colour, double prodPrice, string prodImage, string prodType, string size, string prodDesc, string category, int stockquantity)
        {
            var prodExist = (from e in db.Products where (e.P_Id == prodid) select e).FirstOrDefault();
            if (prodExist != null)
            {
                prodExist.P_Name = prodname;
                prodExist.P_Colour = colour;
                prodExist.P_Price = (decimal)prodPrice;
                prodExist.P_Img = prodImage;
                prodExist.P_Type = prodType;
                prodExist.P_Size = size;
                prodExist.P_Description = prodDesc;
                prodExist.P_Category = category;
                prodExist.P_Quantity = stockquantity;

                db.SubmitChanges();
                return true;
            }

            else
            {
                return false;
            }
        }

        public Invoice GenerateInvoice(double prodTotalprice, int userID, DateTime date, string PRODimage, double PRODprice, int prodID)
        {
            var addToInvoice = new Invoice
            {
                Pds_TotPrice = (decimal)prodTotalprice,
                USER_ID = userID,
                DATE = date,
                PROD_IMAGE = PRODimage,
                PROD_PRICE = (decimal)PRODprice,
                PROD_ID = prodID
            };
            db.Invoices.InsertOnSubmit(addToInvoice);
            try
            {
                db.SubmitChanges();
                return addToInvoice;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return null;
            }
        }



        public List<Cart> GetAddedItems(int userID)
        {
            var query = (from s in db.Carts where s.Us_ID == userID select s).DefaultIfEmpty();
            if (query != null)
            {
                return query.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProductByColour(string prodcolour)
        {
            var colour = (from t in db.Products where t.P_Colour.Equals(prodcolour) select t).DefaultIfEmpty();
            if (colour != null)
            {
                List<Product> productListBycolour = colour.ToList();
                return productListBycolour;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProductByDate(int proddate)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByName(string prodname)
        {
            var name = (from t in db.Products where t.P_Name.Equals(prodname) select t).DefaultIfEmpty();
            if (name != null)
            {
                List<Product> productbyname = name.ToList();
                return productbyname;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProductByCategory(string prodcat)
        {
           var category = (from t in db.Products where t.P_Category.Equals(prodcat) select t).DefaultIfEmpty().ToList();
           if(category != null)
           {
                return category;
           }
            else
            {
                return null;
            }
        }

        public List<Product> GetProductByPrice(decimal minprice, decimal maxprice)
        {
            var price = (from t in db.Products where (t.P_Price > minprice && t.P_Price <= maxprice) select t).DefaultIfEmpty().ToList();
            if (price != null)
            {
                return price;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProductBySize(string size)
        {
            var SIZE = (from t in db.Products where t.P_Size.Equals(size) select t).DefaultIfEmpty();
            if (size != null)
            {
                List<Product> productbySize = SIZE.ToList();
                return productbySize;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProductByType(string prodtype)
        {
            var type = (from t in db.Products where t.P_Type.Equals(prodtype) select t).DefaultIfEmpty();
            if (type != null)
            {
                List<Product> productbytype = type.ToList();
                return productbytype;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProductList()
        {
            var getproductList = (from t in db.Products select t).DefaultIfEmpty();
            if (getproductList != null)
            {
                List<Product> prodlist = getproductList.ToList();
                return prodlist;
            }
            else
            {
                return null;
            }
        }

        public Product GetSignleProduct(int prodid)
        {
            var getSingleProduct = (from t in db.Products where t.P_Id==prodid select t).FirstOrDefault();
            if (getSingleProduct != null)
            {
                return getSingleProduct;
            }
            else
            {
                return null;
            }
        }

        public List<WishLIst> GetWishListItems(int usrID)
        {
            var query = (from w in db.WishLIsts where w.User_ID == usrID select w).DefaultIfEmpty().ToList();
            if (query != null)
            {
                return query;
            }
            else
            {
                return null;
            }
        }

        public bool IncreaseQuantity(int id)
        {
            var getProd = (from g in db.Carts where (g.C_Id == id) select g).FirstOrDefault();
            if (getProd != null)
            {
                if (getProd.Quantity >= 10)
                {
                    getProd.Quantity = 10;
                    getProd.Tot_Price = (decimal)(getProd.P_Price) * getProd.Quantity;
                    db.SubmitChanges();

                    return false;
                }
                else
                {
                    int quant = 1 + getProd.Quantity++;
                    getProd.Tot_Price = (decimal)(getProd.P_Price) * (quant);
                    db.SubmitChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public UserRegistration Login(string email, string password)
        {
            var userlogin = (from l in db.UserRegistrations where l.US_Email.Equals(email) && l.US_Password.Equals(HashPassword(password)) select l).FirstOrDefault();
            if (userlogin != null)
            {
                return userlogin;
            }
            else
            {
                return null;
            }
        }

        public UserRegistration Register(string name, string surname, string email, string password, string type, string managerIDnum, DateTime dob, string managerContact)
        {
            var reg = new UserRegistration()
            {
                US_Name = name,
                US_SurName = surname,
                US_Email = email,
                US_Password = HashPassword(password),
                US_Type = type,
                US_ID_NUM = managerIDnum,
                US_DATE_OF_BIRTH = dob,
                US_CONTACT = managerContact
            };
            db.UserRegistrations.InsertOnSubmit(reg);
            try
            {
                db.SubmitChanges();
                return reg;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return null;
            }
        }

        public bool RemoveFromCart(int id)
        {
            var getITEm = (from t in db.Carts where t.C_Id == id select t).FirstOrDefault();
            if (getITEm != null)
            {
                db.Carts.DeleteOnSubmit(getITEm);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItemonwishlist(int id)
        {
            try
            {
                var getITEm = (from t in db.WishLIsts where t.Id == id select t).FirstOrDefault();
                if (getITEm != null)
                {
                    db.WishLIsts.DeleteOnSubmit(getITEm);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public double TotalPRICE(int userID)
        {
            var userexist = (from f in db.Carts where f.Us_ID == userID select f).FirstOrDefault();
            if (userexist != null)
            {
                var getTotalPRICE = (from g in db.Carts where g.Us_ID == userID select g.Tot_Price).Sum();
                if (getTotalPRICE > 0)
                {
                    return (double)getTotalPRICE;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public int userExistence(string email)
        {
            var exist = (from e in db.UserRegistrations where e.US_Email.Equals(email) select e).FirstOrDefault();
            if (exist != null)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public int count(int userID)
        {
            var getcount = (from c in db.Carts where c.Us_ID == userID select c).Count();
            if(getcount > 0)
            {
                return getcount;
            }
            else
            {
                return 0;
            }
        }

        public List<Invoice> GetRecord(int userID)
        {
            var getoffer = (from u in db.Invoices where u.USER_ID==userID select u).DefaultIfEmpty();
            if(getoffer != null)
            {
                return getoffer.ToList();
            }
            else
            {
                return null;
            }
        }

        public int countSoldPROD()
        {
            var getcount = (from c in db.Invoices select c).DefaultIfEmpty().Count();
            if(getcount > 0)
            {
                return getcount;
            }
            else
            {
                return 0;
            }
        }

        public Invoice GetsingleItemsininvoice(int invID)
        {
            var getsingleprod = (from s in db.Invoices where s.Id == invID select s).FirstOrDefault();
            if (getsingleprod != null)
            {
                return getsingleprod;
            }
            else 
            {
                return null;
            }
        }
    }
}
