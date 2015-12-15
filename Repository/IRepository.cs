﻿using System;
using System.Collections.Generic;

namespace RealProxyInterceptor.Repository
{
	public interface IRepository<T>
	{
		void Add(T entity);
		void Delete(T entity);
		void Update(T entity);
		IEnumerable<T> GetAll ();
		T GetById (int id);
	}
}