using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.SessionState;

namespace ProyectoQA
{
    public partial class Autenticacion : System.Web.UI.Page
    {
        private IConexion conexion;

        public Autenticacion()
        {
            conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
        }
        public Autenticacion(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
        }
        public void registrarRef(object sender, EventArgs e)
        {
            Response.Redirect(url: "Registro.aspx");
        }

        //Autenticación
        public void autenticar(String pUsername, String pPassword)
        {
            conexion.AbrirConexion();
            conexion.setCommandText("call getIdUsuario('" + pUsername + "','" + pPassword + "');");
            IDataReader resultado = conexion.getResultados();
            if (resultado.Read())
            {
                Session["idUsuario"] = resultado.GetInt64(0);
                Response.Redirect("ContactoPersona.aspx");
            }
            else
            {
                Verificador.mostrarMensaje("Acceso denegado", Page);
            }
            conexion.CerrarConexion();
        }
        protected void ingresar(object sender, EventArgs e)
        {
            String username = textUsername.Text;
            String pass = textPassword.Text;

            try
            {
                autenticar(username, pass);
            }
            catch
            {
                Verificador.mostrarMensaje(Page);
            }
            
        }
    }
}