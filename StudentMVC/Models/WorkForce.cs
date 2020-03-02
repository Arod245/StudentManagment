using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVC.Models
{
    public class WorkForce: IdentityUser
    {
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }
        public string Firstname { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }

        public override string PhoneNumber { get; set; }*/
      
    }
}
