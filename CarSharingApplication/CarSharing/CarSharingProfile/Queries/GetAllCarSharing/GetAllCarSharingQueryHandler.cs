using AutoMapper;
using CarSharingApplication.DataTransferObjects;
using CarSharingDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfileCommands.Queries.GetAllCarSharing
{
    public class GetAllCarSharingQueryHandler : IRequestHandler<GetAllCarSharingQuery, IEnumerable<ShowCarSharingProfileModelObject>>
    {
        private readonly ICarSharingRepositories _carSharingRepositories;
        private readonly IMapper _mapper;

        public GetAllCarSharingQueryHandler(ICarSharingRepositories carSharingRepositories, IMapper mapper)
        {
            _carSharingRepositories = carSharingRepositories;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShowCarSharingProfileModelObject>> Handle(GetAllCarSharingQuery request, CancellationToken cancellationToken)
        {
            var CarSharingDomain = await _carSharingRepositories.GetAll();
            var ParseCarDomainToCarObject = _mapper.Map<IEnumerable<ShowCarSharingProfileModelObject>>(CarSharingDomain);
            return ParseCarDomainToCarObject;
        }
    }
}
