<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Employee.AddEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Load" runat="server" Text="Upload" OnClick ="Upload" />
</asp:Content>
