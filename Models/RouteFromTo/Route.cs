using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Models.RouteFromTo
{
    interface ICrud_City_Service
    {
        void Add(Route route);
        void Update(int id);
        void Delete(int id);
        void Get();
    }
    internal class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Route(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }


    class RouteCity : ICrud_City_Service
    {
        private List<Route> _routesList = new List<Route>();
        public void Add(Route route)
        {
            _routesList.Add(route);
        }

        public void Delete(int id)
        {
            foreach (Route route in _routesList) 
            {
                if(route.Id == id)
                {
                    _routesList.Remove(route);
                }
                else
                {
                    throw new Exception("Wrong Id inserted");
                }
            }
        }

        public void Get()
        {
           foreach(Route route in _routesList)
            {
                Console.WriteLine($"{route.Id} | {route.Name}");
            }
        }

        public void Update(int id)
        {
            foreach (Route route in _routesList)
            {
                if (route.Id == id)
                {
                    route.Name = Console.ReadLine();
                }
            }
        }
    }
}
