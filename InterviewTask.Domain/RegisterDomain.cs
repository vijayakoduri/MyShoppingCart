using InterviewTask.Domain.DomainControllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Domain
{
	public static class RegisterDomain
	{
		public static void RegisterDomainControllers(IServiceCollection services)
		{
			services.AddTransient<IProductDomain, ProductDomain>();
		}
	}
}
