<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="PropuestaVentas.aspx.cs" Inherits="ProyectoQA.PropuestaVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="modal fade" id="mymodal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">&times;</a>
                        <h3 class="modal-title">Registrar propuesta</h3>
                    </div>
                    <div class="modal-body">
                        <form method="post" class="form-horizontal" runat ="server" display="Dynamic">

                        <div class="form-group">
                            <label class="control-label">Producto</label>
                            <asp:DropDownList ID="ddIdProducto" CssClass ="form-control" runat="server" required="" onload ="popularProductos">
                            </asp:DropDownList>
                        </div>

                        <div class="hr-line-dashed"></div>                        
                        <div class="form-group">
                            <label class="control-label" >Precio ($)</label>
                            <asp:TextBox ID="precio" CssClass ="form-control" runat="server" type="number" value="0" min="0" required=""></asp:TextBox>
                        </div>

                        <div class="hr-line-dashed"></div>
                         <div class="form-group">
                            <label class="control-label" >Fecha de la propuesta</label>
                            <asp:TextBox ID="fecha" CssClass ="form-control" runat="server" type="date" required=""></asp:TextBox>    
                        </div>

                        <div class="form-group">
                            <label class="control-label">Cliente</label>
                            <asp:DropDownList ID="ddIdContacto" CssClass ="form-control" runat="server" required="" onload ="popularContactos">
                            </asp:DropDownList>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group">
                            <div class="col-sm-8">
                                <asp:Button ID="registrarVentaButton" type ="submit" Onclick ="registrarPropuestaVenta" href ="PropuestaVentas.aspx" CssClass ="btn btn-primary" runat="server" Text ="Registrar propuesta" />
                                <asp:Button ID="cancelarVentaEmpresa" CssClass ="btn btn-default" data-dismiss="modal" href="PropuestaVentas.aspx"  runat="server" Text="Cancelar" />   
                            </div>
                        </div>

                        </form>

                    <div class="modal-footer">
                    </div>

                </div>

            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <li>
        <a href="#">
            <i class=""
                data-toggle="modal" data-target="#mymodal">Agregar propuesta</i>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <li class="dropdown">
        <a href="#">
            <i class="pe-7s-plus"
                data-toggle="modal" data-target="#mymodal"></i>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="hpanel">
            <div class="panel-heading">
                <div class="panel-tools">
                    <a class="showhide"><i class="fa fa-chevron-up"></i></a>
                    <a class="closebox"><i class="fa fa-times"></i></a>
                </div>
                <h1>Propuestas de ventas</h1>
            </div>
            <div class="panel-body">
                <div class="table-responsive">
                <table cellpadding="1" cellspacing="1" class="table table-bordered table-striped">
                    <thead>
                    <tr>
                        <th>Fecha de la propuesta</th>
                        <th>Producto</th>
                        <th>Precio</th>
                        <th>Respuesta</th>
                        <th>Editar respuesta</th>
                    </tr>
                    </thead>
                    <tbody id ="vistaPropuestaVentas"  runat ="server" onload ="verPropuestaVentas">
                
                    </tbody>
                </table>
                </div>

            </div>
            <div class="panel-footer">
                Propuestas de ventas
            </div>
        </div>
    </div>
</asp:Content>
