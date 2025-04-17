using System.Collections.Generic;

namespace lesson45.Services.Abstractions
{
	interface IRepository<T>
	{
		void Add(T t);
		void Update(T t);
		void Delete(int id);
		IEnumerable<T> Get();
	}
}
