using ITPLibrary.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services.IServices
{
    public interface IBookService
    {
        public IEnumerable<BookDto> GetAll();
        public BookDto GetFirstOrDefault(int id);
        public void Add(BookDto book);
        public void Update(BookDto bookDto);
        public void Delete(int id);
    }
}
