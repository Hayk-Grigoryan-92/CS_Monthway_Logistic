using lesson45.ConnectionString;
using lesson45.Models.ContainerType;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.DbImplementations
{
    internal class DbContainerRepository : IRepository<ContainerModel>
    {
        public DbContainerRepository()
        {
        }

        public void Add(ContainerModel item)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Constants.Connection_String))
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
            using (SqlConnection connection = new SqlConnection(ConnectionString.Constants.Connection_String))
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

        public IEnumerable<ContainerModel> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Constants.Connection_String))
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

        public ContainerModel GetById(int id)
        {
           using(SqlConnection connection = new SqlConnection (ConnectionString.Constants.Connection_String))
            {
                connection.Open ();
                ContainerModel container = new ContainerModel();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Container where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            container.Id = int.Parse(reader["Id"].ToString());
                            container.IsOpen = bool.Parse(reader["IsOpen"].ToString());
                            container.Coefficient = int.Parse(reader["Coefficient"].ToString());
                        }
                    }
                }
                return container;
            }
        }

        public void Update(ContainerModel item)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.Constants.Connection_String))
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

