using System.Drawing;

namespace ProcessAsTaskTest
{
  public abstract class ProcessBase
  {
    protected readonly Color StdOutColor = Color.GreenYellow;
    protected readonly Color DefaultColor = Color.Aqua;
    protected readonly Color StdErrColor = Color.Red;

    public abstract void InvokeAsync(string parameter);
  }
}
