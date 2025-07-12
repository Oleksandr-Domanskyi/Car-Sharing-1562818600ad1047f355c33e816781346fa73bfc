using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingDomain.DomainModels
{
    public class GlobalProfileImage
    {
        public string? Name { get; set; }
        public string? FileType { get; set; }
        public byte[]? DataFile { get; set; }
    }
}
