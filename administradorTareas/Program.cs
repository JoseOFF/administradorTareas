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
                Console.Clear();
                Console.WriteLine($"=== {NombreApp} ===");
                foreach(string linea in opcionesMenu)
                {
                    Console.WriteLine(linea);
                }
                Console.WriteLine("Elije una opcion: ");
                opcion = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch (opcion)
                {
                    // Agregar tarea
                    case "1":
                        if (totalTareas >= MaxTareas)
                        {
                            Console.WriteLine("No hay espacio para poner mas tareas.");
                        }
                        else
                        {
                            Console.WriteLine("Titulo de la tarea: ");
                            titulos[totalTareas] = Console.ReadLine() ?? "";

                            Console.WriteLine("Prioridad de la tarea: (1 = Baja, 2 = Media, 3 = Alta)");
                            prioridad[totalTareas] = int.Parse(Console.ReadLine() ?? "");

                            completada[totalTareas] = false; // Inicialmente la tarea no está completada
                            totalTareas++;
                            Console.WriteLine("Tarea agregada correctamente.");
                        }
                        break;

                    // Listar tareas
                    case "2":
                        if (totalTareas == 0)
                        {
                            Console.WriteLine("No hay tareas registradas");
                            break;
                        }

                        int hechas = 0;
                        for (int i = 0; i < totalTareas; i++)
                        {
                            string estado = completada[i] ? "[X]" : "[ ]";
                            string textoPrioridad = prioridad[i] switch
                            {
                                1 => "Baja",
                                2 => "Media",
                                3 => "Alta",
                                _ => "Desconocida"
                            };

                            Console.WriteLine($"{i + 1}. {estado} {titulos[i]} (prioridad: {textoPrioridad})");

                            if (completada[i])
                            {
                                hechas++;
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine($"Tareas completadas: {hechas} de {totalTareas}");
                        break;

                    // Marcar tarea como completada
                    case "3":

                        if (totalTareas == 0)
                        {
                            Console.WriteLine("No hay tareas registradas");
                            break;
                        }

                        Console.WriteLine($"Numero de tareas (1 - {totalTareas}): ");
                        int numero = int.Parse(Console.ReadLine() ?? "");

                        if (numero < 1 || numero > totalTareas)
                        {
                            Console.WriteLine("Numero fuera del rango");
                            break;
                        }
                        else if (completada[ numero - 1])
                        {
                            Console.WriteLine("Esta tarea ya está completada");

                        }
                        else
                        {
                            completada[numero - 1] = true;
                            Console.WriteLine("Tarea marcada como completada");
                        }
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
                    Console.WriteLine();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                }


            } while (opcion != "0");

        }
    }
}
