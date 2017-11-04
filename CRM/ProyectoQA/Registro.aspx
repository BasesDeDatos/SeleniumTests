<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProyectoQA.Registro" %>
<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">


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

<div class="register-container">
    <div class="row">
        <div class="col-md-12">
            <div class="text-center m-b-md">
                <h3>Registar CRM</h3>
             </div>
            <div class="hpanel">
                <div class="panel-body">
                        <form action="#" id="loginForm"  runat ="server">
                            <div class="row">
                            <div class="form-group col-lg-12">
                                <label>Correo Electronico</label>
                                <asp:TextBox ID="correoUsuarioRegistrar" type ="email" CssClass ="form-control" runat = "server" required ="" ></asp:TextBox>
                                
                                
                            </div>
                            <div class="form-group col-lg-6">
                                <label>Contraseña</label>
                             <asp:TextBox ID="contrasenaRegistrar" type ="password" CssClass ="form-control" runat="server" required =""></asp:TextBox> </div>
                            <div class="form-group col-lg-6">
                                <label>Confirmar contraseña</label>
                                <asp:TextBox ID="contrasenaConfirmarRegistrar" type ="password" CssClass ="form-control" runat="server" required =""></asp:TextBox> </div>
                            </div>
                            <div class="text-center" runat ="server">
                                 <asp:Button ID="Registrar"  runat="server"  CssClass ="btn btn-success" Text="Registrar" OnClick="registrarUsuario" />
                        
                                <a id="Cancelar" href ="Autenticacion.aspx" class ="btn btn-default" >Cancelar </a>
                        
                            </div>
                        </form>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
      
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

<!-- Mirrored from webapplayers.com/homer_admin-v2.0/register.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 18 Sep 2017 04:18:53 GMT -->
</html>