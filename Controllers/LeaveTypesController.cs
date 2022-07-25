using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController( ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

            
        }
        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leaveType = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leaveType);

            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (_repo.isExists(id))
            {
                var leaveType = _repo.FindById(id);
                var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
                return View(model);
            }
            else
            {
                return NotFound();
            }
            return View();
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var leaveType = _mapper.Map<LeaveType>(model);
                    leaveType.DateCreated = DateTime.Now;
                   var isSuccess = _repo.Create(leaveType);
                    if (!isSuccess)
                    {
                        ModelState.AddModelError("", "Something Went Wrong...");
                        return View(model);
                    }

                }
                else
                {
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (_repo.isExists(id))
            {
                var leaveType = _repo.FindById(id);
                var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
                return View(model);
            }
            else
            {
                return NotFound();
            }
            
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var leaveType = _mapper.Map<LeaveType>(model);
                    //leaveType.DateCreated = DateTime.Now;
                    var isSuccess = _repo.Update(leaveType);
                    if (!isSuccess)
                    {
                        ModelState.AddModelError("", "Something Went Wrong...");
                        return View(model);
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }
                else
                {
                    return View(model);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            /* if (_repo.isExists(id))
             {
                 var leaveType = _repo.FindById(id);
                 var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
                 return View(model);
             }
             else
             {
                 return NotFound();
             }*/
            try
            {

                var leaveType = _repo.FindById(id);
                if (leaveType == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(leaveType);

                if (isSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //return View(model); also include the LeaveTypeViewModel in the Delete Parameter
                    return BadRequest();
                }

            }
            catch
            {
                return View();
            }

        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        public ActionResult DeleteInfo(int id)
        {
            try
            {

                var leaveType = _repo.FindById(id);
                if(leaveType == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(leaveType);

                if (isSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //return View(model); also include the LeaveTypeViewModel in the Delete Parameter
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
