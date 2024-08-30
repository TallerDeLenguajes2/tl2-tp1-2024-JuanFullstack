using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Cadete
    {
        // Propiedades de solo lectura
        public int Id { get; }
        public string Nombre { get; }
        public string Direccion { get; }
        public string Telefono { get; }
        public List<Pedidos> Pedidos { get; }

        // Campo estático para mantener el próximo ID disponible
        private static int nextId = 1;

        // Constructor sin ID como parámetro
        public Cadete(string nombre, string direccion, string telefono, List<Pedidos> pedidos)
        {
            Id = nextId++; // Asigna el ID actual y luego incrementa el valor para el siguiente objeto
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Pedidos = pedidos;
        }

        // Método para calcular el jornal a cobrar
        public int JornalACobrar()
        {
            return Pedidos.Count * 500; // Retorna el número de pedidos multiplicado por el precio fijo
        }
    }









}
