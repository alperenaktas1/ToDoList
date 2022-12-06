using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMissionService
    {
        List<Mission> GetAll();
        void Add(Mission mission);
        void Delete(Mission mission);
        void Update(Mission mission);
        Mission GetById(int id);
        List<Mission> GetAllByUser(int id);
    }
}
