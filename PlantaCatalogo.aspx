<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlantaCatalogo.aspx.cs" Inherits="PlantAppSE.PlantaCatalogo" %>



<asp:Content ID="BodyContent" style="min-height:600px" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="jumbotron" style="  min-height:600px; background-color: #97cbdc;" >
        <div class="jumbotron" style=" max-height:700px; min-height:500px; background-color:#dde8f0; height:95%;" >
            <h1 class="Display-4" style=" color:#ffffff; text-align: center; font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">Agregar Planta Al Catalogo!</h1><br /><br />
                <div class="row">

                        <asp:Table ID="Table1" CellPadding="10" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0">

                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_Nombre" runat="server" Text="Nombre: "></asp:Label></asp:TableCell>
                                <asp:TableCell  Width="100%"  HorizontalAlign="Center" VerticalAlign="Middle"><asp:TextBox Width="80%" ID="tbx_nombre" runat="server"></asp:TextBox></asp:TableCell>
                                <asp:TableCell   Width="30%"  HorizontalAlign="Center" VerticalAlign="Middle"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Ingresa el nombre" ControlToValidate="tbx_nombre"></asp:RequiredFieldValidator></asp:TableCell>
                            </asp:TableRow>
                            
                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_NombreCientifico" runat="server" Text="Nombre Cientifico: "></asp:Label></asp:TableCell>
                                <asp:TableCell  Width="100%"  HorizontalAlign="Center" VerticalAlign="Middle"><asp:TextBox Width="80%" ID="tbx_NombreCientifico" runat="server"></asp:TextBox></asp:TableCell>
                                <asp:TableCell  Width="30%"  HorizontalAlign="Center" VerticalAlign="Middle"><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Ingresa el nombre cientifico" ControlToValidate="tbx_NombreCientifico"></asp:RequiredFieldValidator></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_Clasificacion" runat="server" Text="Clasificacion: "></asp:Label></asp:TableCell>
                                <asp:TableCell  Width="100%"  HorizontalAlign="Center" VerticalAlign="Middle"><asp:TextBox  Width="80%" ID="tbx_Clasificaion" runat="server"></asp:TextBox></asp:TableCell>
                                <asp:TableCell  Width="30%"  HorizontalAlign="Center" VerticalAlign="Middle"><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Ingresa la clasificacion" ControlToValidate="tbx_Clasificaion"></asp:RequiredFieldValidator></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow Height="60px" HorizontalAlign="Center" VerticalAlign="Bottom">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Middle"><asp:Button ID="Btn_Listo" OnClick="Btn_Listo_Click" runat="server" Text="Agregar" /></asp:TableCell>
                            </asp:TableRow>

                        </asp:Table>
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
