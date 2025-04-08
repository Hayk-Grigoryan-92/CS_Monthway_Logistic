using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Services.Abstractions
{
	interface IRepository<T>
	{
		void Add(T t);
		void Update(T t);
		void Delete(int id);
		List<T> Get();
	}
}
