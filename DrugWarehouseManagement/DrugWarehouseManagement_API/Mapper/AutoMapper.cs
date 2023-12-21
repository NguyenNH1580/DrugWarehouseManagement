using AutoMapper;
using DrugWarehouseManagement_API.Entities;
using DrugWarehouseManagement_ViewModel.ViewModels.User;

namespace DrugWarehouseManagement_API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateUserViewModel, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
