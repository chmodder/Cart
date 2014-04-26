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
        Cart C1Cart = new Cart();

        ////Henter Sessionen kurv til kurv
        C1Cart.TakeCart();

        ////lægger produktet i kurven. Kan evt. videreudbygges til at hente parametre fra DB
        C1Cart.AddToCart(IdTbx.Text, NameTbx.Text, PriceTbx.Text, AmountTbx.Text);

        ////Vis kurv. Skal bruge et navn fra et Gridview, som kurven vises i
        C1Cart.ShowCart(CartGw);
    }

    protected void CartGw_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        //liste kaldet "Cart" med plads til produkter
        Cart C1Cart = new Cart();

        ////Henter Sessionen kurv til kurv
        C1Cart.TakeCart();

        //Sætter Datakey værdien i en variabel
        var DataKey = CartGw.DataKeys[Convert.ToInt32(e.CommandArgument)];

        //lægger produktet i kurven, fjerner produktet eller alle produkterne i rækken (og ikke alle produkterne i kurven)
        switch (e.CommandName)
        {
            case "AddOne":
                C1Cart.AddOne(DataKey);
                break;
            case "RemoveOne":
                C1Cart.RemoveOne(DataKey)
                ;
                break;
            case "RemoveAll":
                C1Cart.RemoveAll(DataKey)
                ;
                break;
        }

        //Vis kurv
        C1Cart.ShowCart(CartGw);
    }
}