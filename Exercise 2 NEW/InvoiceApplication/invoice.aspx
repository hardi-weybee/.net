<%@ Page Title="" Language="C#" MasterPageFile="~/module.Master" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="InvoiceApplication.invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/invoice/addInvoice.css" rel="stylesheet" />
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="invoice">
        <div class="invoiceHeading">
            <asp:Label ID="Label1" runat="server" Text="Invoice Add"></asp:Label>
        </div>
    

    
        <table class="t1">
            <tr>
                <td class="rows">Party Name :</td>
                <td>
                    <asp:DropDownList CssClass="ddl" ID="DropDownListParty" runat="server" OnSelectedIndexChanged="DropDownListParty_SelectedIndexChanged" AutoPostBack="true" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="rows">Product Name :</td>
                <td>
                    <asp:DropDownList CssClass="ddl" ID="DropDownListProduct" runat="server" OnSelectedIndexChanged="DropDownListProduct_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="rows">Current Rate :</td>
                <td>
                    <asp:TextBox CssClass="tb" ID="RateTB" runat="server" Enabled="False"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="rows">Quantity :</td>
                <td>
                    <asp:TextBox CssClass="tb" ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="vali" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox4">*Field cannot be Empty</asp:RequiredFieldValidator>
                
                </td>
            </tr>        
        </table>

        <div class="addBtn">
            <asp:Button CssClass="addInvoice" ID="AddInvoiceBtn" runat="server" Text="Add To Invoice" OnClick="AddInvoiceBtn_Click" />
        </div>

        <br /><br />

        <asp:GridView CssClass="tab" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="partyName" HeaderText="Party" SortExpression="partyID" />
                <asp:BoundField DataField="productName" HeaderText="Product" SortExpression="productID" />
                <asp:BoundField DataField="RateOfProduct" HeaderText="Rate Of Product" SortExpression="RateOfProduct" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#AACFDE" Font-Bold="True" ForeColor="black" Height="35px" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" Height="35px" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
       
        <br /><br />

        <div class="total1">
            <h2 ID="GrandTotal" runat="server">Grand Total: </h2>   <asp:Label ID="answer" runat="server" ></asp:Label>
        </div>

        <div class="total1">
            <asp:Button CssClass="closeInvoice" ID="CloseInvoiceBtn" runat="server" Text="Close Invoice" OnClick="CloseInvoiceBtn_Click" CausesValidation="false"/>
        </div>
    </div>
    
</asp:Content>
