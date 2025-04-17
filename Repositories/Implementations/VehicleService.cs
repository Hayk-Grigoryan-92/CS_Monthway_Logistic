using lesson45.Models.Car;
using lesson45.Models.DataBase;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace lesson45.Services.Implementations
{
	class VehicleService : IRepository<Vehicle>
	{
		public VehicleService(Database database)
		{
			_database = database;
		}

		private readonly Database _database;
		public int Count { get; set; } = 1;

		public void Add(Vehicle item)
		{
			_database.Vehicles.Add(item);
			_database.Routes[_database.Routes.Count - 1].Id = Count;
			Count++;
		}

		public void Update(Vehicle vehicle)
		{
			_database.Vehicles.ForEach(x =>
			{
				if (x.Id == vehicle.Id)
				{
					x.Mark = vehicle.Mark;
				}
			});
		}

		public void Delete(int id)
		{
			foreach (var el in _database.Vehicles)
			{
				if (el.Id == id)
				{
					_database.Vehicles.Remove(el);
				}
				else
				{
					throw new Exception("Wrong ID inserted");
				}
			}
		}

		public IEnumerable<Vehicle> Get()
		{
			return _database.Vehicles;
		}
	}
}
