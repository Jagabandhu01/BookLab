
using AutoMapper;
using BookLab.Models;
using BookLab.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookRecord.Repository
{
    public class BookRepository : IBookRepository
    {
         
        private readonly BookDbContext _dbContext;
        private readonly IMapper _mapper;

        //private IMapper _mapper;

        public BookRepository( BookDbContext bookDbContext,IMapper mapper)
        {
               
            _dbContext = bookDbContext;
            _mapper = mapper;
            //_mapper = mapper;   

        }
        
        public async Task<Book> AddBook(Book book)
        {
            
            if (book.Id > 0)
            {
                _dbContext.Update(book); 
            }
            else
            {
                
                _dbContext.Books.Add(book);
                  
            }
            await  _dbContext.SaveChangesAsync();
            return (book);

        }

        public async Task<Book> GetBookFromId(int id)
        {
            Book bookL = await _dbContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            return (bookL);


        }

        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            var bookList = await _dbContext.Books.ToListAsync();
             return _mapper.Map<IEnumerable<BookDto>>(bookList);   


        }
    }
}
