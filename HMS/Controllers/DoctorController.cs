﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HMS.Models;
using HMS.ViewModel;
using Microsoft.AspNet.Identity;

namespace HMS.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {
        private ApplicationDbContext _context;

        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewDiagnosis()
        {
            var doctorId = User.Identity.GetUserId();
            var patients = from User in _context.Users
                join Ticket in _context.Tickets on User.Id equals Ticket.PatientUserId
                join Diagnosis in _context.Diagnoses on Ticket.TicketId equals Diagnosis.TicketId
                join DoctorDepartment in _context.DoctorDepartments on Ticket.DepartmentId equals DoctorDepartment
                    .DepartmentId
                where DoctorDepartment.DoctorUserId == doctorId
                select User;
            //var pat = patients.ToList();
            var viewModel = new DisplayDiagnosisVIewModel
            {
                Patients = patients
            };
            return View(viewModel);
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
        public ActionResult CreateDiagnosis()
        {
            var doctorId = User.Identity.GetUserId();
            var doctDept = (from doctdept in _context.DoctorDepartments
                where doctdept.DoctorUserId == doctorId
                select doctdept.DepartmentId).FirstOrDefault();
            var ticks = (from t in _context.Tickets
                         where t.DepartmentId == doctDept
                         where t.TicketStatus=="Open"
                         select t.PatientUserId).ToList();
            var openTicketPatients = (from u in _context.Users
                where ticks.Contains(u.Id)
                select u).ToList();
//            var roleId = _context.Roles.Where(m => m.Name == "Patient").Select(m => m.Id).SingleOrDefault();
//            var users = _context.Users
//                .Where(u => u.Roles.Any(r => r.RoleId == roleId)).ToList();
//
//            var ticketPatients = from pat in users
//                join tic in _context.Tickets on pat.Id equals tic.PatientUserId
//                join dept in _context.DoctorDepartments on tic.DepartmentId equals dept.DepartmentId
//                where tic.TicketStatus == "Open"
//                select pat;
            var viewModel = new CreateDiagnosisViewModel
            {
                Patients = openTicketPatients,
                Diagnosis = new Diagnosis()
                
            };
            return View(viewModel);
        }
        public JsonResult GetPatientInfo(string patientId)
        {
            
            var patientData = from pat in _context.Users
                where pat.Id == patientId
                select new
                {
                    dob = pat.DateOfBirth,
                    gender = pat.Gender
                };
            return Json(patientData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOpenTicketPatientInfo(string patientId)
        {
            var doctorId = User.Identity.GetUserId();
            var patientData = from pat in _context.Users
                              join tick in _context.Tickets on pat.Id equals tick.PatientUserId
                              join dept in _context.DoctorDepartments on tick.DepartmentId equals dept.DepartmentId
                              where pat.Id == patientId
                              where dept.DoctorUserId == doctorId
                              where tick.TicketStatus=="Open"
                              select new
                              {
                                  dob = pat.DateOfBirth,
                                  gender = pat.Gender,
                                  ticketId = tick.TicketId
                              };
            return Json(patientData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult StoreDiagnosis(CreateDiagnosisViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateDiagnosis",viewModel);
            }
            viewModel.Diagnosis.DoctorUserId = User.Identity.GetUserId();
            var ticketId = viewModel.Diagnosis.TicketId;
            using (var context = new ApplicationDbContext())
            {
                context.Diagnoses.Add(viewModel.Diagnosis);
                context.SaveChanges();
            }
            using (var context = new ApplicationDbContext())
            {
                var ticket = context.Tickets.Find(ticketId);
                ticket.TicketStatus = "Closed";
                context.SaveChanges();
            }
            var ctx = _context.Tickets.ToList();
            
            return View("Index");
        }
        //Get Events of Patient
        public JsonResult GetEvents()
        {
            //var data = "";
            var doctorId = User.Identity.GetUserId();
            var appointments = _context.Appointments.Include(a => a.DoctorDepartment.Department).Include(a => a.DoctorDepartment.DoctorUser).Where(a => a.DoctorDepartment.DoctorUserId == doctorId).ToList();
            var events = new
            {
                events = appointments.Select(dailyEvent => new
                {
                    title = "Appointment in " + dailyEvent.DoctorDepartment.Department.Name + " Department",
                    start = dailyEvent.AppointmentDate,
                    end = dailyEvent.AppointmentDate.AddMinutes(5),
                    allDay = 0
                })
            };
            return Json(appointments.Select(dailyEvent => new
            {
                title = "Appointment in " + dailyEvent.DoctorDepartment.Department.Name + " Department",
                start = dailyEvent.AppointmentDate.ToString("O"),
                end = dailyEvent.AppointmentDate.AddMinutes(5).ToString("O"),
                allDay = 0
            }), JsonRequestBehavior.AllowGet);
        }
    }
}