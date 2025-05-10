using lesson45.Models.Car;
using lesson45.Repositories.Abstractions;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.DbImplementations
{
    internal class DbVehicleModelService : IServices<VehicleModel>
    {
        private IRepository<VehicleModel> _model;

        public DbVehicleModelService(IRepository<VehicleModel> model)
        {
            _model = model;
        }

        public void Add(VehicleModel model)
        {
            try
            {
                _model.Add(model);
                Console.WriteLine("Model added sucsessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var result = _model.GetById(id);
                if (result == null)
                {
                    Console.WriteLine($"Model with ID {id} does not exist.");
                    return;
                }
                _model.Delete(id);
                Console.WriteLine("Model deleted sucsessfully");
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
                var model = _model.GetById(id);
                if (model == null)
                {
                    Console.WriteLine("No Model found.");
                    return;
                }
                Console.WriteLine($"{model.Id} | {model.Model} | {model.Type} | {model.Year} | {model.Price}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(VehicleModel model)
        {
            try
            {
                var result = _model.GetAll().FirstOrDefault(x => x.Id == model.Id);
                if (result == null)
                {
                    Console.WriteLine($"Model with ID {model.Id} does not exist.");
                    return;
                }
                _model.Update(model);
                Console.WriteLine("Model updated sucsessfully");
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
                var models = _model.GetAll();
                if (models == null)
                {
                    Console.WriteLine("No Models found.");
                    return;
                }
                foreach (var el in models)
                {
                    Console.WriteLine($"{el.Id} |{el.Model} | {el.Type} | {el.Year} | {el.Price}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
