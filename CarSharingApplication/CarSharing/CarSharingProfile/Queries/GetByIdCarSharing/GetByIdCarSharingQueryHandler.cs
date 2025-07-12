using AutoMapper;
using CarSharingApplication.DataTransferObjects;
using CarSharingDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfileCommands.Queries.GetByNameCarSharing
{
    public class GetByIdCarSharingQueryHandler : IRequestHandler<GetByIdCarSharingQuery, ShowCarSharingProfileModelObject>
    {
        private readonly ICarSharingRepositories _carSharingRepositories;
        private readonly IMapper _mapper;

        public GetByIdCarSharingQueryHandler(ICarSharingRepositories carSharingRepositories, IMapper mapper)
        {
            _carSharingRepositories = carSharingRepositories;
            _mapper = mapper;
        }
        public async Task<ShowCarSharingProfileModelObject> Handle(GetByIdCarSharingQuery request, CancellationToken cancellationToken)
        {
            var CarSharing = await _carSharingRepositories.GetByName(request.Id);
            var dto = _mapper.Map<ShowCarSharingProfileModelObject>(CarSharing);

            return dto;
        }
    }
}
