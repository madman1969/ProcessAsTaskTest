using System.Diagnostics;
using System.IO;
using RunProcessAsTask;
using Console = Colorful.Console;

namespace ProcessAsTaskTest
{
  internal class cc65Process : ProcessBase
  {
    const string targetPlatform = "pet";

    public override async void InvokeAsync(string sourceFile)
    {
      // Bail if hooky file ...
      if (string.IsNullOrEmpty(sourceFile) ||
          !File.Exists(sourceFile))
        return;

      var args = $"--verbose -t {targetPlatform} {Path.GetFileName(sourceFile)}";
      var processStartInfo = new ProcessStartInfo
      {
        FileName = "cl65.exe",
        Arguments = args,
        WorkingDirectory = Path.GetDirectoryName(sourceFile)  
      };

      var processResults = await ProcessEx.RunAsync(processStartInfo);

      Console.WriteLine("Exit code: " + processResults.ExitCode, DefaultColor);
      Console.WriteLine("Run time: " + processResults.RunTime, DefaultColor);
      Console.WriteLine("{0} lines of standard output", processResults.StandardOutput.Length, StdOutColor);

      foreach (var output in processResults.StandardOutput)
      {
        Console.WriteLine("Output line: " + output, StdOutColor);
      }

      Console.WriteLine("{0} lines of standard error", processResults.StandardError.Length, StdErrColor);

      foreach (var error in processResults.StandardError)
      {
        Console.WriteLine("Error line: " + error, StdErrColor);
      }
    }
  }
}
