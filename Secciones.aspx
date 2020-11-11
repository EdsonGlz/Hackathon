<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Secciones.aspx.cs" Inherits="PlantAppSE.Secciones" %>
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
        <li style=" padding-left:800px;">
            <asp:HyperLink ID="HyperLink1" runat="server" href ="/Login/Login.aspx">Usuario </asp:HyperLink>  <asp:Label ID="lbl_User" runat="server" Text="Label">| Ninguno </asp:Label>
        </li>
    </ul>
  </div>
</nav>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <div class="card" style="width: 35rem;" runat="server" id="Info">
                  <img class="card-img-top" src="Imagenes/Plantio.jpg" alt="Card image cap">
                  <div class="card-body">
                    <h5 class="card-title">Sección #1</h5>
                    <p class="card-text">Esta es la primer sección del terreno de Edson, aquí hay plantados alrededor de 400 Arboles de aguacate.</p>
                    <a style="" href="./InfoSecciones.aspx?seccion=1" class="btn btn-primary">Ver Sección</a>
                  </div>
                </div>
            </asp:TableCell>
            <asp:TableCell>
                <div class="card" style="width: 35rem;" runat="server" id="Div1">
                  <img class="card-img-top" src="Imagenes/Plantio.jpg" alt="Card image cap">
                  <div class="card-body">
                    <h5 class="card-title">Sección #2</h5>
                    <p class="card-text">Esta es la segunda sección del terreno de Edson, aquí hay plantados alrededor de 400 Arboles de aguacate.</p>
                    <a style="" href="./InfoSecciones.aspx?seccion=2" class="btn btn-primary">Ver Sección</a>
                  </div>
                </div>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableFooterRow>
            <asp:TableCell ColumnSpan="2">
                <hr/>
            </asp:TableCell>
        </asp:TableFooterRow>
        
        <asp:TableRow>
            <asp:TableCell>
                <div class="card" style="width: 35rem;" runat="server" id="Div2">
                  <img class="card-img-top" src="Imagenes/Plantio.jpg" alt="Card image cap">
                  <div class="card-body">
                    <h5 class="card-title">Sección #3</h5>
                   <p class="card-text">Esta es la tercer sección del terreno de Edson, aquí hay plantados alrededor de 400 Arboles de aguacate.</p>
                    <a style="" href="./InfoSecciones.aspx?seccion=3" class="btn btn-primary">Ver Sección</a>
                  </div>
                </div>
            </asp:TableCell>
            <asp:TableCell>
                <div class="card" style="width: 35rem;" runat="server" id="Div3">
                  <img class="card-img-top" src="Imagenes/Plantio.jpg" alt="Card image cap">
                  <div class="card-body">
                    <h5 class="card-title">Sección #4</h5>
                    <p class="card-text">Esta es la cuarta y última sección del terreno de Edson, aquí hay plantados alrededor de 400 Arboles de aguacate.</p>
                    <a style="" href="./InfoSecciones.aspx?seccion=4" class="btn btn-primary">Ver Sección</a>
                  </div>
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>


</asp:Content>
