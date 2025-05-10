using lesson45.Common;
using lesson45.ConnectionString;
using lesson45.Models.Car;
using lesson45.Services.Abstractions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.DbRepository
{
    internal class DbVehiclemodelRepository : IRepository<VehicleModel>
    {
        public void Add(VehicleModel t)
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Model values(@Id, @Model, @Type, @Year, @Price)";
                    command.Parameters.Add(new SqlParameter("@Id", t.Id));
                    command.Parameters.Add(new SqlParameter("@Model", t.Model));
                    command.Parameters.Add(new SqlParameter("@Type", t.Type));
                    command.Parameters.Add(new SqlParameter("@Year", t.Year));
                    command.Parameters.Add(new SqlParameter("@Price", t.Price));
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
                    command.CommandText = "delete from Model where Id = @Id";
                    command.Parameters.Add(new SqlParameter("Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }


        public IEnumerable<VehicleModel> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                List<VehicleModel> models = new List<VehicleModel>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Model";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VehicleModel model = new VehicleModel();
                            model.Model = reader["Model"].ToString();
                            model.Type = (VehicleType)Enum.Parse(typeof(VehicleType), reader["Type"].ToString());
                            model.Year = int.Parse(reader["Year"].ToString());
                            model.Price = int.Parse(reader["Price"].ToString());
                            models.Add(model);
                        }
                    }
                }
                return models;
            }
        }

        public VehicleModel GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                VehicleModel model = new VehicleModel();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Model where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@id", id));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Model = reader["Model"].ToString();
                            model.Type = (VehicleType)Enum.Parse(typeof(VehicleType), reader["Type"].ToString());
                            model.Price = int.Parse(reader["Price"].ToString());
                            model.Year = int.Parse(reader["Year"].ToString());
                        }
                    }
                }
                return model;
            }
        }

        public void Update(VehicleModel t)
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Model set Id = @Id, Mark = @Mark";
                    command.Parameters.Add(new SqlParameter("@Id", t.Id));
                    command.Parameters.Add(new SqlParameter("@Model", t.Model));
                    command.Parameters.Add(new SqlParameter("@Type", t.Type));
                    command.Parameters.Add(new SqlParameter("@Year", t.Year));
                    command.Parameters.Add(new SqlParameter("@Price", t.Price));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
