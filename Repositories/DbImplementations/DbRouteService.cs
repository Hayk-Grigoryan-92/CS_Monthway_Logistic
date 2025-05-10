using lesson45.Models;
using lesson45.Models.RouteFromTo;
using lesson45.Repositories.Abstractions;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.DbImplementations
{
   
    internal class DbRouteService: IServices<Route>
    {
        private IRepository<Route> _route;

        public DbRouteService(IRepository<Route> route)
        {
            _route = route;
        }

        public void Add(Route route) 
        {
            try
            {
                _route.Add(route);
                Console.WriteLine("Container added successfully.");
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
                var result = _route.GetById(id);
                if (result == null)
                {
                    Console.WriteLine($"Route with ID {id} does not exist.");
                    return;
                }
                _route.Delete(id);
                Console.WriteLine("Route deleted sucsessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Route route)
        {
            try
            {
                var result = _route.GetAll().FirstOrDefault(x => x.Id == route.Id);
                if (result == null)
                {
                    Console.WriteLine($"Route with ID {route.Id} does not exist.");
                    return;
                }
                _route.Update(route);
                Console.WriteLine("Route updated sucsessfully");
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
                var routes =_route.GetAll();
                if(routes == null)
                {
                    Console.WriteLine("No Routes found.");
                    return;
                }
                foreach(var el in routes)
                {
                    Console.WriteLine($"{el.Id} | {el.Fromm} | {el.Too} | {el.PricePerKm} | {el.Distance}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowById(int id)
        {
            try
            {
                var route = _route.GetById(id);
                if (route == null)
                {
                    Console.WriteLine("No Route found.");
                    return;
                }
                Console.WriteLine($"{route.Id} | {route.Fromm} | {route.Too} | {route.PricePerKm} | {route.Distance}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
