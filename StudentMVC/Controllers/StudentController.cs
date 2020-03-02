using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public async Task<ActionResult> Index()
        {
            using (HttpResponseMessage response = await APIHelper.client.GetAsync("api/Students"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var empList = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                    return View(empList);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int id)
        {

            using (HttpResponseMessage response = await APIHelper.client.GetAsync("api/students/" + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    var empList = response.Content.ReadAsAsync<Student>().Result;
                    return View(empList);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        

        // GET: Student/Edit/5
        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpResponseMessage response = await APIHelper.client.GetAsync("api/students/" + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    var empList = response.Content.ReadAsAsync<Student>().Result;
                    return View(empList);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Student stud)
        {
            using (HttpResponseMessage response = await APIHelper.client.PutAsJsonAsync("api/students/" + id.ToString(), stud))
            {
                if (response.IsSuccessStatusCode)
                {

                    var empList = response.Content.ReadAsAsync<Student>().Result;
                    return RedirectToAction("index");
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        // GET: Student/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            
            using (HttpResponseMessage response = await APIHelper.client.DeleteAsync("api/students/" + id.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {

                    var empList = response.Content.ReadAsAsync<Student>().Result;
                    return RedirectToAction("index");
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        // POST: Student/Delete/5
        
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}