using CarSharingDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingImage.Commands
{
    public class ImageDeleteCommandHandler : IRequestHandler<ImageDeleteCommand>
    {
        private readonly ICarSharingRepositories _carSharingRepositories;

        public ImageDeleteCommandHandler(ICarSharingRepositories carSharingRepositories)
        {
           _carSharingRepositories = carSharingRepositories;
        }
        public async Task<Unit> Handle(ImageDeleteCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new NotImplementedException();
            }
            await _carSharingRepositories.DeleteImageById(request.Id);
            return Unit.Value;
        }
    }
}
