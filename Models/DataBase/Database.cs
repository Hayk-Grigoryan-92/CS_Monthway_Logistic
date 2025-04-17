using lesson45.Common;
using lesson45.Models.Car;
using lesson45.Models.ContainerType;
using lesson45.Models.RouteFromTo;
using System.Collections.Generic;

namespace lesson45.Models.DataBase
{
	internal class Database
	{
		public List<Route> Routes;
		public List<Operable> Operables;
		public List<Vehicle> Vehicles;
		public List<VehicleModel> VehicleModels;
		public List<ContainerModel> ContainerModels;

		public Database()
		{
			Routes = new List<Route>
			{
				new Route(1, "Yerevan", "Gyumri", 100, 120),
				new Route(2, "Gyumri", "Vanadzor", 100, 150)
			};

			Operables = new List<Operable>
			{
				new Operable(true, 1.1f, 1),
				new Operable(false, 0.8f, 2)
			};

			Vehicles = new List<Vehicle>
			{
				new Vehicle(1, "Toyota"),
				new Vehicle(2, "BMW")
			};

			VehicleModels = new List<VehicleModel>
			{
				new VehicleModel(1, "Corolla", VehicleType.Sedan),
				new VehicleModel(2, "X5", VehicleType.Jeep)
			};

			ContainerModels = new List<ContainerModel>
			{
				new ContainerModel(true, 1.0f, 1),
				new ContainerModel(false, 0.9f, 2)
			};
		}
	}
}
