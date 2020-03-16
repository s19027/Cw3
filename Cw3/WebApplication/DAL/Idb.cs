using WebApplication.Models;
using System.Collections.Generic;

namespace WebApplication.DAL
{
    public interface Idb
    {
        public IEnumerable<Student> GetStudents();
    }
}