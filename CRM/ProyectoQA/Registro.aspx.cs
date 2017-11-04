using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;

namespace ProyectoQA
{
    public partial class Registro : System.Web.UI.Page
    {
        private IConexion conexion;
        public Registro()
        {
            conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
        }
        public Registro(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
        }
        public void loginRef(object sender, EventArgs e)
        {
            Response.Redirect(url: "Autenticacion.aspx");
        }

        //Registro
        public Boolean verificarCorreoDuplicado(String correoUsuario)
        {
            Boolean resultado;
            if (conexion.AbrirConexion() &&
               conexion.setCommandText("call getUsuario('" + correoUsuario + "');"))
            {
                IDataReader resultadosQuery = conexion.getResultados();

                if (resultadosQuery != null 
                    && resultadosQuery.Read())
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
                conexion.CerrarConexion();
                return resultado;
            }
            else
            {
                Verificador.mostrarMensaje(Page);
                return false;
            }
        }
        public Boolean verificarDatosUsuario(String pCorreoUsuario, String pContrasena, String pContrasenaAux)
        {
            if (!Verificador.verificarCorreo(pCorreoUsuario))
            {
                Verificador.mostrarMensaje("Correo Vacío o formato erróneo", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pCorreoUsuario))
            {
                Verificador.mostrarMensaje("Correo electrónico no puede ser vacío", Page);
                return false;
            }
            else if (!verificarCorreoDuplicado(pCorreoUsuario))
            {
                Verificador.mostrarMensaje("Correo electrónico ya existente", Page);
                return false;
            }
            else if (!Verificador.verificarLargoContrasena(pContrasena))
            {
                Verificador.mostrarMensaje("Largo de contraseña corto, digite 6 o mas caracteres para su contraseña", Page);
                return false;
            }
            else if (!pContrasena.Equals(pContrasenaAux))
            {
                Verificador.mostrarMensaje("Contraseñas no son iguales, digitelas de nuevo.", Page);
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean insertarUsuario(String pCorreoUsuario, String pContrasena)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call insertUsuario('" + pCorreoUsuario + "','" + pContrasena + "');");
                conexion.getResultados();
                conexion.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }            
        }
        public void registrarUsuario(object sender, EventArgs e)
        {
            var correoUsuario = correoUsuarioRegistrar.Text.Trim();
            var contrasena = contrasenaRegistrar.Text;
            var contrasenaAux = contrasenaConfirmarRegistrar.Text;

            if (verificarDatosUsuario(correoUsuario, contrasena, contrasenaAux) &&
                insertarUsuario(correoUsuario, contrasena))
            {
                MessageBox.Show("Se ha registrado con éxito");
                Response.Redirect(url: "Autenticacion.aspx");
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }
    }
}