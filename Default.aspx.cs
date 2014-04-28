using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
    protected void ClearCartBtn_Click(object sender, EventArgs e)
    {
        //liste kaldet "Cart" med plads til produkter
        Cart C1Cart = new Cart();

        ////Henter Sessionen kurv til kurv
        C1Cart.TakeCart();

        //Tømmer kurven
        C1Cart.ClearCart();

        //Vis kurv
        C1Cart.ShowCart(CartGw);
    }

    protected void ProductsGv_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(ProductsGv.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Id"].ToString());
        string Name = ProductsGv.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Name"].ToString();
        float Price = float.Parse(ProductsGv.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Price"].ToString());
        int Stock = Convert.ToInt32(ProductsGv.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Stock"].ToString());

        #region Find indholdet Fra Tekstbox I Gridview og gem det i en variabel af typen int
        //Finder rækkenummeret der er valgt via CommanArgument "e" og gemmer den i en variabel som en integer
        //Dataen, der gemmes i varablen er nummeret i arrayet, som starter på 0, og er IKKE Id'et som tilhører rækken
        int rowIndex = Convert.ToInt32(e.CommandArgument);

        //gem det i en variabel af typen TextBox
        TextBox AmountToCartTbx = (TextBox)ProductsGv.Rows[rowIndex].FindControl("AmountToCartTbx");
        //var hej = ProductsGv.DataKeys[Convert.ToInt32(e.CommandArgument)].Values.ToString();

        //Konverterer det til typen int
        int AmountToCart = Convert.ToInt32(AmountToCartTbx.Text);
        #endregion

        #region Testkode
        //Testkode. Skal slettes når metoden virker.
        Response.Write("RowIndex: " + rowIndex + "<hr />");
        //Response.Write(Id + "; " + Name + "; Pris: " + Price + "; Lagerbeholdning: " + Stock + ".<br />Tilføj antal til kurv: <b>" + AmountToCart + "</b");
        #endregion


        ////liste kaldet "Cart" med plads til produkter
        Cart C1Cart = new Cart();

        ////Henter Sessionen kurv til kurv
        C1Cart.TakeCart();

        
        if (Stock >= AmountToCart)
        {
            ////lægger produktet i kurven. Kan evt. videreudbygges til at hente parametre fra DB
            C1Cart.AddToCart(Id, Name, Price, AmountToCart);
            Response.Write(Id + "; " + Name + "; Pris: " + Price + "; Lagerbeholdning: " + Stock + ".<br />Antal tilføjet til kurv: <b>" + AmountToCart + "</b");
        }
        else
        {
            Response.Write("Varenummer: " + Id + ", " + Name + ", som koster " + Price + " <b>Er ikke på lager i det ønskede antal<b/><hr />");
        }

        ////Vis kurv. Skal bruge et navn fra et Gridview, som kurven vises i
        C1Cart.ShowCart(CartGw);

    }
}