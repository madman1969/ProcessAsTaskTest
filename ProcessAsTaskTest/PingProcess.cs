using RunProcessAsTask;
using Console = Colorful.Console;

namespace ProcessAsTaskTest
{
  internal class PingProcess : ProcessBase
  {
    public override async void InvokeAsync(string url)
    {
      var processResults = await ProcessEx.RunAsync("ping.exe", url);

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