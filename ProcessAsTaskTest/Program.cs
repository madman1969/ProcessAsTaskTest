namespace CC65.Console
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            const string sourceFile = @"D:\Commodore Stuff\PET Stuff\csource\Draw\draw.c";
            var process = new Cc65Process();
            var exitCode = process.Compile(sourceFile).Result;

            // Show exit code & run time ...
            Colorful.Console.WriteLine($"Exit code: {exitCode}", process.DefaultColor);
            Colorful.Console.WriteLine($"Run time: {process.Results.RunTime}", process.DefaultColor);

            // 
            // Dump StdOut ...
            //
            Colorful.Console.WriteLine($"{process.Results.StandardOutput.Length} lines of standard output",
                process.StdOutColor);

            foreach (var output in process.Results.StandardOutput)
            {
                Colorful.Console.WriteLine($"Output line: {output}", process.StdOutColor);
            }

            //
            // Dump StdErr ...
            //
            Colorful.Console.WriteLine($"{process.Results.StandardError.Length} lines of standard error",
                process.StdErrColor);

            foreach (var error in process.Results.StandardError)
            {
                Colorful.Console.WriteLine($"Error line: {error}", process.StdErrColor);
            }

            Colorful.Console.ReadLine();
        }
    }
}