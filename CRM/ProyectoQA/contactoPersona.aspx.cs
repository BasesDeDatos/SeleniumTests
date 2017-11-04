using System;
using System.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.UI.HtmlControls;
using ProyectoQA.Classes;

namespace ProyectoQA
{
    public partial class ContactoPersonaForm : System.Web.UI.Page
    {
        private static IConexion conexion;

        public ContactoPersonaForm()
        {
            conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
        }
        public ContactoPersonaForm(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
        }

        //Registro (Probado)
        public Boolean verificarDatosPersona(String pNombrePersona, String pApellido1Persona, String pDireccionPersona, String pTelefonoPersona, String pCorreoPersona)
        {

            if (String.IsNullOrEmpty(pDireccionPersona))
            {
                Verificador.mostrarMensaje("Dirección inválida", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pApellido1Persona))
            {
                Verificador.mostrarMensaje("El apellido no puede ser vacío", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pNombrePersona))
            {
                Verificador.mostrarMensaje("El nombre no puede ser vacío", Page);
                return false;
            }
            else if (!Verificador.verificarCorreo(pCorreoPersona))
            {
                Verificador.mostrarMensaje("Formato o correo inválido", Page);
                return false;
            }
            else if (!Verificador.verificarNumerosTelefono(pTelefonoPersona))
            {
                Verificador.mostrarMensaje("Telefono inválido", Page);
                return false;
            }
            else if (!Verificador.verificarTamanoTelefono(pTelefonoPersona))
            {
                Verificador.mostrarMensaje("El teléfono debe contener entre 8 y 20 números", Page);
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean insertarPersona(String pNombrePersona, String pApellido1Persona, String pApellido2Persona, String pTelefonoPersona,
                                    String pDireccionPersona, String pDescripcionEmpresaPersona, String pCorreoPersona, String pIDUsuario)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call insertPersona('" + pNombrePersona + "','" + pApellido1Persona + "', '" + pApellido2Persona + "','" +
                                    pTelefonoPersona + "','" + pDireccionPersona + "','" + pDescripcionEmpresaPersona + "','" + pIDUsuario +
                                    "','" + pCorreoPersona + "');");
                conexion.getResultados().Close();
                conexion.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void registrarPersona(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();
            var nombrePersona = this.nombrePersona.Text.Trim();
            var apellido1Persona = this.apellido1Persona.Text.Trim();
            var apellido2Persona = this.apellido2Persona.Text.Trim();
            var correoPersona = this.correoPersona.Text.Trim();
            var telefonoPersona = this.telefonoPersona.Text.Trim();
            var direccionPersona = this.direccionPersona.Text.Trim();
            var descripcionEmpresaPersona = nombreEmpresaPersona.Text.Trim();

            if (verificarDatosPersona(nombrePersona, apellido1Persona, direccionPersona, telefonoPersona, correoPersona) &&
                insertarPersona(nombrePersona, apellido1Persona, apellido2Persona, telefonoPersona,
                                direccionPersona, descripcionEmpresaPersona, correoPersona, idUsuario))
            {
                Verificador.mostrarMensaje("El contacto fue registrado", Page);
                Response.Redirect(url: "ContactoPersona.aspx");
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }       
        }

        //Vista (Probado)
        public Boolean consultarContactoPersona(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String contactoPersona = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getContactoPersona(" + pIdUsuario + ");");
                IDataReader resultadosQuery = conexion.getResultados();
                contactoPersona = crearVistaContacto(resultadosQuery);
                conexion.CerrarConexion();
                GUIBuilder.inyectarHTML(contactoPersona, etiqueta);
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
            string contactoEmpresa = "";
            while (reader.Read())
            {
                if (contador % 4 == 0)
                {
                    contactoEmpresa += "<div class = 'row'>";
                }
                contactoEmpresa += "<div class='col-lg-3'>" +
                                       "<div class='hpanel hyellow contact-panel'>" +
                                           "<div class='panel-body'>" +
                                              "<h3><a onclick =  'propuestaVentaXContacto(" + reader[8].ToString() + ")' value = " + reader[0].ToString() + ">" + reader[1].ToString() + " " + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + "</a></h3>" +
                                              "<div class='text-muted font-bold m-b-xs'>Dirección: " + reader[6].ToString() + "</div>" +
                                              "<div class='text-muted font-bold m-b-xs'>Telefono: " + reader[5].ToString() + "</div>" +
                                              "<div class='text-muted font-bold m-b-xs'>Correo: " + reader[7].ToString() + "</div>" +
                                              "<div class='text-muted font-bold m-b-xs'>Empresa(opcional): " + reader[4].ToString() + "</div>" +
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
        public void verContactoPersona(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarContactoPersona(idUsuario, Element))
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
