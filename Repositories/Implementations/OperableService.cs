using lesson45.Models;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.Implementations
{
    internal class OperableService : IRepository<Operable>
    {
        private List<Operable> operables = new List<Operable>();

        public void Add(Operable item)
        {
            operables.Add(item);
        }

        public void Update(Operable item)
        {
            var expected = operables.Find(x => x.IsOperable == item.IsOperable);
            if (expected != null)
            {
                expected.Coefficient = item.Coefficient;
            }
        }

        public void Delete(int id)
        {
            if (id < operables.Count)
            {
                operables.RemoveAt(id);
            }
        }

        public List<Operable> Get()
        {
            return operables;
        }
    }
}
