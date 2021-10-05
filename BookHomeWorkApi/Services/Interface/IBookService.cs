using BookHomeWorkApi.DTO;
using System.Collections.Generic;


namespace BookHomeWorkApi.Services.Interface
{
    interface IBookService
    {
        List<BookDTO> GetAllBook();
        BookDTO GetBookById(int id);

        void Create(BookDTO book);
        BookDTO Edit(int id, BookDTO book);

        BookDTO Delete(int id);
    }
}
