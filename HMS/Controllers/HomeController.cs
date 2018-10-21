using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HMS.Models;
using HMS.ViewModel;
using Microsoft.AspNet.Identity;

namespace HMS.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                Doctors = _context.DoctorDepartments.Include(d=>d.Department).Include(d => d.DoctorUser).Take(4).ToList(),
                Departments = _context.Departments.Take(4).ToList(),
                BlogPosts = _context.Blogs.Take(2).ToList(),
                Testimonials = _context.Testimonials.Take(2).ToList(),
                ProbableEvents = _context.Events.Take(4).ToList()
            };
            return View(viewModel);
        }
        public ActionResult DoctorStory()
        {
            return View();
        }
        public ActionResult PatientStory()
        {
            return View();
        }
        public ActionResult FacilityStory()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Description page.";
            var departments = _context.Departments.ToList();
            var doctors = _context.DoctorDepartments.Include(d => d.Department).Include(d => d.DoctorUser).Take(4)
                .ToList();
            var viewModel = new AboutViewModel
            {
                DoctorDepartments = doctors,
                Departments = departments
            };
            return View(viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";
            var departments = _context.Departments.ToList();
            return View(departments);
        }
        public ActionResult Departments()
        {
            var departments = _context.Departments.ToList();            
            return View(departments);
        }
        public ActionResult Doctors()
        {
            var doctors = _context.DoctorDepartments.Include(d => d.DoctorUser).ToList();
            var departments = _context.Departments.ToList();
            var viewModel = new DoctorListViewModel
            {
                Doctors = doctors,
                Departments = departments
            };
            return View(viewModel);
        }
        public JsonResult GetDoctors(int departmentId)
        {
            
            var doctors = _context.DoctorDepartments.Include(d => d.Department).Include(d => d.DoctorUser).Where(d => d.DepartmentId == departmentId).ToList();
            if (departmentId==0)
            {
                doctors = _context.DoctorDepartments.Include(d => d.Department).Include(d => d.DoctorUser).ToList();
            }
            return Json(doctors, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Blogs()
        {
            var blogPosts = _context.Blogs.Include(b => b.Author).ToList();
            return View(blogPosts);
        }
        public ActionResult Blog(int id)
        {
            var blog = _context.Blogs.Include(b => b.Author).SingleOrDefault(b => b.Id == id);
            if(blog!=null)
                return View("Blog", blog);
            return RedirectToAction("Blogs", "Home");
        }        
        [Authorize(Roles = "Patient")]
        public ActionResult AppointmentBooking()
        {   
            var viewModel = new AppointmentViewModel
            {
                Departments = _context.Departments.ToList(),
                AppointmentDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"),
                DoctorDepartments = new List<DoctorDepartment>()
            };
            return View(viewModel);
        }

        public ActionResult AppointmentBookingByDepartment(int id)
        {
            var department = _context.Departments.Where(d => d.DepartmentId == id);
            if (department.Any())
            {
                var viewModel = new AppointmentViewModel
                {
                    Departments = department,
                    AppointmentDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"),
                    DoctorDepartments = _context.DoctorDepartments.Include(d=>d.DoctorUser).Where(d=>d.DepartmentId==id)
                };
                ViewBag.SearchBy = "Department";
                return View("AppointmentBooking", viewModel);
            }            
            return RedirectToAction("Departments", "Home");
        }

        public ActionResult AppointmentBookingByDoctor(int id)
        {
            var doctor = _context.DoctorDepartments.Include(d=>d.Department).Include(d => d.DoctorUser).Where(d => d.Id == id);
            if (doctor.Any())
            {
                var viewModel = new AppointmentViewModel
                {
                    Departments = _context.Departments.Join(doctor, a=>a.DepartmentId, b=>b.DepartmentId, (a,b)=>a),
                    AppointmentDate = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"),
                    DoctorDepartments = doctor
                };
                ViewBag.SearchBy = "Doctor";
                return View("AppointmentBooking", viewModel);
            }
            return RedirectToAction("Doctors", "Home");
        }
        public ActionResult StoreAppointment(AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AppointmentBooking", model);
            }

            var appointment = new Appointment
            {
                AppointmentDate = DateTime.Parse(model.AppointmentDate),
                DoctorDepartmentId = model.DoctorDepartmentId,
                PatientId = User.Identity.GetUserId(),
                Problem = model.Problem,
                Remarks = model.Remarks
            };
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return RedirectToAction("Index","Patient");
        }
        public ActionResult DoctorDetails(int id)
        {
            var doctorDetails = _context.DoctorDepartments.Include(d=>d.Department).Include(d=>d.DoctorUser).SingleOrDefault(d => d.Id == id);
            return View(doctorDetails);
        }
    }
}