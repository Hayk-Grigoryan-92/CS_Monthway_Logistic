using lesson45.Common;
using lesson45.Models;
using lesson45.Models.Car;
using lesson45.Models.ContainerType;
using lesson45.Models.RouteFromTo;
using lesson45.Repositories.DbImplementations;
using lesson45.Repositories.DbRepository;
using lesson45.Repositories.Implementations;
using lesson45.Repositories.Service;
using lesson45.RequestList;
using System;

namespace lesson45
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var routeRepository = new DbRouteRepository();
			var containerRepository = new DbContainerRepository();
			var vehicleRepository = new DbVehicleRepository();
			var modelRepository = new DbVehiclemodelRepository();
			var operableRepository = new DbOperableRepository();

            var containerService = new DbContainerService(containerRepository);
            var routeService = new DbRouteService(routeRepository);
            var vehicleService = new DbVehicleService(vehicleRepository);
            var modelService = new DbVehicleModelService(modelRepository);
            var operableService = new DbOperableService(operableRepository);
            var vehicleTypeCoefficientService = new VehicleTypeCoefficientService();
			var dataBaseService = new DatabaseService(modelRepository,operableRepository,routeRepository,containerRepository,vehicleTypeCoefficientService);

            

            bool flag = true;
			while (flag)
			{
				Console.WriteLine("-----------Monthway Auto Transport Service-----------------");
				Console.WriteLine("Choose Login type");
				Console.WriteLine("Press 1 : Admin | Press 2 : User | Press 3 : Exit");
				int option = int.Parse(Console.ReadLine());
				switch (option)
				{
					case 1: // Adim Menu
						Console.WriteLine("Press 1 : Route | Press 2 : Vehicle | Press 3 : Vehicle Model | Press 4 : Container | Press 5 : Operrable | Press 6 : Coefficient | Press 7 : Back");
						int adminOption = int.Parse(Console.ReadLine());

						switch (adminOption)
						{
							case 1: // Route Menu
								bool routeFlag = true;
								while (routeFlag)
								{
                                    Console.WriteLine("Press 1 : Add Route | Press 2 : Update Route | Press 3 : Delete Route | Press 4 : Get Routes | Press 5:  Back");
                                    int routeOption = int.Parse(Console.ReadLine());
                                    switch (routeOption)
									{
										case 1: // Add Route
											Console.WriteLine("Enter Route From:");
											string fromA = Console.ReadLine();
											Console.WriteLine("Enter Route To:");
											string toB = Console.ReadLine();
											Console.WriteLine("Enter Route Distance:");
											int routeDistance = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Route Price per km:");
											int routePricePerKm = int.Parse(Console.ReadLine());
											Route newRoute = new Route(fromA, toB, routePricePerKm, routeDistance);
											routeService.Add(newRoute);
											break;
										case 2: // Update Routex
                                            Console.WriteLine("Enter Id");
											int id = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter Route From:");
											string updateFromA = Console.ReadLine();
											Console.WriteLine("Enter Route To:");
											string updateToB = Console.ReadLine();
											Console.WriteLine("Enter Route Distance:");
											int updateRouteDistance = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Route Price per km:");
											int updateRoutePricePerKm = int.Parse(Console.ReadLine());
											Route updatedRoute = new Route(id,updateFromA, updateToB, updateRoutePricePerKm, updateRouteDistance);
											routeService.Update(updatedRoute);
											break;
										case 3: // Dlete Route
											Console.WriteLine("Enter Id");
											int deleteId = int.Parse(Console.ReadLine());
											routeService.Delete(deleteId);
											break;
										case 4: // Get Routes
											routeService.ShowAll();
											break;
										case 5: // Back
											routeFlag = false;
											break;
										default:
											Console.WriteLine("Wrong option choosed");
											break;
									}
								}
								break;

							case 2: // Vehicle Menu
								bool vehicleFlag = true;
								while (vehicleFlag)
								{
                                    Console.WriteLine("Press 1 : Add Vehicle | Press 2 : Update Vehicle | Press 3 : Delete Vehicle | Press 4 : Get Vehicle | Press 5:  Back");
                                    int vehicleOption = int.Parse(Console.ReadLine());
                                    switch (vehicleOption)
									{
										case 1: // Add Vehicle
											Console.WriteLine("Enter Vehicle Mark:");
											string addMark = Console.ReadLine();
											Vehicle newVehicle = new Vehicle(addMark);
											vehicleService.Add(newVehicle);
											break;
										case 2: // Update Vehicle
                                            Console.WriteLine("Enter Id");
                                            int id = int.Parse(Console.ReadLine());
                                            Console.WriteLine("\"Enter Vehicle Mark:");
											string updateMark = Console.ReadLine();
											Vehicle updateVehicle = new Vehicle(id,updateMark);
											vehicleService.Update(updateVehicle);
											break;
										case 3: // Delete Vehicle
											Console.WriteLine("Enter Vehicle Id");
											int deleteId = int.Parse(Console.ReadLine());
											vehicleService.Delete(deleteId);
											break;
										case 4: // Get Vehicles
											vehicleService.ShowAll();
											break;
										case 5: // Back
											vehicleFlag = false;
											break;
										default:
											Console.WriteLine("Wrong option choosed");
											break;
									}
								}
								break;

							case 3: //  Vehicle Model Menu
								bool modelFlag = true;
								while (modelFlag)
								{
                                    Console.WriteLine("Press 1 : Add Model | Press 2 : Update Model | Press 3 : Delete Model | Press 4 : Get Models | Press 5:  Back");
                                    int modelOption = int.Parse(Console.ReadLine());
                                    switch (modelOption)
									{
										case 1: // Add Model
											Console.WriteLine("Enter Vehicle Model:");
											string modelA = Console.ReadLine();
											Console.WriteLine("Enter Vehicle Price:");
											int price = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Vehicle Type (1 - Sedan, 2 - Jeep, 3 - Motorcycle, 4 - Boat, 5 - Truck):");
											VehicleType type = (VehicleType)(int.Parse(Console.ReadLine()) - 1);
											Console.WriteLine("Enter Vehicle Model Coefficient:");
											float modelCoefficient = float.Parse(Console.ReadLine());
											VehicleModel newModel = new VehicleModel(modelA, type);
											modelService.Add(newModel);
											break;
										case 2: // Update Model
                                            Console.WriteLine("Enter Id");
                                            int id = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter Vehicle Model:");
											string updateModelA = Console.ReadLine();
											Console.WriteLine("Enter Vehicle Price:");
											int updatePrice = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Vehicle Type (1 - Sedan, 2 - Jeep, 3 - Motorcycle, 4 - Boat, 5 - Truck):");
											VehicleType updateType = (VehicleType)(int.Parse(Console.ReadLine()) - 1);
											Console.WriteLine("Enter Vehicle Model Coefficient:");
											float updateModelCoefficient = float.Parse(Console.ReadLine());
											VehicleModel updateModel = new VehicleModel(id,updateModelA, updateType);
											modelService.Update(updateModel);
											break;
										case 3: // Dlete Model
											Console.WriteLine("Enter Model Id");
											int deleteId = int.Parse(Console.ReadLine());
											modelService.Delete(deleteId);
											break;
										case 4: // Get Models
											modelService.ShowAll();
											break;
										case 5: // Back
											modelFlag = false;
											break;
										default:
											Console.WriteLine("Wrong option choosed");
											break;
									}
								}
								break;

							case 4: //  Container Menu
								bool containerFlag = true;
								while (containerFlag)
								{
                                    Console.WriteLine("Press 1 : Add Container | Press 2 : Update Container | Press 3 : Delete Container | Press 4 : Get Container | Press 5:  Back");
                                    int containerOption = int.Parse(Console.ReadLine());
                                    switch (containerOption)
									{
										case 1: // Add Container
											Console.WriteLine("Enter Container Open Status (true/false):");
											bool isOpen = bool.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Coefficient:");
											float containerCoefficient = float.Parse(Console.ReadLine());
											ContainerModel newContainer = new ContainerModel(isOpen, containerCoefficient);
											containerService.Add(newContainer);
											break;
										case 2: // Update Container
                                            Console.WriteLine("Enter Id");
                                            int id = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter Container Open Status (true/false):");
											bool updateIsOpen = bool.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Coefficient:");
											float updateContainerCoefficient = float.Parse(Console.ReadLine());
											ContainerModel updateContainer = new ContainerModel(id,updateIsOpen, updateContainerCoefficient);
											containerService.Add(updateContainer);
											break;
										case 3:
											Console.WriteLine("Enter Container Id");
											int deleteId = int.Parse(Console.ReadLine());
											containerService.Delete(deleteId);
											break;
										case 4: // Get Models
											containerService.ShowAll();
											break;
										case 5: // Back
											containerFlag = false;
											break;
										default:
											Console.WriteLine("Wrong option choosed");
											break;
									}
								}
								break;

							case 5: // Operable Menu
								bool operableFlag = true;
								while (operableFlag)
								{
                                    Console.WriteLine("Press 1 : Add Operable | Press 2 : Update Operable | Press 3 : Delete Operable | Press 4 : Get Operable | Press 5:  Back");
                                    int operableOption = int.Parse(Console.ReadLine());
                                    switch (operableOption)
									{
										case 1: // Add Operable
											Console.WriteLine("Enter Container Operable Status (true/false):");
											bool isOperable = bool.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Coefficient:");
											float isOperableCoefficient = float.Parse(Console.ReadLine());
											Operable newOperable = new Operable(isOperable, isOperableCoefficient);
											operableService.Add(newOperable);
											break;
										case 2: // Update Operable;
                                            Console.WriteLine("Enter Id");
                                            int id = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter Container Operable Status (true/false):");
											bool updateIsOperable = bool.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Coefficient:");
											float updateIsOperableCoefficient = float.Parse(Console.ReadLine());
											Operable updateOperable = new Operable(id,updateIsOperable, updateIsOperableCoefficient);
											operableService.Add(updateOperable);
											break;
										case 3: // Delete Operable
											Console.WriteLine("Enter Operable Id");
											int deleteId = int.Parse(Console.ReadLine());
											operableService.Delete(deleteId);
											break;
										case 4: // Get Operables
											operableService.ShowAll();
											break;
										case 5: // Back
                                            operableFlag = false;
											break;
										default:
											Console.WriteLine("Wrong option choosed");
											break;
									}
								}
								break;
							//case 6: // Coefficient Menu

							//    break;
							case 7:
								continue;
							default:
								Console.WriteLine("Invalid option!");
								break;
						}
						break;

					case 2:// User actions
						Console.WriteLine("Transport Car From:");
						string fromUser = Console.ReadLine();
						Console.WriteLine("Transport Car To:");
						string toUser = Console.ReadLine();
						Console.WriteLine("Container Type (1 - Open, 2 - Enclosed):");
						bool typeOptionUser = int.Parse(Console.ReadLine()) == 1;

						Console.WriteLine("Enter Vehicle Year:");
						int yearUser = int.Parse(Console.ReadLine());
						Console.WriteLine("Enter Vehicle Mark:");
						string markUser = Console.ReadLine();
						Console.WriteLine("Enter Vehicle Model:");
						string modelUser = Console.ReadLine();
						Console.WriteLine("Is it operable? (1 - Yes, 2 - No):");
						bool isOperableUser = int.Parse(Console.ReadLine()) == 1;

						Console.WriteLine("Enter your Email:");
						string email = Console.ReadLine();

						Request userRequest = new Request
						{
							From = fromUser,
							To = toUser,
							Year = yearUser,
							Mark = markUser,
							Model = modelUser,
							IsOperable = isOperableUser,
							Email = email
						};
						try
						{
							double result = dataBaseService.CalculationModel(userRequest);
							Console.WriteLine($"Transport cost: {result} AMD");
							Console.WriteLine("Thank you to choose ours service");
							Console.WriteLine("We will glad to see you again");
						}
						catch (Exception ex)
						{
							Console.WriteLine($"Error: {ex.Message}");
						}
						break;
					case 3:
						flag = false;
						break;

					default:
						Console.WriteLine("Invalid option!");
						break;
				}
			}
		}
	}
}
