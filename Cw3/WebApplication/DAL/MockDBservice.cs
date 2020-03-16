using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.DAL
{
    public class MockDBservice : Idb
    {
        private static IEnumerable<Student> _students;

        static MockDBservice()
        {
            _students = new List<Student>
            {
                new Student {IdStudent = 1, FirstName = "Jan", LastName = "Kowalski"},
                new Student {IdStudent = 2, FirstName = "Anna", LastName = "Malewski"},
                new Student {IdStudent = 3, FirstName = "Andrzej", LastName = "Andrzejewski"},
            };
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}