<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestCal.aspx.cs" Inherits="PlantAppSE.TestCal" %>

<%@ Register Src="~/UserControls/CalCGM.ascx" TagPrefix="uc1" TagName="CalCGM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:300px;">
        <tr style="text-align:center;">
            <td>
                Pruebas de Controles Personalizados
            </td>
        </tr>
        <tr>
            <td>Incial </td>
            <td>                
                <uc1:CalCGM runat="server" ID="calCGMFechaInicial" />           
            </td>
        </tr>
        <tr>
            <td>Final </td>
            <td>                
                <uc1:CalCGM runat="server" ID="calCGMFechaFinal" />           
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnReporte" runat="server" Text="Reporte" OnClick="btnReporte_Click" />
            </td>
            <td>
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
