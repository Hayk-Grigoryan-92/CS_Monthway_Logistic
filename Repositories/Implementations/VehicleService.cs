using lesson45.Models.Car;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace lesson45.Services.Implementations
{
	class VehicleService : IRepository<Vehicle>
	{
		private List<Vehicle> _list = new List<Vehicle>();

		public void Add(Vehicle v)
		{
			_list.Add(v);
		}

		public void Update(int id, string mark)
		{
			foreach (var el in _list)
			{
				if (el.Id == id)
				{
					el.Mark = mark;
				}
			}
		}

		public void Delete(int id)
		{
			foreach (var el in _list)
			{
				if (el.Id == id)
				{
					_list.Remove(el);
				}
				else
				{
					throw new Exception("Wrong ID inserted");
				}
			}
		}

		public List<Vehicle> Get()
		{
			return _list;
		}
	}
}
