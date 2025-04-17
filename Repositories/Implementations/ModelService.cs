using lesson45.Models.Car;
using lesson45.Models.DataBase;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace lesson45.Services.Implementations
{
	class ModelService : IRepository<VehicleModel>
	{
		public ModelService(Database database)
		{
			_database = database;
		}
		public int Count { get; set; } = 1;

		private readonly Database _database;

		public void Add(VehicleModel m)
		{
			_database.VehicleModels.Add(m);
			_database.VehicleModels[_database.VehicleModels.Count - 1].Id = Count;
			Count++;
		}

		public void Update(VehicleModel model)
		{
			foreach (var el in _database.VehicleModels)
			{
				if (el.Id == model.Id)
				{
					el.Model = model.Model;
				}
			}
		}

		public IEnumerable<VehicleModel> Get()
		{
			return _database.VehicleModels;
		}

		public void Delete(int id)
		{
			foreach (var el in _database.VehicleModels)
			{
				if (el.Id == id)
				{
					_database.VehicleModels.Remove(el);
				}
				else
				{
					throw new Exception("Wrong ID inserted");
				}
			}
		}
	}
}
