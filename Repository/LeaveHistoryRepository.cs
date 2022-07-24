using Leave_Management.Contracts;
using Leave_Management.Data;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _Db;

        public LeaveHistoryRepository(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        public bool Create(LeaveHistory entity)
        {
            _Db.LeaveHistories.Add(entity);
            //save
            return save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _Db.LeaveHistories.Remove(entity);
            //save
            return save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var LeaveHistory = _Db.LeaveHistories.ToList();
            return LeaveHistory;
        }

        public LeaveHistory FindById(int id)
        {
            return _Db.LeaveHistories.Find(id);
        }

        public bool save()
        {
            var saveChanges = _Db.SaveChanges();
            return saveChanges > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _Db.LeaveHistories.Update(entity);
            //save
            return save();
        }
    }
}
