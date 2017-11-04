<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="RegistroRespuestas.aspx.cs" Inherits="ProyectoQA.RegistroRespuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12" >
        <h3>Registrar respuesta</h3>
                        
        <form method="post" class="form-horizontal" runat ="server" display="Dynamic">

            <div class="form-group">
                <label class="control-label" >Fecha de la propuesta</label>
                <asp:TextBox ID="fecha" CssClass ="form-control" runat="server" type="date" required=""></asp:TextBox>    
            </div>
        
            <div class="hr-line-dashed"></div>
            <div class="form-group">
                <label class="control-label">Estado</label>
                <asp:DropDownList ID="ddEstado" CssClass ="form-control" runat="server" required="">
                    <asp:ListItem value ="No especificado">No especificado</asp:ListItem>
                    <asp:ListItem value ="Aceptado">Aceptado</asp:ListItem>
                    <asp:ListItem value ="Rechazado">Rechazado</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="hr-line-dashed"></div>                        
            <div class="form-group">
                <label class="control-label" >Respuesta</label>
                <asp:TextBox ID="respuesta" CssClass ="form-control" runat="server" required="" value="Sin respuesta"></asp:TextBox>
            </div>

            <div class="hr-line-dashed"></div>
            <div class="form-group">
                <div class="col-sm-8">
                    <asp:Button ID="registrarRespuestaButton" type="submit" Onclick ="registrarRespuesta" href ="PropuestaVentas.aspx" CssClass ="btn btn-primary" runat="server" Text ="Registrar respuesta" />
                    <asp:LinkButton ID="cancelarRespuesta" CssClass="btn btn-default" href="javascript:history.go(-1)"  runat="server" Text="Cancelar" />
                </div>
            </div>

        </form>

    </div>
</asp:Content>
