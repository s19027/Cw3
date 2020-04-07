using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DAL;
using WebApplication.Models;


namespace System.Data
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public string GetStudent()
        {
            return"Kowalski, Malejewski, Andrzejewski";
        }
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
        //44444444444444444444444444444444444444444444444444444444444444
        // [HttpGet]
        // public IActionResult GetStudents()
        // {
        //     var stud = new List<Student>();
        //     using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19027;Integrated Security=True"))
        //     using(var com=new SqlCommand())
        //     {
        //         com.Connection = con;
        //         com.CommandText = "select * from Student ";
        //         
        //         con.Open();
        //         var dr = com.ExecuteReader();
        //         while (dr.Read())
        //         {
        //              var st = new Student();
        //              st.IndexNumber = dr["IndexNumber"].ToString();
        //              st.FirstName = dr["FirstName"].ToString();
        //              st.LastName = dr["LastName"].ToString();
        //              st.BirthDate = DateTime.Parse(dr["BirthDate"].ToString());
        //              st.IdEnrollment = int.Parse(dr["IdEnrollment"].ToString());
        //              stud.Add(st);
        //         }
        //     }
        //
        //     return Ok(stud);
        //     
        // }
        //===========================================================================
       //4444444444444444444444444444444444444444444444444444444444444444444444444444
        // [HttpGet("{id}")]
        // public IActionResult GetStudents(string id)
        // {
        //     using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19027;Integrated Security=True"))
        //     using(var com=new SqlCommand())
        //     {
        //         com.Connection = con;
        //         com.CommandText = "select * from Enrollment WHERE IdEnrollment=(SELECT IdEnrollment FROM Student where IndexNumber = \'"+id+"\')";
        //         
        //         con.Open();
        //         var dr = com.ExecuteReader();
        //         
        //         var stud = new List<string>();
        //         while (dr.Read())
        //         {
        //             stud.Add(dr["Semester"].ToString());
        //         }
        //         return Ok(stud);
        //     }
        // }
        //=============================================================
        //4444444444444444444444444444444444444444444444444444444444444
        // [HttpGet]
        // public IActionResult GetStudents()
        // {
        //     var stud = new List<Student>();
        //     using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19027;Integrated Security=True"))
        //     using(var com=new SqlCommand())
        //     {
        //         string id = "1";
        //         
        //         com.Connection = con;
        //         com.CommandText = "select * from Student where IndexNumber=@id";
        //         com.Parameters.AddWithValue("id", id);
        //         con.Open();
        //         var dr = com.ExecuteReader();
        //         while (dr.Read())
        //         {
        //             var st = new Student();
        //             st.IndexNumber = dr["IndexNumber"].ToString();
        //             st.FirstName = dr["FirstName"].ToString();
        //             st.LastName = dr["LastName"].ToString();
        //             st.BirthDate = DateTime.Parse(dr["BirthDate"].ToString());
        //             st.IdEnrollment = int.Parse(dr["IdEnrollment"].ToString());
        //             stud.Add(st);
        //         }
        //     }
        //
        //     return Ok(stud);
        //     
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
        // private readonly Idb _db;
        //
        // public StudentsController(Idb db)
        // {
        //     _db = db;
        // }

        
    }
}