using lesson45.Models.Car;
using lesson45.Repositories.Abstractions;
using System.Collections.Generic;

namespace lesson45.Repositories.Implementations
{
    internal class VehicleTypeCoefficientService : IVehicleTypeCoefficient
    {
        public  Dictionary<VehicleType, float> _coefficients = new Dictionary<VehicleType, float>
        {
            { VehicleType.Sedan, 1.0f },
            { VehicleType.Jeep, 1.2f },
            { VehicleType.Motorcycle, 0.6f },
            { VehicleType.Boat, 1.5f },
            { VehicleType.Truck, 1.8f }
        };

        public float GetCoefficient(VehicleType type)
        {
            return _coefficients.TryGetValue(type, out float value) ? value : 1.0f;
        }
    }
}
