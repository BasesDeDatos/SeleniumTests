using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoQA
{
    public partial class RegistroRespuestas : System.Web.UI.Page
    {
        private IConexion conexion;

        public RegistroRespuestas()
        {
            conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
        }
        public RegistroRespuestas(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
        }

        //Registro (Probado)
        public Boolean verificarDatosRespuesta(String pRespuesta, String pEstado, String pFecha)
        {
            if (String.IsNullOrEmpty(pRespuesta))
            {
                Verificador.mostrarMensaje("La respuesta no debe ser vacía", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pEstado))
            {
                Verificador.mostrarMensaje("Debe elegir un estado", Page);
                return false;
            }
            else if (!Verificador.verificarEstado(pEstado))
            {
                Verificador.mostrarMensaje("El estado no es válido", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pFecha))
            {
                Verificador.mostrarMensaje("La fecha no es válida", Page);
                return false;
            }
            else
            {
                return true;
            }

        }
        public Boolean insertarRespuesta(String pRespuesta, String pEstado, String pFecha, String pIdPropuesta)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call updateRespuestaPropuestaVenta('" + pEstado + "','" +
                    pFecha + "','" + pRespuesta + "','" + pIdPropuesta + "');");
                conexion.getResultados();
                conexion.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void registrarRespuesta(object sender, EventArgs e)
        {
            String estado = this.ddEstado.Text.Trim();
            String fecha = this.fecha.Text.Trim();
            String respuesta = this.respuesta.Text.Trim();
            String idPropuesta = Request.QueryString["idPropuesta"].ToString();

            if(verificarDatosRespuesta(respuesta, estado, fecha) &&
                insertarRespuesta(respuesta, estado, fecha, idPropuesta))
            {
                Verificador.mostrarMensaje("La ventas fue registrada", Page);
                Response.Redirect(url: "PropuestaVentas.aspx");
            }
            else
            {
                Verificador.mostrarMensaje(Page);
                Response.Redirect(url: "PropuestaVentas.aspx");
            }
        }
    }
}