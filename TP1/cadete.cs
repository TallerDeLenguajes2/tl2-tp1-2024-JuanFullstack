using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Cadete
    {
        public int Id { get; }
        public string Nombre { get; }
        public string Direccion { get; }
        public string Telefono { get; }
        public List<Pedido> Pedidos { get; }

        private static int nextId = 1;

        public Cadete(string nombre, string direccion, string telefono)
        {
            Id = nextId++;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Pedidos = new List<Pedido>();
        }

        public void AsignarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }

        public void ReasignarPedido(Pedido pedido)
        {
            Pedidos.Remove(pedido);
        }

        public int CalcularJornalACobrar()
        {
            return Pedidos.Count * 500; // Calcula el jornal basado en el número de pedidos
        }
    }








}
