<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarAnimales.aspx.cs" Inherits="CapaPresentacion.GestionarAnimales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
    <h2>Administración de Animales Rescatados</h2>
    <p>Añade y administra los perfiles de los animales que están bajo el cuidado de las asociaciones.</p>
    <hr />

    <div class="row">
        <div class="col-md-5">
            <h4>Nuevo / Editar Animal</h4>
            <div class="mb-3">
                <label class="form-label">Nombre Común</label>
                <asp:TextBox ID="txtNombreComun" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Especie Científica</label>
                <asp:TextBox ID="txtEspecieCientifica" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Asociación (Refugio)</label>
                <asp:DropDownList ID="ddlAsociacion" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Estatus Actual</label>
                <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Historia del Rescate</label>
                <asp:TextBox ID="txtHistoriaRescate" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Foto del Animal</label>
                <asp:FileUpload ID="fuFotoAnimal" runat="server" CssClass="form-control" />
            </div>
            
            <asp:Image ID="imgAnimalPreview" runat="server" CssClass="img-thumbnail mb-3" Width="150px" />

            <asp:HiddenField ID="hfAnimalID" runat="server" Value="0" />
            <asp:HiddenField ID="hfRutaFotoActual" runat="server" />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Animal" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" CausesValidation="false" />
        </div>
        <div class="col-md-7">
            <h4>Listado de Animales</h4>
            <asp:GridView ID="gvAnimales" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped" DataKeyNames="AnimalID" OnRowCommand="gvAnimales_RowCommand">
                <Columns>
                    <asp:BoundField DataField="AnimalID" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Foto">
                        <ItemTemplate>
                            <asp:Image ID="imgFoto" runat="server" ImageUrl='<%# "~/Imagenes/Animales/" + Eval("RutaFoto") %>' Width="60px" CssClass="img-thumbnail" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NombreComun" HeaderText="Nombre" />
                    <asp:BoundField DataField="EspecieCientifica" HeaderText="Especie" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-sm btn-info" CommandName="Editar" CommandArgument='<%# Eval("AnimalID") %>' />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger" CommandName="Eliminar" CommandArgument='<%# Eval("AnimalID") %>' OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este animal?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>
