namespace WebApiProj.Business
{
    using AutoMapper;

    /// <summary>
    /// Mapping Profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Client.Models.User, DataAccess.Models.User>();
            CreateMap<DataAccess.Models.User, Client.Models.User>();
        }
    }
}
