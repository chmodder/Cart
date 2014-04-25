using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void AddToCartBtn_Click(object sender, EventArgs e)
    {
        ////liste kaldet "Cart" med plads til produkter
        //List<ProductsInCart> Cart = new List<ProductsInCart>();
        ////evt. smide den i Cart klassens constructor
        Cart C1Cart = new Cart();

        ////Henter Sessionen kurv til kurv
        C1Cart.TakeCart();
        

        ////lægger produktet i kurven. Kan evt. videreudbygges til at hente parametre fra DB
        C1Cart.AddToCart(IdTbx.Text, NameTbx.Text, PriceTbx.Text, AmountTbx.Text);

        ////Vis kurv. Skal bruge et navn fra et Gridview, som kurven vises i
        C1Cart.ShowCart(CartGw);
    }

    
    //private void AddToCart(List<ProductsInCart> Cart)
    //{
    //    bool NewProduct = true;

    //    //undersøg om produktet er i kurven
    //    foreach (ProductsInCart Product in Cart)
    //    {
    //        //Hvis produktet er fundet
    //        if (Product.Id == Convert.ToInt32(IdTbx.Text))
    //        {
    //            //Så opdater antal og samlet pris
    //            Product.Amount += Convert.ToInt32(AmountTbx.Text);

    //            //Nu er det konstateret, at det ikke er noget nyt produkt længere
    //            NewProduct = false;
    //        }

    //    }

    //    //Er det et nyt produkt?
    //    if (NewProduct)
    //    {
    //        //Hvis ja, så tilføj et produkt til listen
    //        Cart.Add(new ProductsInCart(
    //    Convert.ToInt32(IdTbx.Text),
    //    NameTbx.Text,
    //    Convert.ToDecimal(PriceTbx.Text),
    //    Convert.ToInt32(AmountTbx.Text)));
    //    }
    //}

    protected void CartGw_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
    //    //liste kaldet "Cart" med plads til produkter
    //    List<ProductsInCart> Cart = new List<ProductsInCart>();

    //    //Henter Sessionen kurv til kurv
    //    Cart = TakeCart(Cart);

    //    //lægger produktet i kurven
    //    switch (e.CommandName)
    //    {
    //        case "AddOne":
    //            foreach (ProductsInCart Product in Cart)
    //            {
    //                //Hvis produktet er fundet
    //                if (Product.Id == (int)CartGw.DataKeys[Convert.ToInt32(e.CommandArgument)].Value)
    //                {
    //                    //Så opdater antal og samlet pris
    //                    Product.Amount += 1;
    //                }
    //            }
    //            ;
    //            break;
    //        case "RemoveOne":
    //            foreach (ProductsInCart Product in Cart)
    //            {
    //                //Hvis produktet er fundet
    //                if (Product.Id == (int)CartGw.DataKeys[Convert.ToInt32(e.CommandArgument)].Value)
    //                {
    //                    //Så opdater antal og samlet pris
    //                    Product.Amount -= 1;
    //                }
    //            }
    //            ;
    //            break;
    //        case "RemoveAll":
    //            foreach (ProductsInCart Product in Cart)
    //            {
    //                //Hvis produktet er fundet
    //                if (Product.Id == (int)CartGw.DataKeys[Convert.ToInt32(e.CommandArgument)].Value)
    //                {
    //                    //Så opdater antal og samlet pris
    //                    Product.Amount = 0;
    //                }
    //            }
    //            ;
    //            break;
    //    }

    //    //Vis kurv
    //    ShowCart(Cart);
    }
}