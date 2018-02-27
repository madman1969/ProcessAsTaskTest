using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunProcessAsTask;
using Shouldly;

namespace CC65.Test
{
  [TestClass]
  public class BasicCC65Tests
  {
    [TestMethod]
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
  }
}
