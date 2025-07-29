using AutoMapper;
using QuanLyHocVien.Applications.DTOs;
using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Applications.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Trainee, TraineeDto.ViewModel>().ReverseMap();
            CreateMap<Class, ClassDto.ViewModel>().ReverseMap();
        }
    }

}
