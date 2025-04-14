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
		public string From { get; set; }
		public string To { get; set; }
		public float Coefficient {  get; set; }


        public Route(int id, string from, string to, float coefficient)
		{
			Id = id;
			From = from;
			To = to;
			Coefficient = coefficient;
		}
	}
}
