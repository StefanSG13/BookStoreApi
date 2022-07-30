using ITPLibrary.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Repositories.IRepositories
{
    public interface IUserManagementRepository
    {
        void Register(User user);
        User GetFirstOrDefault(string email);
    }
}