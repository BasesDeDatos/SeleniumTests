<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="ContactoEmpresa.aspx.cs" Inherits="ProyectoQA.ContactoEmpresaForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Empresas</h1>
    <div id ="Element"  runat ="server" onload ="verContactoEmpresa">
        
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="modal fade" id="mymodal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">&times;</a>
                        <h3 class="modal-title">Registrar Nueva Empresa</h3>
                    </div>
                    <div class="modal-body">
                        <form method="post" class="form-horizontal" runat ="server" display="Dynamic">
                        <div class="form-group"><label class="control-label">Nombre de la Empresa</label>

                            <div ><asp:TextBox ID="nombreEmpresa" CssClass ="form-control" runat="server" required=""></asp:TextBox></div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        
                        <div class="form-group">
                            <label class="control-label" >Teléfono de la Empresa</label>
                                <asp:TextBox ID="telefonoEmpresa" CssClass ="form-control" runat="server" type ="number" min="0" required="">

                                </asp:TextBox>
                        </div>
                        <div class="hr-line-dashed"></div>
                         <div class="form-group">
                            <label class="control-label" >Direccion de la Empresa</label>
                                <asp:TextBox ID="direccionEmpresa" CssClass ="form-control" runat="server" required=""></asp:TextBox>
                                
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group">
                            <div class="col-sm-8">
                                <asp:Button ID="registrarEmpresaButton" type ="submit" Onclick ="registrarEmpresa" href ="ContactoEmpresa.aspx" CssClass ="btn btn-primary" runat="server" Text ="Registrar contacto de Empresa" />
                               
                                <asp:Button ID="cancelarRegistarEmpresa" CssClass ="btn btn-default" data-dismiss="modal" href ="ContactoEmpresa.aspx"  runat="server" Text="Cancelar" />
                           
                                 
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
                data-toggle="modal" data-target="#mymodal">Agregar Empresa</i>
        </a>
    </li>
</asp:Content>

