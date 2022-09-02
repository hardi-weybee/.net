<%@ Page Title="" Language="C#" MasterPageFile="~/module.Master" AutoEventWireup="true" CodeBehind="addParty.aspx.cs" Inherits="InvoiceApplication.addParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/addParty/addparty.css" rel="stylesheet" />   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="addParty">
        <div class="addPartyHeading">
            <asp:Label ID="heading" runat="server" Text="Add Party"></asp:Label>
        </div>

        <table class="addPartyBody">
            <tr>
                <td class="name">Party Name : </td>
                <td>
                    <asp:TextBox CssClass="tb" ID="partyName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="vali" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="partyName">*Field Cannot be Empty</asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>

        <div class="success">
            <asp:Label ID="textMsg" runat="server" ></asp:Label>
        </div>

        <div class="addPartyBtn">
            <asp:Button CssClass="savePartyBtn" ID="save" runat="server" Text="Save" OnClick="save_Click" />
            <asp:Button CssClass="savePartyBtn" ID="update" runat="server" Text="Update" OnClick="update_Click" visible=false/>
            <asp:Button CssClass="cancelPartyBtn" ID="cancel" runat="server" Text="Cancel" OnClick="cancel_Click" CausesValidation="false"/>
        </div>     
    </div>
</asp:Content>