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
    public class BookRepository : IBookRepository
    {
        private readonly ISqlDataAcces<Book> _db;
        public BookRepository(ISqlDataAcces<Book> db)
        {
            _db = db;
        }

        public void Add(Book entity)
        {
            String sqlCommand = "INSERT INTO Books (title, author, description, price) VALUES(@Title, @Author, @Description, @Price)";
            _db.Add(sqlCommand, entity);
        }
        public void Update(Book entity)
        {
            String sqlCommand = "UPDATE Books SET title=@Title, author=@Author, description=@Description, price=@Price WHERE id=@Id";
            _db.Update(sqlCommand, entity);
        }
        public void Delete(int id)
        {
            string sqlCommand = "DELETE FROM Books WHERE id=@Id;";
            _db.Delete(sqlCommand, id);
        }
        public IEnumerable<Book> GetAll(string? includeProperties = null)
        {
            return _db.GetAll("SELECT * FROM Books");
        }

        public Book GetFirstOrDefault(int id)
        {
            String querryString = String.Format("Select * FROM Books WHERE id={0}", id);
            return _db.Get(querryString);
        }
    }
}
