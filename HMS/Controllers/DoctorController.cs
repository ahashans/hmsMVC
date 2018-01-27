using System.Linq;
using System.Web.Mvc;
using HMS.Models;
using HMS.ViewModel;
using Microsoft.AspNet.Identity;

namespace HMS.Controllers
{
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
        public ActionResult CreateDiagnosis()
        {
            var roleId = _context.Roles.Where(m => m.Name == "Patient").Select(m => m.Id).SingleOrDefault();
            var users = _context.Users
                .Where(u => u.Roles.Any(r => r.RoleId == roleId)).ToList();
            var ticketPatients = from pat in users
                join tic in _context.Tickets on pat.Id equals tic.PatientUserId
                join dept in _context.DoctorDepartments on tic.DepartmentId equals dept.DepartmentId
                where tic.TicketStatus == "Open"
                select pat;
            var viewModel = new CreateDiagnosisViewModel
            {
                Patients = ticketPatients,
                Diagnosis = new Diagnosis()
                
            };
            return View(viewModel);
        }
        public JsonResult GetPatientInfo(string patientId)
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
    }
}