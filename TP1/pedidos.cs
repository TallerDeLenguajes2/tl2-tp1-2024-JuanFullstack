using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Pedido
    {
        public int NumeroPedido { get; private set; }
        public string Observacion { get; }
        public Cliente Cliente { get; }
        public string Estado { get; private set; }

        private static int nextNumeroPedido = 1;

        public Pedido(string observacion, Cliente cliente)
        {
            NumeroPedido = nextNumeroPedido++;
            Observacion = observacion;
            Cliente = cliente;
            Estado = "Pendiente"; // Estado inicial
        }

        public void CambiarEstado(string nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        public void VerDireccionCliente()
        {
            Console.WriteLine("Dirección del cliente: " + Cliente.Direccion);
        }

        public void VerDatosCliente()
        {
            Console.WriteLine("Datos del cliente:");
            Console.WriteLine("Nombre: " + Cliente.Nombre);
            Console.WriteLine("Dirección: " + Cliente.Direccion);
            Console.WriteLine("Teléfono: " + Cliente.Telefono);
            Console.WriteLine("Datos de Referencia: " + Cliente.DatosReferencia);
        }
    }











}
