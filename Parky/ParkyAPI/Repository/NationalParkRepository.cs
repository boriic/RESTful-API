using ParkyAPI.DAL.Context;
using ParkyAPI.DAL.Entities;
using ParkyAPI.Repository.Common;
using System.Collections.Generic;
using System.Linq;

namespace ParkyAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;
        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);

            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Remove(nationalPark);

            return Save();
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Update(nationalPark);

            return Save();
        }

        public NationalPark GetNationalPark(int id)
        {
            var nationalPark = _db.NationalParks.FirstOrDefault(x => x.Id == id);

            return nationalPark;
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            var nationalParks = _db.NationalParks.OrderBy(x => x.Name).ToList();

            return nationalParks;
        }

        public bool NationalParkExists(string name)
        {
            var nationalParkExists = _db.NationalParks.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());

            return nationalParkExists;
        }

        public bool NationalParkExists(int id)
        {
            var nationalParkExists = _db.NationalParks.Any(x => x.Id == id);

            return nationalParkExists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }
    }
}
