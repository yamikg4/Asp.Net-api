using Book_Info.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Book_Info.Controller
{
    public class Movie : ApiController
    {
        DB_Book_infoEntities db = new DB_Book_infoEntities();

        public IHttpActionResult PostData(Tbl_Book Book)
        {
            try
            {
                if (Book != null)
                {
                    db.Tbl_Book.Add(Book);
                    db.SaveChanges();
                    return Ok("Data is Inserted..!!!");
                }

                else
                {
                    return BadRequest("Provide Proper Data..!!");
                }
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Enter Proper Data");
            }
        }
        public IHttpActionResult GetByID(int Bookid)
        {

            Tbl_Book Book = db.Tbl_Book.Find(Bookid);
            if (Book != null)
            {
                return Content(HttpStatusCode.OK, Book);
            }
            else
            {
                return BadRequest("Provide Proper Data..!!");
            }



        }

        public IHttpActionResult Update(Tbl_Book Book, int Book_id)
        {
            try
            {
                Tbl_Book Book1 = db.Tbl_Book.Find(Book_id);

                if (Book1 != null)
                {
                    Book1.Book_name = Book.Book_name;
                    Book1.Author = Book.Author;
                    Book1.Publication = Book.Publication;
                    Book1.subject = Book.subject;
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, "Data Updated Succesfully..!!");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No DATA FOUND To this id " + Book_id);
                }

            }
            catch
            {
                return Content(HttpStatusCode.NoContent, "PLEASE TRY AGAIN..!!");
            }
        }
        public IHttpActionResult Delete(int Book_id)
        {
            try
            {
                Tbl_Book Student = db.Tbl_Book.Find(Book_id);

                if (Student != null)
                {
                    db.Tbl_Book.Remove(Student);
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, "Data Deleted Succesfully..!!");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No DATA FOUND To this id " + Book_id);
                }

            }
            catch
            {
                return Content(HttpStatusCode.NoContent, "PLEASE TRY AGAIN..!!");
            }
        }
        public IHttpActionResult GetAllData()
        {
            try
            {
                List<Tbl_Book> Data = db.Tbl_Book.ToList();
                if (Data.Count > 0)
                {
                    return Content(HttpStatusCode.OK, Data);
                }
                else
                {
                    return Content(HttpStatusCode.NoContent, "No DATA FOUND");
                }

            }
            catch
            {
                return Content(HttpStatusCode.NoContent, "PLEASE TRY AGAIN..!!");
            }
        }
    }
}
