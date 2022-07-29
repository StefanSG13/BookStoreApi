using ITPLibrary.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Data.Repositories.IRepositories
{
    public interface IBookRepository
    {
        void Add(Book entity);
        public void Delete(int id);
        public void Update(Book entity);
        IEnumerable<Book> GetAll(string? includeProperties = null);
        public Book GetFirstOrDefault(int id);
    }
}
