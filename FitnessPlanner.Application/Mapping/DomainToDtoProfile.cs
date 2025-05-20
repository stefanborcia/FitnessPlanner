using AutoMapper;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Domain.Entities;

namespace FitnessPlanner.Application.Mapping
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Goal, opt => opt.MapFrom(src => src.Goal.ToString()))
                .ForMember(dest => dest.BodyType, opt => opt.MapFrom(src => src.BodyType.ToString()));

            CreateMap<Exercise, ExerciseDto>();
            CreateMap<WorkoutPlan, WorkoutPlanDto>();
            CreateMap<RegisterDto, User>();
        }
    }
}
