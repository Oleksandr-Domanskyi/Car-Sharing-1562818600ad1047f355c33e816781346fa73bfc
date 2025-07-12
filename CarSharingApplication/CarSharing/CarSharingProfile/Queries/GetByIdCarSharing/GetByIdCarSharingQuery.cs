using CarSharingApplication.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfileCommands.Queries.GetByNameCarSharing
{
    public class GetByIdCarSharingQuery : IRequest<ShowCarSharingProfileModelObject>
    {
        public Guid Id { get; set; }

        public GetByIdCarSharingQuery(Guid id)
        {
            Id = id;
        }
    }
}
