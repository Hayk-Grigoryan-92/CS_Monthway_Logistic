namespace lesson45.Models.Car
{
	class VehicleModel
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public int Price { get; set; }

		public float Coefficient { get; set; }

		public VehicleModel(int id, string model, int price,int year, float coefficient)
		{
			Id = id;
			Model = model;
			Year = year;
			Price = price;
			Coefficient = coefficient;
		}

    }
}
