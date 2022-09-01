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
            <asp:ImageButton CssClass="btn1" ID="addNewAssign" runat="server" PostBackUrl="~/addAssign.aspx" ToolTip="Add New Assign" ImageUrl="~/images/icons8-add-100.png" />

            <%--<asp:Button CssClass="btn1" ID="addNewAssign" runat="server" Text="Add New Assign" PostBackUrl="~/addAssign.aspx"  />--%>
        </div>

        <br />
      
        <formview>
            <div class="table">
                <asp:GridView CssClass="gr1" ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="PartyName" HeaderText="Party Name" SortExpression="Party_Name" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="Product_Name" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:ImageButton CssClass="head" ID="ImageButton1" runat="server" ImageUrl="~/images/icons8-edit.svg" OnClick="ImageButton1_Click" ToolTip="Edit" />
                                <asp:ImageButton CssClass="del" ID="ImageButton2" runat="server" ImageUrl="~/images/icons8-trash.svg" OnClick="ImageButton2_Click" ToolTip="Delete" />
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
