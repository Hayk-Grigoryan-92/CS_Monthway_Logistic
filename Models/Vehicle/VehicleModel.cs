namespace lesson45.Models.Car
{
    enum VehicleType
    {
        Sedan,
		Jeep,
        Motorcycle,
        Boat,
        Truck,
    }
    class VehicleModel
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public VehicleType Type { get; set; }
		public int Year { get; set; }
		public int Price { get; set; }

		public VehicleModel(int id, string model, VehicleType type)
		{
			Id = id;
			Model = model;
			Type = type;
		}

    }
}
