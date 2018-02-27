using System;

namespace ProcessAsTaskTest
{
  class Program
  {
    static void Main(string[] args)
    {
      //var tmp = new PingProcess();
      //tmp.InvokeAsync("www.bbc.co.uk");

      var sourceFile = @"D:\Commodore Stuff\PET Stuff\csource\Draw\draw.c";
      var tmp = new cc65Process();
      tmp.InvokeAsync(sourceFile);

      Console.ReadLine();
    }    
  }
}
