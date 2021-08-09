using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreBulkTest.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
