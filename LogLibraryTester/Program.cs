using LogLibrary;
//using LogLibrary.Storage;
using System;

namespace LogTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            ILogStorage fileStorage = new FileLogStorage(logPath);
            Logger logger = new Logger(fileStorage);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Seleccione el tipo de log a generar:");
                Console.WriteLine("1. INFO");
                Console.WriteLine("2. WARNING");
                Console.WriteLine("3. ERROR");
                Console.WriteLine("4. Salir");
                Console.Write("\nIngrese una opción: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Ingrese el mensaje de INFO: ");
                        logger.LogInfo(Console.ReadLine());
                        Console.WriteLine("Log INFO registrado.");
                        break;

                    case "2":
                        Console.Write("Ingrese el mensaje de WARNING: ");
                        logger.LogWarning(Console.ReadLine());
                        Console.WriteLine("Log WARNING registrado.");
                        break;

                    case "3":
                        Console.Write("Ingrese el mensaje de ERROR: ");
                        logger.LogError(Console.ReadLine());
                        Console.WriteLine("Log ERROR registrado.");
                        break;

                    case "4":
                        Console.WriteLine("Saliendo de la aplicación...");
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
