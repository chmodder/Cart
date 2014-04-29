<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <%--Produkt formular--%>

            <asp:Label ID="IdLbl" runat="server" Text="Id"></asp:Label><asp:TextBox ID="IdTbx" runat="server"></asp:TextBox><br />
            <asp:Label ID="NameLbl" runat="server" Text="Navn"></asp:Label><asp:TextBox ID="NameTbx" runat="server"></asp:TextBox><br />
            <asp:Label ID="PriceLbl" runat="server" Text="Pris"></asp:Label><asp:TextBox ID="PriceTbx" runat="server"></asp:TextBox><br />
            <asp:Label ID="AmountLbl" runat="server" Text="Antal"></asp:Label><asp:TextBox ID="AmountTbx" runat="server"></asp:TextBox><br />
            <asp:Button ID="AddToCartBtn" runat="server" Text="Put i kurv" OnClick="AddToCartBtn_Click" />

            <hr />

            <%--Produkter--%>
            
            <asp:GridView ID="ProductsGv" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDbProducts"  DataKeyNames="Id,Name,Price,Stock" OnRowCommand="ProductsGv_OnRowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Varenavn" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Beskrivelse" SortExpression="Description"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Pris" SortExpression="Price"></asp:BoundField>
                    <asp:TemplateField SortExpression="Img">
                        <ItemTemplate>
                            <asp:Image ID="ProductImg" ImageUrl='<%#"ProductImg/" + Eval("Img") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Stock" HeaderText="Lagerantal" SortExpression="Stock"></asp:BoundField>
                    <asp:TemplateField HeaderText="Antal der skal i kurven">
                        <ItemTemplate>
                            <asp:TextBox ID="AmountToCartTbx" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField Text="Læg i kurv" ButtonType="Button" CommandName="AddToCart"></asp:ButtonField>
                </Columns>
            </asp:GridView>


            <%--Kurv--%>



            <asp:ObjectDataSource runat="server" ID="ObjectDbProducts" SelectMethod="GetAllProducts" TypeName="ProductDataAccessLayer"></asp:ObjectDataSource>

            <asp:GridView ID="CartGw" runat="server" DataKeyNames="id" OnRowCommand="CartGw_OnRowCommand">
                <Columns>
                    <asp:ButtonField CommandName="AddOne" Text="+" ButtonType="Button"></asp:ButtonField>
                    <asp:ButtonField CommandName="RemoveOne" Text="-" ButtonType="Button"></asp:ButtonField>
                    <asp:ButtonField CommandName="RemoveAll" Text="Fjern" ButtonType="Button"></asp:ButtonField>
                </Columns>
            </asp:GridView>

            <asp:Button ID="ClearCartBtn" runat="server" Text="Tøm kurv" OnClick="ClearCartBtn_Click" />

        </div>
    </form>
</body>
</html>
