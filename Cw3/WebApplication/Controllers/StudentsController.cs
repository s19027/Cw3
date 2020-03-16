using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DAL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        
        //[HttpGet]
        //public string GetStudent()
        //{
        //    return"Kowalski, Malejewski, Andrzejewski";
        //}
        //============================================================
        // [HttpGet("{id}")]
        // public IActionResult GetStudent(int id)
        // {
        //     if (id == 1)
        //     {
        //         return Ok("Kowalski");
        //     }
        //
        //     if (id == 2)
        //     {
        //         return Ok("Malewski");
        //     }
        //     return NotFound("Nie znaleziono studenta");
        // }
        //==============================================================
        // [HttpGet]
        // public string GetStudents(string orderBy)
        // {
        //     return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
        // }
        //==============================================================
        // [HttpPost]
        // public IActionResult CreateStudent(Student student)
        // {
        //     //add to database
        //     //generate index number
        //     student.IndexNumber = $"s{new Random().Next(1, 20000)}";
        //     return Ok(student);
        // }
        //=================================================================
        // [HttpDelete]
        // public IActionResult GetDelete()
        // {
        //     return Ok("Usuwanie zakonczone");
        // }
        //
        // [HttpPut]
        //
        // public IActionResult GetPut()
        // {
        //     return Ok("Aktualizacja dokonczona");
        // }
        //=================================================================
        private readonly Idb _db;

        public StudentsController(Idb db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_db.GetStudents());
        }
    }
}