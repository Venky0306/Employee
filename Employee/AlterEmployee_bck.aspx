<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterEmployee_bck.aspx.cs" Inherits="Employee.AlterEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div id="dvGrid" style="padding: 10px; width: 450px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound"
                        DataKeyNames="EmployeeId" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPaging"
                        OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                        Width="450">
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Name" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="EmployeeName" runat="server" Text='<%# Eval("[Employee Name]") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="EmployeeName" runat="server" Text='<%# Eval("[Employee Name]") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="Department" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="Department" runat="server" Text='<%# Eval("Department") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="Email" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="Email" runat="server" Text='<%# Eval("Email") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone Number" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="PhoneNumber" runat="server" Text='<%# Eval("Phone Number") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="PhoneNumber" runat="server" Text='<%# Eval("Phone Number") %>' Width="140"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
