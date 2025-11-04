using System;
using System.Collections.Generic;

// Ejercicio 1)

public class ProduccionEventArgs : EventArgs
{
    public string NombreProducto { get; set; }
    public TimeSpan TiempoProduccion { get; set; }
}

public class ProcesoProduccion
{
    public event EventHandler ProduccionCompletada;

    public void IniciarProduccion(string nombreProducto, TimeSpan tiempoProduccion)
    {
        ProduccionEventArgs args = new ProduccionEventArgs
        {
            NombreProducto = nombreProducto,
            TiempoProduccion = tiempoProduccion
        };

        ProduccionCompletada?.Invoke(this, args);
    }
}

public class ServicioNotificacion
{
    public void OnProduccionCompletada(object sender, EventArgs e)
    {
        ProduccionEventArgs args = e as ProduccionEventArgs;
        Console.WriteLine($"Notificación: {args.NombreProducto} completado en {args.TiempoProduccion.TotalSeconds} segundos");
    }
}

public class ServicioRegistroProduccion
{
    public void OnProduccionCompletada(object sender, EventArgs e)
    {
        ProduccionEventArgs args = e as ProduccionEventArgs;
        Console.WriteLine($"Registro: {args.NombreProducto} - Tiempo: {args.TiempoProduccion.TotalSeconds}s");
    }
}

// Ejercicio 2)

public class TransmisionEventArgs : EventArgs
{
    public string TituloEvento { get; set; }
    public TimeSpan Duracion { get; set; }
}

public class ControlTransmision
{
    public event EventHandler TransmisionFinalizada;

    public void FinalizarTransmision(string titulo, TimeSpan duracion)
    {
        TransmisionEventArgs args = new TransmisionEventArgs
        {
            TituloEvento = titulo,
            Duracion = duracion
        };

        TransmisionFinalizada?.Invoke(this, args);
    }
}

public class ServicioNotificacionUsuario
{
    public void OnTransmisionFinalizada(object sender, EventArgs e)
    {
        TransmisionEventArgs args = e as TransmisionEventArgs;
        Console.WriteLine($"Notificación Usuario: La transmisión '{args.TituloEvento}' finalizó");
    }
}

public class ServicioRegistroEventos
{
    public void OnTransmisionFinalizada(object sender, EventArgs e)
    {
        TransmisionEventArgs args = e as TransmisionEventArgs;
        Console.WriteLine($"Registro Eventos: {args.TituloEvento} - Duración: {args.Duracion.TotalMinutes} minutos");
    }
}

// Ejercicio 3)

public class PedidoEventArgs : EventArgs
{
    public string NombreCliente { get; set; }
    public List<string> DetallesArticulos { get; set; }
}

public class GestorPedidos
{
    public event EventHandler PedidoConfirmado;

    public void ConfirmarPedido(string nombreCliente, List<string> articulos)
    {
        PedidoEventArgs args = new PedidoEventArgs
        {
            NombreCliente = nombreCliente,
            DetallesArticulos = articulos
        };

        PedidoConfirmado?.Invoke(this, args);
    }
}

public class ServicioCocina
{
    public void OnPedidoConfirmado(object sender, EventArgs e)
    {
        PedidoEventArgs args = e as PedidoEventArgs;
        Console.WriteLine($"Cocina: Preparando pedido para {args.NombreCliente}");
    }
}

public class ServicioNotificacionCliente
{
    public void OnPedidoConfirmado(object sender, EventArgs e)
    {
        PedidoEventArgs args = e as PedidoEventArgs;
        Console.WriteLine($"Notificación Cliente: {args.NombreCliente}, su pedido está confirmado");
    }
}

// Ejercicio 4)

public class StockEventArgs : EventArgs
{
    public string NombreProducto { get; set; }
    public int NivelActual { get; set; }
}

public class ControlStock
{
    public event EventHandler StockBajo;

    public void VerificarStock(string nombreProducto, int nivelActual, int minimoPermitido)
    {
        if (nivelActual < minimoPermitido)
        {
            StockEventArgs args = new StockEventArgs
            {
                NombreProducto = nombreProducto,
                NivelActual = nivelActual
            };

            StockBajo?.Invoke(this, args);
        }
    }
}

public class ServicioPedidoReposicion
{
    public void OnStockBajo(object sender, EventArgs e)
    {
        StockEventArgs args = e as StockEventArgs;
        Console.WriteLine($"Reposición: Generando pedido para '{args.NombreProducto}'");
    }
}

public class ServicioAlertaStock
{
    public void OnStockBajo(object sender, EventArgs e)
    {
        StockEventArgs args = e as StockEventArgs;
        Console.WriteLine($"Alerta Stock: {args.NombreProducto} tiene nivel bajo: {args.NivelActual}");
    }
}

// Ejercicio 5)

public class ReservaEventArgs : EventArgs
{
    public string NombreCliente { get; set; }
    public string TipoHabitacion { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
}

public class GestorReservas
{
    public event EventHandler ReservaConfirmada;

    public void ConfirmarReserva(string nombreCliente, string tipoHabitacion, DateTime entrada, DateTime salida)
    {
        ReservaEventArgs args = new ReservaEventArgs
        {
            NombreCliente = nombreCliente,
            TipoHabitacion = tipoHabitacion,
            FechaEntrada = entrada,
            FechaSalida = salida
        };

        ReservaConfirmada?.Invoke(this, args);
    }
}

public class ServicioLimpieza
{
    public void OnReservaConfirmada(object sender, EventArgs e)
    {
        ReservaEventArgs args = e as ReservaEventArgs;
        Console.WriteLine($"Limpieza: Programada para {args.TipoHabitacion} el {args.FechaEntrada:yyyy-MM-dd}");
    }
}

public class ServicioNotificacionReserva
{
    public void OnReservaConfirmada(object sender, EventArgs e)
    {
        ReservaEventArgs args = e as ReservaEventArgs;
        Console.WriteLine($"Notificación: {args.NombreCliente}, reserva confirmada del {args.FechaEntrada:yyyy-MM-dd} al {args.FechaSalida:yyyy-MM-dd}");
    }
}

// Ejercicio 6)

public class Tecnico
{
    public string Nombre { get; set; }
    public string Especialidad { get; set; }
}

public class IncidenciaEventArgs : EventArgs
{
    public int IdIncidencia { get; set; }
    public string Cliente { get; set; }
    public string Descripcion { get; set; }
}

public class GestorIncidencias
{
    public event EventHandler IncidenciaReportada;

    public void ReportarIncidencia(int id, string cliente, string descripcion)
    {
        IncidenciaEventArgs args = new IncidenciaEventArgs
        {
            IdIncidencia = id,
            Cliente = cliente,
            Descripcion = descripcion
        };

        IncidenciaReportada?.Invoke(this, args);
    }
}

public class ServicioTecnico
{
    private Tecnico[] tecnicos = new Tecnico[]
    {
        new Tecnico { Nombre = "Carlos López", Especialidad = "Hardware" },
        new Tecnico { Nombre = "María García", Especialidad = "Software" },
        new Tecnico { Nombre = "Juan Martínez", Especialidad = "Red" }
    };

    private Random random = new Random();

    public void OnIncidenciaReportada(object sender, EventArgs e)
    {
        IncidenciaEventArgs args = e as IncidenciaEventArgs;
        Tecnico tecnico = tecnicos[random.Next(tecnicos.Length)];
        Console.WriteLine($"Técnico: Incidencia #{args.IdIncidencia} asignada a {tecnico.Nombre}");
    }
}

public class ServicioNotificacionClienteIncidencia
{
    public void OnIncidenciaReportada(object sender, EventArgs e)
    {
        IncidenciaEventArgs args = e as IncidenciaEventArgs;
        Console.WriteLine($"Notificación Cliente: {args.Cliente}, incidencia #{args.IdIncidencia} recibida");
    }
}

public class ServicioRegistroIncidencias
{
    private List<string> baseDatos = new List<string>();

    public void OnIncidenciaReportada(object sender, EventArgs e)
    {
        IncidenciaEventArgs args = e as IncidenciaEventArgs;
        string registro = $"ID: {args.IdIncidencia} - Cliente: {args.Cliente} - Descripción: {args.Descripcion}";
        baseDatos.Add(registro);
        Console.WriteLine($"Registro: {registro}");
    }
}

// Main 

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Ejercicio 1 ===\n");
        ProcesoProduccion proceso = new ProcesoProduccion();
        ServicioNotificacion notificacion = new ServicioNotificacion();
        ServicioRegistroProduccion registro = new ServicioRegistroProduccion();

        proceso.ProduccionCompletada += notificacion.OnProduccionCompletada;
        proceso.ProduccionCompletada += registro.OnProduccionCompletada;

        proceso.IniciarProduccion("Widget A", TimeSpan.FromSeconds(5));

        Console.WriteLine("\n=== Ejercicio 2 ===\n");
        ControlTransmision transmision = new ControlTransmision();
        ServicioNotificacionUsuario notifUsuario = new ServicioNotificacionUsuario();
        ServicioRegistroEventos registroEventos = new ServicioRegistroEventos();

        transmision.TransmisionFinalizada += notifUsuario.OnTransmisionFinalizada;
        transmision.TransmisionFinalizada += registroEventos.OnTransmisionFinalizada;

        transmision.FinalizarTransmision("Concierto Live", TimeSpan.FromMinutes(120));

        Console.WriteLine("\n=== Ejercicio 3 ===\n");
        GestorPedidos gestor = new GestorPedidos();
        ServicioCocina cocina = new ServicioCocina();
        ServicioNotificacionCliente notifCliente = new ServicioNotificacionCliente();

        gestor.PedidoConfirmado += cocina.OnPedidoConfirmado;
        gestor.PedidoConfirmado += notifCliente.OnPedidoConfirmado;

        var articulos = new List<string> { "Pizza", "Refresco" };
        gestor.ConfirmarPedido("José García", articulos);

        Console.WriteLine("\n=== Ejercicio 4 ===\n");
        ControlStock control = new ControlStock();
        ServicioPedidoReposicion reposicion = new ServicioPedidoReposicion();
        ServicioAlertaStock alerta = new ServicioAlertaStock();

        control.StockBajo += reposicion.OnStockBajo;
        control.StockBajo += alerta.OnStockBajo;

        control.VerificarStock("Laptop", 3, 10);

        Console.WriteLine("\n=== Ejercicio 5 ===\n");
        GestorReservas gestorReservas = new GestorReservas();
        ServicioLimpieza limpieza = new ServicioLimpieza();
        ServicioNotificacionReserva notifReserva = new ServicioNotificacionReserva();

        gestorReservas.ReservaConfirmada += limpieza.OnReservaConfirmada;
        gestorReservas.ReservaConfirmada += notifReserva.OnReservaConfirmada;

        gestorReservas.ConfirmarReserva("Ana Martínez", "Suite",
            new DateTime(2025, 12, 15), new DateTime(2025, 12, 20));

        Console.WriteLine("\n=== Ejercicio 6 ===\n");
        GestorIncidencias gestorIncidencias = new GestorIncidencias();
        ServicioTecnico servTecnico = new ServicioTecnico();
        ServicioNotificacionClienteIncidencia notifIncidencia = new ServicioNotificacionClienteIncidencia();
        ServicioRegistroIncidencias registroIncidencias = new ServicioRegistroIncidencias();

        gestorIncidencias.IncidenciaReportada += servTecnico.OnIncidenciaReportada;
        gestorIncidencias.IncidenciaReportada += notifIncidencia.OnIncidenciaReportada;
        gestorIncidencias.IncidenciaReportada += registroIncidencias.OnIncidenciaReportada;

        gestorIncidencias.ReportarIncidencia(1001, "Pedro López", "La impresora no funciona");
    }
}