//using lesson45.Models;
//using lesson45.Models.DataBase;
//using lesson45.Services.Abstractions;
//using System.Collections.Generic;

//namespace lesson45.Repositories.Implementations
//{
//	internal class OperableService : IRepository<Operable>
//	{
//		public OperableService(Database database)
//		{
//			_database = database;
//		}

//		private readonly Database _database;

//		public int Count { get; set; } = 1;

//		public void Add(Operable item)
//		{
//			_database.Operables.Add(item);
//			_database.Operables[_database.Operables.Count - 1].Id = Count;
//			Count++;
//		}

//		public void Update(Operable item)
//		{
//			var expected = _database.Operables.Find(x => x.IsOperable == item.IsOperable);
//			if (expected != null)
//			{
//				expected.Coefficient = item.Coefficient;
//			}
//		}

//		public void Delete(int id)
//		{
//			if (id < _database.Operables.Count)
//			{
//				_database.Operables.RemoveAt(id);
//			}
//		}

//		public IEnumerable<Operable> GetAll()
//		{
//			return _database.Operables;
//		}
//	}
//}
