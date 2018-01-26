using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using HMS.ViewModel;
using Microsoft.AspNet.Identity;

namespace HMS.Controllers
{
    public class ReceptionistController : Controller
    {
        private ApplicationDbContext _context;

        public ReceptionistController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Receptionist
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateTicket()
        {
            var roleId = _context.Roles.Where(m => m.Name == "Patient").Select(m => m.Id).SingleOrDefault();
            var users = _context.Users
                .Where(u => u.Roles.Any(r => r.RoleId == roleId)).ToList();
            var viewModel = new TicketFormViewModel
            {
                Ticket = new Ticket(),
                Departments = _context.Departments.ToList(),
                Patients = users
            };
            return View(viewModel);
        }
        public ActionResult GetDepartmentFee(int departmentId)
        {
            int? fee = _context.Departments.Single(m => m.DepartmentId == departmentId).Fee;
            return Json(new{fees = fee});
        }
        public ActionResult DisplayTicket()
        {
            return View();
        }
        public ActionResult StoreTicket(TicketFormViewModel viewModel)   
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            //viewModel.Ticket.PaymentTimeStamp=DateTime.Now;
            viewModel.Ticket.ReceptionistUserId = User.Identity.GetUserId();
            viewModel.Ticket.TicketStatus = "Open";
            _context.Tickets.Add(viewModel.Ticket);
            _context.SaveChanges();
            return View("DisplayTicket");
        }

    }
}