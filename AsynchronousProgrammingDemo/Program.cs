using AsynchronousProgrammingDemoConsoleApp;

Console.WriteLine($"Application started at thread:{Thread.CurrentThread.ManagedThreadId}");

await CpuAsyncTestMethods.Run();
await IoAsyncTestMethods.Run();

Console.WriteLine($"Methods ran completely on Thread: {Thread.CurrentThread.ManagedThreadId}");

Console.ReadKey();

