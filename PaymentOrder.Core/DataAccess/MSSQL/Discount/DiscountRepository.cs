using PaymentOrder.Core.Domain.Abstract.Discount;
using PaymentOrder.Core.Domain.Entities.Customers;
using PaymentOrder.Core.Domain.Entities.Discount;
using PaymentOrder.Core.Domain.Entities.Employees;
using PaymentOrder.Core.Extentions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.DataAccess.MSSQL.Discount
{
    public class DiscountRepository : IDiscountRepository
    {
        public readonly string connectionString;
        public DiscountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public DiscountEntity Get(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Discount where Id= @id and IsDeleted = 0";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var discount = GetFromReader(reader);
                    return discount;
                }
                else
                {
                    return null;
                }
            }
        }

        private DiscountEntity GetFromReader(SqlDataReader reader)
        {
            return new DiscountEntity
            {
                Id = reader.Get<int>("Id"),
                Discount = reader.Get<int>("Discount"),
                DiscountStartDate = reader.Get<DateTime>("DiscountStartDate"),
                DiscountEndDate = reader.Get<DateTime>("DiscountEndDate"),
                IsModified = reader.Get<DateTime>("IsModified"),
                IsCreated = reader.Get<DateTime>("IsCreated"),
                IsDeleted = reader.Get<bool>("IsDeleted"),
            };
        }

        public List<DiscountEntity> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdTxt = "select * from Discount";
                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<DiscountEntity> discounts = new List<DiscountEntity>();
                    while (reader.Read())
                    {
                        DiscountEntity discount = new DiscountEntity();

                        discount.Id = (int)reader["Id"];
                        discount.Discount = (int)reader["Discount"];
                        discount.DiscountStartDate = Convert.ToDateTime(reader["DiscountStartDate"]);
                        discount.DiscountEndDate = Convert.ToDateTime(reader["DiscountEndDate"]);
                        discount.IsCreated = Convert.ToDateTime(reader["IsCreated"]);
                        discount.IsModified = Convert.ToDateTime(reader["IsModified"]);
                        discount.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);

                        discounts.Add(discount);
                    }
                    return discounts;
                }
            }
        }

        public bool Insert(DiscountEntity value)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdTxt = "Insert into Discount values(@Discount, @DiscountStartDate, @DiscountEndDate, @IsModified, @IsCreated, @IsDeleted)";
                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    cmd.Parameters.AddWithValue("Id", value.Id);
                    cmd.Parameters.AddWithValue("Discount", value.Discount);
                    cmd.Parameters.AddWithValue("DiscountStartDate", value.DiscountStartDate);
                    cmd.Parameters.AddWithValue("DiscountEndDate", value.DiscountEndDate);
                    cmd.Parameters.AddWithValue("IsModified", value.IsModified);
                    cmd.Parameters.AddWithValue("IsCreated", value.IsCreated);
                    cmd.Parameters.AddWithValue("IsDeleted", value.IsDeleted);

                    int affectedRow = cmd.ExecuteNonQuery();

                    return affectedRow == 1;
                }
            }
        }

        public bool Update(DiscountEntity value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdTxt = "Update Discount set Discount = @Discount, DiscountStartDate = @DiscountStartDate, DiscountEndDate = @DiscountEndDate, IsModified = @IsModified, IsCreated = @IsCreated, IsDeleted = @IsDeleted where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    cmd.Parameters.AddWithValue("Id", value.Id);
                    cmd.Parameters.AddWithValue("Discount", value.Discount);
                    cmd.Parameters.AddWithValue("DiscountStartDate", value.DiscountStartDate);
                    cmd.Parameters.AddWithValue("DiscountEndDate", value.DiscountEndDate);
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
