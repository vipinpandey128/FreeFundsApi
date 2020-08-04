using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Mappings
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<UsersProfileViewModel, Users>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.Contactno, opt => opt.MapFrom(src => src.Contactno))
                .ForMember(dest => dest.WithDrawalPin, opt => opt.MapFrom(src => src.WithDrawalPin))
                .ForMember(dest => dest.CurrentBal, opt => opt.MapFrom(src => src.CurrentBal))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Users, UsersProfileViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.Contactno, opt => opt.MapFrom(src => src.Contactno))
                .ForMember(dest => dest.WithDrawalPin, opt => opt.MapFrom(src => src.WithDrawalPin))
                .ForMember(dest => dest.CurrentBal, opt => opt.MapFrom(src => src.CurrentBal))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<SchemeMasterViewModel, SchemeMaster>()
                .ForMember(dest => dest.SchemeName, opt => opt.MapFrom(src => src.SchemeName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<TransactionViewModel, AllTransaction>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.TransactionAmount, opt => opt.MapFrom(src => src.TransactionAmount))
                .ForMember(dest => dest.IpAddress, opt => opt.MapFrom(src => src.IpAddress))
                .ForMember(dest => dest.pin, opt => opt.MapFrom(src => src.pin))
                .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.TransactionTypeId));

            CreateMap<SchemeMasterEditViewModel, SchemeMaster>()
                .ForMember(dest => dest.SchemeName, opt => opt.MapFrom(src => src.SchemeName))
                .ForMember(dest => dest.SchemeID, opt => opt.MapFrom(src => src.SchemeID))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));


            CreateMap<Role, RoleViewModel>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<MemberRegistrationViewModel, MemberRegistration>()
                .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.MemberId))
                .ForMember(dest => dest.MemberFName, opt => opt.MapFrom(src => src.MemberFName))
                .ForMember(dest => dest.MemberLName, opt => opt.MapFrom(src => src.MemberLName))
                .ForMember(dest => dest.MemberMName, opt => opt.MapFrom(src => src.MemberMName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Contactno, opt => opt.MapFrom(src => src.Contactno))
                .ForMember(dest => dest.JoiningDate, opt => opt.MapFrom(src => src.JoiningDate))
                .ForMember(dest => dest.PlanID, opt => opt.MapFrom(src => src.PlanID))
                .ForMember(dest => dest.SchemeID, opt => opt.MapFrom(src => src.SchemeID))
                .ForMember(dest => dest.MemImagePath, opt => opt.Ignore())
                .ForMember(dest => dest.MemImagename, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());

            CreateMap<UsersViewModel, Users>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Contactno, opt => opt.MapFrom(src => src.Contactno))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        }
    }
}

    