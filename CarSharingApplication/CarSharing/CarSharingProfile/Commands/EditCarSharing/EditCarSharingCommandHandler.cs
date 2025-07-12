using AutoMapper;
using CarSharingApplication.ApplicationUser;
using CarSharingApplication.DataTransferObjects;
using CarSharingApplication.Handler.ImageHandler;
using CarSharingApplication.Mapping;
using CarSharingDomain.DomainModels;
using CarSharingDomain.DomainModels.Enums;
using CarSharingDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CarSharingApplication.CarSharing.CarSharingProfileCommands.Commands.EditCarSharing
{
    public class EditCarSharingCommandHandler : IRequestHandler<EditCarSharingCommand>
    {
        private readonly ICarSharingRepositories _carSharingRepositories;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public EditCarSharingCommandHandler(ICarSharingRepositories carSharingRepositories, IMapper mapper,IUserContext userContext)
        {
            _carSharingRepositories = carSharingRepositories;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditCarSharingCommand request, CancellationToken cancellationToken)
        {
            var CarSharing = await _carSharingRepositories.GetByName(request.Id);

            var user = _userContext.GetCurrentUser();
            var isEditable = user!=null && (CarSharing?.CreatedById == user.Id || user.isInRole("Admin"));

            if(!isEditable)
            {
                return Unit.Value;
            }
            
            if (CarSharing == null)
            {
                return Unit.Value;
            }

            
            if( request.NewImages != null)
            {
                var ImagesParsing = ImageHandler.MapImages(request.NewImages!);
                CarSharing.Image.AddRange(ImagesParsing);
            }
            if(request.PreViewImage != null)
            {
                CarSharing.GlobalProfileImage = ImageHandler.MapGlobalImages(request.PreViewImage);
            }
            CarSharing.GlobalProfileImage = CarSharing.GlobalProfileImage;
           
            CarSharing.PricePerDay = request.PricePerDay;
            CarSharing.Description = request.Description;
            CarSharing.Name = request.Name;

            CarSharing.Characteristics.Engine = request.Characteristics?.Engine;
            CarSharing.Characteristics.Color = request.Characteristics?.Color;
            CarSharing.Characteristics.Upholstery = request.Characteristics?.Upholstery;
            CarSharing.Characteristics.Rims = request.Characteristics?.Rims;

            CarSharing.CarContactDetails.ContactNumber = request.ContactNumber;
            CarSharing.CarContactDetails.City = request.City;
            CarSharing.CarContactDetails.Coutry = request.Coutry != null ? Enum.Parse<Countries>(request.Coutry, true) : null;
            CarSharing.CarContactDetails.ValueMoney = Enum.Parse<ValueMoney>(request.ValueMoney.ToString()!, true);


            await _carSharingRepositories.SaveChanges();

            return Unit.Value;


        }
    }
}
