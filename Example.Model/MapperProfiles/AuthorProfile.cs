using AutoMapper;
using Example.Model.Domain;
using Example.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Model.MapperProfiles
{
    public class AuthorProfile : Profile
    {

        public AuthorProfile() {

            CreateMap<Author, GetAuthorDto>();

            CreateMap<AddAuthorDto, Author>();
        
        }

    }
}
