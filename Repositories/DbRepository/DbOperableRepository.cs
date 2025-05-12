using lesson45.ConnectionString;
using lesson45.Models;
using lesson45.Services.Abstractions;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace lesson45.Repositories.DbRepository
{
    internal class DbOperableRepository : IRepository<Operable>
    {
        public void Add(Operable t)
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Operable values(@IsOperable, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("IsOperable", t.IsOperable));
                    command.Parameters.Add(new SqlParameter("Coefficient", t.Coefficient));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from Operable where Id = @Id";
                    command.Parameters.Add(new SqlParameter( "@Id", id ));
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Operable> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open ();
                List<Operable> operables = new List<Operable>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Operable";
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Operable operable = new Operable();
                            operable.Id = int.Parse(reader["Id"].ToString());
                            operable.IsOperable = bool.Parse(reader["IsOperable"].ToString());
                            operable.Coefficient = int.Parse(reader["Coefficient"].ToString());    
                            operables.Add(operable);
                        }
                    }
                }
                return operables;
            }
        }

        public Operable GetById(int id)
        {
            using(SqlConnection connection = new SqlConnection (Constants.Connection_String))
            {
                connection.Open ();
                Operable operable = new Operable();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Operable where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            operable.Id = int.Parse (reader["Id"].ToString());
                            operable.IsOperable = bool.Parse(reader["IsOperable"].ToString());
                            operable.Coefficient = int.Parse(reader["Coefficient"].ToString());
                        }
                    }
                }
                return operable;
            }
        }

        public void Update(Operable t)
        {
            using (SqlConnection connection = new SqlConnection(Constants.Connection_String))
            {
                connection.Open ();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Operable set IsOperable = @IsOperable, Coefficient = @Coefficient where ID = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", t.Id));
                    command.Parameters.Add(new SqlParameter(" @IsOperable", t.IsOperable));
                    command.Parameters.Add(new SqlParameter("@Coefficient", t.Coefficient));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
