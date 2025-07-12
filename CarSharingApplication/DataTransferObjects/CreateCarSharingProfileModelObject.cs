using CarSharingDomain.DomainModels;
using CarSharingDomain.DomainModels.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.DataTransferObjects
{
    public class CreateCarSharingProfileModelObject
    {
        //Car Profile
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int? PricePerDay { get; set; }

        public IFormFile GlobalProfileImage { get; set; } = default!;
        public List<IFormFile> Images { get; set; } = default!;

        //Contact Details
        public string? Coutry { get; set; }
        public string? City { get; set; }
        public string? ContactNumber { get; set; }
        public ValueMoney ValueMoney { get; set; }
        
        //Car Characteristics
        public string? Silnik { get; set; }
        public string? Color { get; set; }
        public string? Felgi { get; set; }
        public string? Tapicerka { get; set; }

    }

}
