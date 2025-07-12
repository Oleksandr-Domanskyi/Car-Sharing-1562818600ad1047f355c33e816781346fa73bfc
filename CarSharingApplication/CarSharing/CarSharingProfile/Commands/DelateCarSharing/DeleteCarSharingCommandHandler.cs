using CarSharingDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CarSharingApplication.CarSharing.CarSharingProfile.Commands.DelateCarSharing
{
    public class DeleteCarSharingCommandHandler : IRequestHandler<DeleteCarSharingCommand>
    {
        private readonly ICarSharingRepositories _carSharingRepositories;

        public DeleteCarSharingCommandHandler(ICarSharingRepositories carSharingRepositories)
        {
            _carSharingRepositories = carSharingRepositories;
        }
        public async Task<Unit> Handle(DeleteCarSharingCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == default)
            {
                throw new ArgumentNullException(nameof(request.Id));
            }
            await _carSharingRepositories.DeleteCarSharing(request.Id);
            return Unit.Value;
        }
    }
}
