using lesson45.Common;
using lesson45.Models;
using lesson45.Models.Car;
using lesson45.Models.ContainerType;
using lesson45.Models.DataBase;
using lesson45.Models.RouteFromTo;
using lesson45.Repositories.Implementations;
using lesson45.Repositories.Service;
using lesson45.RequestList;
using lesson45.Services.Implementations;
using System;
using System.Linq;

namespace lesson45
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Database database = new Database();
			var routeService = new RouteServise(database);
			var vehicleService = new VehicleService(database);
			var modelService = new ModelService(database);
			var containerService = new ContainerService(database);
			var operableService = new OperableService(database);
			var vehicleTypeCoefficientService = new VehicleTypeCoefficientService();

			var dataBaseService = new DatabaseService(
				modelService, operableService, routeService, containerService, vehicleTypeCoefficientService
			);

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
								Console.WriteLine("Press 1 : Add Route | Press 2 : Update Route | Press 3 : Delete Route | Press 4 : Get Routes | Press 5:  Back");
								bool routeFlag = true;
								int routeOption = int.Parse(Console.ReadLine());
								while (routeFlag)
								{
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
											Route newRoute = new Route(1, fromA, toB, routePricePerKm, routeDistance);
											routeService.Add(newRoute);
											Console.WriteLine("Route added successfully!");
											break;
										case 2: // Update Routex
											Console.WriteLine("Enter Id");
											int updateId = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Route From:");
											string updateFromA = Console.ReadLine();
											Console.WriteLine("Enter Route To:");
											string updateToB = Console.ReadLine();
											Console.WriteLine("Enter Route Distance:");
											int updateRouteDistance = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Route Price per km:");
											int updateRoutePricePerKm = int.Parse(Console.ReadLine());
											Route updatedRoute = new Route(updateId, updateFromA, updateToB, updateRoutePricePerKm, updateRouteDistance);
											routeService.Update(updatedRoute);
											Console.WriteLine("Route updated successfully!");
											break;
										case 3: // Dlete Route
											Console.WriteLine("Enter Id");
											int deleteId = int.Parse(Console.ReadLine());
											routeService.Delete(deleteId);
											break;
										case 4: // Get Routes
											var routesList = routeService.Get();
											routesList
												.ToList()
												.ForEach(x => Console.WriteLine($"{x.Id} | {x.Fromm} | {x.Too} | {x.Distance} | {x.PricePerKm}"));
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
								Console.WriteLine("Press 1 : Add Vehicle | Press 2 : Update Vehicle | Press 3 : Delete Vehicle | Press 4 : Get Vehicle | Press 5:  Back");
								int vehicleOption = int.Parse(Console.ReadLine());
								while (vehicleFlag)
								{
									switch (vehicleOption)
									{
										case 1: // Add Vehicle
											Console.WriteLine("Enter Vehicle Mark:");
											string addMark = Console.ReadLine();
											Vehicle newVehicle = new Vehicle(1, addMark);
											vehicleService.Add(newVehicle);
											Console.WriteLine("Vehicle added successfully!");
											break;
										case 2: // Update Vehicle
											Console.WriteLine("Enter Vehicle Id");
											int updateId = int.Parse(Console.ReadLine());
											Console.WriteLine("\"Enter Vehicle Mark:");
											string updateMark = Console.ReadLine();
											Vehicle updateVehicle = new Vehicle(updateId, updateMark);
											vehicleService.Update(updateVehicle);
											Console.WriteLine("Vehicle updated successfully!");
											break;
										case 3: // Delete Vehicle
											Console.WriteLine("Enter Vehicle Id");
											int deleteId = int.Parse(Console.ReadLine());
											vehicleService.Delete(deleteId);
											break;
										case 4: // Get Vehicles
											var vehiclesList = vehicleService.Get();
											vehiclesList.ToList().ForEach(x => Console.WriteLine($"{x.Id} | {x.Mark} "));
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
								Console.WriteLine("Press 1 : Add Model | Press 2 : Update Model | Press 3 : Delete Model | Press 4 : Get Models | Press 5:  Back");
								int modelOption = int.Parse(Console.ReadLine());
								while (modelFlag)
								{
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
											VehicleModel newModel = new VehicleModel(1, modelA, type);
											modelService.Add(newModel);
											Console.WriteLine("Vehicle Model added successfully!");
											break;
										case 2: // Update Model
											Console.WriteLine("Enter Vehicle Id");
											int updateId = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Vehicle Model:");
											string updateModelA = Console.ReadLine();
											Console.WriteLine("Enter Vehicle Price:");
											int updatePrice = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Vehicle Type (1 - Sedan, 2 - Jeep, 3 - Motorcycle, 4 - Boat, 5 - Truck):");
											VehicleType updateType = (VehicleType)(int.Parse(Console.ReadLine()) - 1);
											Console.WriteLine("Enter Vehicle Model Coefficient:");
											float updateModelCoefficient = float.Parse(Console.ReadLine());
											VehicleModel updateModel = new VehicleModel(updateId, updateModelA, updateType);
											modelService.Update(updateModel);
											Console.WriteLine("Vehicle Model updated successfully!");
											break;
										case 3: // Dlete Model
											Console.WriteLine("Enter Model Id");
											int deleteId = int.Parse(Console.ReadLine());
											modelService.Delete(deleteId);
											break;
										case 4: // Get Models
											var modelList = modelService.Get();
											modelList.ToList().ForEach(x => Console.WriteLine($"{x.Id} | {x.Model} | {x.Year} | {x.Price} | {x.Type}"));
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
								Console.WriteLine("Press 1 : Add Container | Press 2 : Update Container | Press 3 : Delete Container | Press 4 : Get Container | Press 5:  Back");
								int containerOption = int.Parse(Console.ReadLine());
								while (containerFlag)
								{
									switch (containerOption)
									{
										case 1: // Add Container
											Console.WriteLine("Enter Container Open Status (true/false):");
											bool isOpen = bool.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Coefficient:");
											float containerCoefficient = float.Parse(Console.ReadLine());
											ContainerModel newContainer = new ContainerModel(isOpen, containerCoefficient, 1);
											containerService.Add(newContainer);
											Console.WriteLine("Container added successfully!");
											break;
										case 2: // Update Container
											Console.WriteLine("Enter Vehicle Id");
											int updateId = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Open Status (true/false):");
											bool updateIsOpen = bool.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Coefficient:");
											float updateContainerCoefficient = float.Parse(Console.ReadLine());
											ContainerModel updateContainer = new ContainerModel(updateIsOpen, updateContainerCoefficient, updateId);
											containerService.Add(updateContainer);
											Console.WriteLine("Container updated successfully!");
											break;
										case 3:
											Console.WriteLine("Enter Container Id");
											int deleteId = int.Parse(Console.ReadLine());
											containerService.Delete(deleteId);
											break;
										case 4: // Get Models
											var containersList = containerService.Get();
											containersList.ToList().ForEach(x => Console.WriteLine($"{x.Id} | {x.Coefficient} | {x.IsOpen}"));
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
								Console.WriteLine("Press 1 : Add Operable | Press 2 : Update Operable | Press 3 : Delete Operable | Press 4 : Get Operable | Press 5:  Back");
								int operableOption = int.Parse(Console.ReadLine());
								while (operableFlag)
								{
									switch (operableOption)
									{
										case 1: // Add Operable
											Console.WriteLine("Enter Container Operable Status (true/false):");
											bool isOperable = bool.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Coefficient:");
											float isOperableCoefficient = float.Parse(Console.ReadLine());
											Operable newOperable = new Operable(isOperable, isOperableCoefficient, 1);
											operableService.Add(newOperable);
											Console.WriteLine("Operable type added successfully!");
											break;
										case 2: // Update Operable
											Console.WriteLine("Enter Vehicle Id");
											int updateId = int.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Operable Status (true/false):");
											bool updateIsOperable = bool.Parse(Console.ReadLine());
											Console.WriteLine("Enter Container Coefficient:");
											float updateIsOperableCoefficient = float.Parse(Console.ReadLine());
											Operable updateOperable = new Operable(updateIsOperable, updateIsOperableCoefficient, updateId);
											operableService.Add(updateOperable);
											Console.WriteLine("Operable type updated successfully!");
											break;
										case 3: // Delete Operable
											Console.WriteLine("Enter Operable Id");
											int deleteId = int.Parse(Console.ReadLine());
											operableService.Delete(deleteId);
											break;
										case 4: // Get Operables
											var operablesList = operableService.Get();
											operablesList.ToList().ForEach(x => Console.WriteLine($"{x.Id} | {x.Coefficient} | {x.IsOperable}"));
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
