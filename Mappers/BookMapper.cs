using AutoMapper;
using BibliotecaAPI.DTOs;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Mappers;

public class BookMapper : Profile
{
   public BookMapper()
   {
      CreateMap<CreateBookDto, Book>();
      CreateMap<UpdateBookDto, Book>() // Ignores ID, CreatedAt, UpdatedAt
         .ForMember(dest => dest.Id, opt => opt.Ignore())
         .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
         .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
         // Ignores null values to update only specified fields
         .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<Book, ReadBookDto>();
   }
}