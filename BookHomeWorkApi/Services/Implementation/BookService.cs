using AutoMapper;
using BookHomeWorkApi.DAL;
using BookHomeWorkApi.DTO;
using BookHomeWorkApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHomeWorkApi.Models;

namespace BookHomeWorkApi.Services.Implementation
{
    public class BookService:IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(BookDTO book)
        {
            var newBook = _mapper.Map<Book>(book);
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        public BookDTO Delete(int id)
        {
            var bookDb = _context.Books.FirstOrDefault(m => m.Id == id);

            if (bookDb is null)
                return null;

            _context.Books.Remove(bookDb);
            _context.SaveChanges();

            return _mapper.Map<BookDTO>(bookDb);
        }

        public BookDTO Edit(int id, BookDTO book)
        {
            var bookDb = _context.Books.FirstOrDefault(m => m.Id == id);

            if (bookDb is null)
                return null;

            book.Id = bookDb.Id;

            _mapper.Map(book, bookDb);

            _context.SaveChanges();

            return book;
        }

        public List<BookDTO> GetAllBook()
        {
            var books = _context.Books.ToList();
            return _mapper.Map<List<BookDTO>>(books);
        }

        public BookDTO GetBookById(int id)
        {
            var bookDb = _context.Books.FirstOrDefault(m => m.Id == id);
            if (bookDb is null)
                return null;

            return _mapper.Map<BookDTO>(bookDb);
        }
    }
}
