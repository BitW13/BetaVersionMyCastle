using AutoMapper;
using Common.Entity.TaskPlannerService;
using TaskPlannerService.WebApi.Models;

namespace TaskPlannerService.WebApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskEntity, CreateTask>()
                .ReverseMap();

            CreateMap<TaskCategory, CreateTaskCategory>()
                .ReverseMap();

            CreateMap<Severity, CreateSeverity>()
                .ReverseMap();
        }
    }
}
