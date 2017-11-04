using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoQA
{
    public class Conexion : IConexion
    {
        private MySqlConnection conexion;
        private MySqlCommand consulta;
        private MySqlDataReader resultados;
        private String servidor;
        private String baseDeDatos;
        private String usuario;
        private String contraseña;
        private String puerto;
        public Conexion(String pServer, String pDatabase, String pUid, String pPassword, String pPort)
        {
            servidor = pServer;
            baseDeDatos = pDatabase;
            usuario = pUid;
            contraseña = pPassword;
            puerto = pPort;
               
            Inicializar();            
        }
        private void Inicializar()
        {
            String conexionString;
            conexionString = "SERVER=" + servidor + "; PORT=" + puerto + "; DATABASE=" +
            baseDeDatos + ";" + "UID=" + usuario + ";" + "PASSWORD=" + contraseña + ";";

            conexion = new MySqlConnection(conexionString);
            consulta = new MySqlCommand();
            consulta.Connection = conexion;
        }
        public Boolean AbrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Close conexion to baseDeDatos
        public Boolean CerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean setCommandText(String comando)
        {
            try
            {
                consulta.CommandText = comando;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IDataReader getResultados()
        {
            resultados = consulta.ExecuteReader();
            return resultados;
        }
        public MySqlConnection getConexion()
        {
            return conexion;
        }

    }
}