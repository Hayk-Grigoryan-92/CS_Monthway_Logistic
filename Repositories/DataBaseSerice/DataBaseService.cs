using lesson45.Models;
using lesson45.Models.Car;
using lesson45.Models.ContainerType;
using lesson45.Models.RouteFromTo;
using lesson45.Repositories.Abstractions;
using lesson45.RequestList;
using lesson45.Services.Abstractions;
using System;
using System.Linq;

namespace lesson45.Repositories.Service
{
	internal class DatabaseService
	{
		public IRepository<VehicleModel> CarType { get; set; }
		public IRepository<Operable> CarOperable { get; set; }
		public IRepository<Route> Route { get; set; }
		public IRepository<ContainerModel> ContainerType { get; set; }

		public IVehicleTypeCoefficient Coefficient { get; set; }

		public DatabaseService(
			IRepository<VehicleModel> carType,
			IRepository<Operable> carOperable,
			IRepository<Route> route,
			IRepository<ContainerModel> containerType,
			IVehicleTypeCoefficient coefficient
			)
		{
			CarType = carType;
			CarOperable = carOperable;
			Route = route;
			ContainerType = containerType;
			Coefficient = coefficient;
		}


        public float CalculationModel(Request request)
        {
            Route route = null;
            Operable operableItem = null;
            ContainerModel container = null;
            VehicleModel vehicleType = null;

            try
            {
                route = Route.GetAll().FirstOrDefault(x => x.Fromm == request.From && x.Too == request.To);
                if (route == null)
                {
                    throw new Exception("Route doesn't exist");
                }

                operableItem = CarOperable.GetAll().FirstOrDefault(x => x.IsOperable == request.IsOperable);
                if (operableItem == null)
                {
                    throw new Exception("Type of operable doesn't exist");
                }

                container = ContainerType.GetAll().FirstOrDefault(x => x.IsOpen == request.Container);
                if (container == null)
                {
                    throw new Exception("Type of container doesn't exist");
                }

                vehicleType = CarType.GetAll().FirstOrDefault(x => x.Model.Equals(request.Model));
                if (vehicleType == null)
                {
                    throw new Exception("Vehicle model doesn't exist");
                }

                var coefficient = Coefficient.GetCoefficient(vehicleType.Type);

                float result = route.Distance * operableItem.Coefficient * container.Coefficient * coefficient * route.PricePerKm;

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Calculation error: " + ex.Message);
                return 0;
            }
        }
    }
}
