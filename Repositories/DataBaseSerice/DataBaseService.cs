using lesson45.Models;
using lesson45.Models.Car;
using lesson45.Models.ContainerType;
using lesson45.Models.RouteFromTo;
using lesson45.Repositories.Implementations;
using lesson45.RequestList;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.Service
{
     internal class DataBaseService
    {
        public IRepository<VehicleType> CarType {  get; set; }
        public IRepository<Operable> CarOperable { get; set; }
        public IRepository<Route> Route { get; set; }
        public IRepository<ContainerType> ContainerType { get; set; }

        public DataBaseService(IRepository<VehicleType> carType, IRepository<Operable> carOperable, IRepository<Route> route, IRepository<ContainerType> containerType)
        {
            CarType = carType;
            CarOperable = carOperable;
            Route = route;
            ContainerType = containerType;
        }

        public float CalculationModel(Request request)
        {
            var route = Route.Get().FirstOrDefault(x => x.From == request.From && x.To == request.To);
            var operableItem = CarOperable.Get().FirstOrDefault(x => x.IsOperable == request.IsOperable);
            var container = ContainerType.Get().FirstOrDefault(x => x.IsOpen == request.Container);

            if (route == null || operableItem == null || container == null)
            {
                throw new Exception("Incorrect data");
            }

            float result = route.Coefficient * operableItem.Coefficient * container.Coefficient;

            return result;
        }
    }
}
