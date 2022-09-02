<%@ Page Title="" Language="C#" MasterPageFile="~/module.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="InvoiceApplication.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/product/product.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product">
        <div class="productHeading">
            <asp:Label ID="Label1" runat="server" Text="Product List"></asp:Label>
        </div>

        <div class="btnProduct">
            <asp:Label CssClass="err" ID="error" runat="server" ></asp:Label>
            <asp:ImageButton CssClass="btn1" ID="addNewProduct" runat="server" PostBackUrl="~/addProduct.aspx" ToolTip="Add New Product" ImageUrl="~/images/icons8-add-100.png" />
        </div>

        <br />

        <formview>
            <div class="table">
                <asp:GridView CssClass="gr1" ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="Product_Name" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:ImageButton CssClass="head" ID="EditBtn" runat="server" ImageUrl="~/images/icons8-edit.svg" OnClick="EditBtn_Click" ToolTip="Edit Product Name" />
                                <asp:ImageButton CssClass="del" ID="DeleteBtn" runat="server" ImageUrl="~/images/icons8-trash.svg" OnClick="DeleteBtn_Click" ToolTip="Delete Product Name" />
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#9fa8da" Font-Bold="True" ForeColor="black" Height="45px" Font-Size="20px" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" Height="45px" Font-Size="18px" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>               
            </div>
        </formview>
    </div>
</asp:Content>
