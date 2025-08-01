<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarEstatus.aspx.cs" Inherits="CapaPresentacion.GestionarEstatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
    <h2>Administración de Estatus de Animales</h2>
    <p>Crea, edita o elimina los estatus que puede tener un animal en el sistema.</p>
    <hr />

    <div class="row">
        <div class="col-md-4">
            <h4>Nuevo / Editar Estatus</h4>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre del Estatus</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            
            <asp:HiddenField ID="hfEstatusID" runat="server" Value="0" />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Estatus" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" CausesValidation="false" />
        </div>
        <div class="col-md-8">
            <h4>Listado de Estatus</h4>
            <asp:GridView ID="gvEstatus" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped" OnRowCommand="gvEstatus_RowCommand">
                <Columns>
                    <asp:BoundField DataField="EstatusID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-sm btn-info" CommandName="Editar" CommandArgument='<%# Eval("EstatusID") %>' />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger" CommandName="Eliminar" CommandArgument='<%# Eval("EstatusID") %>' OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este estatus?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>
