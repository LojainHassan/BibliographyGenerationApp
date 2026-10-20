using AutoMapper;
using BibliographyGenerationApp.DTOs;
using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.Mapper
{
    public class MainAppMapperProfile:Profile
    {
        public MainAppMapperProfile()
        {
            CreateMap<DepositOrder, DepositOrderDto>();
            CreateMap<DepositOrderDto, DepositOrder>();

        }
    }
}
