using lesson45.ConnectionString;
using lesson45.Models.ContainerType;
using lesson45.Models.DataBase;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.DbImplementations
{
    internal class DbContainerRepo : IRepository<ContainerModel>
    {
        public DbContainerRepo(Database database)
        {
            _database = database;
        }

        public DbContainerRepo()
        {
        }

        int Count { get; set; } = 1;

        private readonly Database _database;

        public void Add(ContainerModel item)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.ConnectionString.Connection_String))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Container values(@IsOpen, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@IsOpen", item.IsOpen));
                    command.Parameters.Add(new SqlParameter("@Coefficient", item.Coefficient));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.ConnectionString.Connection_String))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from Container where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ContainerModel> Get()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.ConnectionString.Connection_String))
            {
                connection.Open ();
                List<ContainerModel> containers = new List<ContainerModel>();
                using (SqlCommand command = new SqlCommand()) 
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Container";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            ContainerModel container = new ContainerModel();
                            container.Id = int.Parse(reader["Id"].ToString());
                            container.IsOpen = bool.Parse(reader["IsOpen"].ToString());
                            container.Coefficient = int.Parse(reader["Coefficient"].ToString());

                            containers.Add(container);
                        }
                    }
                }
                return containers;
            }
        }
           

        public void Update(ContainerModel item)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.ConnectionString.Connection_String))
            {
                connection.Open ();
                using (SqlCommand command = new SqlCommand()) 
                {
                    command.Connection = connection;
                    command.CommandText = "update Container set IsOpen = @IsOpen, Coefficient = @Coefficient";
                    command.Parameters.Add(new SqlParameter("@IsOpen", item.IsOpen));
                    command.Parameters.Add(new SqlParameter("@Coefficient", item.Coefficient));

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

