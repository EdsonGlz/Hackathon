<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyTree.aspx.cs" Inherits="PlantAppSE.ModifyTree" %>

<%@ Register Src="~/UserControls/CalCGM.ascx" TagPrefix="uc1" TagName="CalCGM" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div id="jumbo" class="jumbotron fadeInDown" style=" min-height:640px; background-color: #97cbdc; height : 100%">
        <div class="jumbotron" style=" min-height:620px; background-color:#dde8f0; height : 100%" >
            <div class="row">
                <div class="col"> 
                    <h1 class="Display-4" style=" color:#ffffff; text-align: center; font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">Modificar Planta!</h1><br /><br />
                    <asp:Wizard OnFinishButtonClick="Wizard1_FinishButtonClick" CellSpacing="50" CellPadding="50" BorderColor="Blue" style="animation: ease-in; animation-delay:2s; font-size:large; font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;" ID="Wizard1" DisplaySideBar="false" runat="server" ActiveStepIndex="0" Width ="100%">
                    <WizardSteps>
                    
                    <asp:WizardStep ID="WizardStep1" runat="server" Title="Paso 1">
                        <asp:Table ID="Table1" CellPadding="10" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0">
                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_Ubicacion" runat="server" Text="Ubicacion"></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:DropDownList DataValueField="idUbicacion" DataTextField="NombreSector" Width="90%" ID="DDL_Ubicacion" runat="server"></asp:DropDownList></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_PlantaCatalogo" Text="Planta Catalogo" runat="server" ></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:DropDownList DataValueField="idPlantaCatalogo" DataTextField="Nombre" Width="90%" ID="DDL_PlantaCatalogo" runat="server"></asp:DropDownList></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_AnioPlantacion" Text="Año de Plantacion" runat="server" ></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:DropDownList Width="90%" ID="DDL_AnioPlantacion" runat="server"></asp:DropDownList></asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_Altura" Text="Altura" runat="server" ></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:TextBox Width="90%" ID="tbx_Altura" runat="server"></asp:TextBox></asp:TableCell>
                                <asp:TableCell Width="10%" HorizontalAlign="Center" VerticalAlign="Middle"><asp:RegularExpressionValidator runat="server" ControlToValidate="tbx_Altura" ValidationExpression="^[1-9]\d*(\.\d+)?$" ErrorMessage="Solo ingrese numeros"></asp:RegularExpressionValidator></asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true"  ForeColor="Black"  Text="Donador" ID="lbl_Donador" runat="server" ></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:TextBox Height="90%" Width="90%" ID="tbx_Donador" runat="server"></asp:TextBox></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lblValor" Text="Valor Comercial" runat="server" ></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:DropDownList Width="90%" ID="DDl_Valor" runat="server"></asp:DropDownList></asp:TableCell>
                                
                            </asp:TableRow>



                       </asp:Table>
                    </asp:WizardStep>

                    <asp:WizardStep ID="WizardStep2" runat="server" Title="Paso 2">
                        <asp:Table ID="Table2" CellPadding="10" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0" Width="80%">
                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_UltimoRiego" Text="Ultimo Riego" runat="server" ></asp:Label></asp:TableCell>
                                <asp:TableCell Width="80%" HorizontalAlign="Center" VerticalAlign="Middle"><uc1:CalCGM runat="server" ID="CalCGM" /></asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" Text ="Siguiente Riego" ID="lblSiguienteRiego" runat="server" ></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><uc1:CalCGM runat="server" ID="CalCGM1" /></asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_UltimaPoda" runat="server"  Text ="Ultima Poda"></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><uc1:CalCGM runat="server" ID="CalCGM2" /></asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="80%">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_ProximaFertilizacion" Text ="Proxima Fertilizacion" runat="server" ></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><uc1:CalCGM runat="server" ID="CalCGM3" /></asp:TableCell>
                            </asp:TableRow>
                       </asp:Table>
                    </asp:WizardStep>

                        <asp:WizardStep ID="WizardStep3" runat="server" Title="Paso 3">
                            
                            <asp:Table ID="Table4" CellPadding="10" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0">
                                <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom">
                                    <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_Lugar" Text="Lugar de Origen" runat="server" ></asp:Label></asp:TableCell>
                                    <asp:TableCell Width="33%" HorizontalAlign="Center" VerticalAlign="Middle"><asp:DropDownList DataValueField="idEstado" AutoPostBack="true" OnSelectedIndexChanged="DDl_Estado_SelectedIndexChanged" DataTextField="EstadoNombre" Width="90%"  ID="DDl_Estado" runat="server"></asp:DropDownList></asp:TableCell>
                                    <asp:TableCell Width="33%" HorizontalAlign="Center" VerticalAlign="Middle"><asp:DropDownList DataValueField="idMunicipio" DataTextField="NombreMunicipio" Width="90%" ID="DDL_Ciudad" runat="server"></asp:DropDownList></asp:TableCell>
                                </asp:TableRow>
                           </asp:Table>


                        <asp:Table ID="Table3" CellPadding="10" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0">
                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom">
                                <asp:TableCell Width="34%" HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_Imagen" Text="Imagen" runat="server" ></asp:Label></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:FileUpload id="FileUploadControl" runat="server" /></asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                    <asp:Label runat="server" id="StatusLabel"  Visible="false" text="Upload status: " /><br />
                                    <asp:Label runat="server" id="Label2" Visible="false" text="Hay un error en las entradas. " />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                     </asp:WizardStep>
                    </WizardSteps>
                </asp:Wizard>
            </div>
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
         <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" class="btn btn-info" UseSubmitBehavior="false" data-dismiss="modal" aria-hidden="true" text="Aceptar"/>
        </div> 
       </div> 
      </ContentTemplate> 
     </asp:UpdatePanel> 
    </div> 
</div>



</asp:Content>