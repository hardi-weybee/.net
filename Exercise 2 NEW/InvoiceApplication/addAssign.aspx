<%@ Page Title="" Language="C#" MasterPageFile="~/module.Master" AutoEventWireup="true" CodeBehind="addAssign.aspx.cs" Inherits="InvoiceApplication.addAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/addAssign/addAssign.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="addAssign">
        <div class="addAssignHeading">
            <asp:Label ID="heading" runat="server" Text="Assign Party Add"></asp:Label>
        </div>

        <table class="addAssignBody">
            <tr>
                <td class="name">Party Name : </td>
                <td>
                    <asp:DropDownList CssClass="ddl" ID="DropDownListParty" runat="server">
                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="name">Product Name : </td>
                <td>
                    <asp:DropDownList CssClass="ddl" ID="DropDownListProduct" runat="server">
                        <asp:ListItem Selected="True" Text="Select Product"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

        <div class="success">
            <asp:Label ID="textMsg" runat="server" ></asp:Label>
        </div>
        
        <div class="addAssignBtn">
            <asp:Button CssClass="saveAssignBtn" ID="save" runat="server" Text="Save" OnClick="save_Click"  />
            <asp:Button CssClass="saveAssignBtn" ID="update" runat="server" Text="Update" OnClick="update_Click" visible=false/>
            <asp:Button CssClass="cancelAssignBtn" ID="cancel" runat="server" Text="Cancel" OnClick="cancel_Click" />
        </div>

        
    </div>
</asp:Content>
