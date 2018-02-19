<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjemploDataSet.aspx.cs" Inherits="PresentacionWebForms.EjemploDataSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Nick" HeaderText="Nick" SortExpression="Nick" />
                    <asp:BoundField DataField="Contra" HeaderText="Contra" SortExpression="Contra" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="TiendaVirtual.AccesoDatos.TiendaVirtualDataSetTableAdapters.usuariosTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Nick" Type="String" />
                    <asp:Parameter Name="Contra" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nick" Type="String" />
                    <asp:Parameter Name="Contra" Type="String" />
                    <asp:Parameter Name="Original_Id" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="Id" DataSourceID="ObjectDataSource1">
            <EditItemTemplate>
                Id:
                <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                <br />
                Nick:
                <asp:TextBox ID="NickTextBox" runat="server" Text='<%# Bind("Nick") %>' />
                <br />
                Contra:
                <asp:TextBox ID="ContraTextBox" runat="server" Text='<%# Bind("Contra") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Nick:
                <asp:TextBox ID="NickTextBox" runat="server" Text='<%# Bind("Nick") %>' />
                <br />
                Contra:
                <asp:TextBox ID="ContraTextBox" runat="server" Text='<%# Bind("Contra") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insertar" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
            </InsertItemTemplate>
            <ItemTemplate>
                Id:
                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                <br />
                Nick:
                <asp:Label ID="NickLabel" runat="server" Text='<%# Bind("Nick") %>' />
                <br />
                Contra:
                <asp:Label ID="ContraLabel" runat="server" Text='<%# Bind("Contra") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nuevo" />
            </ItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
