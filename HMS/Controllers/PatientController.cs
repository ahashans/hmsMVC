﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HMS.Models;
using Microsoft.AspNet.Identity;

namespace HMS.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        private ApplicationDbContext _context;

        public PatientController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDiagnosis(string patientId)
        {
            var diagnosis = from diag in _context.Diagnoses
                join tick in _context.Tickets on diag.TicketId equals tick.TicketId
                join user in _context.Users on diag.DoctorUserId equals user.Id
                join dept in _context.Departments on tick.DepartmentId equals dept.DepartmentId
                where tick.PatientUserId == patientId
                where tick.TicketStatus == "Closed"
                select new
                {
                    ticketId = tick.TicketId,
                    departmentName = dept.Name,
                    diagnosedBy = user.FullName,
                    diagnosisProvided = diag.DiagnosisProvided,
                    treatmentProvided = diag.TreatmentProvided,
                    requiredTest = diag.RequiredTests,
                    diagnosisDate = diag.DiagnosisTimeStamp
                };

            return Json(diagnosis, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewAllDiagnosis()
        {
            var patientId = User.Identity.GetUserId();
            ViewBag.patientId = patientId;
            return View();
        }
        public JsonResult GetTickets(string patientId)
        {
            var tickets = _context.Tickets.Where(t => t.PatientUserId == patientId).Include(t => t.Department)
                .Include(t => t.PatientUser).Include(t => t.ReceptionistUser).ToArray();
            return Json(tickets, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewAllTickets()
        {
            ViewBag.patientId = User.Identity.GetUserId();
            return View();
        }
    }
}