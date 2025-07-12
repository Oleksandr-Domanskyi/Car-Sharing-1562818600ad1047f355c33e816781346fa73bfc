using AutoMapper;
using CarSharingApplication.ApplicationUser;
using CarSharingDomain.DomainModels;
using CarSharingDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfileCommands.Commands.CreateCarSharing
{
    public class CreateCarSharingCommandHandler : IRequestHandler<CreateCarSharingCommand>
    {
        private readonly ICarSharingRepositories _carSharingRepositories;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarSharingCommandHandler(ICarSharingRepositories carSharingRepositories, IMapper mapper,IUserContext userContext)
        {
            _carSharingRepositories = carSharingRepositories;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateCarSharingCommand request, CancellationToken cancellationToken)
        {
            var CarSharing = _mapper.Map<CarProfileModel>(request);

            CarSharing.CreatedById = _userContext.GetCurrentUser().Id;
            
            await _carSharingRepositories.Create(CarSharing);

            return Unit.Value;
        }
    }
}
