<%@ Page Title="" Language="C#" MasterPageFile="~/module.Master" AutoEventWireup="true" CodeBehind="assignParty.aspx.cs" Inherits="InvoiceApplication.assignParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/assign/assignParty.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="assign">
        <div class="assignHeading">
            <asp:Label ID="Label1" runat="server" Text="Assign Party List"></asp:Label>
        </div>

        <div class="btnAssign">
            <asp:Button CssClass="btn1" ID="addNewAssign" runat="server" Text="Add New Assign" PostBackUrl="~/addAssign.aspx"  />
        </div>

        <br />
      
        <formview>
            <div class="table">
                <asp:GridView CssClass="gr1" ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="PartyName" HeaderText="Party Name" SortExpression="Party_Name" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="Product_Name" />
                        <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Action" ShowHeader="True" Text="Edit" ControlStyle-CssClass="edit" />
                        <asp:ButtonField ButtonType="Button" CommandName="Del" Text="Delete" ControlStyle-CssClass="del" />
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
            </div>
        </formview>
    </div>
</asp:Content>
