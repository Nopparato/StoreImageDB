<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPicture.aspx.cs" Inherits="StoreImageDB.ListPicture" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Image Id:
<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
    Height="22px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
    Width="150px">
</asp:DropDownList>
<br />
<br />
<asp:Image ID="Image1" runat="server" />
</asp:Content>
