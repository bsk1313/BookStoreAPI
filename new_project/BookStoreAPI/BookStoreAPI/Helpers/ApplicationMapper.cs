using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
