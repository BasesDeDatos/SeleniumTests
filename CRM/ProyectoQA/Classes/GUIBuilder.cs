using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoQA.Classes
{
    public static class GUIBuilder
    {
        public static void inyectarHTML(String contactos, HtmlGenericControl etiqueta)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(contactos);
            etiqueta.InnerHtml = stringBuilder.ToString();
        }
        public static List<KeyValuePair<String, String>> getProductos(IConexion pConexion)
        {
            List<KeyValuePair<String, String>> resultado = new List<KeyValuePair<String, String>>();
            pConexion.AbrirConexion();
            pConexion.setCommandText("call getProductos();");
            IDataReader resultadosQuery = pConexion.getResultados();
            while (resultadosQuery.Read())
            {
                resultado.Add(new KeyValuePair<String, String>(resultadosQuery[1].ToString(), resultadosQuery[0].ToString()));
            }
            pConexion.CerrarConexion();
            resultado = resultado.OrderBy(x => x.Key).ToList();
            return resultado;
        }
        public static List<KeyValuePair<String, String>> getEmpresas(String pIdUsuario, IConexion pConexion)
        {
            List<KeyValuePair<String, String>> empresas = new List<KeyValuePair<String, String>>();
            pConexion.AbrirConexion();
            pConexion.setCommandText("call getContactoEmpresa('" + pIdUsuario + "');");
            IDataReader resultadosQuery = pConexion.getResultados();
            while (resultadosQuery.Read())
            {
                empresas.Add(new KeyValuePair<String, String>(resultadosQuery[1].ToString(), resultadosQuery[4].ToString()));
            }
            pConexion.CerrarConexion();
            empresas = empresas.OrderBy(x => x.Key).ToList();
            return empresas;
        }
        public static List<KeyValuePair<String, String>> getPersonas(String pIdUsuario, IConexion pConexion)
        {
            List<KeyValuePair<String, String>> personas = new List<KeyValuePair<String, String>>();
            pConexion.AbrirConexion();
            pConexion.setCommandText("call getContactoPersona('" + pIdUsuario + "');");
            IDataReader resultadosQuery = pConexion.getResultados();
            while (resultadosQuery.Read())
            {
                personas.Add(new KeyValuePair<String, String>(resultadosQuery[1].ToString() + " " + resultadosQuery[2].ToString()
                                                    + " " + resultadosQuery[3].ToString(), resultadosQuery[8].ToString()));
            }
            pConexion.CerrarConexion();
            personas = personas.OrderBy(x => x.Key).ToList();
            return personas;
        }
        public static List<KeyValuePair<String, String>> getContactos(String pIdUsuario, IConexion pConexion)
        {
            List<KeyValuePair<String, String>> contactos = GUIBuilder.getEmpresas(pIdUsuario, pConexion);
            contactos.AddRange(GUIBuilder.getPersonas(pIdUsuario, pConexion));
            contactos = contactos.OrderBy(x => x.Key).ToList();
            return contactos;
        }
        public static String crearVistaPropuestaVentaXContacto(IDataReader reader)
        {
            String nombre;
            String fecha;
            String precio;
            String estado;

            String propuestaVentaXContacto = "";
            while (reader.Read())
            {
                nombre = reader[0].ToString();
                fecha = reader[2].ToString();
                precio = reader[1].ToString();
                estado = reader[3].ToString();

                propuestaVentaXContacto += "<tr>" +
                            "<td>" + fecha + "</td>" +
                            "<td>" + nombre + "</td>" +
                            "<td>" + precio + "$ </td>" +
                            "<td>" + estado + "</td>" +
                        "</tr>";
            }
            return propuestaVentaXContacto;
        }
        public static String crearVistaVentaXContacto(IDataReader reader)
        {
            String nombre;
            String fecha;
            String precio;


            String ventaXContacto = "";
            while (reader.Read())
            {
                nombre = reader[0].ToString();
                fecha = reader[1].ToString();
                precio = reader[2].ToString();


                ventaXContacto += "<tr>" +
                            "<td>" + fecha + "</td>" +
                            "<td>" + nombre + "</td>" +
                            "<td>" + precio + "$ </td>" +
                        "</tr>";
            }
            return ventaXContacto;
        }
        public static String propuestaVentaXContacto(int idContactoPersona, String pIdUsuario, IConexion pConexion)
        {
            String propuestaVentaXContacto = "";

            pConexion.AbrirConexion();
            pConexion.setCommandText("call getPropuestaVentaXContacto(" + pIdUsuario.ToString() + ", "
                                        + idContactoPersona.ToString() + ");");
            IDataReader resultadosQuery = pConexion.getResultados();
            propuestaVentaXContacto = crearVistaPropuestaVentaXContacto(resultadosQuery);
            pConexion.CerrarConexion();
            return propuestaVentaXContacto;
        }
        public static String ventaXContacto(int idContactoPersona, String pIdUsuario, IConexion pConexion)
        {
            String ventaXContacto = "";

            pConexion.AbrirConexion();
            pConexion.setCommandText("call getVentaXContacto(" + pIdUsuario + ", "
                                        + idContactoPersona.ToString() + ");");
            IDataReader resultadosQuery = pConexion.getResultados();
            ventaXContacto = crearVistaVentaXContacto(resultadosQuery);
            pConexion.CerrarConexion();
            return ventaXContacto;
        }
    }
}