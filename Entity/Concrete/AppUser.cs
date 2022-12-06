using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class AppUser : IdentityUser<int>,IEntity
    {
        public string NameSurname { get; set; } 
        public List<Mission> Missions { get; set; }
    }
}
