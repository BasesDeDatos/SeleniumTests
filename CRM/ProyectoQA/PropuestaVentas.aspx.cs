using MySql.Data.MySqlClient;
using ProyectoQA.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoQA
{
    public partial class PropuestaVentas : System.Web.UI.Page
    {
        private IConexion conexion;

        public PropuestaVentas()
        {
            conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
        }
        public PropuestaVentas(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
        }

        //Registro (Probado)
        public Boolean verificarDatosPropuesta(String pIdProducto, String pPrecio, String pFecha, String pContacto)
        {
            if (String.IsNullOrEmpty(pIdProducto))
            {
                Verificador.mostrarMensaje("Producto inválido", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pPrecio))
            {
                Verificador.mostrarMensaje("Precio inválido", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pFecha))
            {
                Verificador.mostrarMensaje("Fecha inválida", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pContacto))
            {
                Verificador.mostrarMensaje("Contacto inválido", Page);
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean insertarPropuestaVenta(String pIdProducto, String pPrecio, String pFecha, String pContacto, String pIdVendedor)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call insertPropuestaVenta('" + pIdProducto + "','" +
                                            pFecha + "','" + pPrecio + "','" + pIdVendedor + "','" + pContacto + "');");
                conexion.getResultados();
                conexion.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void registrarPropuestaVenta(object sender, EventArgs e)
        {
            String idProducto = this.ddIdProducto.Text.Trim();
            String precio = this.precio.Text.Trim();
            String fecha = this.fecha.Text.Trim();
            String idContacto = this.ddIdContacto.Text.Trim();
            String idVendedor = Session["idUsuario"].ToString();

            if (verificarDatosPropuesta(idProducto, precio, fecha, idContacto) &&
                insertarPropuestaVenta(idProducto, precio, fecha, idContacto, idVendedor))
            {
                Verificador.mostrarMensaje("La propuestaVentas fue registrada", Page);
                Response.Redirect(url: "PropuestaVentas.aspx");
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }

        //Vista (Probado)
        public Boolean consultarPropuestaVenta(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String propuestaVentas = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getPropuestaVenta('" + pIdUsuario + "');");
                IDataReader resultadosQuery = conexion.getResultados();
                propuestaVentas = crearVistaPropuestaVenta(resultadosQuery);
                conexion.CerrarConexion();
                GUIBuilder.inyectarHTML(propuestaVentas, etiqueta);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public String crearVistaPropuestaVenta(IDataReader reader)
        {
            String nombre;
            String fecha;
            String precio;
            String estado;
            String idPropuesta;

            String propuestaVenta = "";
            while (reader.Read())
            {
                nombre = reader[0].ToString();
                fecha = reader[2].ToString();
                precio = reader[1].ToString();
                estado = reader[4].ToString();
                idPropuesta = reader[3].ToString();
                propuestaVenta += "<tr>" +
                            "<td>" + fecha + "</td>" +
                            "<td>" + nombre + "</td>" +
                            "<td>" + precio + "$ </td>" +
                            "<td>" + estado + "</td>" +
                            "<td>" + "<a href='RegistroRespuestas.aspx?idPropuesta=" + idPropuesta + "'>Editar respuesta</a>" + "</td>" +
                        "</tr>";
            }
            return propuestaVenta;
        }
        public void verPropuestaVentas(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarPropuestaVenta(idUsuario, vistaPropuestaVentas))
            {
                Page_Load(sender, e);
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }

        //SelectBox (Probado)
        public void popularProductos(object sender, EventArgs e)
        {
            try
            {
                List<KeyValuePair<String, String>> productos = GUIBuilder.getProductos(conexion);
                foreach (KeyValuePair<String, String> p in productos)
                {
                    ddIdProducto.Items.Add(new ListItem(p.Key, p.Value));
                }
                ddIdProducto.Items.Insert(0, new ListItem("Seleccione un producto", ""));
            }
            catch
            {
                Verificador.mostrarMensaje(Page);
            }
        }
        public void popularContactos(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();
            try
            {
                List<KeyValuePair<String, String>> contactos = GUIBuilder.getContactos(idUsuario, conexion);
                foreach (KeyValuePair<String, String> c in contactos)
                {
                    ddIdContacto.Items.Add(new ListItem(c.Key, c.Value));
                }
                ddIdContacto.Items.Insert(0, new ListItem("Seleccione un contacto", ""));
            }
            catch
            {
                Verificador.mostrarMensaje(Page);
            }

        }
    }
}