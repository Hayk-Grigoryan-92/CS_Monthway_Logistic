using lesson45.ConnectionString;
using lesson45.Models.Car;
using lesson45.Services.Abstractions;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace lesson45.Repositories.DbRepository
{
    internal class DbVehicleRepository : IRepository<Vehicle>
    {
        public void Add(Vehicle t)
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Vehicle values(@Mark)";
                    command.Parameters.Add(new SqlParameter("@Mark", t.Mark));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from Vehicle where Id = @Id";
                    command.Parameters.Add(new SqlParameter("Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Vehicle> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                List<Vehicle> vehicles = new List<Vehicle>();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection= connection;
                    command.CommandText = "select * from Vehicle";
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehicle vehicle = new Vehicle();
                            vehicle.Id = int.Parse(reader["Id"].ToString());
                            vehicle.Mark = reader["Mark"].ToString();
                            vehicles.Add(vehicle);
                        }
                    }
                }
                return vehicles;
            }
        }

        public Vehicle GetById(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                Vehicle vehicle = new Vehicle();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Vehicle where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@id", id));
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vehicle.Id = int.Parse(reader["Id"].ToString());
                            vehicle.Mark = reader["Mark"].ToString();
                        }
                    }
                }
                return vehicle;
            }
        }

        public void Update(Vehicle t)
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                using(SqlCommand command=new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Vehicle set Mark = @Mark where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", t.Id));
                    command.Parameters.Add(new SqlParameter("@Mark", t.Mark));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
