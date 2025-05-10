using lesson45.ConnectionString;
using lesson45.Models.RouteFromTo;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Repositories.DbRepository
{
    internal class DbRouteRepository : IRepository<Route>
    {
        public void Add(Route t)
        {
            using(SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Route values(@Id, @Fromm, @Too, @PricePerKm, @Distance)";
                    command.Parameters.Add(new SqlParameter("@Id", t.Id));
                    command.Parameters.Add(new SqlParameter("@Fromm", t.Fromm));
                    command.Parameters.Add(new SqlParameter("@Too", t.Too));
                    command.Parameters.Add(new SqlParameter("@PricePerKm", t.PricePerKm));
                    command.Parameters.Add(new SqlParameter("@Distance", t.Distance));
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
                    command.CommandText = "delete from Route where Id = @Id";
                    command.Parameters.Add(new SqlParameter("id", id));
                    command.ExecuteNonQuery ();
                }
            }
        }

        public IEnumerable<Route> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                List<Route> routes = new List<Route>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Route";
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Route route = new Route();
                            route.Id = int.Parse(reader["Id"].ToString());
                            route.Fromm = reader["Fromm"].ToString();
                            route.Too = reader["Too"].ToString();
                            route.PricePerKm = int.Parse(reader["PricePerKm"].ToString());
                            route.Distance = int.Parse(reader["Distance"].ToString());
                            routes.Add(route);
                        }
                    }
                }
                return routes;
            }
        }

        public Route GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                Route route = new Route();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Route where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            route.Id = int.Parse(reader["Id"].ToString());
                            route.Fromm = reader["Fromm"].ToString();
                            route.Too = reader["Too"].ToString() ;
                            route.Id = int.Parse(reader["PricePerKm"].ToString());
                            route.Id = int.Parse(reader["Distance"].ToString());
                        }
                    }
                }
                return route;
            }
        }

        public void Update(Route t)
        {
            using(SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Route set Id = @Id, Fromm = @Fromm, Too = @Too, PricePerKm = @PricePerKm, Distance = @Distance";
                    command.Parameters.Add(new SqlParameter("@Id", t.Id));
                    command.Parameters.Add(new SqlParameter("@Fromm", t.Fromm));
                    command.Parameters.Add(new SqlParameter("Too", t.Too));
                    command.Parameters.Add(new SqlParameter("PricePerKm", t.PricePerKm));
                    command.Parameters.Add(new SqlParameter("Distance", t.Distance));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
