using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using HMS.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace HMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationDbContext _context { get; set; }
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager {
            get {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }


        // GET: Admin
        public ActionResult Index()
        {
            var usersWithRoles = (from user in _context.Users
                from userRole in user.Roles
                join role in _context.Roles on userRole.RoleId equals
                    role.Id
                select new UserListViewModel()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = role.Name
                }).ToList();
            var viewModel = new AdminIndexViewModel
            {
                UserList = usersWithRoles,
                DiagnosisCount = _context.Diagnoses.Count(),
                StaffCount = usersWithRoles.Count(u => u.Role=="Receptionist"),
                PatientCount = usersWithRoles.Count(u => u.Role == "Patient"),
                DoctorCount = usersWithRoles.Count(u => u.Role == "Doctor"),

            };
            return View("Index","_AdminLayout",viewModel);
        }
        public ActionResult CreateUser()
        {
            var viewModel= new CreateUserViewModel
            {
                Departments = _context.Departments.ToList()
            };
            return View("CreateUser", "_AdminLayout", viewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(CreateUserViewModel model)
        {
            //            if (model.Role == "Receptionist")
            //            {Recep@hms.c0m
            //                ModelState["model.DepartmentId"].Errors.Clear();
            //                ModelState.Clear();
            //            }
            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            string finalPath = "";
            if (model.ProfilePicture != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(model.ProfilePicture.FileName);
                string extension = Path.GetExtension(model.ProfilePicture.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                finalPath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
                model.ProfilePicture.SaveAs(fileName);

            }
            if (ModelState.IsValid || allErrors.Count()==1)
            {
                var user = new ApplicationUser { FullName = model.FullName, Gender = model.Gender, DateOfBirth = model.DateOfBirth, Address = model.Address, Mobile = model.Mobile, UserName = model.Email, Email = model.Email, ProfileImagePath = finalPath};
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    await UserManager.AddToRoleAsync(user.Id, model.Role);
                    if (model.Role=="Doctor")
                    {
                        var doctorDepartment = new DoctorDepartment
                        {
                            DepartmentId = model.DepartmentId,
                            DoctorUserId = user.Id
                           
                        };
                        _context.DoctorDepartments.Add(doctorDepartment);
                        await _context.SaveChangesAsync();
                    }
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Admin");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        [HttpPost]
        public JsonResult CheckEmail(string Email)
        {
            var result = UserManager.FindByEmail(Email) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateDepartment()
        {
            var department = new Department();
            return View("CreateDepartment", "_AdminLayout", department);
        }
        public ActionResult AllDepartments()
        {
            var departments = _context.Departments.ToList();

            return View("AllDepartments", "_AdminLayout", departments);
        }
        public ActionResult StoreDepartment(Department department)
        {
            if (!ModelState.IsValid)//invalid
            {
                return View("CreateDepartment", "_AdminLayout", department);
            }
            _context.Departments.Add(department);
            _context.SaveChanges();

            var departments = _context.Departments.ToList();
            
            return View("AllDepartments", "_AdminLayout", departments);
        }
        public ActionResult AllUsers()
        {
            var usersWithRoles = (from user in _context.Users
                from userRole in user.Roles
                join role in _context.Roles on userRole.RoleId equals
                    role.Id
                select new UserListViewModel()
                {
                    FullName = user.FullName,
                    Gender = user.Gender,
                    Email = user.Email,
                    Role = role.Name,
                    ProfilePicture = user.ProfileImagePath
                }).ToList();
            return View(usersWithRoles);
        }
        public ActionResult Blog()
        {
            var blogposts = _context.Blogs.Include(b=> b.Author).ToList();
            return View(blogposts);
        }
        public ActionResult CreateBlog()
        {
            var viewModel = new BlogFormViewModel
            {
                BlogPost = new Blog
                {
                    CreatedAt = DateTime.Today,
                    FeatureImagePath = "no image selected"
                }
            };
            return View("BlogForm", viewModel);
        }
        public ActionResult EditBlog(int id)
        {
            var blogpost = _context.Blogs.Include(b=>b.Author).SingleOrDefault(b => b.Id == id);
            if (blogpost != null)
            {
                var viewModel = new BlogEditFormViewModel
                {
                    BlogPost = blogpost
                };
                return View("BlogEditForm", viewModel);
            }

            return RedirectToAction("Blog");
        }
        public ActionResult UpdateBlog(BlogEditFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("BlogEditForm", viewModel);
            }
            if (viewModel.FeatureImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.FeatureImage.FileName);
                string extension = Path.GetExtension(viewModel.FeatureImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                viewModel.BlogPost.FeatureImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
                viewModel.FeatureImage.SaveAs(fileName);
            }

//            viewModel.BlogPost.AuthorId = User.Identity.GetUserId();
            var blogPostInDb = _context.Blogs.SingleOrDefault(b => b.Id == viewModel.BlogPost.Id);
//            _context.Blogs.Add(viewModel.BlogPost);
            blogPostInDb.Content = viewModel.BlogPost.Content;
            blogPostInDb.Title = viewModel.BlogPost.Title;
            blogPostInDb.FeatureImagePath = viewModel.BlogPost.FeatureImagePath;
            _context.SaveChanges();
            return RedirectToAction("Blog", "Admin");
        }
        public ActionResult SaveBlog(BlogFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("BlogForm", viewModel);
            }
            if (viewModel.FeatureImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.FeatureImage.FileName);
                string extension = Path.GetExtension(viewModel.FeatureImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                viewModel.BlogPost.FeatureImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
                viewModel.FeatureImage.SaveAs(fileName);
            }

            viewModel.BlogPost.AuthorId = User.Identity.GetUserId();
            _context.Blogs.Add(viewModel.BlogPost);
            _context.SaveChanges();
            return RedirectToAction("Blog", "Admin");
        }
        public ActionResult DeleteBlog(int id)
        {
            var blogPostInDb = _context.Blogs.SingleOrDefault(b => b.Id == id);
            if (blogPostInDb != null)
            {
                if (System.IO.File.Exists(Request.MapPath(blogPostInDb.FeatureImagePath)))
                {
                    System.IO.File.Delete(Request.MapPath(blogPostInDb.FeatureImagePath));
                }
                _context.Blogs.Remove(blogPostInDb);
                _context.SaveChanges();
            }
            return RedirectToAction("Blog", "Admin");
        }
        public ActionResult Events()
        {
            var events = _context.Events.ToList();
            return View(events);
        }
        public ActionResult CreateEvent()
        {
            var viewModel = new EventCreateViewModel
            {
                ProbableEvent = new ProbableEvent
                {
                    EventDate = DateTime.Today
                }
            };
            return View("EventForm", viewModel);  
        }
        public ActionResult EditEvent(int id)
        {
            var viewModel = new EventEditViewModel()
            {
                ProbableEvent = _context.Events.SingleOrDefault(e=>e.Id==id)
            };
            return View("EventEditForm", viewModel);
        }

        public ActionResult StoreEvent(EventCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EventForm", viewModel);
            }
            if (viewModel.FeatureImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.FeatureImage.FileName);
                string extension = Path.GetExtension(viewModel.FeatureImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                viewModel.ProbableEvent.FeatureImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
                viewModel.FeatureImage.SaveAs(fileName);
            }

            _context.Events.Add(viewModel.ProbableEvent);
            _context.SaveChanges();
            return RedirectToAction("Events", "Admin");
        }
        public ActionResult UpdateEvent(EventEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EventEditForm", viewModel);
            }
            if (viewModel.FeatureImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.FeatureImage.FileName);
                string extension = Path.GetExtension(viewModel.FeatureImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                viewModel.ProbableEvent.FeatureImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
                viewModel.FeatureImage.SaveAs(fileName);
            }

            var eventInDb = _context.Events.SingleOrDefault(e => e.Id == viewModel.ProbableEvent.Id);
            if (eventInDb != null)
            {
                eventInDb.FeatureImagePath = viewModel.ProbableEvent.FeatureImagePath;
                eventInDb.EventDate = viewModel.ProbableEvent.EventDate;
                eventInDb.ShortDescription = viewModel.ProbableEvent.ShortDescription;
                eventInDb.Title = viewModel.ProbableEvent.Title;
                _context.SaveChanges();
            }
            return RedirectToAction("Events", "Admin");
        }
        public ActionResult DeleteEvent(int id)
        {
            var eventInDb = _context.Events.SingleOrDefault(e => e.Id == id);
            if (eventInDb != null)
            {
                if (System.IO.File.Exists(Request.MapPath(eventInDb.FeatureImagePath)))
                {
                    System.IO.File.Delete(Request.MapPath(eventInDb.FeatureImagePath));
                }
                _context.Events.Remove(eventInDb);
                _context.SaveChanges();
            }
            return RedirectToAction("Events", "Admin");
        }
        public ActionResult Testimonials()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }
        public ActionResult CreateTestimonials()
        {
            var viewModel = new TestimonialCreateFormViewModel
            {
                Testimonial = new Testimonial()
            };
            return View("TestimonialForm", viewModel);
        }
        public ActionResult StoreTestimonial(TestimonialCreateFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("TestimonialForm", viewModel);
            }
            if (viewModel.ProfilePicture != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.ProfilePicture.FileName);
                string extension = Path.GetExtension(viewModel.ProfilePicture.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                viewModel.Testimonial.ProfileImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
                viewModel.ProfilePicture.SaveAs(fileName);
            }

            _context.Testimonials.Add(viewModel.Testimonial);
            _context.SaveChanges();
            return RedirectToAction("Testimonials", "Admin");
        }
        public ActionResult EditTestimonials(int id)
        {
            var viewModel = new TestimonialEditFormViewModel
            {
                Testimonial = _context.Testimonials.SingleOrDefault(t=>t.Id==id)
            };
            return View("TestimonialEditForm", viewModel);
        }
        public ActionResult UpdateTestimonial(TestimonialEditFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("TestimonialEditForm", viewModel);
            }
            if (viewModel.ProfilePicture != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.ProfilePicture.FileName);
                string extension = Path.GetExtension(viewModel.ProfilePicture.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                viewModel.Testimonial.ProfileImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
                viewModel.ProfilePicture.SaveAs(fileName);
            }

            var testimonialInDb = _context.Testimonials.SingleOrDefault(t => t.Id == viewModel.Testimonial.Id);
            if (testimonialInDb != null)
            {
                testimonialInDb.Name = viewModel.Testimonial.Name;
                testimonialInDb.Designation = viewModel.Testimonial.Designation;
                testimonialInDb.Message = viewModel.Testimonial.Message;
                testimonialInDb.ProfileImagePath = viewModel.Testimonial.ProfileImagePath;
                _context.SaveChanges();
            }
            return RedirectToAction("Testimonials", "Admin");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var testimonialInDb = _context.Events.SingleOrDefault(t => t.Id == id);
            if (testimonialInDb != null)
            {
                if (System.IO.File.Exists(Request.MapPath(testimonialInDb.FeatureImagePath)))
                {
                    System.IO.File.Delete(Request.MapPath(testimonialInDb.FeatureImagePath));
                }
                _context.Events.Remove(testimonialInDb);
                _context.SaveChanges();
            }
            return RedirectToAction("Testimonials", "Admin");
        }
    }
}