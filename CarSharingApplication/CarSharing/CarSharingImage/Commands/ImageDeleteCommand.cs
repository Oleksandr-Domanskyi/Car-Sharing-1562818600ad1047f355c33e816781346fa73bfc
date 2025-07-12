using CarSharingApplication.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingImage.Commands
{
    public class ImageDeleteCommand:IRequest
    {
        public ImageDeleteCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
