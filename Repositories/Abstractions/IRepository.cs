using System.Collections.Generic;

namespace lesson45.Services.Abstractions
{
	public interface IRepository<T>
	{
		void Add(T t);
		void Update(T t);
		void Delete(int id);
		T GetById(int id);
		IEnumerable<T> GetAll();
	}
}
