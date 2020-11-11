<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PlantAppSE._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="jumbo" class="jumbotron fadeInDown" style="background-color: #97cbdc">
        <div class="jumbotron" style="background-color:#dde8f0">
        <div>
            <table>
                <tbody>
                    <tr class="contain">
                            <td>
                                <img style="width:40px;" src="Imagenes/LogoRSE.png">
                                <asp:HyperLink ID="HyperLink1" runat="server" href ="/Login/Login.aspx">Usuario </asp:HyperLink>  <asp:Label ID="lbl_User" runat="server" Text="Label">| Ninguno </asp:Label>
                                <asp:ImageButton ImageAlign="Right" style="width:40px; vertical-align:middle;" src="Imagenes/Agregar.png" ID="Agregar_Button" Visible="false" PostBackUrl="/AddTree.aspx" runat="server" />
                                <asp:ImageButton ImageAlign="Right" style="width:40px; vertical-align:middle;" src="Imagenes/Registro.png" ID="Editar_Button" Visible="false" OnClick="Editar_Button_Click" runat="server" />
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>     
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
     <div id="toolbox" visible="false" runat="server" class="jumbotron" style="margin-left:auto; margin-right:auto; margin-top:auto; margin-bottom:auto; align-self:center; width:70%; height:10%; background-color:#dde8f0">
         <table>
             <tr>
                 <td>
                     <asp:ImageButton OnClick="AgregarRiego_Click" ID="AgregarRiego" style=" margin-left:auto; margin-right:auto; margin-top:auto; margin-bottom:auto; width:40px" src="/Imagenes/planta.png" runat="server" />
                 </td>
                 <td>
                     <asp:ImageButton OnClick="AgregarFumigacion_Click" ID="AgregarFumigacion" style="margin-left:auto; margin-right:auto; margin-top:auto; margin-bottom:auto; width:40px" src="/Imagenes/pesticida.png" runat="server" />
                 </td>
                 <td>
                     <asp:ImageButton OnClick="AgregarSupervision_Click" ID="AgregarSupervision" style="margin-left:auto; margin-right:auto; margin-top:auto; margin-bottom:auto; width:40px" src="/Imagenes/buscar.png" runat="server" />
                 </td>
                 <td>
                     <asp:ImageButton OnClick="AgregarPoda_Click" ID="AgregarPoda" style="margin-left:auto; margin-right:auto; margin-top:auto; margin-bottom:auto; width:40px" src="/Imagenes/Poda.png" runat="server" />
                 </td>
                 <td>
                     <asp:ImageButton OnClick="AgregarPlantaCatalogo_Click" ID="AgregarPlantaCatalogo" style="margin-left:auto; margin-right:auto; margin-top:auto; margin-bottom:auto; width:40px" src="/Imagenes/menu.png" runat="server" />
                 </td>
             </tr>
         </table>
    </div>

    <div class="row">
        <div class="col">
            <table style="width:100%; margin-left:auto; margin-right:auto;">
                <tr style="text-align:center; background-color: #dde8f0;color:black;font-weight:bold;"><td> <asp:Label ID="NombrePlanta" runat="server"></asp:Label> </td></tr> 
                <br /><br />
                <tr>
                    <td>
                         <table style="width:90%; margin-left:auto; margin-right:auto;">
                                    <tr>
                                        <td  style="text-align:center; align-content:center; align-items:center; margin-left:auto; margin-right:auto;">
                                            <asp:Image HorizontalAlign="Center" class="ImagenPlanta" ID="ImagenPlanta" runat="server" /><br /><br />


                                    <asp:GridView HorizontalAlign="Center" ID="GVBitacoraRiego"  OnPageIndexChanging="GVBitacoraRiego_PageIndexChanged1" PageSize ="5" allowpaging="true" style="align-content:center; align-items:center;" CssClass="mGrid" runat="server" AutoGenerateColumns = "false" EnableModelValidation="False">
                                        <Columns>
                                            <asp:BoundField DataField="FechaHora" HeaderText ="Fecha y Hora"  />
                                            <asp:BoundField DataField="LitrosAgua" HeaderText ="Litros"  />
                                        </Columns>
                                    </asp:GridView>

                                    <asp:GridView HorizontalAlign="Center" ID="GVBitacorFumigacion" OnPageIndexChanging="GVBitacorFumigacion_PageIndexChanging" PageSize= "5" allowpaging="true" style="align-content:center; align-items:center;" CssClass="mGrid" runat="server" AutoGenerateColumns = "false">
                                        <Columns>
                                            <asp:BoundField DataField="MotivoDescripcion" HeaderText ="Motivo" />
                                            <asp:BoundField DataField="Nombre" HeaderText ="Quimico"  />
                                            <asp:BoundField DataField="Fecha" HeaderText ="Fecha"  />
                                        </Columns>
                                    </asp:GridView>

                                    <asp:GridView HorizontalAlign="Center" ID="GVBitacoraSupervision" OnPageIndexChanging="GVBitacoraSupervision_PageIndexChanging" PageSize= "5" allowpaging="true" style="align-content:center; align-items:center;" CssClass="mGrid" runat="server" AutoGenerateColumns = "false">
                                        <Columns>
                                            <asp:BoundField DataField="EstadoTronco" HeaderText ="Estado Tronco" />
                                            <asp:BoundField DataField="EstadoHojas" HeaderText ="Estado Hojas"  />
                                            <asp:BoundField DataField="EstadoRamas" HeaderText ="Estado Ramas"  />
                                            <asp:BoundField DataField="Fecha" HeaderText ="Fecha"  />
                                            <asp:BoundField DataField="Observaciones" HeaderText ="Observaciones"  />
                                        </Columns>
                                    </asp:GridView>
                                            

                                    <asp:GridView Width="100%" CssClass="mGrid" HorizontalAlign="right" OnPageIndexChanging="GVBitacoraPoda_PageIndexChanging" PageSize= "2" allowpaging="true" Visible="false" ID="GVBitacoraPoda" style="align-content:center; align-items:center;"  runat="server" AutoGenerateColumns = "false">
                                        <Columns >
                                            <asp:BoundField DataField="FechaHora" HeaderText ="Fecha y Hora" />
                                            <asp:ImageField ControlStyle-CssClass="ImagenPlanta"  DataImageUrlField="ImagenPodaUrl" HeaderText="Imagen"></asp:ImageField>          
                                        </Columns>
                                    </asp:GridView>
                                    

                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <table style="width:90%; align-items:center; text-align:center; margin-left:auto; margin-right:auto;">

                                                <tr style="padding-top:10px;">
                                                    <td style="font-weight:bold;text-align:left;">
                                                        <asp:Label ID="Propiedad1" runat="server" Text="Label">Nombre científico:</asp:Label>
                                                    </td>

                                                    <td style="color:darkgreen;font-weight:bold;">
                                                        <asp:Label ID="Valor1" runat="server"></asp:Label>
                                                    </td>
                                                </tr>


                                                <tr style="padding-top:10px; ">
                                                    <td style="font-weight:bold;text-align:left;">
                                                        <asp:Label ID="Propiedad2" runat="server">Clasificación: </asp:Label>
                                                    </td>

                                                    <td style="color:darkgreen;font-weight:bold;">
                                                        <asp:Label ID="Valor2" runat="server"></asp:Label>
                                                    </td>
                                                </tr>


                                                <tr style="padding-top:10px;">
                                                    <td style="font-weight:bold;text-align:left;">
                                                        <asp:Label  ID="Propiedad3" runat="server">Ubicación:</asp:Label>
                                                    </td>

                                                    <td style="color:darkgreen;font-weight:bold;">
                                                        <asp:Label ID="Valor3" runat="server"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr style="padding-top:10px;">
                                                    <td style="font-weight:bold;text-align:left;">
                                                        <asp:Label ID="Propiedad4" runat="server">Ultimo riego recibido:</asp:Label>
                                                    </td>

                                                    <td style="color:darkgreen;font-weight:bold;">
                                                        <asp:Label ID="Valor4" runat="server"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr style="padding-top:10px;">
                                                    <td style="font-weight:bold;text-align:left;">
                                                        <asp:Label ID="Propiedad5" runat="server">Siguiente riego programado:</asp:Label>
                                                    </td>

                                                    <td style="color:darkgreen;font-weight:bold;">
                                                        <asp:Label ID="Valor5" runat="server"></asp:Label>
                                                        <asp:ImageButton style="width:20px;" ID="Img_SiguienteRiego" src="Imagenes/Service.png" OnClick="AddFutureEvents" runat="server" />
                                                    </td>
                                                </tr>

                                                <tr style="padding-top:10px;">
                                                    <td style="font-weight:bold; text-align:left;">
                                                        <asp:Label ID="Propiedad6" runat="server">Ultima poda realizada:</asp:Label>
                                                    </td>

                                                    <td style="color:darkgreen;font-weight:bold;">
                                                        <asp:Label ID="Valor6" runat="server"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr style="padding-top:10px;">
                                                    <td style="font-weight:bold; text-align:left;">
                                                        <asp:Label ID="Propiedad7" runat="server">Proxima fertilización programada:</asp:Label>
                                                    </td>

                                                    <td style="color:darkgreen;font-weight:bold;">
                                                        <asp:Label ID="Valor7" runat="server"></asp:Label>
                                                        <asp:ImageButton style="width:20px;" OnClick="AddFutureEvents" ID="Img_ProximaFertilizacion" src="Imagenes/Service.png" runat="server" />
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                    <tr><td><br /><br /></td></tr>
                                    <tr>
                                        <td>
                                            <div id="Calendario" visible="false" runat="server" class="jumbotron" style="margin-left:auto; margin-right:auto; margin-top:auto; margin-bottom:auto; align-self:center; width:90%; height:10%; background-color:#dde8f0">
                                                        <asp:Table ID="Calendario1" runat="server">
                                                            <asp:TableRow> <asp:TableCell HorizontalAlign="Center" ColumnSpan="3" > <asp:Label ID="lbl_Fecha" style="font-weight:bolder; color:#000099" runat="server" Text="Fecha"></asp:Label> <hr style="color:red" /> </asp:TableCell> </asp:TableRow>
                                                            
                                                            <asp:TableRow>
                                                                <asp:TableCell HorizontalAlign="Center" Width="33%">
                                                                    <asp:DropDownList style="border-radius:5px" Width="70%" ID="DDl_Year" runat="server"></asp:DropDownList>
                                                                </asp:TableCell>
                                                                
                                                                <asp:TableCell HorizontalAlign="Center" Width="33%">
                                                                    <asp:DropDownList style="border-radius:5px" Width="70%" ID="DDl_Months" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                                </asp:TableCell>
                                                                
                                                                <asp:TableCell HorizontalAlign="Center" Width="33%">
                                                                    <asp:DropDownList style="border-radius:5px" Width="70%" ID="DDl_Days" runat="server"></asp:DropDownList>
                                                                </asp:TableCell>
                                                            </asp:TableRow>
                                                        </asp:Table>
                                                        <br />
                                                       <asp:Table ID="Table1" runat="server">
                                                           <asp:TableRow> <asp:TableCell HorizontalAlign="Center" ColumnSpan="3" > <asp:Label ID="lbl_Hora" style="font-weight:bolder; color:#000099" runat="server" Text="Hora"></asp:Label> <hr style="color:blue" /></asp:TableCell> </asp:TableRow>
                                                            <asp:TableRow>
                                                                <asp:TableCell HorizontalAlign="Center" Width="50%">
                                                                    <asp:DropDownList style="border-radius:5px" Width="70%" ID="DDl_Horas" runat="server"></asp:DropDownList>
                                                                </asp:TableCell>
                                                                
                                                                <asp:TableCell HorizontalAlign="Center" Width="50%">
                                                                    <asp:DropDownList style="border-radius:5px" Width="70%" ID="DDl_Minutos" runat="server"></asp:DropDownList>
                                                                </asp:TableCell>                                                                
                                                            </asp:TableRow>
                                                           <asp:TableRow>
                                                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" Width="50%">.
                                                                    <br />
                                                                    <asp:Button ID="btn_CalendarioListo" AutoPostBack="true" OnClick="btn_CalendarioListo_Click" Text="Agregar Fecha" runat="server"/>
                                                                </asp:TableCell>                                                                
                                                            </asp:TableRow>
                                                        </asp:Table>
                                                    </div>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <table style="width:90%;  margin-left:auto; margin-right:auto;">
                                                <tr>
                                                    <td style="text-align:center;color:#333333;font-weight:bold;">
                                                        <asp:ImageButton type="image" src="Imagenes/guion.png" style="width:100%;"  class="ImagenLogo"  ID="ImageHistoria" OnClick="ImageHistoria_Click" runat="server" />
                                                        <br />
                                                        <asp:Label ID="Historia" runat="server" text-align="center" Text="Historia"></asp:Label>
                                                    </td>
                                                    <td style="text-align:center;color:#333333;font-weight:bold;">
                                                        <asp:ImageButton  ID="ImagenBitRiego" class="ImagenLogo" src="Imagenes/planta.png" OnClick="ImageBitacoraRiego_Click" style="width:100%;" runat="server" /> 
                                                        <br />
                                                        <asp:Label ID="BitacoraRiego" runat="server" text-align="center" Text="Bitacora Riego"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align:center;color:#333333;font-weight:bold;">
                                                        <asp:ImageButton  ID ="ImagenBitFumigacion" type="image" class="ImagenLogo" OnClick="ImageBitacoraFumigacion_Click"  src="Imagenes/pesticida.png" style="width:100%;" runat="server" /> 
                                                        <br />
                                                        <asp:Label ID="BitacoraFumigacion" runat="server" text-align="center" Text="Bitacora Fumigacion"></asp:Label>
                                                    </td>
                                                    <td style="text-align:center;color:#333333;font-weight:bold;">
                                                        <asp:ImageButton  ID ="ImageButton1" type="image" class="ImagenLogo" src="Imagenes/Buscar.png" OnClick="ImageBitacoraSupervision_Click" style="width:100%;" runat="server" /> 
                                                        <br />
                                                        <asp:Label ID="BitacoraSuervision" runat="server" text-align="center" Text="Bitacora Supervision"></asp:Label>
                                                    </td>                                                
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style=" margin-left:auto; margin-right:auto; padding:inherit; text-align:center;color:#333333;font-weight:bold;">
                                                        <asp:ImageButton type="image" CssClass="ImagenLogo" OnClick="ImagenPoda_Click" src="Imagenes/Poda.png" ID="ImagenPoda" runat="server" /><br />
                                                        <asp:Label ID="Label1" runat="server" text-align="center" Text="Bitacora Poda"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                    </td>
                </tr>            
             </table>
        </div>    
     </div>
    </div>



    <!-- Bootstrap Modal Dialog --> 
<div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true"> 
    <div class="modal-dialog"> 
     <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional"> 
      <ContentTemplate> 
       <div class="modal-content"> 
        <div class="modal-header"> 
         <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button> 
         <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4> 
        </div> 
        <div class="modal-body"> 
         <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label> 
        </div> 
        <div class="modal-footer"> 
         <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button> 
        </div> 
       </div> 
      </ContentTemplate> 
     </asp:UpdatePanel> 
    </div> 
</div> 

</asp:Content>
