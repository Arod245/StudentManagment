using StudentWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentWPF.APIMethods
{
    public class ApiMethods
    {
        public void test() { }
        public  async Task Create (string firstName, string lastName, int age, double gpa, string letterGrade) 
        {
            Student stud = new Student();
            stud.FirstName = firstName;
            stud.LastName = lastName;
            stud.Age = age;
            stud.GPA = gpa;
            stud.LetterGrade = letterGrade;

            using (HttpResponseMessage response = await APIHelper.client.PostAsJsonAsync("api/students", stud))
            {
                if (response.IsSuccessStatusCode)
                { 
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
        public async Task Delete(int id) 
        {
            using (HttpResponseMessage response = await APIHelper.client.DeleteAsync("api/students/" + id.ToString())) 
            {
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
