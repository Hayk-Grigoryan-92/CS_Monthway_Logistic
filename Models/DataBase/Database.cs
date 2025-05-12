//using lesson45.Common;
//using lesson45.Models.Car;
//using lesson45.Models.ContainerType;
//using lesson45.Models.RouteFromTo;
//using System.Collections.Generic;

//namespace lesson45.Models.DataBase
//{
//	internal class Database
//	{
//		public List<Route> Routes;
//		public List<Operable> Operables;
//		public List<Vehicle> Vehicles;
//		public List<VehicleModel> VehicleModels;
//		public List<ContainerModel> ContainerModels;

//		public Database()
//		{
//			Routes = new List<Route>
//			{
//				new Route("Yerevan", "Gyumri", 100, 120),
//				new Route("Gyumri", "Vanadzor", 100, 150)
//			};

//			Operables = new List<Operable>
//			{
//				new Operable(true, 1.1f),
//				new Operable(false, 0.8f)
//			};

//			Vehicles = new List<Vehicle>
//			{
//				new Vehicle("Toyota"),
//				new Vehicle("BMW")
//			};

//			VehicleModels = new List<VehicleModel>
//			{
//				new VehicleModel("Corolla", VehicleType.Sedan),
//				new VehicleModel("X5", VehicleType.Jeep)
//			};

//			ContainerModels = new List<ContainerModel>
//			{
//				new ContainerModel(true, 1.0f),
//				new ContainerModel(false, 0.9f)
//			};
//		}
//	}
//}
