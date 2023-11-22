using AutoMapper;
using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Infrastructure.Identity.DTOs;

public class ApplicationUserDto: IMapFrom<ApplicationUser>
{
    public ApplicationUserDto(string id, string? username, string name, string email, UploadedFile profilePicture)
    {
        Id = id;
        Username = username;
        Name = name;
        Email = email;
        ProfilePicture = profilePicture;
    }

    public string Id { get; set; }
    public string? Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UploadedFile ProfilePicture { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ApplicationUser, ApplicationUserDto>()
            .ForMember(desc => desc.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture))
            .ForMember(desc => desc.Name, opt => opt.MapFrom(src => src.FullName))
            .ForMember(desc => desc.Username, opt => opt.MapFrom(src => src.UserName))
            .ForMember(desc => desc.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.Id));
    }
}
