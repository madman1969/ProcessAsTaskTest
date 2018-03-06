using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using RunProcessAsTask;

namespace CC65
{
  public class CC65Process
  {
    #region Fields and properties

    public string WorkingDirectory { get; set; }
    public string TargetPlatform { get; set; }
    public string Compiler { get; private set; }
    public string SourceFile { get; private set; }
    public bool IsVerbose { get; set; }
    public string Arguments { get; set; }
    public ProcessResults Results { get; private set; }

    public readonly Color StdOutColor = Color.GreenYellow;
    public Color DefaultColor = Color.Aqua;
    public Color StdErrColor = Color.Red;

    #endregion

    #region Constructor

    public CC65Process()
    {
      // Set properties to defaults ...
      WorkingDirectory = string.Empty;
      TargetPlatform = "pet";
      Compiler = "cl65.exe";
      SourceFile = string.Empty;
      IsVerbose = true;
      Arguments = string.Empty;
      Results = null;
    }

    #endregion 

    #region Public Methods

    /// <summary>
    /// Compiles the supplied source file.
    /// </summary>
    /// <param name="sourceFile">C source file path</param>
    /// <returns>-1 if error encountered, else 0</returns>
    public async Task<int> Compile(string sourceFile)
    {
      // Bail if hooky file ...
      if (string.IsNullOrEmpty(sourceFile) ||
          !File.Exists(sourceFile))
        return -1;

      //
      // Setup compile process ...
      //
      SetWorkingDirectory(sourceFile);
      SetSourceFile(sourceFile);
      SetArguments();

      var processStartInfo = new ProcessStartInfo
      {
        FileName = Compiler,
        Arguments = Arguments,
        WorkingDirectory = WorkingDirectory
      };

      // Run compilation as async process ...
      Results = await ProcessEx.RunAsync(processStartInfo);

      return Results.ExitCode;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Set the working directory for the compilation process.
    /// 
    /// N.B. Only set if no existing value
    /// 
    /// </summary>
    /// <param name="sourceFile"></param>
    private void SetWorkingDirectory(string sourceFile)
    {
      if (string.IsNullOrEmpty(WorkingDirectory))
      {
        WorkingDirectory = Path.GetDirectoryName(sourceFile);
      }
    }

    /// <summary>
    /// Set the source file for the compilation process.
    /// 
    /// N.B. Only set if no existing value.
    /// 
    /// </summary>
    /// <param name="sourceFile"></param>
    private void SetSourceFile(string sourceFile)
    {
      if (string.IsNullOrEmpty(SourceFile))
      {
        SourceFile = Path.GetFileName(sourceFile);
      }
    }

    /// <summary>
    /// Set the arguments for the compilation process.
    /// </summary>
    private void SetArguments()
    {
      var verboseSetting = IsVerbose ? "--verbose" : string.Empty;
      Arguments = $"{verboseSetting} -t {TargetPlatform} {SourceFile}";
    }

    #endregion 
  }
}
