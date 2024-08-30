using System;
using System.Collections.Generic;
using TP1; // Asegúrate de tener el using para el namespace que contiene tus clases.

class Program
{
    static void Main(string[] args)
    {
        // Inicialización de la cadetería con datos de ejemplo o carga desde CSV
        Cadeteria cadeteria = new Cadeteria("Cadetería ABC", "123-456-789");

        // Cargar datos desde archivos CSV (implementa la lógica dentro del método)
        cadeteria.CargarDatosDesdeCSV("cadetes.csv", "pedidos.csv");

        while (true)
        {
            // Mostrar menú de opciones
            Console.WriteLine("Sistema de Gestión de Cadetería");
            Console.WriteLine("1. Dar de alta pedido");
            Console.WriteLine("2. Asignar pedido a cadete");
            Console.WriteLine("3. Cambiar estado de pedido");
            Console.WriteLine("4. Reasignar pedido a otro cadete");
            Console.WriteLine("5. Mostrar informe de la jornada");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();


            switch (opcion)
            {
                case "1":
                    DarDeAltaPedido(cadeteria);
                    break;
                case "2":
                    AsignarPedidoACadete(cadeteria);
                    break;
                case "3":
                    CambiarEstadoPedido(cadeteria);
                    break;
                case "4":
                    ReasignarPedidoACadete(cadeteria);
                    break;
                case "5":
                    cadeteria.MostrarInformeFinal();
                    break;
                case "6":
                    Console.WriteLine("Saliendo del sistema...");
                    return; // Salir del programa
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }

    static void DarDeAltaPedido(Cadeteria cadeteria)
    {
        Console.Write("Ingrese el nombre del cliente: ");
        string nombreCliente = Console.ReadLine();
        Console.Write("Ingrese la dirección del cliente: ");
        string direccionCliente = Console.ReadLine();
        Console.Write("Ingrese el teléfono del cliente: ");
        string telefonoCliente = Console.ReadLine();
        Console.Write("Ingrese los datos de referencia del cliente: ");
        string datosReferencia = Console.ReadLine();

        Cliente nuevoCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);

        Console.Write("Ingrese la observación del pedido: ");
        string observacionPedido = Console.ReadLine();

        Pedido nuevoPedido = new Pedido(observacionPedido, nuevoCliente);

        Console.WriteLine("Pedido dado de alta con éxito.");
    }

    static void AsignarPedidoACadete(Cadeteria cadeteria)
    {
        Console.Write("Ingrese el número de pedido a asignar: ");
        int numeroPedido = int.Parse(Console.ReadLine());

        Pedido pedido = BuscarPedidoPorNumero(cadeteria, numeroPedido);

        if (pedido != null)
        {
            Console.Write("Ingrese el ID del cadete: ");
            int idCadete = int.Parse(Console.ReadLine());

            Cadete cadete = cadeteria.Cadetes.Find(c => c.Id == idCadete);

            if (cadete != null)
            {
                cadeteria.AsignarPedidoACadete(pedido, cadete);
                Console.WriteLine("Pedido asignado con éxito.");
            }
            else
            {
                Console.WriteLine("Cadete no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Pedido no encontrado.");
        }
    }

    static void CambiarEstadoPedido(Cadeteria cadeteria)
    {
        Console.Write("Ingrese el número de pedido a cambiar de estado: ");
        int numeroPedido = int.Parse(Console.ReadLine());

        Pedido pedido = BuscarPedidoPorNumero(cadeteria, numeroPedido);

        if (pedido != null)
        {
            Console.Write("Ingrese el nuevo estado: ");
            string nuevoEstado = Console.ReadLine();
            pedido.CambiarEstado(nuevoEstado);
            Console.WriteLine("Estado del pedido actualizado.");
        }
        else
        {
            Console.WriteLine("Pedido no encontrado.");
        }
    }

    static void ReasignarPedidoACadete(Cadeteria cadeteria)
    {
        Console.Write("Ingrese el número de pedido a reasignar: ");
        int numeroPedido = int.Parse(Console.ReadLine());

        Pedido pedido = BuscarPedidoPorNumero(cadeteria, numeroPedido);

        if (pedido != null)
        {
            Console.Write("Ingrese el ID del cadete actual: ");
            int idCadeteActual = int.Parse(Console.ReadLine());
            Cadete cadeteActual = cadeteria.Cadetes.Find(c => c.Id == idCadeteActual);

            Console.Write("Ingrese el ID del nuevo cadete: ");
            int idNuevoCadete = int.Parse(Console.ReadLine());
            Cadete nuevoCadete = cadeteria.Cadetes.Find(c => c.Id == idNuevoCadete);

            if (cadeteActual != null && nuevoCadete != null)
            {
                cadeteria.ReasignarPedidoACadete(pedido, nuevoCadete, cadeteActual);
                Console.WriteLine("Pedido reasignado con éxito.");
            }
            else
            {
                Console.WriteLine("Cadete(s) no encontrado(s).");
            }
        }
        else
        {
            Console.WriteLine("Pedido no encontrado.");
        }
    }

    static Pedido BuscarPedidoPorNumero(Cadeteria cadeteria, int numeroPedido)
    {
        foreach (var cadete in cadeteria.Cadetes)
        {
            Pedido pedido = cadete.Pedidos.Find(p => p.NumeroPedido == numeroPedido);
            if (pedido != null)
            {
                return pedido;
            }
        }
        return null;
    }
}
