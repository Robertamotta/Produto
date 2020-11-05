using System;
using System.Collections.Generic;
using System.Text;
using Estoque.Application.ValueObject;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace Estoque.Application.Produto
{

     public class GetDadosProduto : IRequest<ProdutoVO>
    {
//      using (var conn = new SqlConnection(connString))
//    {
//        conn.Open();

//        var cmd = new SqlCommand("SELECT Person.PersonID, Person.LastName, Person.FirstName, Course.Title, Course.Credits " +
//            "FROM Course INNER JOIN " +
//                  "CourseInstructor ON Course.CourseID = CourseInstructor.CourseID RIGHT OUTER JOIN " +
//                  "Person ON CourseInstructor.PersonID = Person.PersonID " +
//                  "WHERE (Person.Discriminator = 'Instructor') " +
//                  "ORDER BY Person.PersonID", conn);
//    var reader = cmd.ExecuteReader();

//    int currentPersonID = 0;
//    Instructor currentInstructor = null;
//        while (reader.Read())
//        {
//            var personID = Convert.ToInt32(reader["PersonID"]);
//            if (personID != currentPersonID)
//            {
//                currentPersonID = personID;
//                if (currentInstructor != null)
//                {
//                    instructors.Add(currentInstructor);
//                }
//currentInstructor = new Instructor();
//currentInstructor.LastName = reader["LastName"].ToString();
//currentInstructor.FirstMidName = reader["FirstName"].ToString();
//            }
//            if (reader["Title"] != DBNull.Value)
//{
//    var course = new Course();
//    course.Title = reader["Title"].ToString();
//    course.Credits = Convert.ToInt32(reader["Credits"]);
//    currentInstructor.Courses.Add(course);
//}
//        }
//        if (currentInstructor != null)
//{
//    instructors.Add(currentInstructor);
//}

//reader.Close();
//cmd.Dispose();
//    }
//    return instructors;


        public GetDadosProduto(int Codproduto)
        {
            this.Codproduto = Codproduto;
            //using SqlConnection connection = new SqlCommand(SQL, connection);
            //using SqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
            //}
        }

        public int Codproduto { get; }
    }
}