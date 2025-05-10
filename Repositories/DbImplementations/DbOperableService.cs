using lesson45.Models;
using lesson45.Repositories.Abstractions;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lesson45.Repositories.DbImplementations
{
    internal class DbOperableService : IServices<Operable>
    {
        private IRepository<Operable> _opearble;

        public DbOperableService(IRepository<Operable> opearble)
        {
            _opearble = opearble;
        }

        public void Add(Operable operable)
        {
            try
            {
                _opearble.Add(operable);
                Console.WriteLine("Container added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void ShowAll()
        {
            try
            {
                var operables = _opearble.GetAll();
                if (operables == null)
                {
                    Console.WriteLine("No containers found.");
                    return;
                }
                foreach (var el in operables)
                {
                    Console.WriteLine($"{el.Id} | {el.IsOperable} | {el.Coefficient}");
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
                var operable = _opearble.GetById(id);
                if (operable == null)
                {
                    Console.WriteLine("No Operable found.");
                    return;
                }
                Console.WriteLine($"{operable.Id} | {operable.IsOperable} | {operable.Coefficient}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Operable operable)
        {
            try
            {
                var result = _opearble.GetAll().FirstOrDefault(x => x.Id == operable.Id);
                if (result == null)
                {
                    Console.WriteLine($"Operable with ID {operable.Id} does not exist.");
                    return;
                }
                _opearble.Update(operable);
                Console.WriteLine("Operable updated sucsessfully");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var result = _opearble.GetById(id);
                if (result == null)
                {
                    Console.WriteLine($"Operable with ID {id} does not exist.");
                    return;
                }
                _opearble.Delete(id);
                Console.WriteLine("Operable deleted sucsessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
