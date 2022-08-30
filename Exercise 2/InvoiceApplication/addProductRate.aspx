<%@ Page Title="" Language="C#" MasterPageFile="~/module.Master" AutoEventWireup="true" CodeBehind="addProductRate.aspx.cs" Inherits="InvoiceApplication.addProductRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/addProductRate/addProductRate.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="addPR">
        <div class="addPRHeading">
            <asp:Label ID="Label1" runat="server" Text="Product Rate Add"></asp:Label>
        </div>

        <table class="addPRBody">
            <tr>
                <td class="name">Product Name : </td>
                <td>
                    <asp:DropDownList CssClass="ddl" ID="ddl1" runat="server">
                        <asp:ListItem Selected="True" Text="Select Product"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="name">Product Rate : </td>
                <td>
                    <asp:TextBox CssClass="tb" ID="productRate" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="vali" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="productRate">*Field cannot be Empty</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="name">Date Of Rate : </td>
                <td>                   
                    <asp:TextBox class="tb1" ID="dttb" runat="server" ></asp:TextBox>          <asp:Button class="tb2" ID="Button1" runat="server" Text="Select Date" OnClick="Button1_Click" />
                    <br /><br />
                    
                    <asp:Calendar ID="dt" runat="server" Visible="False" OnSelectionChanged="dt_SelectionChanged" Height="16px" Width="300px" CellPadding="0" >                      
                        <DayStyle ForeColor="#6699FF" />
                        <TitleStyle BackColor="#99CCFF" Font-Bold="true" />
                        <TodayDayStyle ForeColor="black" BackColor="#99CCFF" />
                    </asp:Calendar>
                </td>
            </tr>
        </table>

        <div class="success">
            <asp:Label ID="text" runat="server" ></asp:Label>
        </div>

        <div class="addPRBtn">
            <asp:Button CssClass="savePRBtn" ID="save" runat="server" Text="Save" OnClick="save_Click" />
            <asp:Button CssClass="savePRBtn" ID="update" runat="server" Text="Update" OnClick="update_Click" visible=false/>
            <asp:Button CssClass="cancelPRBtn" ID="cancel" runat="server" Text="Cancel" OnClick="cancel_Click" CausesValidation="false"/>
        </div>       
    </div>
</asp:Content>
