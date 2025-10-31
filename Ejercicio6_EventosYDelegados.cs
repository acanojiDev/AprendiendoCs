using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6_EventosYDelegados
{
        // ========== EJERCICIO 1: Sistema de Registro y Notificación de Ventas ==========

        // EventArgs personalizado para ventas
        public class VentaEventArgs : EventArgs
        {
            public string Producto { get; set; }
            public decimal Precio { get; set; }

            public VentaEventArgs(string producto, decimal precio)
            {
                Producto = producto;
                Precio = precio;
            }
        }

        // Clase emisora del evento
        public class RegistroVentas
        {
            // Declaración del evento
            public event EventHandler<VentaEventArgs> VentaRealizada;

            // Método para procesar venta
            public void ProcesarVenta(string producto, decimal precio)
            {
                Console.WriteLine($"\n--- Procesando venta de {producto} ---");

                // Emitir el evento
                OnVentaRealizada(new VentaEventArgs(producto, precio));
            }

            // Método protegido para invocar el evento
            protected virtual void OnVentaRealizada(VentaEventArgs e)
            {
                VentaRealizada?.Invoke(this, e);
            }
        }

        // Servicio de registro
        public class ServicioRegistro
        {
            public void RegistrarVenta(object sender, VentaEventArgs e)
            {
                Console.WriteLine($"[REGISTRO] Venta registrada: {e.Producto} - {e.Precio:C}");
            }
        }

        // Servicio de notificación
        public class ServicioNotificacion
        {
            public void EnviarNotificacionVenta(object sender, VentaEventArgs e)
            {
                Console.WriteLine($"[NOTIFICACIÓN] Se ha vendido {e.Producto} por {e.Precio:C}");
            }
        }

        // ========== EJERCICIO 2: Sistema de Control de Temperatura ==========

        public class TemperaturaEventArgs : EventArgs
        {
            public double TemperaturaActual { get; set; }
            public double Umbral { get; set; }

            public TemperaturaEventArgs(double temperaturaActual, double umbral)
            {
                TemperaturaActual = temperaturaActual;
                Umbral = umbral;
            }
        }

        public class ControlTemperatura
        {
            public event EventHandler<TemperaturaEventArgs> TemperaturaAlta;
            private double umbralTemperatura;

            public ControlTemperatura(double umbral)
            {
                umbralTemperatura = umbral;
            }

            public void VerificarTemperatura(double temperatura)
            {
                Console.WriteLine($"\n--- Verificando temperatura: {temperatura}°C ---");

                if (temperatura > umbralTemperatura)
                {
                    OnTemperaturaAlta(new TemperaturaEventArgs(temperatura, umbralTemperatura));
                }
                else
                {
                    Console.WriteLine("Temperatura dentro del rango normal.");
                }
            }

            protected virtual void OnTemperaturaAlta(TemperaturaEventArgs e)
            {
                TemperaturaAlta?.Invoke(this, e);
            }
        }

        public class ServicioAlerta
        {
            public void EnviarAlerta(object sender, TemperaturaEventArgs e)
            {
                Console.WriteLine($"[ALERTA] ¡Temperatura excesiva! {e.TemperaturaActual}°C supera el umbral de {e.Umbral}°C");
            }
        }

        public class ServicioRegistroTemperatura
        {
            public void RegistrarTemperatura(object sender, TemperaturaEventArgs e)
            {
                Console.WriteLine($"[REGISTRO] Temperatura registrada: {e.TemperaturaActual}°C (Umbral: {e.Umbral}°C) - {DateTime.Now:HH:mm:ss}");
            }
        }

        // ========== EJERCICIO 3: Sistema de Backup y Notificación ==========

        public class BackupEventArgs : EventArgs
        {
            public string NombreArchivo { get; set; }
            public DateTime Fecha { get; set; }

            public BackupEventArgs(string nombreArchivo, DateTime fecha)
            {
                NombreArchivo = nombreArchivo;
                Fecha = fecha;
            }
        }

        public class GestorBackups
        {
            public event EventHandler<BackupEventArgs> BackupCompletado;

            public void RealizarBackup(string nombreArchivo)
            {
                Console.WriteLine($"\n--- Realizando backup de {nombreArchivo} ---");

                // Simular proceso de backup
                System.Threading.Thread.Sleep(500);

                OnBackupCompletado(new BackupEventArgs(nombreArchivo, DateTime.Now));
            }

            protected virtual void OnBackupCompletado(BackupEventArgs e)
            {
                BackupCompletado?.Invoke(this, e);
            }
        }

        public class ServicioNotificacionBackup
        {
            public void NotificarBackup(object sender, BackupEventArgs e)
            {
                Console.WriteLine($"[NOTIFICACIÓN] Backup completado: {e.NombreArchivo} el {e.Fecha:dd/MM/yyyy HH:mm:ss}");
            }
        }

        public class ServicioLog
        {
            public void RegistrarBackup(object sender, BackupEventArgs e)
            {
                Console.WriteLine($"[LOG] {e.Fecha:yyyy-MM-dd HH:mm:ss} - Backup realizado: {e.NombreArchivo}");
            }
        }

        // ========== EJERCICIO 4: Sistema de Monitoreo de Sensores ==========

        public class IntrusoEventArgs : EventArgs
        {
            public string NombreSensor { get; set; }
            public DateTime HoraDeteccion { get; set; }

            public IntrusoEventArgs(string nombreSensor, DateTime horaDeteccion)
            {
                NombreSensor = nombreSensor;
                HoraDeteccion = horaDeteccion;
            }
        }

        public class SensorMonitoreo
        {
            public event EventHandler<IntrusoEventArgs> AlertaIntruso;
            private int horaInicio = 22; // 10 PM
            private int horaFin = 6;     // 6 AM

            public void VerificarEstado(string nombreSensor, bool estaAbierto)
            {
                Console.WriteLine($"\n--- Verificando sensor: {nombreSensor} ---");

                int horaActual = DateTime.Now.Hour;

                if (estaAbierto && (horaActual >= horaInicio || horaActual < horaFin))
                {
                    OnAlertaIntruso(new IntrusoEventArgs(nombreSensor, DateTime.Now));
                }
                else if (estaAbierto)
                {
                    Console.WriteLine($"Sensor {nombreSensor} abierto en horario permitido.");
                }
                else
                {
                    Console.WriteLine($"Sensor {nombreSensor} cerrado - Todo normal.");
                }
            }

            protected virtual void OnAlertaIntruso(IntrusoEventArgs e)
            {
                AlertaIntruso?.Invoke(this, e);
            }
        }

        public class ServicioAlarma
        {
            public void ActivarAlarma(object sender, IntrusoEventArgs e)
            {
                Console.WriteLine($"[ALARMA] 🚨 ¡ALERTA! Sensor {e.NombreSensor} detectado abierto a las {e.HoraDeteccion:HH:mm:ss}");
                Console.WriteLine("[ALARMA] Activando sirena y notificando a seguridad...");
            }
        }

        public class ServicioRegistroIncidencias
        {
            public void GuardarIncidencia(object sender, IntrusoEventArgs e)
            {
                Console.WriteLine($"[BASE DE DATOS] Incidencia guardada: {e.NombreSensor} - {e.HoraDeteccion:yyyy-MM-dd HH:mm:ss}");
            }
        }

        // ========== EJERCICIO 5: Sistema de Supervisión de Energía ==========

        public class EnergiaEventArgs : EventArgs
        {
            public double ConsumoActual { get; set; }
            public double Umbral { get; set; }

            public EnergiaEventArgs(double consumoActual, double umbral)
            {
                ConsumoActual = consumoActual;
                Umbral = umbral;
            }
        }

        public class MonitorEnergia
        {
            public event EventHandler<EnergiaEventArgs> ConsumoExcesivoDetectado;
            private double umbralConsumo;

            public MonitorEnergia(double umbral)
            {
                umbralConsumo = umbral;
            }

            public void RegistrarConsumo(double consumo)
            {
                Console.WriteLine($"\n--- Registrando consumo: {consumo} kWh ---");

                if (consumo > umbralConsumo)
                {
                    OnConsumoExcesivoDetectado(new EnergiaEventArgs(consumo, umbralConsumo));
                }
                else
                {
                    Console.WriteLine("Consumo dentro del rango normal.");
                }
            }

            protected virtual void OnConsumoExcesivoDetectado(EnergiaEventArgs e)
            {
                ConsumoExcesivoDetectado?.Invoke(this, e);
            }
        }

        public class ServicioNotificacionEnergia
        {
            public void EnviarAdvertencia(object sender, EnergiaEventArgs e)
            {
                Console.WriteLine($"[ADVERTENCIA] Consumo excesivo detectado: {e.ConsumoActual} kWh (Límite: {e.Umbral} kWh)");
            }
        }

        public class ServicioAjusteAutomatizado
        {
            public void AjustarDispositivos(object sender, EnergiaEventArgs e)
            {
                Console.WriteLine($"[AJUSTE AUTOMÁTICO] Reduciendo consumo...");
                Console.WriteLine($"[AJUSTE AUTOMÁTICO] Apagando dispositivos no esenciales para reducir {e.ConsumoActual - e.Umbral:F2} kWh");
            }
        }

        // ========== PROGRAMA PRINCIPAL ==========

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║  EJERCICIOS DE EVENTOS Y DELEGADOS EN C#               | ");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");

                // ===== EJERCICIO 1 =====
                Console.WriteLine("\n\n═══════════════════════════════════════════════════════");
                Console.WriteLine("EJERCICIO 1: Sistema de Registro y Notificación de Ventas");
                Console.WriteLine("═══════════════════════════════════════════════════════");

                RegistroVentas registroVentas = new RegistroVentas();
                ServicioRegistro servicioRegistro = new ServicioRegistro();
                ServicioNotificacion servicioNotificacion = new ServicioNotificacion();

                // Suscribir manejadores
                registroVentas.VentaRealizada += servicioRegistro.RegistrarVenta;
                registroVentas.VentaRealizada += servicioNotificacion.EnviarNotificacionVenta;

                // Procesar ventas
                registroVentas.ProcesarVenta("Laptop HP", 899.99m);
                registroVentas.ProcesarVenta("Mouse Logitech", 25.50m);

                // ===== EJERCICIO 2 =====
                Console.WriteLine("\n\n═══════════════════════════════════════════════════════");
                Console.WriteLine("EJERCICIO 2: Sistema de Control de Temperatura");
                Console.WriteLine("═══════════════════════════════════════════════════════");

                ControlTemperatura controlTemp = new ControlTemperatura(30.0);
                ServicioAlerta servicioAlerta = new ServicioAlerta();
                ServicioRegistroTemperatura servicioRegTemp = new ServicioRegistroTemperatura();

                controlTemp.TemperaturaAlta += servicioAlerta.EnviarAlerta;
                controlTemp.TemperaturaAlta += servicioRegTemp.RegistrarTemperatura;

                controlTemp.VerificarTemperatura(25.0);
                controlTemp.VerificarTemperatura(35.5);

                // ===== EJERCICIO 3 =====
                Console.WriteLine("\n\n═══════════════════════════════════════════════════════");
                Console.WriteLine("EJERCICIO 3: Sistema de Backup y Notificación");
                Console.WriteLine("═══════════════════════════════════════════════════════");

                GestorBackups gestorBackups = new GestorBackups();
                ServicioNotificacionBackup servicioNotifBackup = new ServicioNotificacionBackup();
                ServicioLog servicioLog = new ServicioLog();

                gestorBackups.BackupCompletado += servicioNotifBackup.NotificarBackup;
                gestorBackups.BackupCompletado += servicioLog.RegistrarBackup;

                gestorBackups.RealizarBackup("database.sql");
                gestorBackups.RealizarBackup("documentos.zip");

                // ===== EJERCICIO 4 =====
                Console.WriteLine("\n\n═══════════════════════════════════════════════════════");
                Console.WriteLine("EJERCICIO 4: Sistema de Monitoreo de Sensores");
                Console.WriteLine("═══════════════════════════════════════════════════════");

                SensorMonitoreo sensorMonitoreo = new SensorMonitoreo();
                ServicioAlarma servicioAlarma = new ServicioAlarma();
                ServicioRegistroIncidencias servicioIncidencias = new ServicioRegistroIncidencias();

                sensorMonitoreo.AlertaIntruso += servicioAlarma.ActivarAlarma;
                sensorMonitoreo.AlertaIntruso += servicioIncidencias.GuardarIncidencia;

                sensorMonitoreo.VerificarEstado("Puerta Principal", false);
                sensorMonitoreo.VerificarEstado("Ventana Cocina", true);

                // ===== EJERCICIO 5 =====
                Console.WriteLine("\n\n═══════════════════════════════════════════════════════");
                Console.WriteLine("EJERCICIO 5: Sistema de Supervisión de Energía");
                Console.WriteLine("═══════════════════════════════════════════════════════");

                MonitorEnergia monitorEnergia = new MonitorEnergia(100.0);
                ServicioNotificacionEnergia servicioNotifEnergia = new ServicioNotificacionEnergia();
                ServicioAjusteAutomatizado servicioAjuste = new ServicioAjusteAutomatizado();

                monitorEnergia.ConsumoExcesivoDetectado += servicioNotifEnergia.EnviarAdvertencia;
                monitorEnergia.ConsumoExcesivoDetectado += servicioAjuste.AjustarDispositivos;

                monitorEnergia.RegistrarConsumo(85.5);
                monitorEnergia.RegistrarConsumo(125.8);

                Console.WriteLine("\n\n═══════════════════════════════════════════════════════");
                Console.WriteLine("Todos los ejercicios completados exitosamente");
                Console.WriteLine("═══════════════════════════════════════════════════════");

                Console.WriteLine("\nPresiona cualquier tecla para salir...");
                Console.ReadKey();
        }
    }
}

