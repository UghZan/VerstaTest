using AutoMapper;
using VerstaMain.Data.Models;
using VerstaMain.Models;

namespace VerstaMain.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddOrderModel, Order>()
                .ForMember(u => u.Id, m => m.MapFrom(s => Guid.NewGuid()))
                .ForMember(u => u.CreationDate, m => m.MapFrom(s => DateTime.Now));
            CreateMap<Order, GetOrderModel>();
        }
    }
}
