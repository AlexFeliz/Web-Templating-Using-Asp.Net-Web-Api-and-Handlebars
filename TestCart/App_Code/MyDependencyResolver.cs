using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Reflection;
using System.Web.Configuration;

using Shared.Interfaces;
using Data;

namespace TestCart.App_Code
{
	public class MyDependencyResolver : IDependencyResolver
	{
		private static readonly ProductMapper Mapper = new ProductMapper(DataHelper.CreateMapper(WebConfigurationManager.AppSettings["MapperType"].ToString()));

		public Object GetService(Type serviceType)
		{
			return serviceType == typeof(ProductController) ? new ProductController(Mapper) : null;		
		}

		public IEnumerable<Object> GetServices(Type serviceType)
		{
			return new List<Object>();
		}

		public IDependencyScope BeginScope()
		{
			return this;
		}

		public void Dispose()
		{

		}
	}
}