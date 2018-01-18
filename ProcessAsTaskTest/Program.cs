using System;
using RunProcessAsTask;

namespace ProcessAsTaskTest
{
  class Program
  {
    static void Main(string[] args)
    {
      var processResults = ProcessEx.RunAsync("ping.exe", "www.bbc.co.uk").Result;

      Console.WriteLine("Exit code: " + processResults.ExitCode);
      Console.WriteLine("Run time: " + processResults.RunTime);

      Console.WriteLine("{0} lines of standard output", processResults.StandardOutput.Length);
      foreach (var output in processResults.StandardOutput)
      {
        Console.WriteLine("Output line: " + output);
      }

      Console.WriteLine("{0} lines of standard error", processResults.StandardError.Length);
      foreach (var error in processResults.StandardError)
      {
        Console.WriteLine("Error line: " + error);
      }

      Console.ReadLine();
    }
  }
}
