using PaymentOrder.Core.Domain.Abstract.Customers;
using PaymentOrder.Core.Domain.Entities.Customers;
using PaymentOrder.Core.Domain.Entities.Employees;
using PaymentOrder.Core.Extentions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.DataAccess.MSSQL.Customers
{
    public class CustomersRepository : ICustomersRepository
    {
        public readonly string connectionString;
        public CustomersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CustomersEntity> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdTxt = "select * from Customers";
                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<CustomersEntity> customers = new List<CustomersEntity>();
                    while (reader.Read())
                    {
                        CustomersEntity customer = new CustomersEntity();

                        customer.Id = (int)reader["Id"];
                        customer.Name = Convert.ToString(reader["Name"]);
                        customer.Surname = Convert.ToString(reader["Surname"]);
                        customer.Email = Convert.ToString(reader["Email"]);
                        customer.Telephone = (int)reader["Telephone"];
                        customer.IsModified = Convert.ToDateTime(reader["IsModified"]);
                        customer.IsCreated = Convert.ToDateTime(reader["IsCreated"]);
                        customer.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);

                        customers.Add(customer);
                    }
                    return customers;
                }
            }
        }

        public CustomersEntity Get(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Customers where Id= @id and IsDeleted = 0";
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

        private CustomersEntity GetFromReader(SqlDataReader reader)
        {
            return new CustomersEntity
            {
                Id = reader.Get<int>("Id"),
                Name = reader.Get<string>("Name"),
                Surname = reader.Get<string>("Surname"),
                Email = reader.Get<string>("Email"),
                Telephone = reader.Get<int>("Telephone"),
                IsModified = reader.Get<DateTime>("IsModified"),
                IsCreated = reader.Get<DateTime>("IsCreated"),
                IsDeleted = reader.Get<bool>("IsDeleted"),
            };
        }

        public bool Insert(CustomersEntity value)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Insert into Customers values(@Name, @Surname, @Email,@Telephone, @IsModified, @IsCreated, @IsDeleted)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Name", value.Name);
                    cmd.Parameters.AddWithValue("Surname", value.Surname);
                    cmd.Parameters.AddWithValue("Email", value.Email);
                    cmd.Parameters.AddWithValue("Telephone", value.Telephone);
                    cmd.Parameters.AddWithValue("IsModified", value.IsModified);
                    cmd.Parameters.AddWithValue("IsCreated", value.IsCreated);
                    cmd.Parameters.AddWithValue("IsDeleted", value.IsDeleted);

                    int affectedRow = cmd.ExecuteNonQuery();

                    return affectedRow == 1;
                }
            }
        }

        public bool Update(CustomersEntity value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdTxt = "Update Customers set Name = @Name, Surname = @Surname, Email = @Email, Telephone = @Telephone, IsModified = @IsModified, IsCreated = @IsCreated, IsDeleted = @IsDeleted where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    cmd.Parameters.AddWithValue("Id", value.Id);
                    cmd.Parameters.AddWithValue("Name", value.Name);
                    cmd.Parameters.AddWithValue("Surname", value.Surname);
                    cmd.Parameters.AddWithValue("Email", value.Email);
                    cmd.Parameters.AddWithValue("Telephone", value.Telephone);
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
