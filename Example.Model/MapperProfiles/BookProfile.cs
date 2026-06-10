using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Example.Model.Domain;
using Example.Model.DTO;

namespace Example.Model.MapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile() {


            CreateMap<Book, GetBookDto>();

            CreateMap<AddBookDto, Book>();

        }
    }
}
