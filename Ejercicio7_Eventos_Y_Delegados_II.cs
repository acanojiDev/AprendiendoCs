using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Ejercicio1.Program;

namespace Ejercicio1
{
    internal class Program
    {
        // EventArgs personalizado para el evento de producción
        public class ProduccionEventArgs : EventArgs
        {
            public string NombreProducto { get; set; }
            public int TiempoProduccion { get; set; }

            public ProduccionEventArgs(string nombreProducto, int tiempoProduccion)
            {
                NombreProducto = nombreProducto;
                TiempoProduccion = tiempoProduccion;
            }
        }

        // Clase principal que simula el proceso de producción
        public class ProcesoProduccion
        {
            // Declaración del evento
            public event EventHandler<ProduccionEventArgs> ProduccionCompletada;

            // Método para iniciar la producción
            public void IniciarProduccion(string nombreProducto, int tiempoProduccion)
            {
                // Simular el proceso de producción
                Console.WriteLine($"Produciendo: {nombreProducto}");

                // Completar producción y disparar el evento
                OnProduccionCompletada(new ProduccionEventArgs(nombreProducto, tiempoProduccion));
            }

            // Método protegido para disparar el evento
            protected virtual void OnProduccionCompletada(ProduccionEventArgs e)
            {
                ProduccionCompletada?.Invoke(this, e);
            }
        }

        // Servicio de notificación
        public class ServicioNotificacion
        {
            public void SuscribirseAProduccion(ProcesoProduccion proceso)
            {
                proceso.ProduccionCompletada += EnviarNotificacion;
            }

            private void EnviarNotificacion(object sender, ProduccionEventArgs e)
            {
                Console.WriteLine($"Notificación: Producción completada de {e.NombreProducto} en {e.TiempoProduccion} minutos");
            }
        }

        // Servicio de registro de producción
        public class ServicioRegistroProduccion
        {
            public void SuscribirseAProduccion(ProcesoProduccion proceso)
            {
                proceso.ProduccionCompletada += GuardarRegistro;
            }

            private void GuardarRegistro(object sender, ProduccionEventArgs e)
            {
                Console.WriteLine($"Registro guardado: {e.NombreProducto} - {e.TiempoProduccion} minutos");
            }
        }
        static void Main(string[] args)
        {
             // Crear instancias
             ProcesoProduccion proceso = new ProcesoProduccion();
             ServicioNotificacion servicioNotificacion = new ServicioNotificacion();
             ServicioRegistroProduccion servicioRegistro = new ServicioRegistroProduccion();

             // Suscribir los servicios al evento
             servicioNotificacion.SuscribirseAProduccion(proceso);
             servicioRegistro.SuscribirseAProduccion(proceso);

             // Iniciar producción
             proceso.IniciarProduccion("Silla", 30);
             proceso.IniciarProduccion("Mesa", 45);
        }
    }
}

namespace Ejercicio2
{
    public class TransmisionEventArgs : EventArgs
    {
        public string Titulo {  get; set; }
        public double Duracion { get; set; }

        public TransmisionEventArgs(string titulo, double duracion)
        {
            Titulo = titulo;
            Duracion = duracion;
        }
    }

    public class ControlTransmision
    {
        public event EventHandler<TransmisionEventArgs> TransmisionFinalizada;

        public void FinalizarTransmision(string titulo, double duracion)
        {
            Console.WriteLine($"Finalizando la transmisión: {titulo}");
            OnTransmisionCompletada(new TransmisionEventArgs(titulo, duracion));
        }

        protected virtual void OnTransmisionCompletada(TransmisionEventArgs e)
        {
            TransmisionFinalizada?.Invoke(this, e);
        }
    }

    public class ServicioNotificacionUsuario
    {
        public void SuscribirseANotificacion(ControlTransmision control)
        {
            control.TransmisionFinalizada += EnviarNotificacion;
        }

        private void EnviarNotificacion(object sender, TransmisionEventArgs e)
        {
            Console.WriteLine($"Notificacion: Transmision de {e.Titulo} finaliza por {e.Duracion} ");
        }
    }

    public class ServicioRegistroEventos
    {
        
    }

    public static void Main()
    {

    }
}