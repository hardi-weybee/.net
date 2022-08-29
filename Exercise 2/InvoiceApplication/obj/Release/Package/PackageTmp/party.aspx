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
            <asp:Button CssClass="btn1" ID="addNewParty" runat="server" Text="Add New Party"  PostBackUrl="~/addParty.aspx" />
        </div>
        
        <br />

        <formview>
            <div class="table">
                <asp:GridView CssClass="gr1" ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." CellPadding="4" GridLines="None" ForeColor="#333333" OnRowCommand="GridView1_RowCommand" HorizontalAlign="Left" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="PartyName" HeaderText="Party Name" SortExpression="Party_Name" />
                        <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Action" ShowHeader="True" Text="Edit" ControlStyle-CssClass="edit"/>
                        <asp:ButtonField ButtonType="Button" CommandName="Del" Text="Delete" ControlStyle-CssClass="del"/>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataRowStyle Font-Size="X-Large" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#AACFDE" Font-Bold="True" ForeColor="black" Height="35px" />          
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="left" />
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
