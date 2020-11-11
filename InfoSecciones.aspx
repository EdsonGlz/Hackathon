<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoSecciones.aspx.cs" Inherits="PlantAppSE.InfoSecciones" %>
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
    <div>
        <h2 id="titulo" runat="server">

        </h2>
    </div>

    <div>
        <asp:GridView HorizontalAlign="Center" ID="GVPlantasxSeccion" OnPageIndexChanging="GVPlantasxSeccion_PageIndexChanging" PageSize= "5" allowpaging="true" style="align-content:center; align-items:center;" CssClass="mGrid" runat="server" AutoGenerateColumns = "false">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="idPlanta" DataNavigateUrlFormatString="./default.aspx?id={0}" DataTextField="idPlanta" HeaderText="idPlanta" />
                <asp:BoundField DataField="Nombre" HeaderText ="Nombre Planta"  />
                <asp:BoundField DataField="NombreSector" HeaderText ="Sector"  />
                <asp:BoundField DataField="AnioPlatancion" HeaderText ="Año de Plantacion"  />
                <asp:ImageField HeaderText="Imagen Arbol" DataImageUrlField="ImagenUrl" ItemStyle-Width="60px" ControlStyle-Width="150" ControlStyle-Height = "100" NullDisplayText="Imagen no disponible"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
