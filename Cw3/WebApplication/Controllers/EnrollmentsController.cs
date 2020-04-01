using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace System.Data
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : Controller
    {
        [HttpPost]
        public IActionResult newStudent(Student student)
        {
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19027;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction;

                transaction = con.BeginTransaction("newStudent");

                command.Connection = con;
                command.Transaction = transaction;
                var t = new Enrollment();
                t.StartDate=DateTime.Now;
                t.Studies = student.Studies;
                bool trigger = false;
                if (student.IndexNumber == null) { trigger = true;}
                if(student.FirstName==null){ trigger = true;}
                if(student.LastName==null){ trigger = true;}
                if(student.BirthDate==null){ trigger = true;}
                if(student.Studies == null){ trigger = true;}
                
                    if (trigger == true)
                    {
                        return BadRequest("brakuje danych");
                    }

                    try
                    {
                        command.CommandText = "select distinct Name,IdStudy from studies where name= '" +
                                              student.Studies + "'";
                        var dr = command.ExecuteReader();
                        int count = 0;
                        int id = 0;
                        while (dr.Read())
                        {
                            id = int.Parse(dr["IdStudy"].ToString());
                            count++;
                        }

                        if (count == 0)
                        {
                            return BadRequest("dany kierunek nie istnieje");
                        }

                        dr.Close();

                        command.CommandText =
                            "select * from Enrollment where IdStudy=" + id +
                            " AND startdate=(SELECT MAX(startdate) from Enrollment where semester =1)";
                        dr = command.ExecuteReader();
                        bool exist = false;
                        while (dr.Read())
                        {
                            exist = true;
                        }

                        dr.Close();
                        int idenrollment = 0;
                        if (exist == true)
                        {
                            command.CommandText = "select Idenrollment,StartDate from enrollment where idstudy=" + id;
                            dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                idenrollment = int.Parse(dr["idenrollment"].ToString());
                                t.StartDate = DateTime.Parse(dr["StartDate"].ToString());
                            }

                            dr.Close();
                        }

                        if (exist == false)
                        {
                            command.CommandText = "Select MAX(Idenrollment)+1 'b' from enrollment";
                            dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                idenrollment = int.Parse(dr["b"].ToString());
                            }

                            dr.Close();
                            command.CommandText = "INSERT into Enrollment values (" + idenrollment + ",1," + id +
                                                  ",GETDATE())";
                            command.ExecuteNonQuery();
                        }

                        command.CommandText = "SELECT * FROM student WHERE IndexNumber=\'" + student.IndexNumber + "\'";
                        dr = command.ExecuteReader();
                        bool newstud = false;
                        while (dr.Read())
                        {
                            newstud = true;
                        }

                        dr.Close();

                        if (newstud == true)
                        {
                            return BadRequest("istnieje student o danym indexie");
                        }

                        if (newstud == false)
                        {
                            command.CommandText = "Insert into student values (\'" + student.IndexNumber + "\',\'" +
                                                  student.FirstName + "\',\'" + student.LastName + "\',\'" +
                                                  student.BirthDate.ToString("yyyy-MM-dd") +
                                                  "\',\'" + idenrollment + "\')";
                            command.ExecuteNonQuery();
                        }

                        command.CommandText =
                            "Select (SELECT Max(startDate) from enrollment where semester=1) from enrollment";
                        dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            t.IdEnrollment = idenrollment;
                            t.Semester = 1;
                            t.IdStudy = id;
                        }
                        dr.Close();
                        transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit exception ");
                    Console.WriteLine(ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback Exception ");
                        Console.WriteLine(ex2.Message);
                    }
                }
                    return Created("", t);
            }
        }

        [HttpPost]
        [Route("promotions")]
        public IActionResult PROMOTED(Enrollment promoted)
        {
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19027;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.Connection = con;
                command.CommandText = "select * from enrollment join studies on enrollment.idstudy=studies.idstudy where name=\'"+promoted.Studies+"\' AND semester=\'"+promoted.Semester+"\'";
                var dr = command.ExecuteReader();
                bool data = !!dr.Read();
                if (!data)
                {
                    return NotFound("nie znaleziono danych");
                }
                dr.Close();
                
                var t = new Enrollment();
                
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PROMOTED";
                command.Parameters.AddWithValue("Studies", promoted.Studies);
                command.Parameters.AddWithValue("Semester", promoted.Semester);
                command.ExecuteNonQuery();

                command.CommandType = CommandType.Text;
                command.CommandText =
                    "Select *  from enrollment e where e.Semester=("+promoted.Semester+"+1) AND e.IdStudy =(Select IdStudy from Studies s where s.Name = \'"+promoted.Studies+"\')";
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    t.IdEnrollment = int.Parse(dr["IdEnrollment"].ToString());
                    t.Semester=int.Parse(dr["Semester"].ToString());
                    t.IdStudy = int.Parse(dr["IdStudy"].ToString());
                    t.StartDate=DateTime.Parse(dr["StartDate"].ToString());
                    t.Studies = promoted.Studies;
                }
                return Created("", t);
            }
        }
    }
}



