using CarSharingApplication.DataTransferObjects;
using CarSharingDomain.DomainModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfileCommands.Commands.CreateCarSharing
{
    public class CreateCarSharingCommand : CreateCarSharingProfileModelObject, IRequest
    {
    }
}
