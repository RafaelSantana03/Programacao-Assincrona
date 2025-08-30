
using System;
using System.Threading;

class Program
{
    static SemaphoreSlim semaphore = new SemaphoreSlim(2); // permite 2 threads simultâneas

    static void Main()
    {
        for (int i = 1; i <= 5; i++)
        {
            int threadId = i;
            new Thread(() => AcessarRecurso(threadId)).Start();
        }
    }

    static void AcessarRecurso(int id)
    {
        Console.WriteLine($"Thread {id} esperando...");
        semaphore.Wait(); // entra no semáforo

        Console.WriteLine($"Thread {id} entrou!");
        Thread.Sleep(2000); // simula trabalho

        Console.WriteLine($"Thread {id} saindo...");
        semaphore.Release(); // libera o semáforo
    }
}
