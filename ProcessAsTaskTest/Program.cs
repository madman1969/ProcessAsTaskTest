using System;
using System.Drawing;
using RunProcessAsTask;
using Colorful;

using Console = Colorful.Console;

namespace ProcessAsTaskTest
{
  class Program
  {
    static void Main(string[] args)
    {
      var tmp = new InvokePing();
      tmp.Ping("www.bbc.co.uk");

      Console.ReadLine();
    }    
  }
}
