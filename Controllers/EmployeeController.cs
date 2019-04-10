using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NWApi.Model;
using NWApi.Context;
using Microsoft.EntityFrameworkCore;

namespace NWApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private NWContext db;
        public EmployeeController(NWContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Employee> Get()
        {

            return db.Employees.ToList();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
          
            return db.Employees.Find(id);
            
        }

        [HttpPost]
        public IActionResult Post([FromBody]Employee newEmployee)
        {

            db.Employees.Add(newEmployee);
            db.SaveChanges();
            return new ObjectResult("Added!");

        }
    

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            db.Employees.Remove(db.Employees.Find(id));
            db.SaveChanges();
            return new ObjectResult("Deleted!");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee obj)
        {
          
                db.Entry<Employee>(obj).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResult("Modified!");
            
        }

    }
}
    
