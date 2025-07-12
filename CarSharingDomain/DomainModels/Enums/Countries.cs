using CarSharingDomain.DomainModels.Enums.EnumDefinitionsOfStringValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingDomain.DomainModels.Enums
{
    
    public enum Countries
    {
        [EnumStringValueAttribute("Poland")]
        Poland,
        [EnumStringValueAttribute("German")]
        German,
        [EnumStringValueAttribute("Ukraine")]
        Ukraine,
        [EnumStringValueAttribute("USA")]
        USA,
        [EnumStringValueAttribute("France")]
        France
    }

    
}
