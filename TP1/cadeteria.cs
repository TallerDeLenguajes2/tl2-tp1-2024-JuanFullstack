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
            try
            {
                // Cargar datos de los cadetes
                using (StreamReader srCadetes = new StreamReader(archivoCadetes))
                {
                    string lineaCadete;
                    while ((lineaCadete = srCadetes.ReadLine()) != null)
                    {
                        string[] datosCadete = lineaCadete.Split(',');
                        if (datosCadete.Length >= 4) // Asegurarse de que hay suficientes columnas
                        {
                            string nombre = datosCadete[1];
                            string direccion = datosCadete[2];
                            string telefono = datosCadete[3];

                            Cadete nuevoCadete = new Cadete(nombre, direccion, telefono);
                            Cadetes.Add(nuevoCadete);
                        }
                    }
                }

                // Cargar datos de los pedidos
                using (StreamReader srPedidos = new StreamReader(archivoPedidos))
                {
                    string lineaPedido;
                    while ((lineaPedido = srPedidos.ReadLine()) != null)
                    {
                        string[] datosPedido = lineaPedido.Split(',');
                        if (datosPedido.Length >= 7) // Asegurarse de que hay suficientes columnas
                        {
                            string observacion = datosPedido[1];
                            string nombreCliente = datosPedido[2];
                            string direccionCliente = datosPedido[3];
                            string telefonoCliente = datosPedido[4];
                            string datosReferencia = datosPedido[5];
                            string estado = datosPedido[6];
                            int idCadete = int.Parse(datosPedido[7]);

                            // Crear cliente
                            Cliente cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);

                            // Crear pedido
                            Pedido nuevoPedido = new Pedido(observacion, cliente);
                            nuevoPedido.CambiarEstado(estado);

                            // Asignar el pedido al cadete correspondiente
                            Cadete cadeteAsignado = Cadetes.Find(c => c.Id == idCadete);
                            if (cadeteAsignado != null)
                            {
                                cadeteAsignado.AsignarPedido(nuevoPedido);
                            }
                            else
                            {
                                Console.WriteLine($"Cadete con ID {idCadete} no encontrado para el pedido {nuevoPedido.NumeroPedido}");
                            }
                        }
                    }
                }
                Console.WriteLine("Datos cargados correctamente desde los archivos CSV.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al cargar datos desde archivos CSV: {e.Message}");
            }
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
