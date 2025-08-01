<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarAsociaciones.aspx.cs" Inherits="CapaPresentacion.GestionarAsociaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
    <h2>Administración de Asociaciones</h2>
    <p>Registra las asociaciones, refugios y centros de rescate que forman parte de la red.</p>
    <hr />

    <div class="row">
        <div class="col-md-5">
            <h4>Nueva / Editar Asociación</h4>
            <div class="mb-3">
                <label class="form-label">Nombre de la Asociación</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Dirección</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Tipo (Ej: Refugio, Santuario)</label>
                <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="mb-3">
                <label class="form-label">Misión</label>
                <asp:TextBox ID="txtMision" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Logo</label>
                <asp:FileUpload ID="fuLogo" runat="server" CssClass="form-control" />
            </div>
            
            <asp:Image ID="imgLogoPreview" runat="server" CssClass="img-thumbnail mb-3" Width="150px" />

            <asp:HiddenField ID="hfAsociacionID" runat="server" Value="0" />
            <asp:HiddenField ID="hfRutaLogoActual" runat="server" />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Asociación" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" CausesValidation="false" />
        </div>
        <div class="col-md-7">
            <h4>Listado de Asociaciones</h4>
            <asp:GridView ID="gvAsociaciones" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped" DataKeyNames="AsociacionID" OnRowCommand="gvAsociaciones_RowCommand">
                <Columns>
                    <asp:BoundField DataField="AsociacionID" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Logo">
                        <ItemTemplate>
                            <asp:Image ID="imgLogo" runat="server" ImageUrl='<%# "~/Imagenes/Logos/" + Eval("RutaLogo") %>' Width="50px" CssClass="img-thumbnail" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-sm btn-info" CommandName="Editar" CommandArgument='<%# Eval("AsociacionID") %>' />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger" CommandName="Eliminar" CommandArgument='<%# Eval("AsociacionID") %>' OnClientClick="return confirm('¿Estás seguro de que deseas eliminar esta asociación?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>
