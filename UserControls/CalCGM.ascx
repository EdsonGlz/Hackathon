<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalCGM.ascx.cs" Inherits="PlantAppSE.UserControls.CalCGM" %>
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <asp:Table ID="TableCal" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0" Width="100%">
        <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" Width="1px" style="max-width:10px">
            <asp:TableCell Width="100%">
              <asp:TextBox ID="tbFecha" runat="server" Width="100%"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="100%">
                <asp:Button ID="btnVerCalendario" runat="server" Text="Ver Calendario" OnClick="btnVerCalendario_Click" style="max-width:80px"/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow Height="70px" HorizontalAlign="Center" VerticalAlign="Bottom" >
            <asp:TableCell ColumnSpan="3" style="text-align:center;">
                <asp:PlaceHolder ID="phCalendario" runat="server"  Visible="false">
                    <asp:Table ID="Table1" CellPadding="10" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0" Width="10%">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Table ID="TableTime" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0" Width="100%">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            Hora
                                            <asp:DropDownList ID="ddl_Horas" runat="server" Height="29px" Width="100%" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </asp:TableCell>

                                        <asp:TableCell>
                                            Minuto
                                            <asp:DropDownList ID="ddl_Minutos" runat="server" Height="29px" Width="100%" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>

                                <asp:Table ID="Table2" CellPadding="10" GridLines="Both" HorizontalAlign="Center" runat="server" BorderColor="#dde8f0" Width="100%">
                                    <asp:TableRow>
                                        <asp:TableCell>Año</asp:TableCell>
                                        <asp:TableCell>
                                            <asp:DropDownList ID="ddlAno" runat="server" Height="29px" Width="100%" style="min-width:60px" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" AutoPostBack="true" >                         
                                            </asp:DropDownList>
                                        </asp:TableCell>

                                        <asp:TableCell>Mes</asp:TableCell>
                                        <asp:TableCell>
                                            <asp:DropDownList ID="ddlMes" runat="server" Height="29px" Width="80%" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>
                                 <asp:Calendar ID="calendario" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="calendario_SelectionChanged">
                                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                    <OtherMonthDayStyle ForeColor="#999999" />
                                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                 </asp:Calendar>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:PlaceHolder>
            </asp:TableCell>
        </asp:TableRow>
    </asp:table>
</asp:PlaceHolder>
