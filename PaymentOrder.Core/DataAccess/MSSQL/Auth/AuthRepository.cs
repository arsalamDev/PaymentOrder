using PaymentOrder.Core.Domain.Abstract.Auth;
using PaymentOrder.Core.Domain.Entities.Auth;
using PaymentOrder.Core.Extentions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.DataAccess.MSSQL.Auth
{
    public class AuthRepository : IAuthRepository
    {
        public readonly string connectionString;
        public AuthRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Delete from Auth where @Id = Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    int affectedRow = cmd.ExecuteNonQuery();

                    return affectedRow == 1;
                }
            }
        }

        public List<AuthEntity> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select * from Users";
                List<AuthEntity> users = new List<AuthEntity>();
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    AuthEntity user = new AuthEntity();
                    user.Id = (int)reader["Id"];
                    user.Email = Convert.ToString(reader["Email"]);
                    user.PasswordHash = Convert.ToString(reader["PasswordHash"]);

                    users.Add(user);
                }

                return users;
            }
        }

        public AuthEntity GetEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select * from Auth where Email = @Email";
                var command = new SqlCommand(cmdText, connection);
                command.Parameters.AddWithValue("@Email", email);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var login = GetFromReader(reader);
                    return login;
                }
                else
                {
                    return null;
                }
            }
        }
        private AuthEntity GetFromReader(SqlDataReader reader)
        {
            return new AuthEntity
            {
                Id = reader.Get<int>("Id"),
                Email = reader.Get<string>("Email"),
                PasswordHash = reader.Get<string>("PasswordHash"),
            };
        }

        public bool Insert(AuthEntity value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Insert into Login values(@Email,@PasswordHash)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Email", value.Email);
                    cmd.Parameters.AddWithValue("PasswordHash", value.PasswordHash);

                    int affecteRow = cmd.ExecuteNonQuery();

                    return affecteRow == 1;
                }
            }
        }

        public bool Update(AuthEntity value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Update Users set Email = @Email, PasswordHash = @PasswordHash where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Email", value.Email);
                    cmd.Parameters.AddWithValue("PasswprdHash", value.PasswordHash);

                    int affectedRow = cmd.ExecuteNonQuery();

                    return affectedRow == 1;
                }
            }
        }

        public AuthEntity Get(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Auth where Id= @id and IsDeleted = 0";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var auth = GetFromReader(reader);
                    return auth;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
    
