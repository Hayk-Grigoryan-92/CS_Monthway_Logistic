using lesson45.Models.Car;
using lesson45.Models.RouteFromTo;
using lesson45.Services.Abstractions;
using System;
using System.Linq;

namespace lesson45.Repositories.DbImplementations
{
    internal class DbVehicleService
    {
        private IRepository<Vehicle> _vehicle;

        public DbVehicleService(IRepository<Vehicle> vehicle)
        {
            _vehicle = vehicle;
        }   

        public void Add(Vehicle vehicle)
        {
            try
            {
                _vehicle.Add(vehicle);
                Console.WriteLine("Vehicle added sucsessfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var result = _vehicle.GetById(id);
                if (result == null)
                {
                    Console.WriteLine($"Vehicle with ID {id} does not exist.");
                    return;
                }
                _vehicle.Delete(id);
                Console.WriteLine("Vehicle deleted sucsessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Vehicle vehicle)
        {
            try
            {
                var result = _vehicle.GetAll().FirstOrDefault(x => x.Id == vehicle.Id);
                if (result == null)
                {
                    Console.WriteLine($"Vehicle with ID {vehicle.Id} does not exist.");
                    return;
                }
                _vehicle.Update(vehicle);
                Console.WriteLine("Vehicle updated sucsessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowAll()
        {
            try
            {
                var vehicles = _vehicle.GetAll();
                if (vehicles == null)
                {
                    Console.WriteLine("No Vehicles found.");
                    return;
                }
                foreach (var el in vehicles)
                {
                    Console.WriteLine($"{el.Id} | {el.Mark}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowById(int id)
        {
            try
            {
                var vehicle = _vehicle.GetById(id);
                if (vehicle == null)
                {
                    Console.WriteLine("No Vehicle found.");
                    return;
                }
                Console.WriteLine($"{vehicle.Id} | {vehicle.Mark}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
