using System.Linq;
using AutoMapper;
using BusinessProcesses.Server.Domain.Models;
using BusinessProcesses.Server.Domain.ViewModels;

namespace BusinessProcesses.Web.Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {           
            CreateMap<Job, ListJobItem>()
                .ForMember(
                    job => job.CountActive, 
                    from => from.MapFrom(src => src.JobInstances.Count(j => j.Status == JobStatus.Active))
                )
                .ForMember(
                    job => job.UpdatedOn, 
                    opt => opt.Condition(src => src.UpdatedOn.HasValue)
                )
                .ForMember(
                    job => job.UpdatedBy, 
                    opt => opt.MapFrom(src => src.UpdatedByUser.Name)
                )
                .ForMember(
                    job => job.CreatedBy, 
                    opt => opt.MapFrom(src => src.CreatedByUser.Name)
                );

            CreateMap<User, UserItem>();
        }    
    }
}