using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Hairoscope_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Ihairoscrope" in both code and config file together.
    [ServiceContract]
    public interface Ihairoscrope
    {
        [OperationContract]
        UserRegistration Register(string name, string surname, string email, string password, string type, string managerIDnum, DateTime dob, string managerContact);

        [OperationContract]
        int userExistence(string email);

        [OperationContract]
        UserRegistration Login(string email, string password);

        [OperationContract]
        List<Product> GetProductList();

        [OperationContract]
        Product GetSignleProduct(int prodid);

        [OperationContract]
        List<Product> GetProductByType(string prodtype);

        [OperationContract]
        List<Product> GetProductByColour(string prodcolour);

        [OperationContract]
        List<Product> GetProductByName(string prodname);

        [OperationContract]
        List<Product> GetProductByCategory(string prodcat);

        [OperationContract]
        List<Product> GetProductByPrice(decimal minprice, decimal maxprice);

        [OperationContract]
        List<Product> GetProductByDate(int proddate);

        [OperationContract]
        List<Product> GetProductBySize(String size);

        [OperationContract]
        Cart Addtocart(int userid, int productid, double ProdPrice, string prodImage, int quantity, DateTime dateaddedce, double totalPrice, string prodname);

        [OperationContract]
        List<Cart> GetAddedItems(int userID);

        [OperationContract]
        bool AddtowishList(int productId, string prodname, int userID ,   string prodImage, double prodPrice, string prodDescription, DateTime date);

        [OperationContract]
        List<WishLIst> GetWishListItems(int usrID);

        [OperationContract]
        bool RemoveItemonwishlist(int id);

        [OperationContract]
        bool IncreaseQuantity(int id);

        [OperationContract]
        double TotalPRICE(int userID);

        [OperationContract]
        bool DecreaseQuantity(int id);

        [OperationContract]
        bool RemoveFromCart(int id);

        [OperationContract]
        bool AddProduct(string prodname, string colour, double prodPrice, string prodImage, string prodType, string size, DateTime date ,string prodDesc, string category, int stockquantity);

        [OperationContract]
        bool EditProduct(int prodid, string prodname, string colour, double prodPrice, string prodImage, string prodType, string size, string prodDesc, string category, int stockquantity);

        [OperationContract]
        bool DeleteProduct(int prodID);

        [OperationContract]
        Invoice GenerateInvoice(double prodTotalprice, int userID, DateTime date, string PRODimage, double PRODprice, int prodID);

        [OperationContract]
        int count(int userID);

        [OperationContract]
        List<Invoice> GetRecord(int userID);

        [OperationContract]
        int countSoldPROD();

        [OperationContract]
        Invoice GetsingleItemsininvoice(int invID);
    }
}
