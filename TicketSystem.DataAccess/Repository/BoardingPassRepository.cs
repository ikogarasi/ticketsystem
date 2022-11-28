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
    public class BoardingPassRepository : Repository<BoardingPassModel>, IBoardingPassRepository
    {
        private readonly ApplicationDbContext _db;
    
        public BoardingPassRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    
        public void Update(BoardingPassModel obj)
        {
            var boardPassFromDb = _db.BoardingPasses.FirstOrDefault(i => i.Id == obj.Id);
            if (boardPassFromDb != null)
            {
                foreach (PropertyInfo prop in typeof(BoardingPassModel).GetProperties())
                {
                    if (prop.GetValue(obj) != null)
                    {
                        prop.SetValue(boardPassFromDb, prop.GetValue(obj, null));
                    }
                }
            }
        }
    }
}
