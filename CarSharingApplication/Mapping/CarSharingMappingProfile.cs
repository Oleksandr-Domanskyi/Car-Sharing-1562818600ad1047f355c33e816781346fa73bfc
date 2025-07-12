using AutoMapper;
using CarSharingApplication.DataTransferObjects;
using CarSharingDomain.DomainModels;
using CarSharingApplication.Handler.ImageHandler;
using CarSharingDomain.DomainModels.Enums;
using System.Linq;
using Microsoft.AspNetCore.Http;
using CarSharingApplication.CarSharing.CarSharingProfileCommands.Commands.EditCarSharing;
using CarSharingApplication.ApplicationUser;

namespace CarSharingApplication.Mapping
{
    public class CarSharingMappingProfile : Profile
    {
        public CarSharingMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<CarProfileModel, CreateCarSharingProfileModelObject>()
                .ForMember(dto => dto.Silnik, opt => opt.MapFrom(src => src.Characteristics.Engine))
                .ForMember(dto => dto.Tapicerka, opt => opt.MapFrom(src => src.Characteristics.Upholstery))
                .ForMember(dto => dto.Felgi, opt => opt.MapFrom(src => src.Characteristics.Rims))
                .ForMember(dto => dto.Color, opt => opt.MapFrom(src => src.Characteristics.Color));

            CreateMap<CreateCarSharingProfileModelObject, CarProfileModel>()
                .ForMember(dto => dto.Characteristics, opt => opt.MapFrom(src => new CarChatacteristics()
                {
                    Engine = src.Silnik,
                    Color = src.Color,
                    Rims = src.Felgi,
                    Upholstery = src.Tapicerka
                }))
                .ForMember(dto => dto.CarContactDetails, opt => opt.MapFrom(src => new CarContactDetails
                {
                    Coutry = src.Coutry != null ? Enum.Parse<Countries>(src.Coutry, true) : null,
                    City = src.City,
                    ContactNumber = src.ContactNumber,
                    ValueMoney = Enum.Parse<ValueMoney>(src.ValueMoney.ToString(), true)
                }))
                .ForMember(dest => dest.GlobalProfileImage, opt => opt.MapFrom(src => ImageHandler.MapGlobalImages(src.GlobalProfileImage)))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ImageHandler.MapImages(src.Images)));


            CreateMap<CarProfileModel, ShowCarSharingProfileModelObject>()
                .ForMember(dest => dest.Silnik, opt => opt.MapFrom(src => src.Characteristics.Engine))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Characteristics.Color))
                .ForMember(dest => dest.Felgi, opt => opt.MapFrom(src => src.Characteristics.Rims))
                .ForMember(dest => dest.Tapicerka, opt => opt.MapFrom(src => src.Characteristics.Upholstery))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.GlobalProfileImage, opt => opt.MapFrom(src => src.GlobalProfileImage))

                .ForMember(dest => dest.Coutry, opt => opt.MapFrom(src => src.CarContactDetails.Coutry.ToString()))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.CarContactDetails.City))
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(src => src.CarContactDetails.ContactNumber))
                .ForMember(dest => dest.ValueMoney, opt => opt.MapFrom(src => src.CarContactDetails.ValueMoney.ToString()))

                .ForMember(dest => dest.IsEditable, opt => opt.MapFrom(src => user!=null && (src.CreatedById == user.Id || user.isInRole("Admin"))));

            CreateMap<ShowCarSharingProfileModelObject, EditCarSharingCommand>()
                .ForMember(dest => dest.ExistingImages, opt => opt.MapFrom(src => src.Images))
                .ForMember(dest => dest.NewImages, opt => opt.MapFrom(src => new List<IFormFile>()))
                .ForMember(dest => dest.GlobalProfileImage, opt => opt.MapFrom(src => src.GlobalProfileImage));
        }
    }
}
