using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    private int _id;
    private string _name;
    private string _description;
    private string _img;
    private float _price;
    private int _stock;

	public Product()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public string Img
    {
        get { return _img; }
        set { _img = value; }
    }

    public float Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public int Stock
    {
        get { return _stock; }
        set { _stock = value; }
    }
}