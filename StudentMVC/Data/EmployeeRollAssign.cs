using StudentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVC.Data
{
    public class EmployeeRollAssign : WorkForce 
    {
        public string EmpEmail  { get; set; }

        public string GrabEmail() 
        {
            EmpEmail = Email;
            return EmpEmail; 
        }
      


    }
}
