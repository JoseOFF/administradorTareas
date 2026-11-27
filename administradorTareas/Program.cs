using System.Globalization;

namespace administradorTareas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // permite que la consola muestre caracteres especiales como acentos y Ñ
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const string NombreApp = "Administrador de tareas";
            const int MaxTareas = 10;

            // almacenar las tareas en 3 arreglos direfentes
            string[] titulos = new string[MaxTareas];
            int[] prioridad = new int[MaxTareas];
            bool[] completada = new bool[MaxTareas];
            int totalTareas = 0;

            string[] opcionesMenu =
            {
                "1. Agregar tarea",
                "2. Listar tareas",
                "3. Marcar tarea como completada",
                "0. Salir"
            };

            string opcion;

            do
            {
                MostrarMenu(NombreApp, opcionesMenu);
                opcion = LeerTexto("Elije una opcion: ");
                Console.WriteLine();

                switch (opcion)
                {
                    // Agregar tarea
                    case "1":
                        totalTareas = AgregarTarea(titulos, prioridad, completada, totalTareas);
                        break;

                    // Listar tareas
                    case "2":
                        ListarTareas(titulos, prioridad, completada, totalTareas);
                        break;

                    // Marcar tarea como completada
                    case "3":
                        CompletarTarea(completada, totalTareas);
                        break;

                    case "0":
                        Console.WriteLine("Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida");
                        break;

                }

                if (opcion != "0")
                {
                    Pausar();
                }


            } while (opcion != "0");

        }

        static void MostrarMenu(string nombreApp, string[] opciones)
        {
            Console.Clear();
            Console.WriteLine($"=== {nombreApp} ===");
            foreach (String linea in opciones)
            {
                Console.WriteLine(linea);
            }

        }

        static string LeerTexto(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine() ?? "";
        }

        static int LeerEntero(string mensaje)
        {
            string texto = LeerTexto(mensaje);
            return int.Parse(texto);
        }

        static int AgregarTarea(string[] titulos, int[] prioridad, bool[] completada, int totalTareas)
        {
            if (totalTareas >= titulos.Length)
            {
                Console.WriteLine("No hay espacio para poner mas tareas.");
                return totalTareas;
            }

            titulos[totalTareas] = LeerTexto("Titulo: ");
            prioridad[totalTareas] = LeerEntero("Prioridad (1 = Baja, 2 = Media, 3 = Alta): ");
            completada[totalTareas] = false; // Inicialmente la tarea no está completada

            Console.WriteLine("Tarea agregada correctamente.");
            return totalTareas + 1;
        }

        static void ListarTareas(string[] titulos, int[] prioridad, bool[] completada, int totalTareas)
        {
            if (totalTareas == 0)
            {
                Console.WriteLine("No hay tareas para registradas aun");
                return;
            }

            int hechas = 0;

            for (int i = 0; i < totalTareas; i++)
            {
                string estado = completada[i] ? "[X]" : "[ ]";
                string textoPrioridad = obtenerTextoPrioridad(prioridad[i]);
                Console.WriteLine($"{i + 1} {estado} {titulos[i]} (Prioridad: {textoPrioridad})");

                if (completada[i])
                {
                    hechas++;
                }

                Console.WriteLine();
                Console.WriteLine($"Completadas {hechas} de {totalTareas}");

            }

        }

        static string obtenerTextoPrioridad(int prioridad) => prioridad switch
        {

            1 => "Baja",
            2 => "Media",
            3 => "Alta",
            _ => "Desconocida"

        };

        static void CompletarTarea(bool[] completado, int totalTareas)
        {
            if (totalTareas == 0)
            {
                Console.WriteLine("No hay tareas registradas");
                return;
            }

            int numero = LeerEntero($"Numero de tareas (1 - {totalTareas}): ");

            if (numero < 1 || numero > totalTareas)
            {
                Console.WriteLine("Numero fuera del rango");
            }
            else if (completado[numero - 1])
            {
                Console.WriteLine("Esta tarea ya está completada");
            }
            else
            {
                completado[numero - 1] = true;
                Console.WriteLine("Tarea marcada como completada");
            }
        }

        static void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine("Pulsa cualquier tacla para continuar");
            Console.ReadKey(true);
        }


    }
}
