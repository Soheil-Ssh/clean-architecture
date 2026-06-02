namespace CleanArch.Api.Mappers;

public class CommonMapperProfile : Profile
{
    public CommonMapperProfile()
    {
        // map type of Pagination<> => another type of Pagination<>
        CreateMap(typeof(Pagination<>), typeof(Pagination<>));
    }
}