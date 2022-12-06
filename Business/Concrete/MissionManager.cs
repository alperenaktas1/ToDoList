using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MissionManager : IMissionService
    {
        IMissionDal _missionDal;
        public MissionManager(IMissionDal missionDal)
        {
            _missionDal= missionDal;
        }
        public void Add(Mission mission)
        {
            if (mission.MissionName.Length >=2)
            {
                _missionDal.Add(mission);
            }
            else
            {
                Console.WriteLine("Mission name can not be less than 2 characters");
            }
        }

        public void Delete(Mission mission)
        {
           _missionDal.Delete(mission);
        }

        public List<Mission> GetAll()
        {
            return _missionDal.GetAll();
        }

        public Mission GetById(int id)
        {
            return _missionDal.Get(x=>x.MissionID== id);
        }

        public void Update(Mission mission)
        {
           _missionDal.Update(mission);
        }

        public List<Mission> GetAllByUser(int id)
        {
            return _missionDal.GetAll(x => x.UserId == id);
        }
    }
}
