using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart
{
    private List<ProductsInCart> _cartList;

    #region PROPERTIES

    public List<ProductsInCart> CartList
    {
        get { return _cartList; }
        set { _cartList = value; }
    }

    #endregion

    public Cart()
	{
        //liste kaldet "Cart" med plads til produkter
        List<ProductsInCart> CartList = new List<ProductsInCart>();
        this._cartList = CartList;
	}

    /// <summary>
    /// Take Cart (not finished!)
    /// </summary>
    /// <param name="CartList"></param>
    public void TakeCart()
    {
        //Hvis ikke vi har en session kaldet Cart
        if (HttpContext.Current.Session["Cart"] == null)
        {
            //Så oprettes en Session Cart med værdien List Cart
        HttpContext.Current.Session.Add("Cart", this.CartList);
        }

        //Sæt "List Cart" lig med "Session Cart"
        this.CartList = (List<ProductsInCart>)HttpContext.Current.Session["Cart"];
        
    }

    //unsure about syntax for now, or if it is possible to add default parameters this way
//    public void AddToCart() : this(0,"",0,0);
//{
    
//}

    /// <summary>
    /// Adds item to Cart (not finished)
    /// </summary>
    public void AddToCart(object Id, string ProductName, object ProductPrice, object Amount)
    {
        bool NewProduct = true;

        //undersøg om produktet er i kurven
        foreach (ProductsInCart Product in CartList)
        {
            //Hvis produktet er fundet
            if (Product.Id == Convert.ToInt32(Id))
            {
                //Så opdater antal og samlet pris
                Product.Amount += Convert.ToInt32(Amount);

                //Nu er det konstateret, at det ikke er noget nyt produkt længere
                NewProduct = false;
            }

        }

        //Er det et nyt produkt?
        if (NewProduct)
        {
            //Hvis ja, så tilføj et produkt til listen
            this.CartList.Add(new ProductsInCart(
        Convert.ToInt32(Id),
        ProductName,
        Convert.ToDecimal(ProductPrice),
        Convert.ToInt32(Amount)));
        }
    }

    /// <summary>
    /// Shows cart in Gridview
    /// Takes 1 parameter of type GridView and databinds it to the CartList
    /// </summary>
    /// <param name="View"></param>
    public void ShowCart(GridView View)
    {
        View.DataSource = this.CartList;
        View.DataBind();
    }


}