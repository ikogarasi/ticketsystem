using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.DataAccess.Repository.IRepository
{
    public interface IStationRepository : IRepository<StationModel>
    {
        void Update(StationModel obj);

        bool Contains(string name);
    }
}
