<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="ContactoPersona.aspx.cs" Inherits="ProyectoQA.ContactoPersonaForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Personas</h1>
    <div id ="Element"  runat ="server" onload ="verContactoPersona" >
        
    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="modal fade" id="mymodal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">&times;</a>
                        <h3 class="modal-title">Registrar Nueva Personas</h3>
                    </div>
                    <div class="modal-body">
                       <form method="post" class="form-horizontal" runat ="server">
                        <div class="form-group" runat ="server">

                            <div class="col-sm-4">
                                <label class="control-label">Nombre</label>
                                <asp:TextBox ID="nombrePersona" CssClass ="form-control" runat="server" required=""></asp:TextBox>
                                
                            </div>

                            <div class="col-sm-4">
                                <label class="control-label">Primer Apellido</label>
                                <asp:TextBox ID="apellido1Persona" CssClass ="form-control col-sm-3" runat="server" required=""></asp:TextBox>
                                
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">Segundo Apellido (Opcional)</label>
                                <asp:TextBox ID="apellido2Persona" CssClass ="form-control col-sm-3 " runat="server"></asp:TextBox>
                                
                            </div>
                            
                                
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group" runat ="server">
                    
                            <label class="control-label" for="password">Correo de Persona</label>
                                <asp:TextBox ID="correoPersona" CssClass ="form-control" runat="server" type ="email" required=""></asp:TextBox>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group" runat ="server">
                            <label class="control-label" >Teléfono de Persona</label>
                             <asp:TextBox ID="telefonoPersona" CssClass ="form-control" runat="server" type ="number" min="0" required=""></asp:TextBox>
                                
                        </div>
                         
                        <div class="hr-line-dashed"></div>
                         <div class="form-group" runat ="server">
                            <label class="control-label" >Direccion de la Persona</label>                             
                             <asp:TextBox ID="direccionPersona" CssClass ="form-control" runat="server" required=""></asp:TextBox>
                                
                        </div>
                        <div class="hr-line-dashed"></div>
                         <div class="form-group" runat ="server">
                            <label class="control-label" >Nombre de la Empresa que pertence la persona(opcional)</label>                             
                             <asp:TextBox ID="nombreEmpresaPersona" CssClass ="form-control" runat="server"></asp:TextBox>
                                
                        </div>
                      
                        <div class="hr-line-dashed"></div>
                        <div class="form-group" runat ="server">
                            <div class="col-sm-8">
                                <asp:Button ID="registrarPersonaButton"  Onclick ="registrarPersona" CssClass ="btn btn-primary"  runat="server" Text ="Registrar contacto de persona" />
                               
                                <asp:Button ID="cancelarRegistrarPersona" CssClass ="btn btn-default" data-dismiss="modal"  runat="server" Text="Cancelar" />
                           
                                 
                            </div>
                        </div>
                        </form>

                    <div class="modal-footer">
                    </div>

                </div>

            </div>

        </div>
    </div>
    

<div class="modal fade" id="contactoPropuestaModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">&times;</a>
                        <h3 class="modal-title">Propuestas del contacto</h3>
                    </div>
                   <div class="modal-body">
 
                            <div class="table-responsive">
                            <table cellpadding="1" cellspacing="1" class="table table-bordered table-striped">
                                <thead>
                                <tr><th colspan="4" style="text-align:center;">Propuestas</th></tr>
                                <tr>
                                    
                                    <th>Fecha de la propuesta</th>
                                    <th>Producto</th>
                                    <th>Precio</th>
                                    <th>Estado</th>
                                   
                                </tr>
                                </thead>
                                <tbody id ="contactoPropuesta">
                
                                </tbody>
                                </table>
                                <table cellpadding="1" cellspacing="1" class="table table-bordered table-striped">
                                <thead>
                                <tr><th colspan="4" style="text-align:center;">Ventas</th></tr>
                                <tr>
                                 
                                    <th>Fecha de la venta</th>
                                    <th>Producto</th>
                                    <th>Precio</th>
                                    
                                   
                                </tr>
                                </thead>
                                <tbody id ="contactoVenta">
                
                                </tbody>

                            </table>
                            </div>

                </div>

            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <li class="dropdown">
        <a href="#">
            <i class="pe-7s-plus"
                data-toggle="modal" data-target="#mymodal"></i>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <li>
        <a href="#">
            <i class=""
                data-toggle="modal" data-target="#mymodal">Agregar Persona</i>
        </a>
    </li>
</asp:Content>