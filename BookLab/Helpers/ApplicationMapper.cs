using AutoMapper;
using BookLab.Models;
using BookLab.Models.Dto;

namespace BookLab.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }

    }
}
