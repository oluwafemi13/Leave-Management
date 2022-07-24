using Leave_Management.Contracts;
using Leave_Management.Data;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {

        private readonly ApplicationDbContext _Db;

        public LeaveAllocationRepository(ApplicationDbContext Db)
        { 
            _Db = Db;
        }
        public bool Create(LeaveAllocation entity)
        {
            _Db.LeaveAllocations.Add(entity);
            return save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _Db.LeaveAllocations.Remove(entity);
            return save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var LeaveAllocation = _Db.LeaveAllocations.ToList();
            return LeaveAllocation;

        }

        public LeaveAllocation FindById(int id)
        {
           return _Db.LeaveAllocations.Find(id);
        }

        public bool save()
        {
            var saveChanges = _Db.SaveChanges();
            return saveChanges > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _Db.LeaveAllocations.Update(entity);
            return save();
        }
    }
}
