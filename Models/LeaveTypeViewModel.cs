using System;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Models
{
    public class LeaveTypeViewModel
    {
       
        public int Id { get; set; }

        
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
    }


    public class CreateLeaveTypeViewModel
    {
        [Required]          
        public string Name { get; set; }

    }
}
