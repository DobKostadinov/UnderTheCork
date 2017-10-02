using AutoMapper;

namespace UnderTheCork.Web.Infrastructure.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
