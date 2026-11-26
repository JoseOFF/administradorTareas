namespace administradorTareas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // permite que la consola muestre caracteres especiales como acentos y Ñ
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // nombre de la aplicación
            const string NombreApp = "Administrador de Tareas";

            string version = "0.1";

            Console.WriteLine($"=== {NombreApp} v{version} ===");
            Console.WriteLine();

            // capturar datos
            Console.Write("Titulo de la tarea: ");
            string titulo = Console.ReadLine() ?? "";

            Console.Write("Prioridad (1.Alta, 2.Media, 3.Baja): ");
            int prioridad = int.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Horas estimada (ejemplo: 1.5): ");
            double horas = double.Parse(Console.ReadLine() ?? "");

            int idTarea = 1;
            bool completada = false;

            // resumen de la tarea
            Console.WriteLine();
            Console.WriteLine("-- Resumen de la tarea --");
            Console.WriteLine($"ID: {idTarea}");
            Console.WriteLine($"Titulo: {titulo}");
            Console.WriteLine($"Prioridad: {prioridad}");
            Console.WriteLine($"Horas estimadas: {horas}");
            Console.WriteLine($"Minutos estimadoss: {horas * 60}");
            Console.WriteLine($"Completado: {completada}");
            Console.WriteLine($"Caracteres en el titulo: {titulo.Length}")
        }
    }
}
