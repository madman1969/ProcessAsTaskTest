namespace CC65
{
    public class Cc65Options
    {
        public Cc65Options()
        {
            // Set properties to defaults ...
            WorkingDirectory = string.Empty;
            TargetPlatform = "pet";
            Compiler = "cl65.exe";
            SourceFile = string.Empty;
            IsVerbose = true;
            Arguments = string.Empty;
        }

        public string WorkingDirectory { get; set; }
        public string TargetPlatform { get; set; }
        public string Compiler { get; set; }
        public string SourceFile { get; set; }
        public bool IsVerbose { get; set; }
        public string Arguments { get; set; }
    }
}