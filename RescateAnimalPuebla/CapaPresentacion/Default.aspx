<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapaPresentacion._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<main>
    <div class="container mt-4">
        <div class="text-center mb-5">
            <h1 class="display-4">Encuentra a tu Nuevo Mejor Amigo</h1>
            <p class="lead">Explora los perfiles de los animales que esperan un hogar en los refugios de Puebla.</p>
        </div>

        <asp:Repeater ID="repeaterAnimales" runat="server">
            <HeaderTemplate>
                <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 shadow-sm">
                        <asp:Image runat="server" ImageUrl='<%# "~/Imagenes/Animales/" + Eval("RutaFoto") %>' CssClass="card-img-top" style="height: 250px; object-fit: cover;" />
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("NombreComun") %></h5>
                            <p class="card-text">
                                <span class="badge bg-success"><%# Eval("Estatus") %></span> <br />
                                <strong>Refugio:</strong> <%# Eval("NombreAsociacion") %><br />
                            </p>
                        </div>
                        <div class="card-footer bg-transparent border-0 pb-3">
                             <asp:HyperLink runat="server" NavigateUrl='<%# "DetalleAnimal.aspx?id=" + Eval("AnimalID") %>' Text="Ver Historia Completa" CssClass="btn btn-primary w-100" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
 </main>
</asp:Content>
