using KMCAA.Data;
using KMCAA.Models;
using KMCAA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace KMCAA.Controllers
{
    public class MembershipController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MembershipController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var obj = await (from a in _context.MembersDetail
                             join status in _context.LookUps on a.MembershipTypeId equals status.Id
                             join Reside in _context.LookUps on a.MemberResideIn equals Reside.Id
                             orderby a.Id descending
                             select new MemberVM
                             {
                                 Id = a.Id,
                                 TypeName = status.Name,
                                 MemberResideIn = Reside.Name,
                                 FullName = a.FullName,
                                 Gender = a.Gender,
                                 MobileNumber = a.MobileNumber,
                                 PresendWorkPlance = a.PresendWorkPlance,
                                 ImageUrl=a.ImageUrl,

                             }).ToListAsync();
            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> AddorEdit(int? id)
        {
            if (id == 0 || id == null)
            {
                MemberVM iOjb = new MemberVM();
                iOjb.ImageUrl = "Content/DoctorAvatar.jpg";
                return View(iOjb);
            }
            else
            {
                var obj = await (from a in _context.MembersDetail
                                 where a.Id == id
                                 select new MemberVM
                                 {
                                     MembershipTypeId = a.MembershipTypeId,
                                     MemberResideInId = a.MemberResideIn,
                                     FullName = a.FullName,
                                     Gender = a.Gender,
                                     GraduationFrom = a.GraduationFrom,
                                     YearOfGraduation = a.YearOfGraduation,
                                     Email = a.Email,
                                     PresendWorkPlance = a.PresendWorkPlance,
                                     MailingAddress = a.MailingAddress,
                                     PermanentAddress = a.PermanentAddress,
                                     OfficeNumber = a.OfficeNumber,
                                     ClinicNumber = a.ClinicNumber,
                                     MobileNumber = a.MobileNumber,
                                     ImageUrl=a.ImageUrl,
                                 }).FirstOrDefaultAsync();



                return View(obj);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddorEdit(int? id, MemberVM obj, IFormFile file)
        {
            //Image upload
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string profilePath = Path.Combine(wwwRootPath, @"Images\ProfileImages");
                if (!string.IsNullOrEmpty(obj.ImageUrl))
                {

                    var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(profilePath, fileName), FileMode.CreateNew))
                {
                    file.CopyTo(fileStream);
                }
                obj.ImageUrl = @"Images/ProfileImages/" + fileName;
            }
            else
            {
                obj.ImageUrl = @"Images/ProfileImages/DoctorAvatar.jpg";

            }

            MemberDetail member = new MemberDetail()
            {
                MembershipTypeId = obj.MembershipTypeId,
                MemberResideIn = obj.MemberResideInId,
                FullName = obj.FullName,
                Gender = obj.Gender,
                GraduationFrom = obj.GraduationFrom,
                YearOfGraduation = obj.YearOfGraduation,
                PresendWorkPlance = obj.PresendWorkPlance,
                Email = obj.Email,
                MailingAddress = obj.MailingAddress,
                PermanentAddress = obj.PermanentAddress,
                OfficeNumber = obj.OfficeNumber,
                ClinicNumber = obj.ClinicNumber,
                MobileNumber = obj.MobileNumber,
                ImageUrl=obj.ImageUrl,
            };
            if (id == 0 || id == null)
            {
                _context.MembersDetail.Add(member);
                await _context.SaveChangesAsync();

            }
            else
            {
                member.Id = obj.Id;
                _context.MembersDetail.Update(member);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Membership");
            //return View(obj);
        }

        #region Add Finance
        [HttpGet]
        public IActionResult AddFinance(int? id)
        {
            var obj = new FinanceVM();
            if (id == 0 || id == null)
            {
                return View(obj);
            }
            else
            {
                Finance member = new Finance()
                {
                    PaymentTypeId = obj.PaymentTypeId,
                    ReceiptNo = obj.ReceiptNo,
                    PaymentDate = Convert.ToDateTime(obj.PaymentDate),
                };
                return View(obj);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddFinance(FinanceVM obj)
        {
            Finance finance = new Finance()
            {
                MemberId = obj.Id,
                PaymentTypeId = obj.PaymentTypeId,
                ReceiptNo = obj.ReceiptNo,
                PaymentDate = Convert.ToDateTime(obj.PaymentDate),
                PaymentYear = obj.PaymentYear
            };
            _context.Finances.Add(finance);
            await _context.SaveChangesAsync();
            return View(obj);

        }
        [HttpGet]
        //public Object getFinanceData(int? id)
        //{
        //    return (from a in _context.Finances
        //            join pType in _context.LookUps on a.PaymentTypeId equals pType.Id
        //            where a.MemberId == id
        //            orderby a.Id descending
        //            select new FinanceVM
        //            {
        //                Id = a.Id,
        //                TypeName = pType.Name,
        //                ReceiptNo = a.ReceiptNo,
        //                PaymentDate = a.PaymentDate,
        //            }).ToList();
        //}
        public async Task<ActionResult> getFinanceData(int? id)
        {
            var Payments = await (from a in _context.Finances
                                  join pType in _context.LookUps on a.PaymentTypeId equals pType.Id
                                  where a.MemberId == id
                                  orderby a.Id descending
                                  select new FinanceVM
                                  {
                                      Id = a.Id,
                                      TypeName = pType.Name,
                                      ReceiptNo = a.ReceiptNo,
                                      PaymentDate = a.PaymentDate.GetValueOrDefault().ToString("dd/MM/yyyy"),
                                      PaymentYear = a.PaymentYear,
                                  }).ToListAsync();

            return Json(new { data = Payments });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int? id)
        {
            var PaymentDel = await _context.Finances.FindAsync(id);

            if (PaymentDel != null)
            {
                _context.Remove(PaymentDel);
            }
            _context.SaveChanges();
            return Json(new { success = true, message = "Deleted successfully!" });
        }
        #endregion




        public Object MembershipTypes()
        {
            return (_context.LookUps.Select(x => new
            {
                LookupTypeId = x.LookUpTypeId,
                Id = x.Id,
                Name = x.Name,
            }).ToList().Where(x => x.LookupTypeId == (int)KMCAA.Enums.LookupTypes.Membership));
        }
        public Object MemberResideIn()
        {
            return (_context.LookUps.Select(x => new
            {
                LookupTypeId = x.LookUpTypeId,
                Id = x.Id,
                Name = x.Name,
            }).ToList().Where(x => x.LookupTypeId == (int)KMCAA.Enums.LookupTypes.MemberReside));
        }

        public Object PaymentTypes()
        {
            return (_context.LookUps.Select(x => new
            {
                LookupTypeId = x.LookUpTypeId,
                Id = x.Id,
                Name = x.Name,
            }).ToList().Where(x => x.LookupTypeId == (int)KMCAA.Enums.LookupTypes.Payment));
        }




    }
}

