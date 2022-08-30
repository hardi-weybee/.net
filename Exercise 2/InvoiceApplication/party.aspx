<%@ Page Title="" Language="C#" MasterPageFile="~/module.Master" AutoEventWireup="true" CodeBehind="party.aspx.cs" Inherits="InvoiceApplication.party" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/party/party.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="party">
        <div class="partyHeading">
            <asp:Label ID="Label1" runat="server" Text="Party List"></asp:Label>
        </div>

        <div class="btnParty">
            <asp:Label CssClass="err" ID="error" runat="server" ></asp:Label>

            <asp:ImageButton CssClass="btn1" ID="addNewParty" runat="server" PostBackUrl="~/addParty.aspx" ImageUrl="~/images/icons8-add-100.png" ToolTip="Add New Party" />

            <%--<asp:Button CssClass="btn1" ID="addNewParty" runat="server" Text="Add New Party"  PostBackUrl="~/addParty.aspx"  />--%>
        </div>
        
        <br />


        <formview>
            <div class="table">
                <asp:GridView CssClass="gr1" ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" GridLines="None" ForeColor="#333333" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="PartyName" HeaderText="Party Name" SortExpression="Party_Name" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:ImageButton CssClass="head" ID="ImageButton1" runat="server" ImageUrl="~/images/icons8-edit.svg" OnClick="ImageButton1_Click" />
                                <asp:ImageButton CssClass="del" ID="ImageButton2" runat="server" ImageUrl="~/images/icons8-trash.svg" OnClick="ImageButton2_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataRowStyle Font-Size="X-Large" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#9fa8da" Font-Bold="True" ForeColor="black" Height="45px" Font-Size="20px" HorizontalAlign="left" />          
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="left" />
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
