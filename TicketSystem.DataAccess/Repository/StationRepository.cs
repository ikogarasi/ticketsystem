using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DataAccess.Data;
using TicketSystem.DataAccess.Repository.IRepository;
using TicketSystem.Models;

namespace TicketSystem.DataAccess.Repository
{
    public class StationRepository : Repository<StationModel>, IStationRepository
    {
        private readonly ApplicationDbContext _db;

        public StationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Contains(string name)
        {
            if (_db.Stations.FirstOrDefault(i => i.Name == name) != null)
                return true;
            return false;
        }

        public void Update(StationModel obj)
        {
            var stationFromDb = _db.Stations.FirstOrDefault(i => i.Id == obj.Id);
            if (stationFromDb != null)
            {
                foreach (PropertyInfo prop in typeof(StationModel).GetProperties())
                {
                    if (prop.GetValue(obj) != null)
                    {
                        prop.SetValue(stationFromDb, prop.GetValue(obj, null));
                    }
                }
            }
        }
    }
}
