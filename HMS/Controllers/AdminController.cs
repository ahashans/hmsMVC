using System.Linq;
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
                    UserName = user.FullName,
                    Email = user.Email,
                    Role = role.Name
                }).ToList();
            var viewModel = new AdminIndexViewModel
            {
                UserList = usersWithRoles
            };
            return View(viewModel);
        }
        public ActionResult CreateUser()
        {
            var viewModel= new CreateUserViewModel
            {
                Departments = _context.Departments.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { FullName = model.FullName, Gender = model.Gender, DateOfBirth = model.DateOfBirth, Address = model.Address, Mobile = model.Mobile, UserName = model.Email, Email = model.Email };
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
                        _context.SaveChanges();
                    }
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
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
        public ActionResult CreateDepartment()
        {
            var department = new Department();
            return View(department);
        }
        public ActionResult AllDepartments()
        {
            var departments = _context.Departments.ToList();

            return View(departments);
        }
        public ActionResult StoreDepartment(Department department)
        {
            if (!ModelState.IsValid)//invalid
            {
                return View("CreateDepartment",department);
            }
            _context.Departments.Add(department);
            _context.SaveChanges();

            var departments = _context.Departments.ToList();
            
            return View("AllDepartments",departments);
        }
    }
}