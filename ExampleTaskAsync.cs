using System.Diagnostics;

namespace DotNetCodeExamples
{
    internal class ExampleTaskAsync
    {
        // classe com exemplo da diferença entre execução sincorna e assincrona retornando seus tempos de execução
        // class with example of the difference between synchronous and asynchronous execution returning their execution times

        public async Task ExecuteValidationAsync()
        {
            await Task.Delay(5000);
            Console.WriteLine("Running validation one");
        }

        public async Task ExecuteSequentialMode()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await ExecuteValidationAsync();
            await ExecuteValidationAsync();
            stopwatch.Stop();
            Console.WriteLine("Execution time of the method in sequential mode was {0} ms", stopwatch.ElapsedMilliseconds);
        }

        public async Task ExecuteParallelMode()
        {
            Stopwatch stopwatch = new Stopwatch();
            var tarefasValidacao = new List<Task>();
            stopwatch.Start();
            tarefasValidacao.Add(ExecuteValidationAsync());
            tarefasValidacao.Add(ExecuteValidationAsync());
            await Task.WhenAll(tarefasValidacao);
            stopwatch.Stop();
            Console.WriteLine("Execution time of the method in parallel mode was: {0} ms", stopwatch.ElapsedMilliseconds);
        }

        public async Task TestMethodsAsync()
        {
            await ExecuteParallelMode();
            await ExecuteSequentialMode();
        }
    }
}