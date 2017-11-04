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
    public partial class RegistroVentas : System.Web.UI.Page
    {
        private IConexion conexion;

        public RegistroVentas()
        {
            conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
        }

        public RegistroVentas(IConexion pConexion)
        {
            conexion = pConexion;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            //popularProductos();
        }

        //Registro (Probado)
        public Boolean verificarDatosVenta(String pIdProducto, String pDescuento, String pPorcentajeComision, String pFecha, String pContacto)
        {
            if (String.IsNullOrEmpty(pIdProducto))
            {
                Verificador.mostrarMensaje("Producto inválido", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pContacto))
            {
                Verificador.mostrarMensaje("Cliente inválido", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pDescuento))
            {
                Verificador.mostrarMensaje("Descuento inválido", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pPorcentajeComision))
            {
                Verificador.mostrarMensaje("Comisión inválida", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pFecha))
            {
                Verificador.mostrarMensaje("Fecha inválida", Page);
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean insertarVenta(String pIdProducto, String pDescuento, String pPorcentajeComision, String pFecha, String pContacto, String pIdVendedor)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call insertVenta('" + pIdProducto + "','" + pDescuento + "','" + pPorcentajeComision + 
                                        "','" + pFecha + "','" + pIdVendedor + "','" + pContacto + "');");
                conexion.getResultados();
                conexion.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void registrarVenta(object sender, EventArgs e)
        {
            String idProducto = this.ddIdProducto.Text.Trim();
            String descuento = this.descuento.Text.Trim();
            String comision = this.comision.Text.Trim();
            String fecha = this.fecha.Text.Trim();
            String idContacto = this.ddIdContacto.Text.Trim();
            String idVendedor = Session["idUsuario"].ToString();

            if (verificarDatosVenta(idProducto, descuento, comision, fecha, idContacto) &&
                insertarVenta(idProducto, descuento, comision, fecha, idContacto, idVendedor))
            {
                Verificador.mostrarMensaje("La ventas fue registrada", Page);
                Response.Redirect(url: "RegistroVentas.aspx");
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }

        //Vista (Probado)
        public Boolean consultarVentas(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String ventas = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getVentas('" + pIdUsuario + "');");
                IDataReader resultadosQuery = conexion.getResultados();
                ventas = crearVistaVenta(resultadosQuery);
                conexion.CerrarConexion();
                GUIBuilder.inyectarHTML(ventas, etiqueta);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string crearVistaVenta(IDataReader reader)
        {
            String nombre;
            String descuento;
            String porcentajeComision;
            String fecha;
            String precioFinal;
            String comision;

            String venta = "";
            while (reader.Read())
            {
                nombre = reader[0].ToString();
                descuento = reader[1].ToString();
                porcentajeComision = reader[2].ToString();
                fecha = reader[3].ToString();
                precioFinal = reader[4].ToString();
                comision = reader[5].ToString();
                venta += "<tr>" + 
                            "<td>" + fecha + "</td>" +
                            "<td>" + nombre +"</td>" +
                            "<td>" + descuento +"% </td>" +
                            "<td>" + porcentajeComision +"% </td>" +
                            "<td>" + precioFinal +"$ </td>" +
                            "<td>" + comision + "$ </td>" +
                        "</tr>";
            }
            return venta;
        }
        public void verVentas(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarVentas(idUsuario, vistaVentas))
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
                foreach(KeyValuePair<String, String> c in contactos)
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