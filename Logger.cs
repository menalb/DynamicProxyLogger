using System;

namespace RealProxyInterceptor
{

  public interface ILog
  {
    void Log(string msg, object arg = null);
  }

  public class ConsoleLogger : ILog
  {
    public void Log(string msg, object arg = null)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine(msg, arg);
      Console.ResetColor();
    }
  }
}