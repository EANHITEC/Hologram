using System;
using System.ComponentModel.DataAnnotations;

namespace Hologram.Models
{
    public class AdminInfoViewModel
    {
        public int No { get; set; }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        public string Nickname { get; set; }

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