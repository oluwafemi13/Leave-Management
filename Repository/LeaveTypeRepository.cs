using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {

        private readonly ApplicationDbContext _Db;

        public LeaveTypeRepository(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        public bool Create(LeaveType entity)
        {
            _Db.LeaveTypes.Add(entity);
            //save
            return save();
        }

        public bool Delete(LeaveType entity)
        {
            _Db.LeaveTypes.Remove(entity);
            //save you must save to the database
            return save();
        } 

        public ICollection<LeaveType> FindAll()
        {
            var LeaveTypes = _Db.LeaveTypes.ToList();
            return LeaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var LeaveType = _Db.LeaveTypes.Find(id);
            return LeaveType;
        }

        public bool save()
        {
            var changes = _Db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveType entity)
        {
            _Db.LeaveTypes.Update(entity);

            return save();
            
        }
    }
}
