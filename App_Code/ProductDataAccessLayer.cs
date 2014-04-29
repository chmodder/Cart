using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;


/// <summary>
/// Summary description for ProductDataAccessLayer
/// </summary>
public class ProductDataAccessLayer
{
    public ProductDataAccessLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<Product> GetAllProducts()
    {
        List<Product> ListProducts = new List<Product>();

        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand();


        Cmd.CommandText = "Select * From Products";

        Cmd.Connection = Conn;

        Conn.Open();

        SqlDataReader Reader = Cmd.ExecuteReader();

        while (Reader.Read())
        {
            Product TempProduct = new Product();

            TempProduct.Id = Convert.ToInt32(Reader["Id"]);
            TempProduct.Name = Reader["Name"].ToString();
            TempProduct.Description = Reader["Description"].ToString();
            TempProduct.Img = Reader["Img"].ToString();
            TempProduct.Price = Convert.ToSingle(Reader["Price"]);
            //TempProduct.Price = (float)float.Parse(Reader["Price"]);
            TempProduct.Stock = Convert.ToInt32(Reader["Stock"]);

            ListProducts.Add(TempProduct);
        }
        Conn.Close();

        return ListProducts;
    }
}