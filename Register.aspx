<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HairoScope.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="bg0 p-t-104 p-b-116">
       <form runat="server">
        <div class="container">
            <div class="flex-w flex-tr">
                <div class="size-210 bor10 p-lr-70 p-t-55 p-b-70 p-lr-15-lg w-full-md">

                    <h3 class="mtext-111 cl2 p-b-16">Register
                    </h3>

                    <div class="bor8 m-b-20 how-pos4-parent">
                        <input class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" type="text" runat="server" id="username" placeholder="Your Name">
                    </div>

                    <div class="bor8 m-b-20 how-pos4-parent">
                        <input class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" type="text" runat="server" id="usersurname" placeholder="Your Surname">
                    </div>



                    <div class="bor8 m-b-20 how-pos4-parent">
                        <input class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" type="text" runat="server" id="useremail" placeholder="Your Email Address">
                    </div>

                    <div class="bor8 m-b-20 how-pos4-parent">
                        <input class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" type="date" runat="server" id="userdateofbirth" placeholder="Your Date of Birth">
                    </div>

                    <div class="bor8 m-b-20 how-pos4-parent">
                        <input class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" type="password" runat="server" id="userpass" placeholder="Create Your Password">
                    </div>


                    <div class="bor8 m-b-20 how-pos4-parent">
                        <input class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" type="password" runat="server" id="usercpass" placeholder="Confirm Your Password">
                    </div>

                    <asp:Button ID="btnReg" Style="background-color: #e1bee7" class="flex-c-m stext-101 cl0 size-103 bg1 bor1 hov-btn2 p-lr-15 trans-04" Text="Register" runat="server" OnClick="btnReg_Click" />
                </div>
            </div>
        </div>
      </form>
    </section>
</asp:Content>
