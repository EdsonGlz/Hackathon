<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Terrenos.aspx.cs" Inherits="PlantAppSE.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="./Terrenos" style="color:green; font-family:'Brush Script MT'; font-size:large;" >PlantApp</a>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="./Default?id=15">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Link</a>
      </li>
        <li style=" padding-left:800px;">
            <asp:HyperLink ID="HyperLink1" runat="server" href ="/Login/Login.aspx">Usuario </asp:HyperLink>  <asp:Label ID="lbl_User" runat="server" Text="Label">| Ninguno </asp:Label>
        </li>
    </ul>
  </div>
</nav>

            <div runat="server" id="noTerrenos" visible="false">
                <h1 style="text-align:center; padding-top:20%">
                    No hay terrenos para mostrar :(
                </h1>
                <a id="iniciaSesion" href="./Login/Login.aspx">
                    <h1 style="text-align:center;">
                    Porfavor inicia sesion dando click aqui
                    </h1>
                </a>
            </div>

    <div class="card" style="width: 35rem;" runat="server" id="Info">
  <img class="card-img-top" src="Imagenes/Plantio.jpg" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">Terreno #1</h5>
    <p class="card-text">Este es el terreno de Edson, aquí hay plantados alrededor de 1600 Arboles de aguacate.</p>
    <a style="" href="./Secciones.aspx" class="btn btn-primary">Ver Terreno</a>
  </div>
</div>
</asp:Content>
