using lesson45.Models.ContainerType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.DbImplementations
{
    internal class DbContainerService
    {
        private DbContainerRepo _container = new DbContainerRepo();

        public void AddContainer(ContainerModel container)
        {
            _container.Add(container);
            Console.WriteLine("Container added successfully.");
        }

        public void ShowAllContainers()
        {
            var containrs = _container.Get();
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

        public void UpdateContainer(ContainerModel container)
        {
            var result = _container.Get().FirstOrDefault(x => x.Id == container.Id);
            if (result == null)
            {
                Console.WriteLine($"Container with ID {container.Id} does not exist.");
                return;
            }
            _container.Update(container);
            Console.WriteLine("Container updated successfully.");
        }

        public void DeleteContainer(int id) 
        {
            var result = _container.Get().FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                Console.WriteLine($"Container with ID {id} does not exist.");
                return;
            }
            _container.Delete(id);
            Console.WriteLine("Container deleted successfully.");
        }
    }
}
