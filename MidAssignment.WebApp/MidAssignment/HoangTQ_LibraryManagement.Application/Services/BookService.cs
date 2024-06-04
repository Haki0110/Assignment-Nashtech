using HoangTQ_LibraryManagement.Application.DTOs;
using HoangTQ_LibraryManagement.Application.Interfaces;
using HoangTQ_LibraryManagement.Domain.Entities;
using HoangTQ_LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoangTQ_LibraryManagement.Application.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Category)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    CategoryId = b.CategoryId,
                    CategoryName = b.Category.Name
                }).ToListAsync();
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Category)
                .SingleOrDefaultAsync(b => b.Id == id);

            if (book == null)
                return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                CategoryName = book.Category.Name
            };
        }

        public async Task<BookDto> CreateBookAsync(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                CategoryId = bookDto.CategoryId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            bookDto.Id = book.Id;
            return bookDto;
        }

        public async Task<bool> UpdateBookAsync(int id, BookDto bookDto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return false;

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.CategoryId = bookDto.CategoryId;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
