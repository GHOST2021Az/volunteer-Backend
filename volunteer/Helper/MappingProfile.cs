using AutoMapper;
using volunteer.Models;
using volunteer.DTO;

namespace volunteer.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aprovedpost, AprovedDTO>();
            CreateMap<Pendingpost, pendingDTO>();
            CreateMap<AprovedDTO, Aprovedpost>();
            CreateMap<pendingDTO, Pendingpost>();
        }
    }
}