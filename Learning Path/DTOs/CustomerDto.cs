using Learning_Path.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning_Path.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        
        public byte MembershipTypeId { get; set; }
        
        [Min18YerasIfAMember]
        public DateTime? Birthday { get; set; }
    }
}