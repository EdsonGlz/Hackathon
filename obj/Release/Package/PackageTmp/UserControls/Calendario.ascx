<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendario.ascx.cs" Inherits="PlantAppSE.UserControls.Calnedario" %>

<link rel="stylesheet" href="~/StyleDefault.css" />

<div id="Calendario" visible="true" runat="server" class="jumbotron" style="margin-left:auto; margin-right:auto; margin-top:auto; margin-bottom:auto; align-self:center; width:90%; height:10%; background-color:#dde8f0">
    <asp:Table ID="Fecha" runat="server">
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
    <asp:Table ID="Hora" runat="server">
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
                <asp:Button ID="btn_CalendarioListo" AutoPostBack="true" Text="Agregar Fecha" runat="server"/>
            </asp:TableCell>                                                                
        </asp:TableRow>
    </asp:Table>
</div>
