using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Models.Car
{
    interface ICrud_Service<T>
    {
        void Add(T t);
        void Update(int id);
        void Delete(int id);
        void Get();
    }
    internal class Vehicle
    {
        public int Id { get; set; }
        public string Mark {  get; set; }

        private List<Model> _models = new List<Model>(); 
    }

    class VehicleService : ICrud_Service<Vehicle>
    {
        private List<Vehicle> _list = new List<Vehicle>();

        public void Add(Vehicle v)
        {
            _list.Add(v);
        }

        public void Update(int id)
        {
            foreach (var el in _list) 
            {
                if (el.Id == id) 
                {
                    el.Mark = Console.ReadLine();
                }
            }
        }

        public void Delete(int id)
        {
            foreach (var el in _list)
            {
                if (el.Id == id)
                {
                   _list.Remove(el);
                }
                else
                {
                    throw new Exception("Wrong ID inserted");
                }
            }
        }

        public void Get()
        {
            foreach (var item in _list)
            {
                Console.WriteLine($"{item.Id} | {item.Mark}");
            }
        }
    }

    class Model
    {
        public int Id { get; set; }
        public string MyModel { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
    }

    class ModelService : ICrud_Service<Model>
    {
        private List<Model> _list = new List<Model>();
        public void Add(Model m)
        {
            _list.Add(m);
        }

        public void Update(int id)
        {
            foreach (var el in _list)
            {
                if (el.Id == id)
                {
                    el.MyModel = Console.ReadLine();
                    el.Year = int.Parse(Console.ReadLine());
                    el.Price = int.Parse(Console.ReadLine());
                }
            }
        }

        public void Get()
        {
           foreach(var item in _list)
            {
                Console.WriteLine($"{item.Id} | {item.MyModel} | {item.Year} | {item.Price}");
            }
        }

        public void Delete(int id)
        {
            foreach (var el in _list)
            {
                if (el.Id == id)
                {
                    _list.Remove(el);
                }
                else
                {
                    throw new Exception("Wrong ID inserted");
                }
            }
        }
    }


}
