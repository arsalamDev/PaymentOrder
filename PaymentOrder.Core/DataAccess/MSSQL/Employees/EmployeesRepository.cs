using PaymentOrder.Core.Domain.Abstract.Employees;
using PaymentOrder.Core.Domain.Entities.Auth;
using PaymentOrder.Core.Domain.Entities.Employees;
using PaymentOrder.Core.Extentions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml;

namespace PaymentOrder.Core.DataAccess.MSSQL.Employees
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public readonly string connectionString;
        public EmployeesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Delete from Employees where @Id = Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    int affectedRow = cmd.ExecuteNonQuery();

                    return affectedRow == 1;
                }
            }
        }

        public List<EmployeesEntity> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdTxt = "select * from Employees";
                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<EmployeesEntity> employees = new List<EmployeesEntity>();
                    while (reader.Read())
                    {
                        EmployeesEntity employee = new EmployeesEntity();

                        employee.Id = (int)reader["Id"];
                        employee.Name = Convert.ToString(reader["Name"]);
                        employee.Surname = Convert.ToString(reader["Surname"]);
                        employee.Email = Convert.ToString(reader["Email"]);
                        employee.IsCreated = Convert.ToDateTime(reader["IsCreated"]);
                        employee.IsModified = Convert.ToDateTime(reader["IsModified"]);
                        employee.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);

                        employees.Add(employee);
                    }
                    return employees;
                }
            }
        }

        public EmployeesEntity Get(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Employees where Id= @id and IsDeleted = 0";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var employee = GetFromReader(reader);
                    return employee;
                }
                else
                {
                    return null;
                }
            }
        }

        private EmployeesEntity GetFromReader(SqlDataReader reader)
        {
            return new EmployeesEntity
            {
                Id = reader.Get<int>("Id"),
                Name = reader.Get<string>("Name"),
                Surname = reader.Get<string>("Surname"),
                Email = reader.Get<string>("Email"),
                PasswordHash = reader.Get<string>("PasswordHash"),
                IsModified = reader.Get<DateTime>("IsModified"),
                IsCreated = reader.Get<DateTime>("IsCreated"),
                IsDeleted = reader.Get<bool>("IsDeleted"),
            };
        }

        public bool Insert(EmployeesEntity value)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Insert into Employees values(@Name, @Surname, @Email,@PasswordHash, @IsModified, @IsCreated, @IsDeleted)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Name", value.Name);
                    cmd.Parameters.AddWithValue("Surname", value.Surname);
                    cmd.Parameters.AddWithValue("Email", value.Email);
                    cmd.Parameters.AddWithValue("PasswordHash", value.PasswordHash);
                    cmd.Parameters.AddWithValue("IsModified", value.IsModified);
                    cmd.Parameters.AddWithValue("IsCreated", value.IsCreated);
                    cmd.Parameters.AddWithValue("IsDeleted", value.IsDeleted);

                    int affectedRow = cmd.ExecuteNonQuery();

                    return affectedRow == 1;
                }
            }
        }

        public bool Update(EmployeesEntity value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdTxt = "Update Employees set Name = @Name, Surname = @Surname, Email = @Email, PasswordHash = @PasswordHash, IsModified = @IsModified, IsCreated = @IsCreated, IsDeleted = @IsDeleted where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    cmd.Parameters.AddWithValue("Id", value.Id);
                    cmd.Parameters.AddWithValue("Name", value.Name);
                    cmd.Parameters.AddWithValue("Surname", value.Surname);
                    cmd.Parameters.AddWithValue("Email", value.Email);
                    cmd.Parameters.AddWithValue("PasswordHash", value.PasswordHash);
                    cmd.Parameters.AddWithValue("IsModified", value.IsModified);
                    cmd.Parameters.AddWithValue("IsCreated", value.IsCreated);
                    cmd.Parameters.AddWithValue("IsDeleted", value.IsDeleted);

                    int affectedRow = cmd.ExecuteNonQuery();

                    return affectedRow == 1;
                }
            }
        }
    }
}
