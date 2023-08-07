using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hologram.Models
{
    public class AdminListViewModel
    {
        public AdminInfoViewModel CurrentAdmin { get; set; }
        public List<AdminListViewModel> AdminList { get; set; }

        public int No { get; set; }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Email { get; set; }

        public string Dept { get; set; }

        public string Job_Title { get; set; }

        public string Memo { get; set; }

        public DateTime Reg_Date { get; set; }
    }
}