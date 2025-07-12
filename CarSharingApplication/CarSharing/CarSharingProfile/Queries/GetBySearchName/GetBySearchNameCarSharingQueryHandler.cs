using AutoMapper;
using CarSharingApplication.DataTransferObjects;
using CarSharingDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfile.Queries.GetBySearchName
{
    public class GetBySearchNameCarSharingQueryHandler : IRequestHandler<GetBySearchNameCarSharingQuery, IEnumerable<ShowCarSharingProfileModelObject>>
    {
        private readonly ICarSharingRepositories _carSharingRepositories;
        private readonly IMapper _mapper;

        public GetBySearchNameCarSharingQueryHandler(ICarSharingRepositories carSharingRepositories, IMapper mapper)
        {
            _carSharingRepositories = carSharingRepositories;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShowCarSharingProfileModelObject>> Handle(GetBySearchNameCarSharingQuery request, CancellationToken cancellationToken)
        {
            var DomainModel = await _carSharingRepositories.GetBySearchName(request.Search);

            var DomainToDto = _mapper.Map<IEnumerable<ShowCarSharingProfileModelObject>>(DomainModel);

            return DomainToDto;
        }
    }
}
