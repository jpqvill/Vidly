using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please Enter your name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public Nullable<DateTime> BirthDate { get; set; }
        
        public bool IsSubscribedToNewsLetter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Types")]
        public byte MembershipTypeId { get; set; }
    }
}