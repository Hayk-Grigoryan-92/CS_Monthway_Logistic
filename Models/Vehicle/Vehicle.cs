using System.Collections.Generic;

namespace lesson45.Models.Car
{

	internal class Vehicle
	{
		public int Id { get; set; }
		public string Mark { get; set; }

		private List<VehicleModel> _models = new List<VehicleModel>();
	}
}
