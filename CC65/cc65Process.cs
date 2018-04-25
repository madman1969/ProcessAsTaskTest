using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using RunProcessAsTask;

namespace CC65
{
    public class Cc65Process
    {
        #region Constructor

        public Cc65Process()
        {
            Options = new Cc65Options();

            // Set properties to defaults ...      
            Results = null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Compiles the supplied source file.
        /// </summary>
        /// <param name="sourceFile">C source file path</param>
        /// <returns>-1 if error encountered, else 0</returns>
        public async Task<int> Compile(string sourceFile)
        {
            // Bail if hooky file ...
            if (string.IsNullOrEmpty(sourceFile) ||
                !File.Exists(sourceFile))
            {
                return -1;
            }

            //
            // Set up compile process ...
            //
            SetWorkingDirectory(sourceFile);
            SetSourceFile(sourceFile);
            SetArguments();

            var processStartInfo = new ProcessStartInfo
            {
                FileName = Options.Compiler,
                Arguments = Options.Arguments,
                WorkingDirectory = Options.WorkingDirectory
            };

            // Run compilation as async process ...
            Results = await ProcessEx.RunAsync(processStartInfo);

            return Results.ExitCode;
        }

        #endregion

        #region Fields and properties

        public Cc65Options Options { get; }
        public ProcessResults Results { get; private set; }

        public readonly Color StdOutColor = Color.GreenYellow;
        public Color DefaultColor = Color.Aqua;
        public Color StdErrColor = Color.Red;

        #endregion

        #region Private Methods

        /// <summary>
        ///     Set the working directory for the compilation process.
        ///     N.B. Only set if no existing value
        /// </summary>
        /// <param name="sourceFile"></param>
        private void SetWorkingDirectory(string sourceFile)
        {
            if (string.IsNullOrEmpty(Options.WorkingDirectory))
            {
                Options.WorkingDirectory = Path.GetDirectoryName(sourceFile);
            }
        }

        /// <summary>
        ///     Set the source file for the compilation process.
        ///     N.B. Only set if no existing value.
        /// </summary>
        /// <param name="sourceFile"></param>
        private void SetSourceFile(string sourceFile)
        {
            if (string.IsNullOrEmpty(Options.SourceFile))
            {
                Options.SourceFile = Path.GetFileName(sourceFile);
            }
        }

        /// <summary>
        ///     Set the arguments for the compilation process.
        /// </summary>
        private void SetArguments()
        {
            var verboseSetting = Options.IsVerbose ? "--verbose" : string.Empty;
            Options.Arguments = $"{verboseSetting} -t {Options.TargetPlatform} {Options.SourceFile}";
        }

        #endregion
    }
}