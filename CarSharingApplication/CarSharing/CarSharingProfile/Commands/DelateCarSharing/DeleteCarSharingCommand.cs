using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfile.Commands.DelateCarSharing
{
    public class DeleteCarSharingCommand:IRequest
    {
        public DeleteCarSharingCommand(Guid id)
        {
            Id= id;
        }
        public Guid Id { get; set;}
    }
}
