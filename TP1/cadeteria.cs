using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Cadeteria
    {
        // Propiedades de solo lectura
        public string Nombre { get; }
        public string Telefono { get; }
        public List<Cadete> Cadetes { get; } // Cambio a plural y uso del nombre de clase correcto

        // Constructor
        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
        {
            Nombre = nombre;
            Telefono = telefono;
            Cadetes = cadetes; // Asignación de la lista de cadetes
        }
    }






}
