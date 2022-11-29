using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.DataAccess.Repository.IRepository
{
    public interface IRouteRepository : IRepository<RouteModel>
    {
        void Update(RouteModel obj);

        IEnumerable<RouteModel> GetRoutesFromId(List<Guid> id);
    }
}
