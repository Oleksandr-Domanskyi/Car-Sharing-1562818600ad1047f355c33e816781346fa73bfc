using CarSharingApplication.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfileCommands.Queries.GetAllCarSharing
{
    public class GetAllCarSharingQuery : IRequest<IEnumerable<ShowCarSharingProfileModelObject>>
    {
    }
}
