using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace CC65.Test
{
    [TestClass]
    public class BasicCc65Tests
    {
        private const string ValidSourceFile = @"D:\Commodore Stuff\PET Stuff\csource\Draw\draw.c";
        private const string InvalidSourceFile = "sdfsdfsdf";

        [TestMethod]
        // Verify can create CC65Process instance.
        public void CreateCc65ProcessShouldSucceed()
        {
            // Arrange ...

            // Act ...
            var process = new Cc65Process();

            // Assert ...
            process.ShouldNotBeNull();
            process.Results.ShouldBeNull();
        }

        [TestMethod]
        // Verify Compile with invalid source file fails.
        public void CompileWithInvalidSourceFileShouldFailAsync()
        {
            // Arrange ...

            // Act ...
            var process = new Cc65Process();
            var resultCode = process.Compile(InvalidSourceFile).Result;

            // Assert ...
            process.ShouldNotBeNull();
            process.Results.ShouldBeNull();
            resultCode.ShouldBe(-1);
        }

        [TestMethod]
        // Verify Compile with valid soruce file succeeds.
        public void CompileWithValidSourceFileWithDefaultOptionsShouldSucceedAsync()
        {
            // Arrange ...

            // Act ...
            var process = new Cc65Process();
            var resultCode = process.Compile(ValidSourceFile).Result;

            // Assert ...
            process.ShouldNotBeNull();
            process.Results.ShouldNotBeNull();
            process.Results.StandardError.Length.ShouldBe(0);
            process.Results.StandardOutput.Length.ShouldBeGreaterThan(0);
            resultCode.ShouldNotBe(-1);
        }

        [TestMethod]
        // Verify Compile with valid source file and without verbose option succeeds.
        public void CompileWithValidSourceFileNotVerboseShouldSucceedAsync()
        {
            // Arrange ...

            // Act ...
            var process = new Cc65Process();
            process.Options.IsVerbose = false;
            var resultCode = process.Compile(ValidSourceFile).Result;


            // Assert ...
            process.ShouldNotBeNull();
            process.Results.ShouldNotBeNull();
            process.Results.StandardError.Length.ShouldBe(0);
            process.Results.StandardOutput.Length.ShouldBe(0);
            process.Options.IsVerbose.ShouldBe(false);
            resultCode.ShouldNotBe(-1);
        }
    }
}