using PaymentOrder.Core.Domain.Abstract.Products;
using PaymentOrder.Core.Domain.Entities.Discount;
using PaymentOrder.Core.Extentions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PaymentOrder.Core.DataAccess.MSSQL.Products
{
    public class ProductsRepository : IProductRepository
    {
        public readonly string connectionString;
        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ProductsEntity> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdTxt = "select Discount.Discount,Products.Id, Products.Name,Products.Count,Products.ProductCode,Products.Price,Products.IdDiscount,Products.IsModified,Products.IsCreated,Products.IsModified, Products.IsDeleted from Products " + 
                                "inner join Discount on Discount.Id = Products.IdDiscount where Products.IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProductsEntity> products = new List<ProductsEntity>();
                    while (reader.Read())
                    {
                        ProductsEntity product = new ProductsEntity();

                        product.Discount = new DiscountEntity()
                        {
                            Discount = (int)reader["Discount"]
                        };
                        product.Id = (int)reader["Id"];
                        product.Name = Convert.ToString(reader["Name"]);
                        product.ProductCode = Convert.ToString(reader["ProductCode"]);
                        product.Count = (int)reader["Count"];
                        product.Price = (int)reader["Price"];
                        product.IdDiscount = (int)reader["IdDiscount"];
                        product.IsModified = Convert.ToDateTime(reader["IsModified"]);
                        product.IsCreated = Convert.ToDateTime(reader["IsCreated"]);
                        product.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);

                        products.Add(product);
                    }
                    return products;
                }
            }
        }

        public bool Insert(ProductsEntity value)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Insert into Employees values(@Name, @ProductCode, @Count, @Price, @IdDiscount, @IsModified, @IsCreated, @IsDeleted)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Name", value.Name);
                    cmd.Parameters.AddWithValue("ProductCode", value.ProductCode);
                    cmd.Parameters.AddWithValue("Count", value.Count);
                    cmd.Parameters.AddWithValue("Price", value.Price);
                    cmd.Parameters.AddWithValue("IdDiscount", value.IdDiscount);
                    cmd.Parameters.AddWithValue("IsModified", value.IsModified);
                    cmd.Parameters.AddWithValue("IsCreated", value.IsCreated);
                    cmd.Parameters.AddWithValue("IsDeleted", value.IsDeleted);

                    int affectedRow = cmd.ExecuteNonQuery();

                    return affectedRow == 1;
                }
            }
        }

        public bool Update(ProductsEntity value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdTxt = "Update Products set Name = @Name,ProductCode=@ProductCode, Count = @Count, Price = @Price, IdDiscount = @IdDiscount, IsModified = @IsModified,IsCreated = @IsCreated, IsDeleted = @IsDeleted where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    cmd.Parameters.AddWithValue("Name", value.Name);
                    cmd.Parameters.AddWithValue("ProductCode", value.ProductCode);
                    cmd.Parameters.AddWithValue("Count", value.Count);
                    cmd.Parameters.AddWithValue("Price", value.Price);
                    cmd.Parameters.AddWithValue("IdDiscount", value.IdDiscount);
                    cmd.Parameters.AddWithValue("IsModified", value.IsModified);
                    cmd.Parameters.AddWithValue("IsCreated", value.IsCreated);
                    cmd.Parameters.AddWithValue("IsDeleted", value.IsDeleted);

                    int affectedRow = cmd.ExecuteNonQuery();

                    return affectedRow == 1;
                }
            }
        }
        public ProductsEntity Get(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Products where Id= @id and IsDeleted = 0";
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

        private ProductsEntity GetFromReader(SqlDataReader reader)
        {
            return new ProductsEntity
            {
                Id = reader.Get<int>("Id"),
                Name = reader.Get<string>("Name"),
                ProductCode = reader.Get<string>("ProductCode"),
                Count = reader.Get<int>("Count"),
                Price = reader.Get<int>("Price"),
                IsModified = reader.Get<DateTime>("IsModified"),
                IsCreated = reader.Get<DateTime>("IsCreated"),
                IsDeleted = reader.Get<bool>("IsDeleted"),
            };
        }
    }
}
