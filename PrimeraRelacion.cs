using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT1_UD1
{
    internal class Ejercicio1
    {
        static void Main(string[] args)
        {
            int suma = 0;
            double media = 1;

            Console.WriteLine("Introduce el tamaño del array:");
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            Console.WriteLine("Introduce los elementos del array:");
            for(int i = 0; i<size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                suma += array[i];
            }
            media = (double)suma / size;
            Console.WriteLine($"La suma es: {suma}");
            Console.WriteLine($"La media es: {media}");
        }
    }

    internal class Ejercicio2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce una frase: ");
            String frase = Console.ReadLine();
            int contador_espacios = 0;
            char[] caracteres_frase = frase.ToCharArray();
            for (int i = 0; i < caracteres_frase.Length; i++)
            {
                if (caracteres_frase[i] == ' ')
                {
                    contador_espacios++;
                }
            }
            Console.WriteLine($"La frase contiene {contador_espacios} espacios en blanco.");
        }
    }

    internal class Ejercicio3
    {
        public static int calcular_factorial_recursivo(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * calcular_factorial_recursivo(n - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Calculo el factorial de un numero introducido por teclado: ");
            int factorial = int.Parse(Console.ReadLine());
            long resultado = calcular_factorial_recursivo(factorial);
            Console.WriteLine($"El factorial de {factorial} es: {resultado}");
        }
    }
    
    internal class Ejercicio4
    { 
        public static bool calcularPrimo(int numero)
        {
            bool esPrimo = true;
            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0)
                {
                    esPrimo = false;
                    break;
                }
            }
            return esPrimo;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Introduce un numero para comprobar si es primo: ");
            int numero = int.Parse(Console.ReadLine());
            if (numero < 0) { 
                Console.WriteLine("Entrada inválida. Introduce un entero positivo.");
                return;
            }
            calcularPrimo(numero);
        }
    }
    
    internal class Ejercicio5
    {
        //iterativa
        public static int calcular_base_iterativa(int n1,int n2)
        {
            int resultado = 1;
            for (int i = 0; i < n2; i++)
            {
                resultado = n1 * n1;
            }
            return resultado;
        }

        //recursiva
        public static int calcular_base_recursiva(int n1,int n2)
        {
            if (n2 == 0)
                return 1;
            return n1 * calcular_base_recursiva(n1, n2 - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce la base y exponente y se calculará la potencia:");
            int base_introducida = int.Parse(Console.ReadLine());
            int exponente_introducida = int.Parse(Console.ReadLine());
            Console.WriteLine(calcular_base_recursiva(base_introducida,exponente_introducida));
        }

    }

    internal class Ejercicio6
    {
        public static bool ValidarLogin(string usuario, string contraseña)
        {
            return usuario == "usuario2DAM" && contraseña == "pass2DAM";
        }

        static void Main(string[] args)
        {
            int intentos = 0;
            bool accesoConcedido = false;

            while (intentos < 3 && !accesoConcedido)
            {
                Console.Write("Introduce el usuario: ");
                string usuario = Console.ReadLine();
                Console.Write("Introduce la contraseña: ");
                string contraseña = Console.ReadLine();

                if (ValidarLogin(usuario, contraseña))
                {
                    accesoConcedido = true;
                    Console.WriteLine("Acceso concedido.");
                }
                else
                {
                    intentos++;
                    Console.WriteLine($"Acceso denegado. Intentos restantes: {3 - intentos}");
                }
            }

            if (!accesoConcedido)
            {
                Console.WriteLine("Has superado el número máximo de intentos.");
            }
        }
    }

    internal class Ejercicio7
    {
        public static bool EsMultiplo(int a, int b)
        {
            if (b == 0)
            {
                return false;
            }
            return a % b == 0;
        }

        static void Main(string[] args)
        {
            Console.Write("Introduce el primer número entero: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Introduce el segundo número entero: ");
            int num2 = int.Parse(Console.ReadLine());

            if (EsMultiplo(num1, num2))
            {
                Console.WriteLine($"{num1} es múltiplo de {num2}.");
            }
            else if (EsMultiplo(num2, num1))
            {
                Console.WriteLine($"{num2} es múltiplo de {num1}.");
            }
            else
            {
                Console.WriteLine("Ninguno de los números es múltiplo del otro.");
            }
        }
    }

    internal class Ejercicio8
    {
        public static int SumaDigitos(int numero)
        {
            int suma = 0;
            numero = Math.Abs(numero);
            while (numero > 0)
            {
                suma += numero % 10;
                numero /= 10;
            }
            return suma;
        }

        static void Main(string[] args)
        {
            Console.Write("Introduce un número entero: ");
            int num = int.Parse(Console.ReadLine());
            int resultado = SumaDigitos(num);
            Console.WriteLine($"La suma de los dígitos de {num} es: {resultado}");
        }
    }

    internal class Ejercicio9
    {
        public static int PosicionMenor(int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("El array no puede estar vacío.");

            int posicionMenor = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[posicionMenor])
                {
                    posicionMenor = i;
                }
            }
            return posicionMenor;
        }

        static void Main(string[] args)
        {
            int[] valores = { 8, 3, 15, 2, 7, 9 };
            int posicion = PosicionMenor(valores);
            Console.WriteLine($"La posición del número menor es: {posicion} (valor: {valores[posicion]})");
        }
    }

    internal class Cliente
    {
        private string nombre;
        private double cantidadTotal;

        public Cliente(string nombre)
        {
            this.nombre = nombre;
            this.cantidadTotal = 0;
        }

        public void Ingresar(double cantidad)
        {
            if (cantidad > 0)
                cantidadTotal += cantidad;
        }

        public void Sacar(double cantidad)
        {
            if (cantidad > 0 && cantidad <= cantidadTotal)
                cantidadTotal -= cantidad;
        }

        public double GetCantidadTotal()
        {
            return cantidadTotal;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Cliente: {nombre}, Saldo: {cantidadTotal}€");
        }
    }

    internal class Banco
    {
        private Cliente cliente1;
        private Cliente cliente2;
        private Cliente cliente3;

        public Banco()
        {
            cliente1 = new Cliente("Carmen");
            cliente2 = new Cliente("Chema");
            cliente3 = new Cliente("Adri");
        }

        public void Operar()
        {
            cliente1.Ingresar(1000);
            cliente2.Ingresar(1500);
            cliente3.Ingresar(2000);

            cliente1.Sacar(200);
            cliente2.Sacar(300);
            cliente3.Sacar(500);
        }

        public void ObtenerEstado()
        {
            double totalBanco = cliente1.GetCantidadTotal() + cliente2.GetCantidadTotal() + cliente3.GetCantidadTotal();
            Console.WriteLine($"Dinero total en el banco: {totalBanco}€");
            cliente1.MostrarInformacion();
            cliente2.MostrarInformacion();
            cliente3.MostrarInformacion();
        }

        static void Main(string[] args)
        {
            Banco banco = new Banco();
            banco.Operar();
            banco.ObtenerEstado();
        }
    }
}
