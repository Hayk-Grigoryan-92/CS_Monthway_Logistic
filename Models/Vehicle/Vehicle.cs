using lesson45.Services.Implementations;
using System.Collections.Generic;

namespace lesson45.Models.Car
{
	
	internal class Vehicle
	{
		public int Id { get; set; }
		public string Mark { get; set; }

        public List<VehicleModel> _models = new List<VehicleModel>();

		public Vehicle(int id, string mark) 
		{
			Id = id;
			Mark = mark;
		}
	}
}
