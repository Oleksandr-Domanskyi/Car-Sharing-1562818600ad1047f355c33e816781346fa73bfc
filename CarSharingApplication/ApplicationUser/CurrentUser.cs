using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.ApplicationUser
{
    public class CurrentUser
    {

        public CurrentUser(string id, string email, string roles)
        {
            Id = id;
            Email = email;
            Roles = roles;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string? Roles { get; set; }


        public bool isInRole(string role)=>Roles == role;

    }
}
