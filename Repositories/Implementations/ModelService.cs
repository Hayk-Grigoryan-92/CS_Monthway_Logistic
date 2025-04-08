using lesson45.Models.Car;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace lesson45.Services.Implementations
{
	class ModelService : IRepository<VehicleModel>
	{
		private List<VehicleModel> _list = new List<VehicleModel>();

		public void Add(VehicleModel m)
		{
			_list.Add(m);
		}

		public void Update(VehicleModel model)
		{
			foreach (var el in _list)
			{
				if (el.Id == model.Id)
				{
					el.Model = model.Model;
					el.Year = model.Year;
					el.Price = model.Price;
				}
			}
		}

		public List<VehicleModel> Get()
		{
			return _list;
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
	}
}
