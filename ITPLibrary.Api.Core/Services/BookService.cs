using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data.Models;
using ITPLibrary.Api.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services
{
    public class BookService : IServices.IBookService
    {
        private readonly IBookRepository _books;
        private readonly IMapper _mapper;

        public BookService(IBookRepository books,IMapper mapper)
        {
            _books = books;
            _mapper = mapper;
        }

        public IEnumerable<BookDto> GetAll()
        {
            return _mapper.Map<IEnumerable<BookDto>>(_books.GetAll());
        }

        public BookDto GetFirstOrDefault(int id)
        {
            return _mapper.Map<BookDto>(_books.GetFirstOrDefault(id));
        }

        public void Add(BookDto bookDto)
        {
            _books.Add(_mapper.Map<Book>(bookDto));
        }

        public void Update(BookDto bookDto)
        {
            _books.Update(_mapper.Map<Book>(bookDto));
        }

        public void Delete(int id)
        {
            _books.Delete(id);
        }
    }
}
