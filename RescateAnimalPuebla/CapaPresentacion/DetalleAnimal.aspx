<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleAnimal.aspx.cs" Inherits="CapaPresentacion.DetalleAnimal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
    <div class="row">
        <div class="col-md-5">
            <asp:Image ID="imgAnimal" runat="server" CssClass="img-fluid rounded shadow" />
        </div>

        <div class="col-md-7">
            <h1 class="display-5"><asp:Literal ID="ltlNombreAnimal" runat="server"></asp:Literal></h1>
            <p class="lead text-muted"><asp:Literal ID="ltlEspecie" runat="server"></asp:Literal></p>
            
            <ul class="list-group list-group-flush mb-4">
                <li class="list-group-item"><strong>Refugio:</strong> <asp:Literal ID="ltlRefugio" runat="server"></asp:Literal></li>
                <li class="list-group-item"><strong>Estatus actual:</strong> <asp:Literal ID="ltlEstatus" runat="server"></asp:Literal></li>
            </ul>

            <h4>Historia del Rescate</h4>
            <p><asp:Literal ID="ltlHistoria" runat="server"></asp:Literal></p>

            <div class="d-grid gap-2 mt-4">
                <asp:HyperLink ID="lnkVolver" runat="server" NavigateUrl="~/Default.aspx" CssClass="btn btn-secondary">
                    &laquo; Volver al Catálogo
                </asp:HyperLink>
            </div>
        </div>
    </div>
</div>
</asp:Content>
