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
            String sqlCommand = "INSERT INTO Books (title, author, shortdesc,longdesc, thumbnail, image, ispopular, price, createddatetime) VALUES(@Title, @Author, @ShortDesc,@LongDesc, @Thumbnail, @Image, @IsPopular, @Price, @CreatedDateTime)";
            _db.Add(sqlCommand, entity);
        }
        public void Update(Book entity)
        {
            String sqlCommand = "UPDATE Books SET title=@Title, author=@Author, shortdesc=@ShortDesc,longdesc=@LongDesc, thumbnail=@Thumbnail, image=@Image, ispopular=@IsPopular, price=@Price, createddatetime=@CreatedDateTime WHERE bookId=@BookId";
            _db.Update(sqlCommand, entity);
        }
        public void Delete(int id)
        {
            string sqlCommand = "DELETE FROM Books WHERE bookid=@BookId;";
            _db.Delete(sqlCommand, id);
        }
        public IEnumerable<Book> GetAll(string? includeProperties = null)
        {
            return _db.GetAll("SELECT * FROM Books");
        }

        public Book GetFirstOrDefault(int id)
        {
            String querryString = String.Format("Select * FROM Books WHERE BookId={0}", id);
            return _db.Get(querryString);
        }
    }
}
