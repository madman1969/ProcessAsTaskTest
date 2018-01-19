using System.Drawing;
using RunProcessAsTask;
using Console = Colorful.Console;

namespace ProcessAsTaskTest
{
  public class Invoke
  {
    private readonly Color stdOutColor = Color.GreenYellow;
    private readonly Color defaultColor = Color.Aqua;
    private readonly Color stdErrColor = Color.Red;

    public void Ping(string url)
    {
      var processResults = ProcessEx.RunAsync("ping.exe", url).Result;

      Console.WriteLine("Exit code: " + processResults.ExitCode, defaultColor);
      Console.WriteLine("Run time: " + processResults.RunTime, defaultColor);

      Console.WriteLine("{0} lines of standard output", processResults.StandardOutput.Length, stdOutColor);
      foreach (var output in processResults.StandardOutput)
      {
        Console.WriteLine("Output line: " + output, stdOutColor);
      }

      Console.WriteLine("{0} lines of standard error", processResults.StandardError.Length, stdErrColor);
      foreach (var error in processResults.StandardError)
      {
        Console.WriteLine("Error line: " + error, stdErrColor);
      }
    }
  }
}
