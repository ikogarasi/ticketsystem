using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStationRepository Stations { get; }
        IRouteRepository Routes { get; }
        IBoardingPassRepository BoardingPasses { get; }
        IUserRepository Users { get;  }

        void Save();
    }
}
