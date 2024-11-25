using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using XXMountainBrigadeNew.MBRepository;
using XXMountainBrigadeNew.Models;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net.WebSockets;
using Microsoft.IdentityModel.Tokens;


namespace XXMountainBrigadeNew.Controllers
{
    public class PersonnelController : Controller
    {
        private readonly MBDbContext dbContext;
        private readonly PersonnelRepository _PersonnelRepository = null;
        public PersonnelController(IPersonnel iPersonnel, MBDbContext dbContext)
        {
            this.dbContext = dbContext;
            _PersonnelRepository = new PersonnelRepository(dbContext);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usertbl user)
        {
            var myUser = dbContext.UsersTbl.Where(x => x.email == user.email && x.password == user.password).FirstOrDefault();
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.email);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Login Failed";
            }
            return View();
        }
        public async Task<IActionResult> Index(string FirstName)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            ViewBag.FirstName = FirstName;

            if (string.IsNullOrEmpty(FirstName))
            {
                var personnelData = await _PersonnelRepository.getAllPersonnelAsync();
                return View(personnelData);
            }
            else
            {
                var personnelData = await _PersonnelRepository.getPersonnelByNameAsync(FirstName);
                return View(personnelData);
            }
        }
        public IActionResult Create()
        {
            var personnelTypes = new List<SelectListItem>
            {
                 new SelectListItem { Value = "JCO", Text = "JCO" },
                 new SelectListItem { Value = "OR", Text = "OR" },
                 new SelectListItem { Value = "Other", Text = "Other" }
            };

            ViewBag.PersonnelTypes = personnelTypes;

            var companies = dbContext.Companies
                .Select(c => new SelectListItem
                {
                    Value = c.CoyId.ToString(),
                    Text = c.CoyName
                }).ToList();
            var ranks = dbContext.Ranks
               .Select(r => new SelectListItem
               {
                   Value = r.RankId.ToString(),
                   Text = r.RankName
               }).ToList();

            var vmCompaniesRank = new PersonnelViewModel
            {
                Companies = companies,
                Ranks = ranks
            };

            return View(vmCompaniesRank);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonnelViewModel personelVM)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
                var company = await dbContext.Companies.FindAsync(personelVM.CoyId);
                var rank = await dbContext.Ranks.FindAsync(personelVM.CoyId);

                var personnelEntity = new Personnel
                {
                    PersId = personelVM.PersId,
                    Companies = company,
                    Ranks = rank,
                    TypeOfPersonnel = personelVM.TypeOfPersonnel,
                    PersNo = personelVM.PersNo,
                    FirstName = personelVM.FirstName,
                    LastName = personelVM.LastName,
                    DateOfBirth = personelVM.DateOfBirth,
                    PermanentAddress = personelVM.PermanentAddress,
                    CoyName = company?.CoyName, // Set the company name
                    RankName = rank?.RankName // Set the rank name

                };
                await _PersonnelRepository.addPesonnelAsync(personnelEntity);
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Log the error message
                }
            }
            var personnelTypes = new List<SelectListItem>
            {
                 new SelectListItem { Value = "JCO", Text = "JCO" },
                 new SelectListItem { Value = "OR", Text = "OR" },
                 new SelectListItem { Value = "Other", Text = "Other" }
            };

            ViewBag.PersonnelTypes = personnelTypes;

            personelVM.Companies = dbContext.Companies
           .Select(c => new SelectListItem
           {
               Value = c.CoyId.ToString(),
               Text = c.CoyName
           }).ToList();
            personelVM.Ranks = dbContext.Ranks
          .Select(r => new SelectListItem
          {
              Value = r.RankId.ToString(),
              Text = r.RankName
          }).ToList();
            return View(personelVM);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            if (id.Equals(null))
            {
                return NotFound();
            }
            var personnelData = await _PersonnelRepository.getPersonnelByIdAsync(id);
            if (personnelData.FirstName == null || personnelData.PersId.Equals(null))
            {
                return NotFound();
            }
            return View(personnelData);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }

            if (id.Equals(null))
            {
                return NotFound();
            }
            var perDataEdit = await _PersonnelRepository.getPersonnelByIdAsync(id);
            if (perDataEdit.FirstName == null || perDataEdit.PersId.Equals(null))
            {
                return NotFound();
            }
            var personnelTypes = new List<SelectListItem>
            {
                 new SelectListItem { Value = "JCO", Text = "JCO" },
                 new SelectListItem { Value = "OR", Text = "OR" },
                 new SelectListItem { Value = "Other", Text = "Other" }
            };

            ViewBag.PersonnelTypes = personnelTypes;
            var companies = dbContext.Companies
                .Select(c => new SelectListItem
                {
                    Value = c.CoyId.ToString(),
                    Text = c.CoyName,
                    Selected = c.CoyId == perDataEdit.Id
                }).ToList();
            var ranks = dbContext.Ranks
               .Select(r => new SelectListItem
               {
                   Value = r.RankId.ToString(),
                   Text = r.RankName,
                   Selected = r.RankName == perDataEdit.RankName
               }).ToList();

            var vmCompaniesRank = new PersonnelViewModel
            {
                PersId = perDataEdit.PersId,
                TypeOfPersonnel = perDataEdit.TypeOfPersonnel,
                PersNo = perDataEdit.PersNo,
                FirstName = perDataEdit.FirstName,
                LastName = perDataEdit.LastName,
                DateOfBirth = perDataEdit.DateOfBirth,
                PermanentAddress = perDataEdit.PermanentAddress,
                Companies = companies,
                Ranks = ranks,
                CoyId = Convert.ToInt16(dbContext.Companies.FirstOrDefault(c => c.CoyId == id)?.CoyName), // Pre-select the company
                RankId = Convert.ToInt16(dbContext.Ranks.FirstOrDefault(c => c.RankId == id)?.RankName) // Pre-select the rank

            };
            return View(vmCompaniesRank);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PersonnelViewModel personnelVM)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
                var company = await dbContext.Companies.FindAsync(personnelVM.CoyId);
                var rank = await dbContext.Ranks.FindAsync(personnelVM.CoyId);

                var personnelEntity = new Personnel
                {
                    Id = personnelVM.Id,
                    PersId = personnelVM.PersId,
                    Companies = company,
                    Ranks = rank,
                    TypeOfPersonnel = personnelVM.TypeOfPersonnel,
                    PersNo = personnelVM.PersNo,
                    FirstName = personnelVM.FirstName,
                    LastName = personnelVM.LastName,
                    DateOfBirth = personnelVM.DateOfBirth,
                    PermanentAddress = personnelVM.PermanentAddress,
                    CoyName = company?.CoyName, // Set the company name
                    RankName = rank?.RankName // Set the rank name
                    
                };
                await _PersonnelRepository.updateEditPersonnelAsync(personnelEntity);
                return RedirectToAction("Index");
            }
            var personnelTypes = new List<SelectListItem>
            {
                 new SelectListItem { Value = "JCO", Text = "JCO" },
                 new SelectListItem { Value = "OR", Text = "OR" },
                 new SelectListItem { Value = "Other", Text = "Other" }
            };

            ViewBag.PersonnelTypes = personnelTypes;
            var companies = dbContext.Companies
                .Select(c => new SelectListItem
                {
                    Value = c.CoyId.ToString(),
                    Text = c.CoyName
                }).ToList();
            var ranks = dbContext.Ranks
               .Select(r => new SelectListItem
               {
                   Value = r.RankId.ToString(),
                   Text = r.RankName
               }).ToList();

            var vmCompaniesRank = new PersonnelViewModel
            {
                Companies = companies,
                Ranks = ranks
            };
            return View(vmCompaniesRank);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            if (id.Equals(null))
            {
                return NotFound();
            }
            var persDelete = await _PersonnelRepository.getPersonnelByIdAsync(id);
            return View(persDelete);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            if (id.Equals(null))
            {
                return NotFound();
            }
            else
            {
                await _PersonnelRepository.persDeleteConfirmedAsync(id);
                return RedirectToAction("Index", "Personnel");
            }
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
