using System;
using System.Collections.Generic;

namespace RealProxyInterceptor.Repository
{
	public class Repository<T> : IRepository<T>
	{
		public Repository ()
		{
		}

		public void Add(T entity)
		{
			Console.WriteLine ("Adding {0}", entity);
		}

		public void Delete(T entity)
		{
			Console.WriteLine ("Deleting {0}", entity);
		}

		public void Update(T entity)
		{
			Console.WriteLine ("Updating {0}", entity);
		}

		public IEnumerable<T> GetAll()
		{
			Console.WriteLine ("Get entities");
			return null;
		}

		public T GetById(int Id)
		{
			Console.WriteLine ("Getting entity {0}", Id);
			return default(T);
		}
	}
}