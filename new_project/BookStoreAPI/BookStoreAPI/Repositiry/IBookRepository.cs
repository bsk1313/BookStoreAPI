using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStoreAPI.Repositiry
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBookAsync();

        Task<BookModel> GetBookByIdAsync(int bookId);

        Task<int> AddBookAsync(BookModel bookModel);

        Task UpdateBookAsync(int bookId, BookModel bookModel);

        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel);

        Task DeleteBookAsync(int bookId);
    }
}
