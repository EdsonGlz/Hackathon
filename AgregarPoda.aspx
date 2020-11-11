<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarPoda.aspx.cs" Inherits="PlantAppSE.AgregarPoda" %>

<asp:Content ID="BodyContent" style="max-height:800px; min-height:600px" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="jumbotron" style=" max-height:800px; min-height:600px; background-color: #97cbdc;" >
        <div class="jumbotron" style=" max-height:700px; min-height:500px; background-color:#dde8f0; height:95%;" >
            <h1 class="Display-4" style=" color:#ffffff; text-align: center; font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">Agregar Poda!</h1><br /><br />
            <div class="container">
                    <div class="row">

                        <asp:Table ID="Table1" CellPadding="10" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0">

                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label Font-Bold="true" ForeColor="Black" ID="lbl_Imagen" runat="server" Text="Imagen: "></asp:Label></asp:TableCell>
                                <asp:TableCell  Width="50%"  HorizontalAlign="Center" VerticalAlign="Middle">
                                    <asp:FileUpload Width="100%" id="FileUploadControl" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                    <asp:Button ID="Button1" OnClick="Btn_Listo_Click" runat="server" Text="Agregar" />
                                </asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                    <asp:Label runat="server" id="StatusLabel"  Visible="false" text="Upload status: " />
                                    <asp:Label runat="server" id="LabelError" Visible="false" text="Hay un error en las entradas. " />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
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
         <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click1" class="btn btn-info" UseSubmitBehavior="false" data-dismiss="modal" aria-hidden="true" text="Aceptar"/>
        </div> 
       </div> 
      </ContentTemplate> 
     </asp:UpdatePanel> 
    </div> 
</div>

</asp:Content>

