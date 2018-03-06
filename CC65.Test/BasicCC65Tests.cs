using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunProcessAsTask;
using Shouldly;

namespace CC65.Test
{
  [TestClass]
  public class BasicCC65Tests
  {
    [TestMethod]
    // Verify can create CC65Process instance.
    public void CreateCC65ProcessShouldSucceed()
    {
      // Arrange ...

      // Act ...
      var process = new CC65Process();

      // Assert ...
      process.ShouldNotBeNull();
      process.WorkingDirectory.ShouldBeNullOrEmpty();
      process.Compiler.ShouldBe("cl65.exe");
      process.SourceFile.ShouldBeNullOrEmpty();
      process.IsVerbose.ShouldBeTrue();
      process.Arguments.ShouldBeNullOrEmpty();
      process.Results.ShouldBeNull();
    }

    [TestMethod]
    // Verify Compile with invalid source file fails.
    public void CompileWithInvalidSourceFileShouldFailAsync()
    {
      // Arrange ...
      var invalidSourceFile = "sdfsdfsdf";

      // Act ...
      var process = new CC65Process();
      var resultCode = process.Compile(invalidSourceFile).Result;

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
      var validSourceFile = @"D:\Commodore Stuff\PET Stuff\csource\Draw\draw.c";
      
      // Act ...
      var process = new CC65Process();
      var resultCode = process.Compile(validSourceFile).Result;
      
      
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
      var validSourceFile = @"D:\Commodore Stuff\PET Stuff\csource\Draw\draw.c";

      // Act ...
      var process = new CC65Process { IsVerbose = false };
      var resultCode = process.Compile(validSourceFile).Result;


      // Assert ...
      process.ShouldNotBeNull();
      process.Results.ShouldNotBeNull();
      process.Results.StandardError.Length.ShouldBe(0);
      process.Results.StandardOutput.Length.ShouldBe(0);
      resultCode.ShouldNotBe(-1);
    }
  }
}
