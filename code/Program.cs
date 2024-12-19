using System;
using System.Runtime;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Настройка сборщика мусора...");

        // Установка режима низкой задержки
        GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;

        Console.WriteLine($"GC Latency Mode: {GCSettings.LatencyMode}");

        // Создание и использование больших объектов
        byte[] largeArray = new byte[85 * 1024]; // Пример объекта в LOH (Large Object Heap)
        Console.WriteLine("Большой объект создан.");

        // Освобождение памяти
        largeArray = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("GC завершил работу. Нажмите любую клавишу для завершения работы.");
        Console.ReadKey();
    }
}
