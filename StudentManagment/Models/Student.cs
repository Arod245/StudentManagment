using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagment.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
        public string LetterGrade { get; set; }



    }
}