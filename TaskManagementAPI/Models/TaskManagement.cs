using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class TaskManagement
    {
        [Key]
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public int AssignBy { get; set; }

        public string AssignDate { get; set; }

        public string AssignTime { get; set;}

        public string Deadline { get; set; }

        public string Status { get; set; }




    }
}
