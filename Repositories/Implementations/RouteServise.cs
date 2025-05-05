using lesson45.Models.DataBase;
using lesson45.Models.RouteFromTo;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace lesson45.Services.Implementations
{
	class RouteServise : IRepository<Route>
	{
		public RouteServise(Database database)
		{
			_database = database;
		}

		private readonly Database _database;

		public int Count { get; set; } = 1;

		public void Add(Route route)
		{
			_database.Routes.Add(route);
			_database.Routes[_database.Routes.Count - 1].Id = Count;
			Count++;
		}
		public void Delete(int id)
		{
			foreach (Route route in _database.Routes)
			{
				if (route.Id == id)
				{
					_database.Routes.Remove(route);
				}
				else
				{
					throw new Exception("Wrong Id inserted");
				}
			}
		}

		public IEnumerable<Route> Get()
		{
			return _database.Routes;
		}

		public void Update(Route route)
		{
			_database.Routes.ForEach(x =>
		   {
			   if (x.Id == route.Id)
			   {
				   x.Fromm = route.Fromm;
				   x.Too = route.Too;
				   x.PricePerKm = route.PricePerKm;
				   x.Distance = route.Distance;
			   }
		   });
		}
	}
}
