<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Autenticacion.aspx.cs" Inherits="ProyectoQA.Autenticacion" %>

<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <!-- Page title -->
    <title>CRM</title>


    <link rel="stylesheet" href="vendor/fontawesome/css/font-awesome.css" />
    <link rel="stylesheet" href="vendor/metisMenu/dist/metisMenu.css" />
    <link rel="stylesheet" href="vendor/animate.css/animate.css" />
    <link rel="stylesheet" href="vendor/bootstrap/dist/css/bootstrap.css" />

    <!-- App styles -->
    <link rel="stylesheet" href="fonts/pe-icon-7-stroke/css/pe-icon-7-stroke.css" />
    <link rel="stylesheet" href="fonts/pe-icon-7-stroke/css/helper.css" />
    <link rel="stylesheet" href="styles/style.css">

</head>
<body class="blank">



<div class="color-line"></div>

<div class="login-container">
    <div class="row">
        <div class="col-md-12">
            <div class="text-center m-b-md">
                <h3>...CRM...</h3>
                <small>Su mejor opción!</small>
            </div>
            <div class="hpanel">
                <div class="panel-body">
                        <form id="loginForm" runat="server">
                            <div class="form-group">
                                <label class="control-label" for="username">Nombre de Usuario</label>
                                <asp:TextBox ID="textUsername" placeholder="example@gmail.com" CssClass ="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="password">Contraseña</label>
                                 <asp:TextBox ID="textPassword" type="password" placeholder="********" CssClass ="form-control" runat="server" ></asp:TextBox>
                                
                            </div>
                            
                            <asp:Button ID="Button1" runat="server" CssClass ="btn btn-success btn-block" Text="Ingresar al CRM" OnClick="ingresar" />
                            <asp:Button ID="Button2" runat="server" CssClass ="btn btn-default btn-block" Text="Registrarse al CRM" href ="" OnClick="registrarRef" />
                        </form>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center">
         
        </div>
    </div>
</div>


<!-- Vendor scripts -->
<script src="vendor/jquery/dist/jquery.min.js"></script>
<script src="vendor/jquery-ui/jquery-ui.min.js"></script>
<script src="vendor/slimScroll/jquery.slimscroll.min.js"></script>
<script src="vendor/bootstrap/dist/js/bootstrap.min.js"></script>
<script src="vendor/metisMenu/dist/metisMenu.min.js"></script>
<script src="vendor/iCheck/icheck.min.js"></script>
<script src="vendor/sparkline/index.js"></script>

<!-- App scripts -->
<script src="scripts/homer.js"></script>

</body>

</html>
