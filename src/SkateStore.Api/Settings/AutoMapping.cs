using AutoMapper;
using SkateStore.Api.Model;
using SkateStore.Api.ViewModel;

namespace SkateStore.Api.Settings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
        }
    }
}
