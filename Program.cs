﻿using System;
using RealProxyInterceptor.Model;

namespace RealProxyInterceptor
{
  class MainClass
  {
    static void Main(string[] args)
    {
      Console.WriteLine("***\r\n Begin program - no logging\r\n");
      var customerRepository = RepositoryFactory.Create<Customer>(new ConsoleLogger());

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