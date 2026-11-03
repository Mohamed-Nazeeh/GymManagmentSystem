using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentSystem.DAL.Models
{
    public class HealthRecord : BaseEntitiy
    {
        public decimal Height { get; set; }
        public decimal Weidth { get; set; }
        [Required , MaxLength(5)]
        public string bloodType { get; set; } = default!;
        [MaxLength(100)]
        public string? Note { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;
    }
}
