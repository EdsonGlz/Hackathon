<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventosFuturos.aspx.cs" Inherits="PlantAppSE.EventosFuturos" %>

<!DOCTYPE html>

<html style="width: 100%; height:100%" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.15.1/moment.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/js/bootstrap-datetimepicker.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/css/bootstrap-datetimepicker.min.css">


    <title></title>
</head>
    <body style="width:100%; height:100vh; padding-bottom:0px;">
        <div class="jumbotron" style="width:100%; height:100vh; margin-left:auto; margin-right:auto; padding:0px; width:80%; max-height:800px; min-height:600px; background-color: #97cbdc;" >
            <div class="jumbotron" style="width:100%; height:100vh; margin-left:auto; margin-right:auto; padding:0px; align-self:center; width:60%; max-height:700px; min-height:500px; background-color:#dde8f0; height:95%;" >
             <form runat="server">
                <h1 class="Display-4" style=" color:#ffffff; text-align: center; font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">Agregar Poda!</h1><br /><br />
                <div class="container">
                    <div class="row">
                        <div class='col-sm-6'>
                            <div class="form-group">
                            <div class='input-group date' id='datetimepicker1'>
                                <input id="datetime" name="datetime" type="text" class="form-control" />
                                <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                            </div>
                        </div>
                    </div>
                 </div>
                
                        <asp:Label ID="prueba" runat="server" Text="Prueba"></asp:Label>
                        <asp:Button ID="ready" runat="server" OnClick="ready_Click" Text="Button" />
               </form>
            </div>
        </div>
    
    </body>
</html>
<script>
    $(function () {
        $('#datetimepicker1').datetimepicker();
   });

</script>

