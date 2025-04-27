using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class ConectarDB
    {

        private const string Servidor = "Alan";
        private const string BaseDatos = "DISTRIBUIDORA";
        private const string Usuario = "admin";
        private const string Password = "admin";

        public static string cadenaConexion => $"Data Source={Servidor}; " +
                                               $"Initial Catalog={BaseDatos}; " +
                                               $"User={Usuario}; Password={Password}";

    }
}
