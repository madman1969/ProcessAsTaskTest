using System.Diagnostics;
using System.IO;
using RunProcessAsTask;
using Console = Colorful.Console;

namespace ProcessAsTaskTest
{
  internal class cc65Process : ProcessBase
  {
    public override async void InvokeAsync(string sourceFile)
    {
      if (string.IsNullOrEmpty(sourceFile) ||
          !File.Exists(sourceFile))
        return;

      var processResults = await ProcessEx.RunAsync(@"c:\cc65\bin\cl65.exe", sourceFile);

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

    private string AddQuotesIfRequired(string path)
    {
      return !string.IsNullOrEmpty(path) ?
        path.Contains(" ") ? "\"" + path + "\"" : path
        : string.Empty;
    }
  }
}
