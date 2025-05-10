using lesson45.Models.ContainerType;
using lesson45.Repositories.Abstractions;
using lesson45.Services.Abstractions;
using System;
using System.Linq;

namespace lesson45.Repositories.DbImplementations
{
    internal class DbContainerService : IServices<ContainerModel>
    {
        private IRepository<ContainerModel> _container;

        public DbContainerService(IRepository<ContainerModel> container)
        {
            _container = container;
        }

        public void Add(ContainerModel container)
        {
            try
            {
                _container.Add(container);
                Console.WriteLine("Container added successfully.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowAll()
        {
            try
            {
                var containrs = _container.GetAll();
                if (containrs == null)
                {
                    Console.WriteLine("No containers found.");
                    return;
                }
                foreach (var el in containrs)
                {
                    Console.WriteLine($"{el.Id} | {el.IsOpen} | {el.Coefficient}");
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
                var container = _container.GetById(id);
                if(container == null)
                {
                    Console.WriteLine("No Container found.");
                    return;
                }
                Console.WriteLine($"{container.Id} | {container.IsOpen} | {container.Coefficient}");
            }
            catch( Exception ex ) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(ContainerModel container)
        {
            try
            {
                var result = _container.GetAll().FirstOrDefault(x => x.Id == container.Id);
                if (result == null)
                {
                    Console.WriteLine($"Container with ID {container.Id} does not exist.");
                    return;
                }
                _container.Update(container);
                Console.WriteLine("Container updated successfully.");
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
                var result = _container.GetById(id);
                if (result == null)
                {
                    Console.WriteLine($"Container with ID {id} does not exist.");
                    return;
                }
                _container.Delete(id);
                Console.WriteLine("Container deleted successfully.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
