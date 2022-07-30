using ITPLibrary.Api.Data.Data;
using ITPLibrary.Api.Data.Models;
using ITPLibrary.Api.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly ISqlDataAcces<User> _db;
        public UserManagementRepository(ISqlDataAcces<User> db)
        {
            _db = db;
        }
        public void Register(User user)
        {
            var sqlCommand = "INSERT INTO Users (email, password) VALUES(@Email, @Password)";
            _db.Add(sqlCommand, user);
        }
    }
}
