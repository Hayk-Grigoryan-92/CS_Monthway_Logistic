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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var dataBaseService = new DataBaseService(
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
                    case 1:
                        Console.WriteLine("Press 1 : Add Route | Press 2 : Add Vehicle | Press 3 : Add Vehicle Model | Press 4 : Add Container");
                        int adminOption = int.Parse(Console.ReadLine());

                        switch (adminOption)
                        {
                            case 1: // Adim add Route
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

                            case 2: // Admin add Vehicle
                                Console.WriteLine("Enter Vehicle Mark:");
                                string mark = Console.ReadLine();
                                Vehicle newVehicle = new Vehicle(1, mark);
                                vehicleService.Add(newVehicle);
                                Console.WriteLine("Vehicle added successfully!");
                                break;

                            case 3: // Admin add Vehicle Model
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

                            case 4: // Admin add Container
                                Console.WriteLine("Enter Container Open Status (true/false):");
                                bool isOpen = bool.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Container Coefficient:");
                                float containerCoefficient = float.Parse(Console.ReadLine());

                                ContainerModel newContainer = new ContainerModel(isOpen, containerCoefficient, 1);
                                containerService.Add(newContainer);
                                Console.WriteLine("Container added successfully!");
                                break;

                                case 5:
                                Console.WriteLine("Enter Container Operable Status (true/false):");
                                bool isOperable = bool.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Container Coefficient:");
                                float isOperableCoefficient = float.Parse(Console.ReadLine());
                                Operable newOperable = new Operable(isOperable, isOperableCoefficient,1);
                                operableService.Add(newOperable);
                                Console.WriteLine("Operable type added successfully!");
                                break;

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
