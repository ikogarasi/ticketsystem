using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DataAccess.Data;
using TicketSystem.DataAccess.Repository.IRepository;

namespace TicketSystem.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Stations = new StationRepository(_db);
            Routes = new RouteRepository(_db);
            BoardingPasses = new BoardingPassRepository(_db);
            Users = new UserRepository(_db);
        }

        public IStationRepository Stations { get; private set; }
        public IRouteRepository Routes { get; private set; }
        public IBoardingPassRepository BoardingPasses { get; private set; }
        public IUserRepository Users { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
