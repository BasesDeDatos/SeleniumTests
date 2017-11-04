using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoQA
{
    public interface IConexion
    {
        Boolean AbrirConexion();
        Boolean CerrarConexion();
        Boolean setCommandText(String comando);
        IDataReader getResultados();
    }
}
