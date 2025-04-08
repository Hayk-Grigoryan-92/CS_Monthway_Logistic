using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Models.RouteFromTo
{
	internal class Route
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Route(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
