using CarSharingDomain.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingDomain.DomainModels
{
    public class CarContactDetails
    {
        public Countries? Coutry { get; set; }
        public string? City { get; set; }
        public string? ContactNumber { get; set; }

        public ValueMoney ValueMoney { get; set; }
    }
}
