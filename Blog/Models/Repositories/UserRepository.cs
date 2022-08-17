using Blog.Models;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Blog.Models.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection)
            => _connection = connection;
 
        public IEnumerable<User> Get()
            => _connection.GetAll<User>();

        public User Get(int id)
            => _connection.Get<User>(id);

        public void Create(User user)   
            => _connection.Insert<User>(user);

        

    }


}
