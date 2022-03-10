using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositiry
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBookAsync()
        {
            var records= await _context.Books.ToListAsync();

            return _mapper.Map<List<BookModel>>(records); 
        }


        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //var records = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();

            //return records;

            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }


        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }


        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //var book = await _context.Books.FindAsync(bookId);

            //if(book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;

            //    await this._context.SaveChangesAsync();
            //}

            var book = new Books()
            {
                Id = bookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await this._context.Books.FindAsync(bookId);
            if(book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();

            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books()
            {
                Id = bookId
            };

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

        }
    }
}
