using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Cadeteria
    {
        public string Nombre { get; }
        public string Telefono { get; }
        public List<Cadete> Cadetes { get; }

        public Cadeteria(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
            Cadetes = new List<Cadete>();
        }

        public void CargarDatosDesdeCSV(string archivoCadetes, string archivoPedidos)
        {
            // Implementar la lógica para cargar datos desde los archivos CSV
        }

        public void AsignarPedidoACadete(Pedido pedido, Cadete cadete)
        {
            cadete.AsignarPedido(pedido);
        }

        public void ReasignarPedidoACadete(Pedido pedido, Cadete nuevoCadete, Cadete cadeteAnterior)
        {
            cadeteAnterior.ReasignarPedido(pedido);
            nuevoCadete.AsignarPedido(pedido);
        }

        public void MostrarInformeFinal()
        {
            Console.WriteLine("Informe final de la jornada:");
            foreach (var cadete in Cadetes)
            {
                Console.WriteLine($"Cadete: {cadete.Nombre} - Envíos: {cadete.Pedidos.Count} - Monto ganado: {cadete.CalcularJornalACobrar()}");
            }
            double promedioEnvios = Cadetes.Count > 0 ? Cadetes.Sum(c => c.Pedidos.Count) / (double)Cadetes.Count : 0;
            Console.WriteLine($"Envíos promedio por cadete: {promedioEnvios:F2}");
        }
    }





}
