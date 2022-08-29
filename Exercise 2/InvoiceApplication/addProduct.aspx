<%@ Page Title="" Language="C#" MasterPageFile="~/module.Master" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="InvoiceApplication.addProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/addProduct/addProduct.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="addProduct">
        <div class="addProductHeading">
            <asp:Label ID="Label1" runat="server" Text="Add Product"></asp:Label>
        </div>

        <table class="addProductBody">
            <tr>
                <td class="name">Product Name : </td>
                <td>
                    <asp:TextBox CssClass="tb" ID="productName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="vali" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="productName">*Field Cannot be Empty</asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>

        <div class="success">
            <asp:Label ID="text" runat="server" ></asp:Label>
        </div>

        <div class="addProductBtn">
            <asp:Button CssClass="saveProductBtn" ID="save" runat="server" Text="Save" OnClick="save_Click" />
            <asp:Button CssClass="saveProductBtn" ID="update" runat="server" Text="Update" OnClick="update_Click" visible=false/>
            <asp:Button CssClass="cancelProductBtn" ID="cancel" runat="server" Text="Cancel" OnClick="cancel_Click" CausesValidation="false"/>
        </div>

        
    </div>
</asp:Content>
