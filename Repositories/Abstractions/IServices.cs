using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.Abstractions
{
    internal interface IServices<T>
    {
        void Add(T repository);
        void ShowAll();
        void ShowById(int id);
        void Update(T repository);
        void Delete(int id);
    }
}
