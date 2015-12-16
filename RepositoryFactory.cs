using RealProxyInterceptor.Repository;

namespace RealProxyInterceptor
{
	public class RepositoryFactory
	{
		public static IRepository<T> Create<T>()
		{
			var repository = new Repository<T> ();
		  var dynamicProxy = new DynamicProxy<IRepository<T>>(repository);
			return dynamicProxy.GetTransparentProxy () as IRepository<T>;
		}    

    public static IRepository<T> Create<T>(ILog logger)
    {
      var repository = new Repository<T>();
      var dynamicProxy = new DynamicProxy<IRepository<T>>(repository)
        .OnBeforeExecuting(methodName => logger.Log("In Dynamic Proxy - Before executing '{0}'", methodName))
        .OnAfterExecuting(methodName => logger.Log("In Dynamic Proxy - After executing '{0}'", methodName))
        .OnCatchingException((methodName, exception) => logger.Log(string.Format("In Dynamic Proxy - Exception {0} executing '{1}'", exception), methodName));
      return dynamicProxy.GetTransparentProxy() as IRepository<T>;
    }
    
	}
}