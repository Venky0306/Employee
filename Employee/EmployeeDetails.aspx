<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Employee.EmployeeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Search" runat="server" Text="Enter employee id"></asp:Label><asp:TextBox ID="tSearch" runat="server" ></asp:TextBox> <br />
    <asp:Button ID="Filter" runat="server" Text="Filter" OnClick="Filter_Click" />
    <asp:GridView ID="dFilter" runat="server"></asp:GridView>
</asp:Content>
