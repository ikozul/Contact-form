using ContactForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ContactForm.Controllers
{
    public class ContactFormController : Controller
    {
        // GET: ContactForm

        public ActionResult ShowSubjects()
        {
            try
            {
                return View(Repo.GetAllSubjects());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult InsertSubject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertSubject(MailModel model)
        {
                try
                {
                    Repo.InsertSubject(model);
                    ViewBag.message = "Response succesfully submited";
                    return View("Accepted");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }

        }

        [HttpGet]
        public ActionResult EditSubject(int IDForm)
        {            
            try
            {
                MailModel mm = Repo.GetSubjectById(IDForm);
                return View(mm);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult EditSubject(MailModel model)
        {
            if (ModelState.IsValid)
            {
               Repo.EditSubject(model);
               return View("Accepted");
            }
            else
            {
                return View("Error");
            }
        }

       




        [HttpGet]
         public ActionResult Details(int IDForm)
         {
             try
             {
                 MailModel m;
                 try
                 {
                     m = Repo.GetSubjectById(IDForm);
                     return View(m);
                 }
                 catch (Exception ex)
                 {
                     ViewBag.error = ex.GetBaseException().Message;
                     return View("Error");
                 }


             }
             catch (Exception ex)
             {
                 ViewBag.error = ex.GetBaseException().Message;
                 return View("Error");
             }
         }


    }
}