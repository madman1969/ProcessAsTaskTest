using CC65;
using Console = Colorful.Console;

namespace CC65Console
{
  class Program
  {
    static void Main(string[] args)
    {
      var sourceFile = @"D:\Commodore Stuff\PET Stuff\csource\Draw\draw.c";
      var process = new CC65Process();
      var tmp = process.Compile(sourceFile).Result;

      // Show exit code & run time ...
      Console.WriteLine("Exit code: " + process.Results.ExitCode, process.DefaultColor);
      Console.WriteLine("Run time: " + process.Results.RunTime, process.DefaultColor);

      // 
      // Dump StdOut ...
      //
      Console.WriteLine("{0} lines of standard output", process.Results.StandardOutput.Length, process.StdOutColor);

      foreach (var output in process.Results.StandardOutput)
      {
        Console.WriteLine("Output line: " + output, process.StdOutColor);
      }

      //
      // Dump StdErr ...
      //
      Console.WriteLine("{0} lines of standard error", process.Results.StandardError.Length, process.StdErrColor);

      foreach (var error in process.Results.StandardError)
      {
        Console.WriteLine("Error line: " + error, process.StdErrColor);
      }

      Console.ReadLine();
    }    
  }
}
