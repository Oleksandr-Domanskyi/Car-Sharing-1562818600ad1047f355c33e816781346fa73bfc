using CarSharingDomain.DomainModels.Enums.EnumDefinitionsOfStringValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingDomain.DomainModels.Enums
{
    public enum ValueMoney
    {
        [EnumStringValueAttribute("Zł")]
        Zł,
        [EnumStringValueAttribute("Euro")]
        Euros,
        [EnumStringValueAttribute("Dollar")]
        Dollars,

    }
}
