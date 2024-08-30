using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Pedidos
    {
        private int NumeroPedido;
        private string Observacion;
        private Cliente Cliente;
        private string Estado;

        public Pedidos(string observacion, Cliente cliente)
        {
            Observacion = observacion;
            Cliente = cliente;
        }

        public void VerDireccionCliente()
        {
            Console.WriteLine("Informe final de la jornada:");
            // Acceso directo a la propiedad
            Console.WriteLine("Dirección del cliente: " + Cliente.Direccion);
        }

        public void VerDatosCliente()
        {
            // Muestra todos los datos del cliente
            Console.WriteLine("Datos del cliente:");
            Console.WriteLine("Nombre: " + Cliente.Nombre);
            Console.WriteLine("Dirección: " + Cliente.Direccion);
            Console.WriteLine("Teléfono: " + Cliente.Telefono);
            Console.WriteLine("Datos de Referencia: " + Cliente.DatosReferencia);
        }
    }












}
