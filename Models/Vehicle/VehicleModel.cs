using lesson45.Common;

namespace lesson45.Models.Car
{
	class VehicleModel
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public VehicleType Type { get; set; }
		public int Year { get; set; }
		public int Price { get; set; }

		public VehicleModel(string model, VehicleType type)
		{
			Model = model;
			Type = type;
		}
		public VehicleModel() { }
	}
}
