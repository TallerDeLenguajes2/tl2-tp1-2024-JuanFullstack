# Sistema para una Cadetería

Este proyecto implementa un sistema para una empresa de cadetería con el objetivo de asignar pedidos a los cadetes, hacer un seguimiento de los pedidos despachados y calcular el jornal correspondiente para cada cadete. El sistema también permite generar informes de actividad de la cadetería.

## Preguntas y Respuestas

### 1. ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?

- **Composición:** La relación entre **Cadetería** y **Cadete** es de composición, ya que los cadetes solo existen en el contexto de la cadetería. Si se elimina la cadetería, los cadetes también deberían eliminarse.

- **Agregación:** La relación entre **Cadete** y **Pedidos** es de agregación. Los pedidos pueden existir independientemente de un cadete en particular, lo que significa que pueden reasignarse a otro cadete sin que se destruya el pedido.

### 2. ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

#### Cadetería

- `AgregarCadete(Cadete cadete)`: Añadir un nuevo cadete a la lista.
- `RemoverCadete(Cadete cadete)`: Eliminar un cadete de la lista.
- `ListarCadetes()`: Obtener un listado de todos los cadetes.
- `AsignarPedido(Cadete cadete, Pedido pedido)`: Asignar un pedido a un cadete específico.

#### Cadete

- `AsignarPedido(Pedido pedido)`: Añadir un pedido al listado de pedidos del cadete.
- `RemoverPedido(Pedido pedido)`: Eliminar un pedido del listado de pedidos.
- `VerJornal()`: Calcular y ver el jornal a cobrar en base a los pedidos asignados.
- `ListarPedidos()`: Obtener un listado de todos los pedidos asignados.

### 3. Teniendo en cuenta los principios de abstracción y ocultamiento, ¿qué atributos, propiedades y métodos deberían ser públicos y cuáles privados?

#### Atributos y Propiedades

- **Privados (`private`):**
  - Atributos que representan datos internos y no deben ser modificados directamente por otras clases.
  - Ejemplos: `Direccion`, `Telefono` en `Cadete`; `ListadoPedidos` en `Cadete`, `ListadoCadetes` en `Cadetería`.

- **Públicos (`public`):**
  - Métodos de acceso y manipulación que deben estar disponibles para otras clases.
  - Ejemplos: `ListarCadetes()`, `AsignarPedido()`, `VerJornal()`.

#### Métodos

- **Privados (`private`):** Métodos que implementan detalles específicos de la funcionalidad interna y no deben ser accesibles desde fuera de la clase (e.g., `calcularDistancia()` si es un cálculo interno).

- **Públicos (`public`):** Métodos que definen la interfaz pública de la clase y deben estar accesibles para otras clases, como `AsignarPedido()` y `CompletarPedido()`.

### 4. ¿Cómo diseñaría los constructores de cada una de las clases?


public Cadeteria(string nombre, string telefono)
{
    Nombre = nombre;  // Inicializa el nombre de la cadetería.
    Telefono = telefono;  // Inicializa el teléfono de la cadetería.
    Cadetes = new List<Cadete>();  // Crea una lista vacía de cadetes para gestionar los cadetes de la cadetería.
}

public Cadete(string nombre, string direccion, string telefono)
{
    Id = nextId++;  // Asigna un identificador único al cadete, incrementando un contador estático (nextId).
    Nombre = nombre;  // Inicializa el nombre del cadete.
    Direccion = direccion;  // Inicializa la dirección del cadete.
    Telefono = telefono;  // Inicializa el teléfono del cadete.
    Pedidos = new List<Pedido>();  // Crea una lista vacía de pedidos que serán asignados al cadete.
}



### 5. ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?

#### Análisis de Responsabilidades (SRP - Single Responsibility Principle)

Cada clase debe tener una única responsabilidad bien definida:

- Si la clase `Cadete` maneja tanto la información del cadete como la lógica de los pedidos, se podría dividir en dos clases:
  - **Cadete:** Para gestionar la información personal del cadete (como nombre, dirección, teléfono, etc.).
  - **GestorDePedidos:** Para manejar la lógica de asignación y gestión de pedidos.

#### Reutilización de Código (Herencia o Composición)

- **Herencia:**
  - Crear una clase base (**Persona**) que contenga atributos comunes, como `Nombre` y `Direccion`, de la cual **Cadete** y **Cliente** hereden.

- **Composición:**
  - Extraer comportamientos reutilizables en una clase separada y utilizarlos mediante composición, lo cual permite un diseño más modular y flexible.

#### Uso de Herencia

- Crear subclases de **Cadete** si existen variaciones con características especiales (por ejemplo, `CadeteSenior` o `CadeteJunior`), permitiendo que cada subclase tenga atributos o métodos específicos adicionales.

#### Interfaz o Clase Abstracta para Pedidos

- Definir una **interfaz** o una **clase abstracta** que represente diferentes tipos de pedidos, permitiendo que los pedidos específicos implementen o extiendan esta estructura. Esto facilita la extensión y modificación del sistema cuando se agreguen nuevos tipos de pedidos en el futuro.
