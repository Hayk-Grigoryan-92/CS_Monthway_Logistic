using lesson45.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.Abstractions
{
    internal interface IVehicleTypeCoefficient
    {
        float GetCoefficient(VehicleType type);
    }
}
