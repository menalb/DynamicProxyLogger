using System;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Reflection;

namespace RealProxyInterceptor
{
  public class DynamicProxy<T> : RealProxy
  {
    private readonly T _decorated;

    private Action<string> _onBeforeExecutingAction;
    private Action<string> _onAfterExecutingAction;
    private Action<string,Exception> _onCatchingExceptionAction;

    public DynamicProxy(T decorated) : base(typeof(T))
    {
      _decorated = decorated;
    }

    public DynamicProxy<T> OnBeforeExecuting(Action<string> onBeforeExecutingAction)
    {
      _onBeforeExecutingAction = onBeforeExecutingAction;
      return this;
    }

    public DynamicProxy<T> OnAfterExecuting(Action<string> onAfterExecutingAction)
    {
      _onAfterExecutingAction = onAfterExecutingAction;
      return this;
    }

    public DynamicProxy<T> OnCatchingException(Action<string,Exception> onCatchingExceptionAction)
    {
      _onCatchingExceptionAction = onCatchingExceptionAction;
      return this;
    }

    private void BeforeExecuting(string methodName)
    {
      if (_onBeforeExecutingAction != null)
        _onBeforeExecutingAction(methodName);
    }

    private void AfterExecuting(string methodName)
    {
      if (_onAfterExecutingAction != null)        
        _onAfterExecutingAction(methodName);
    }

    private void CatchingException(string methodName, Exception exception)
    {
      if (_onCatchingExceptionAction != null)        
        _onCatchingExceptionAction(methodName,exception);
    }

    public override IMessage Invoke(IMessage msg)
    {
      var methodCall = msg as IMethodCallMessage;
      var methodInfo = methodCall.MethodBase as MethodInfo;
      BeforeExecuting(methodCall.MethodName);
      try
      {
        var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
        AfterExecuting(methodCall.MethodName);
        return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
      }
      catch (Exception exception)
      {
        CatchingException(methodCall.MethodName, exception);
        return new ReturnMessage(exception, methodCall);
      }
    }
  }
}