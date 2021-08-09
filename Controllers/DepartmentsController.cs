using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using EFCoreBulkTest.Data;
using EFCoreBulkTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBulkTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly EfCoreBulkTestContext _context;

        public DepartmentsController(EfCoreBulkTestContext context)
        {
            _context = context;
        }


        [HttpGet("WithIncludeGraph")]
        public async Task<ActionResult<Department>> PostDepartmentWithStudents()
        {
            var department = new Department
            {
                Name = "Software",
                Students = new List<Student>
                {
                    new Student{Name = "Student A"},
                    new Student{Name = "Student B"},
                    new Student{Name = "Student C"},
                }
            };

            var cnf = new BulkConfig
            {
                IncludeGraph = true
            };


            await _context.BulkInsertAsync(new List<Department> { department }, cnf);
            await _context.DisposeAsync();
            return Ok(department.Id);
        }

        [HttpGet("WithNoIncludeGraph")]
        public async Task<ActionResult<Department>> PostDepartmentOnly()
        {
            var department = new Department
            {
                // Id = Guid.NewGuid(), //uncomment this and the test passes
                Name = "Software"
            };



            await _context.BulkInsertAsync(new List<Department> { department });
            await _context.DisposeAsync();

            return Ok(department.Id);
        }


    }
}
