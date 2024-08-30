using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Cliente
    {

        public string Nombre { get; }
        public string Direccion { get; }
        public string Telefono { get; }
        public string DatosReferencia { get; }

        public Cliente(string nombre, string direccion, string telefono, string datosReferencia)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            DatosReferencia = datosReferencia;
        }
    }



















}
