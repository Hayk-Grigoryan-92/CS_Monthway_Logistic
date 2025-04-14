using System.Collections.Generic;

namespace lesson45.Models.Car
{
	enum VehicleType
	{
		Car,
		Motorcycle,
		Boat,
		Truck
	}

	internal class Vehicle
	{
		public int Id { get; set; }
		public string Mark { get; set; }

		public float Coefficient { get; set; }

		public VehicleType Type { get; set; }


        private List<VehicleModel> _models = new List<VehicleModel>();

		public Vehicle(int id, string mark, float coefficient) 
		{
			Id = id;
			Mark = mark;
			Coefficient = coefficient;
		}
	}
}
