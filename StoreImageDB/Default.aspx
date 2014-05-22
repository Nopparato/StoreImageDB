<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="StoreImageDB._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" Width="346px" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Upload &amp; Save Picture" />
&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Upload &amp; Display Only" />
    <br />
    <br />
    <asp:Image ID="Image1" runat="server" />
    <br />
    <br />
    <br />
</asp:Content>
