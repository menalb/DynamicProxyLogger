using System;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Runtime.Remoting;
using System.Collections;
using System.Runtime.Remoting.Channels;
using RealProxyInterceptor.Repository;
using RealProxyInterceptor.Model;

namespace RealProxyInterceptor
{
	class MainClass
	{
		static void Main(string[] args)
		{
			Console.WriteLine("***\r\n Begin program - no logging\r\n");
			IRepository<Customer> customerRepository =
				RepositoryFactory.Create<Customer> ();
			
			var customer = new Customer
			{
				Id = 1,
				Name = "Customer 1",
				Address = "Address 1"
			};
			customerRepository.Add(customer);
			customerRepository.Update(customer);
			customerRepository.Delete(customer);
			Console.WriteLine("\r\nEnd program - no logging\r\n***");
			Console.ReadLine();
		}
	}
}
