using lesson45.Common;

namespace lesson45.Repositories.Abstractions
{
	internal interface IVehicleTypeCoefficient
	{
		float GetCoefficient(VehicleType type);
	}
}
