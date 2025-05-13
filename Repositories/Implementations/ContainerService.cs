//using lesson45.Models.ContainerType;
//using lesson45.Models.DataBase;
//using lesson45.Services.Abstractions;
//using System.Collections.Generic;

//namespace lesson45.Repositories.Implementations
//{
//	internal class ContainerService : IRepository<ContainerModel>
//	{
//		public ContainerService(Database database)
//		{
//			_database = database;
//		}
		
//		int Count { get; set; } = 1;
		
//		private readonly Database _database;

//		public void Add(ContainerModel item)
//		{
//			_database.ContainerModels.Add(item);
//			_database.ContainerModels[_database.ContainerModels.Count - 1].Id = Count;
//			Count++;
//		}

//		public void Delete(int id)
//		{
//			if (id < _database.ContainerModels.Count)
//			{
//				_database.ContainerModels.RemoveAt(id);
//			}
//		}

//		public IEnumerable<ContainerModel> GetAll()
//			=> _database.ContainerModels;

//		public void Update(ContainerModel item)
//		{
//			var expected = _database.ContainerModels.Find(x => x.IsOpen == item.IsOpen);
//			if (expected != null)
//			{
//				expected.Coefficient = item.Coefficient;
//			}
//		}
//	}
//}
