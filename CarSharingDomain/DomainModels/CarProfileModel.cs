using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingDomain.DomainModels
{
    public class CarProfileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public GlobalProfileImage GlobalProfileImage { get; set; } = default!;
        public CarChatacteristics Characteristics { get; set; } = default!;
        public CarContactDetails CarContactDetails { get; set; } = default!;
        public int? PricePerDay { get; set; }

        

        public List<Image> Image { get; set; } = default!;
    }
}
