<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="checkot.aspx.cs" Inherits="HairoScope.checkot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
body {
  font-family: Arial;
  font-size: 17px;
  padding: 8px;
}

* {
  box-sizing: border-box;
}

.row {
  display: -ms-flexbox; /* IE10 */
  display: flex;
  -ms-flex-wrap: wrap; /* IE10 */
  flex-wrap: wrap;
  margin: 0 -16px;
}

.col-25 {
  -ms-flex: 25%; /* IE10 */
  flex: 25%;
}

.col-50 {
  -ms-flex: 50%; /* IE10 */
  flex: 50%;
}

.col-75 {
  -ms-flex: 75%; /* IE10 */
  flex: 75%;
}

.col-25,
.col-50,
.col-75 {
  padding: 0 16px;
}

.container {
  background-color: #f2f2f2;
  padding: 5px 20px 15px 20px;
  border: 1px solid lightgrey;
  border-radius: 3px;
}

input[type=text] {
  width: 100%;
  margin-bottom: 20px;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 3px;
}

label {
  margin-bottom: 10px;
  display: block;
}

.icon-container {
  margin-bottom: 20px;
  padding: 7px 0;
  font-size: 24px;
}

.btn {
  background-color: #04AA6D;
  color: white;
  padding: 12px;
  margin: 10px 0;
  border: none;
  width: 100%;
  border-radius: 3px;
  cursor: pointer;
  font-size: 17px;
}

.btn:hover {
  background-color: #45a049;
}

a {
  color: #2196F3;
}

hr {
  border: 1px solid lightgrey;
}

span.price {
  float: right;
  color: grey;
}

/* Responsive layout - when the screen is less than 800px wide, make the two columns stack on top of each other instead of next to each other (also change the direction - make the "cart" column go on top) */
@media (max-width: 800px) {
  .row {
    flex-direction: column-reverse;
  }
  .col-25 {
    margin-bottom: 20px;
  }
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="bg0 p-t-104 p-b-116">
        <form runat="server">
            <div class="container">
                <div class="flex-w flex-tr">
                    <div class="size-210 bor10 p-lr-70 p-t-55 p-b-70 p-lr-15-lg w-full-md">
                        <h3>Billing Address</h3>
                        <label for="fname"><i class="fa fa-user"></i>Name</label>
                        <input type="text" runat="server" id="fname" name="firstname" placeholder="John">
                        <label for="contact"><i class="fa fa-envelope"></i>Contact</label>
                        <input type="number" runat="server" id="contact" name="contact" placeholder="0768495601">
                        <label for="email"><i class="fa fa-envelope"></i>Email</label>
                        <input type="text" runat="server" id="email" name="email" placeholder="john@example.com">
                        <label for="adr"><i class="fa fa-address-card-o"></i>Address</label>
                        <input type="text" runat="server" id="adr" name="address" placeholder="542 W. 15th Street">
                        <label for="city"><i class="fa fa-institution"></i>City</label>
                        <input type="text" runat="server" id="city" name="city" placeholder="Gauteng">

                        <div class="col-50">
                            <h3>Payment</h3>
                            <label for="fname">Accepted Cards</label>
                            <div class="icon-container">
                                <i class="fa fa-cc-visa" style="color: navy;"></i>
                                <i class="fa fa-cc-amex" style="color: blue;"></i>
                                <i class="fa fa-cc-mastercard" style="color: red;"></i>
                                <i class="fa fa-cc-discover" style="color: orange;"></i>
                            </div>
                            <label for="cname">Name on Card</label>
                            <input type="text" runat="server" id="cname" name="cardname" placeholder="John More Doe">
                            <label for="ccnum">Credit card number</label>
                            <input type="text" runat="server" id="ccnum" name="cardnumber" placeholder="1111-2222-3333-4444">
                            <label for="expmonth">Exp Month</label>
                            <input type="text" runat="server" id="expmonth" name="expmonth" placeholder="September">
                            <div class="row">
                                <div class="col-50">
                                    <label for="expyear">Exp Year</label>
                                    <input type="text" runat="server" id="expyear" name="expyear" placeholder="2018">
                                </div>
                                <div class="col-50">
                                    <label for="cvv">CVV</label>
                                    <input type="password" runat="server" id="cvv" name="cvv" placeholder="352">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-25">
                </div>
            </div>
            <div class="container" id="lblcartproducts" runat="server">
                <h4>Cart <span class="price" style="color: black"><i class="fa fa-shopping-cart"></i><b>4</b></span></h4>
                <p><a href="#">Product 1</a> <span class="price">$15</span></p>
                <p><a href="#">Product 2</a> <span class="price">$5</span></p>
                <p><a href="#">Product 3</a> <span class="price">$8</span></p>
                <p><a href="#">Product 4</a> <span class="price">$2</span></p>
                <hr>
                <p>Total <span class="price" style="color: black"><b>$30</b></span></p>
            </div>
             <asp:Button ID="BtnGenerateInvoice" Style="background-color: #e1bee7" class="flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer" Text="GenerateInvoice" OnClick="BtnGenerateInvoice_Click" runat="server" />
        </form>
    </section>
</asp:Content>
