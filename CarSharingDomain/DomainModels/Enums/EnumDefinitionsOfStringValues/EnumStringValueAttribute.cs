using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingDomain.DomainModels.Enums.EnumDefinitionsOfStringValues
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class EnumStringValueAttribute : Attribute
    {
        public string Value { get; }

        public EnumStringValueAttribute(string value)
        {
            Value = value;
        }
    }
}
