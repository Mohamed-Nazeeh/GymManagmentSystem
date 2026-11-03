using GymManagmentSystem.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentSystem.DAL.Models
{
    public abstract class GymUser : BaseEntitiy
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required, MaxLength(20), EmailAddress]
        public string Email { get; set; } = null!;
        [Required,MaxLength(11)]
        [RegularExpression(@"^(010|011|012|015)\d{8}$",ErrorMessage = "Egyption Phone Formate Only")]
        public string Phone { get; set; } = null!;
        public DateOnly DateOfBarth { get; set; }
        public Gander Gander { get; set; }
        public Address Address { get; set; } = null!;
    }

    [Owned]
    public class  Address
    {
       
        public int BuildingNumber { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; } = null!;
        [Required, MaxLength(100)]
        public string Street { get; set; } = null!;

    }
}
