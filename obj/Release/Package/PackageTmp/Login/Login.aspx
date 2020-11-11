<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PlantAppSE.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>

    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" runat="server">
    <div class="wrapper fadeInDown" >
  <div id="formContent">
    <!-- Tabs Titles -->
    <h2 class="active"> Sign In </h2>
    <!-- Icon -->
    <div class="fadeIn first">
      <img class="Logo" style="max-width:350px" src="/Imagenes/LogoRSE.png" id="icon" alt="User Icon" />
    </div>

    <!-- Login Form -->
        <asp:TextBox placeholder="User" type="text" ID="tbx_User" runat="server"></asp:TextBox>
        <asp:TextBox placeholder="Password" type="password" ID="tbx_Pass" runat="server"></asp:TextBox>

    <!-- Remind Passowrd -->
      <div>     
          <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" />
      </div>
  </div>
</div>
        </form>
</body>
</html>
