using lesson45.Models.RouteFromTo;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace lesson45.Services.Implementations
{
	class RouteCity : IRepository<Route>
	{
		private List<Route> _routesList = new List<Route>();

		public void Add(Route route)
		{
			_routesList.Add(route);
		}

		public void Delete(int id)
		{
			foreach (Route route in _routesList)
			{
				if (route.Id == id)
				{
					_routesList.Remove(route);
				}
				else
				{
					throw new Exception("Wrong Id inserted");
				}
			}
		}

		public List<Route> Get()
		{
			return _routesList;
		}

		public void Update(Route route)
		{
			_routesList.ForEach(x =>
		   {
			   if (x.Id == route.Id)
			   {
				   x.From = route.From;
				   x.To = route.To;
			   }
		   });
		}
	}
}
