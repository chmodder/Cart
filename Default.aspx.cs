using System;
using System.Collections.Generic;
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
        //liste kaldet "Cart" med plads til produkter
        List<ProductsInCart> Cart = new List<ProductsInCart>();

        //Henter Sessionen kurv til kurv
        Cart = TakeCart(Cart);

        //lægger produktet i kurven
        AddToCart(Cart);

        //Vis kurv
        ShowCart(Cart);
    }

    private void ShowCart(List<ProductsInCart> Cart)
    {
        CartGw.DataSource = Cart;
        CartGw.DataBind();
    }

    private void AddToCart(List<ProductsInCart> Cart)
    {
        bool NewProduct = true;

        //undersøg om produktet er i kurven
        foreach (ProductsInCart Product in Cart)
        {
            //Hvis produktet er fundet
            if (Product.Id == Convert.ToInt32(IdTbx.Text))
            {
                //Så opdater antal og samlet pris
                Product.Amount += Convert.ToInt32(AmountTbx.Text);

                //Nu er det konstateret, at det ikke er noget nyt produkt længere
                NewProduct = false;
            }

        }

        //Er det et nyt produkt?
        if (NewProduct)
        {
            //Hvis ja, så tilføj et produkt til listen
            Cart.Add(new ProductsInCart(
        Convert.ToInt32(IdTbx.Text),
        NameTbx.Text,
        Convert.ToDecimal(PriceTbx.Text),
        Convert.ToInt32(AmountTbx.Text)));
        }
    }

    protected void CartGw_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        //liste kaldet "Cart" med plads til produkter
        List<ProductsInCart> Cart = new List<ProductsInCart>();

        //Henter Sessionen kurv til kurv
        Cart = TakeCart(Cart);


        //lægger produktet i kurven
        switch (e.CommandName)
        {
            case "AddOne":
                foreach (ProductsInCart Product in Cart)
                {
                    //Hvis produktet er fundet
                    if (Product.Id == (int)CartGw.DataKeys[Convert.ToInt32(e.CommandArgument)].Value)
                    {
                        //Så opdater antal og samlet pris
                        Product.Amount += 1;
                    }
                }
                ;
                break;
            case "RemoveOne":
                foreach (ProductsInCart Product in Cart)
                {
                    //Hvis produktet er fundet
                    if (Product.Id == (int)CartGw.DataKeys[Convert.ToInt32(e.CommandArgument)].Value)
                    {
                        //Så opdater antal og samlet pris
                        Product.Amount -= 1;
                    }
                }
                ;
                break;
            case "RemoveAll":
                foreach (ProductsInCart Product in Cart)
                {
                    //Hvis produktet er fundet
                    if (Product.Id == (int)CartGw.DataKeys[Convert.ToInt32(e.CommandArgument)].Value)
                    {
                        //Så opdater antal og samlet pris
                        Product.Amount = 0;
                    }
                }
                ;
                break;
        }
        //Vis kurv
        ShowCart(Cart);
    }

    private List<ProductsInCart> TakeCart(List<ProductsInCart> Cart)
    {
        //Hvis ikke vi har en session kaldet Cart
        if (Session["Cart"] == null)
        {
            //Så oprettes en Session Cart med værdien List Cart
            Session.Add("Cart", Cart);
        }

        //Sæt "List Cart" lig med "Session Cart"
        Cart = (List<ProductsInCart>)Session["Cart"];
        return Cart;
    }
}