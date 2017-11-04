using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Web.UI.HtmlControls;
using ProyectoQA.Classes;

namespace ProyectoQA
{
    public partial class ContactoEmpresaForm : System.Web.UI.Page
    {
        private static IConexion conexion;

        public ContactoEmpresaForm()
        {
            conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
        }
        public ContactoEmpresaForm(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
        }

        //Registro (Probado)
        public Boolean verificarDatosEmpresa(String pNombreEmpresa, String pDireccionEmpresa, String pTelefonoEmpresa)
        {
            if (String.IsNullOrEmpty(pNombreEmpresa))
            {
                Verificador.mostrarMensaje("Nombre de Empresa inválido", Page);
                return false;

            }
            else if (String.IsNullOrEmpty(pDireccionEmpresa))
            {
                Verificador.mostrarMensaje("Dirección de Empresa inválido", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pTelefonoEmpresa))
            {
                Verificador.mostrarMensaje("Número de teléfono inválido", Page);
                return false;
            }
            else if (!Verificador.verificarTamanoTelefono(pTelefonoEmpresa))
            {
                Verificador.mostrarMensaje("El teléfono debe contener entre 8 y 20 números", Page);
                return false;
            }
            else if (!Verificador.verificarNumerosTelefono(pTelefonoEmpresa))
            {
                Verificador.mostrarMensaje("Formato de número invalido", Page);
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean insertarEmpresa(String pNombreEmpresa, String pDireccionEmpresa, String pTelefonoEmpresa, String pIdUsuario)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call insertEmpresa('" + pNombreEmpresa + "','" + pTelefonoEmpresa
                                        + "','" + pDireccionEmpresa + "'," + pIdUsuario + ");");
                conexion.getResultados().Close();
                conexion.CerrarConexion();
                return true;
            }                
            catch
            {
                return false;
            }
        }
        public void registrarEmpresa(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();
            var nombreEmpresa = this.nombreEmpresa.Text.Trim();
            var telefonoEmpresa = this.telefonoEmpresa.Text.Trim();
            var direccionEmpresa = this.direccionEmpresa.Text.Trim();
            
            if (verificarDatosEmpresa(nombreEmpresa, direccionEmpresa, telefonoEmpresa) &&
                insertarEmpresa(nombreEmpresa, direccionEmpresa, telefonoEmpresa,idUsuario))
            {
                Verificador.mostrarMensaje("El contacto fue registrado", Page);
                Response.Redirect(url: "ContactoEmpresa.aspx");
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }

        //Vista (Probado)
        public Boolean consultarContactoEmpresa(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String contactoEmpresa = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getContactoEmpresa(" + pIdUsuario + ");");
                IDataReader resultadosQuery = conexion.getResultados();
                contactoEmpresa = crearVistaContacto(resultadosQuery);
                conexion.CerrarConexion();
                GUIBuilder.inyectarHTML(contactoEmpresa, etiqueta);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public String crearVistaContacto(IDataReader reader)
        {
            int contador = 0;
            String contactoEmpresa = "";
            while (reader.Read())
            {
                if (contador % 4 == 0)
                {
                    contactoEmpresa += "<div class = 'row'>";
                }
                contactoEmpresa += "<div class='col-lg-3'>" +
                                "<div class='hpanel hred contact-panel'>" +
                                    "<div class='panel-body'>" +
                                       "<h3><a onclick = 'propuestaVentaXContacto("+ reader[4].ToString() + ")' value = " + reader[0].ToString() + ">" + reader[1].ToString() + "</a></h3>" +
                                       "<div class='text-muted font-bold m-b-xs'>Dirección: " + reader[3].ToString() + "</div>" +
                                       "<div class='text-muted font-bold m-b-xs'>Telefono: " + reader[2].ToString() + "</div>" +
                                   "</div>" +
                                "</div>" +
                            "</div>";
                if (contador % 4 == 3)
                {
                    contactoEmpresa += "</div>";
                }
                contador++;
            }
            return contactoEmpresa;
        }
        public void verContactoEmpresa(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarContactoEmpresa(idUsuario, Element))
            {
                Page_Load(sender, e);
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }

        //Vista de ventas y propuestas (Probado)
        [WebMethod]
        public static String propuestaVentaXContactoJS(int idContactoPersona, Boolean accion)
        {
            String idUsuario = HttpContext.Current.Session["idUsuario"].ToString();
            String vista = "";
            if (accion)
            {
                vista = GUIBuilder.ventaXContacto(idContactoPersona, idUsuario, conexion);
            }
            else
            {
                vista = GUIBuilder.propuestaVentaXContacto(idContactoPersona, idUsuario, conexion);
            }

            return vista;
        }
    }
}