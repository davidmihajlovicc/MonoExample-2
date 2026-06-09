using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Model
{
    public class AuthorProfile : Profile
    {

        public AuthorProfile() {

            CreateMap<Author, GetAuthorDto>();

            CreateMap<AddAuthorDto, Author>();
        
        }

    }
}
