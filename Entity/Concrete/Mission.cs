using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Mission : IEntity
    {
        public int UserId { get; set; }
        public int MissionID { get; set; }
        public string MissionName { get; set; }
        public string MissionDescription { get; set;}
        public bool MissionState { get; set; }
        public AppUser User { get; set; }
    }
}
